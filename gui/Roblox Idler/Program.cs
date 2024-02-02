using System.Diagnostics;
using WinFormsTimer = System.Windows.Forms.Timer;
using WindowsInput;
using WindowsInput.Native;

namespace Roblox_Idler
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        public static bool keepAlive = true;
        public static Stopwatch durationTimer = new Stopwatch();
        public static WinFormsTimer updateTimer = new WinFormsTimer();

        [STAThread]

        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new App());
        }

        public static async Task SimulateKeystrokes(decimal uInput)
        {
            int uInputToInt = Convert.ToInt32(uInput);
            int loopDelay = uInputToInt * 60000;
            string[] keystrokes = { "W", "A", "S", "D", " " };
            InputSimulator inputSimulator = new InputSimulator();

            while (keepAlive)
            {
                foreach (string keystroke in keystrokes)
                {
                    if (!keepAlive)
                        break;

                    VirtualKeyCode keyCode = GetVirtualKeyCode(keystroke);

                    inputSimulator.Keyboard.KeyDown(keyCode); // Press the key
                    await Task.Delay(5000); // Hold the key for 5 seconds
                    inputSimulator.Keyboard.KeyUp(keyCode); // Release the key

                    // If the keystroke is not a space, introduce a delay before the next keypress
                    if (keystroke != " ")
                    {
                        await Task.Delay(1000); // Delay before the next keypress
                    }
                    else
                    {
                        await Task.Delay(loopDelay); // If the keystroke is a space, delay before repeating the loop
                    }
                }
            }
        }

        private static VirtualKeyCode GetVirtualKeyCode(string key)
        {
            // Map the key string to the corresponding virtual key code
            switch (key.ToUpper())
            {
                case "W":
                    return VirtualKeyCode.VK_W;
                case "A":
                    return VirtualKeyCode.VK_A;
                case "S":
                    return VirtualKeyCode.VK_S;
                case "D":
                    return VirtualKeyCode.VK_D;
                case " ":
                    return VirtualKeyCode.SPACE;
                default:
                    throw new ArgumentException($"Unsupported key: {key}");
            }
        }
        /// <summary>
        ///     Show a start message to give them enough time to switch the game to the foreground 
        /// </summary>
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