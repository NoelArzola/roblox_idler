using System.Diagnostics;
using System.Timers;

namespace Roblox_Idler
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        public static bool keepAlive = true;
        public static Stopwatch durationTimer = new Stopwatch();
        public static TimeSpan ts = durationTimer.Elapsed;

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
            int i = 10;
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
            Debug.WriteLine("I should be updating!");
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
            s.Text = $"Total Duration: {ts}";
        }

        public static void ResetTimer(ToolStripStatusLabel s)
        {
            s.Text = "Total Duration: 00:00:00:00";
        }

    }

}