using System;
using System.Windows.Forms;

namespace FTPLogger
{
    public partial class FTPLogger : Form
    {
        public FTPLogger()
        {
            InitializeComponent();
        }

        public LogHandler logs = new LogHandler();

        private void TestBox_TextChanged(object sender, EventArgs e)
        {

        }



        private void ExportButton_Click(object sender, EventArgs e)
        {
            logs.WriteToFile(logDisplay.Text, PathBox.Text);
            this.Close();
        }

        private void FtpConnect_Click(object sender, EventArgs e)
        {
            logs.ListBuilder(hostBox.Text, usernameBox.Text, passwordBox.Text);

            logDisplay.Text = logs.ListPrinter(logDisplay.Text);

            Timer t = new Timer();

            t.Interval = 15000; // specify interval time as you want
            t.Tick += new EventHandler(timer_Tick);
            t.Start();

            void timer_Tick(object sender, EventArgs e)
            {
                logs.ListBuilder(hostBox.Text, usernameBox.Text, passwordBox.Text);

                logDisplay.Text = logs.ListPrinter(logDisplay.Text);
            }
        }

    }
}
