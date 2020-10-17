using System;
using System.Drawing;
using System.Windows.Forms;

namespace Among_Us_Hook
{
    public partial class Form1 : Form
    {
        private static readonly string webHook = "https://discord.com/api/webhooks/767012934806274058/z87rHyTBsgD_ldVKPndVK8L0WQdhX4YwWfaDcK9Fp4sNJEVQ8dkDx2dc5CsRl4neENFV";
        protected dWebHook dcWeb = new dWebHook();
        public Form1()
        {
            InitializeComponent();
        }

        public bool Connect()
        {
            try
            {
                dcWeb.ProfilePicture = "";
                dcWeb.UserName = "Hooks";
                dcWeb.WebHook = webHook;
                return true;
            }
            catch (Exception ex)
            {
                UpdateStatus(ex.Message, Color.Red);
                return false;
            };
        }

        public void UpdateStatus(string message, Color colour)
        {
            lblStatus.Text = $"Status: {message}.";
            lblStatus.ForeColor = colour;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dcWeb.SendMessage("au mute");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dcWeb.SendMessage("au unmute");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = Properties.Settings.Default.TopMost;
            this.TopMost = checkBox1.Checked;
            if (Connect()) { UpdateStatus("Established Webhook.", Color.Green); }

            dcWeb.SendMessage("au webhook");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.TopMost = checkBox1.Checked;
            Properties.Settings.Default.Save();
        }
    }
}
