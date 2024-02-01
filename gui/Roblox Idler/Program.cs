using System.Diagnostics;
using WinFormsTimer = System.Windows.Forms.Timer;
using SharpDX.DirectInput;
using Keyboard = SharpDX.DirectInput.Keyboard;
using System.Runtime.InteropServices;


namespace RobloxIdler
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        public static bool keepAlive = true;
        public static Stopwatch durationTimer = new Stopwatch();
        public static WinFormsTimer updateTimer = new WinFormsTimer();
        // Create a DirectInput object
        private static DirectInput directInput = new DirectInput();
        // Create a keyboard device
        private static Keyboard? keyboard;

        [DllImport("user32.dll")]
        static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);

        [DllImport("user32.dll")]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("kernel32.dll")]
        static extern uint GetCurrentThreadId();

        [DllImport("user32.dll")]
        static extern IntPtr FindWindow(IntPtr lpClassName, string lpWindowName);



        [STAThread]

        static void Main()
        {
            uint currentThreadId = GetCurrentThreadId();

            IntPtr robloxWindowHandle = FindWindow((IntPtr)null, "Roblox");
            uint robloxThreadId;
            GetWindowThreadProcessId(robloxWindowHandle, out robloxThreadId);
            AttachThreadInput(currentThreadId, robloxThreadId, true);

            // Initialize DirectInput keyboard
            keyboard = new Keyboard(directInput);
            
            try
            {
                keyboard.Acquire();
            }
            catch (Exception ex)
            {
                // Log or print the exception details
                Debug.WriteLine($"Error acquiring keyboard: {ex.Message}");
            }

            //keyboard.Acquire();
            ApplicationConfiguration.Initialize();
            Application.Run(new App());
        }

        public static async Task SimulateKeystrokes(decimal uInput)
        {
            int uInputToInt = Convert.ToInt32(uInput);
            int loopDelay = uInputToInt * 60000;
            int keyDelay = 1000;
            string[] keystrokes = { "W", "A", "S", "D", " " };

            await Task.Run(async () =>
            {
                while (keepAlive)
                {
                    foreach (string keystroke in keystrokes)
                    {
                        if (keepAlive && (keystroke != " "))
                        {
                            // Simulate key press using DirectInput
                            SimulateKeyPress(keystroke);
                            await Task.Delay(keyDelay);
                        }
                        else if (keepAlive)
                        {
                            // Simulate key press using DirectInput
                            SimulateKeyPress(keystroke);
                            await Task.Delay(loopDelay);
                        }
                    }
                }
            });
        }

        // Helper method to simulate key press using DirectInput
        private static void SimulateKeyPress(string key)
        {
            // Simulate key press
            var keyState = new KeyboardState();
            var keyCode = ConvertKeyToKeyCode(key);
            keyState.PressedKeys.Add(keyCode[0]);
            keyState.IsPressed(keyCode[0]);

            // Allow time for the application to process the input
            Application.DoEvents();
        }

        // Helper method to convert string key to DirectInput KeyCode
        private static Key[] ConvertKeyToKeyCode(string key)
        {
            switch (key.ToUpper())
            {
                case "W": return new Key[] { Key.W };
                case "A": return new Key[] { Key.A };
                case "S": return new Key[] { Key.S };
                case "D": return new Key[] { Key.D };
                case " ": return new Key[] { Key.Space };
                default: return new Key[] { };
            }
        }

        public static async Task StartMessage(ToolStripStatusLabel s)
        {
            int i = 5;
            string startMessage;

            while (i >= 0)
            {
                startMessage = $"Ready in {i} seconds";
                s.Text = startMessage;
                i--;
                await AddDelay(1000);
            }
        }

        public static async Task AddDelay(int ms)
        {
            await Task.Delay(ms);
        }

        public static void RunningMessage(ToolStripStatusLabel s)
        {
            string runningMessage = "The idler is running!";
            s.Text = runningMessage;
        }

        public static void StopMessage(ToolStripStatusLabel s)
        {
            string stopMessage = "Stopping idler . . .";
            s.Text = stopMessage;
        }

        public static void ResetMessage(ToolStripStatusLabel s)
        {
            string resetMessage = "Click start to begin";
            s.Text = resetMessage;
        }

        public static void EnableButton(Button b)
        {
            b.Enabled = true;
        }

        public static void DisableButton(Button b)
        {
            b.Enabled = false;
        }

        public static void StartTimer(ToolStripStatusLabel s)
        {
            if (!durationTimer.IsRunning)
            {
                durationTimer.Start();
                updateTimer.Interval = 1000; // Set the timer interval to 1000 ms
                updateTimer.Tick += (sender, e) => UpdateTimerDisplay(s);
                updateTimer.Start(); // Start the timer
            }
            s.Text = $"Total Duration: {durationTimer.Elapsed.ToString("mm\\:ss")}";
        }

        public static void ResetTimer(ToolStripStatusLabel s)
        {
            durationTimer.Reset();
            updateTimer.Stop(); // Stop the timer
            UpdateTimerDisplay(s); // Update the display after resetting
        }

        public static void UpdateTimerDisplay(ToolStripStatusLabel s)
        {
            // Update the label/status bar with the formatted elapsed time
            s.Text = $"Total Duration: {durationTimer.Elapsed:mm\\:ss}";
        }

    }

}