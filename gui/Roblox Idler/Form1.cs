using static Roblox_Idler.Program;
namespace Roblox_Idler
{
    public partial class App : Form
    {
        public App()
        {
            InitializeComponent();
        }

        private async void btnStop_Click(object sender, EventArgs e)
        {
            DisableButton(btnStop);
            StopMessage(statusBarMessage);
            await AddDelay(1000);
            keepAlive = false;
            EnableButton(btnStart);
            ResetTimer(statusBarTimer);
            ResetMessage(statusBarMessage);
        }

        private async void btnStart_ClickAsync(object sender, EventArgs e)
        {
            DisableButton(btnStart);
            await StartMessage(statusBarMessage);
            keepAlive = true;
            EnableButton(btnStop);
            RunningMessage(statusBarMessage);
            StartTimer(statusBarTimer);
            _ = SimulateKeystrokes(usrInput.Value);
        }

        private void App_Load(object sender, EventArgs e)
        {

        }
    }
}