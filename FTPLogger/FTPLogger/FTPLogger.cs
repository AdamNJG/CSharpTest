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
            logDisplay.Text = logs.ListIterator(logs.ListBuilder(hostBox.Text, usernameBox.Text, passwordBox.Text), logDisplay.Text);
        }




    }
}
