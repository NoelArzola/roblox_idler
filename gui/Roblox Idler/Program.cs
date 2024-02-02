using System.Diagnostics;
using WinFormsTimer = System.Windows.Forms.Timer;

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
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new App());
        }

        public static async Task SimulateKeystrokes(decimal uInput)
        {
            int uInputToInt = Convert.ToInt32(uInput);
            int loopDelay = uInputToInt * 60000;
            int keyDelay = 1000;
            string[] keystrokes = { "W", "A", "S", "D", " " };

            while (keepAlive)
            {
                foreach (string keystroke in keystrokes)
                {
                    if (keepAlive && (keystroke != " "))
                    {
                        SendKeys.SendWait($"{keystroke}");
                        await Task.Delay(keyDelay);
                    }
                    else if (keepAlive)
                    {
                        SendKeys.SendWait($"{keystroke}");
                        await Task.Delay(loopDelay);
                    }
                }
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