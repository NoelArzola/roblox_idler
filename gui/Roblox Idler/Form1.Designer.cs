namespace Roblox_Idler
{
    partial class App
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnStart = new Button();
            btnStop = new Button();
            lblUserInput = new Label();
            lblUserInputHelper = new Label();
            statusBarMessage = new ToolStripStatusLabel();
            statusStrip1 = new StatusStrip();
            statusBarTimer = new ToolStripStatusLabel();
            usrInput = new NumericUpDown();
            timer1 = new System.Windows.Forms.Timer(components);
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)usrInput).BeginInit();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(12, 89);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(145, 51);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_ClickAsync;
            // 
            // btnStop
            // 
            btnStop.Enabled = false;
            btnStop.Location = new Point(157, 89);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(145, 51);
            btnStop.TabIndex = 3;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // lblUserInput
            // 
            lblUserInput.AutoSize = true;
            lblUserInput.Location = new Point(12, 21);
            lblUserInput.Name = "lblUserInput";
            lblUserInput.Size = new Size(287, 15);
            lblUserInput.TabIndex = 5;
            lblUserInput.Text = "How often (in minutes) should we move your avatar?";
            // 
            // lblUserInputHelper
            // 
            lblUserInputHelper.AutoSize = true;
            lblUserInputHelper.Location = new Point(60, 49);
            lblUserInputHelper.Name = "lblUserInputHelper";
            lblUserInputHelper.Size = new Size(210, 15);
            lblUserInputHelper.TabIndex = 6;
            lblUserInputHelper.Text = "Enter a number (1-19). The default is 5.";
            // 
            // statusBarMessage
            // 
            statusBarMessage.Name = "statusBarMessage";
            statusBarMessage.Padding = new Padding(20, 0, 0, 0);
            statusBarMessage.Size = new Size(127, 17);
            statusBarMessage.Text = "Click Start to begin";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { statusBarMessage, statusBarTimer });
            statusStrip1.Location = new Point(0, 163);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(316, 22);
            statusStrip1.SizingGrip = false;
            statusStrip1.TabIndex = 4;
            statusStrip1.Text = "statusStrip1";
            // 
            // statusBarTimer
            // 
            statusBarTimer.Margin = new Padding(30, 3, 0, 2);
            statusBarTimer.Name = "statusBarTimer";
            statusBarTimer.Size = new Size(144, 17);
            statusBarTimer.Text = "Total Duration: 00:00";
            statusBarTimer.TextAlign = ContentAlignment.MiddleRight;
            // 
            // usrInput
            // 
            usrInput.Location = new Point(12, 47);
            usrInput.Maximum = new decimal(new int[] { 19, 0, 0, 0 });
            usrInput.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            usrInput.Name = "usrInput";
            usrInput.Size = new Size(42, 23);
            usrInput.TabIndex = 7;
            usrInput.TextAlign = HorizontalAlignment.Center;
            usrInput.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // App
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(316, 185);
            Controls.Add(usrInput);
            Controls.Add(lblUserInputHelper);
            Controls.Add(lblUserInput);
            Controls.Add(statusStrip1);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "App";
            Text = "Roblox Idler";
            Load += App_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)usrInput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private Button btnStop;
        private Label lblUserInput;
        private Label lblUserInputHelper;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusBarMessage;
        private NumericUpDown usrInput;
        private ToolStripStatusLabel statusBarTimer;
        private System.Windows.Forms.Timer timer1;
    }
}