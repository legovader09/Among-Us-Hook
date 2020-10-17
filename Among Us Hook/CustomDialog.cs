using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Among_Us_Hook
{
    public partial class CustomDialog : Form
    {
        public string returnVal { get; set; }
        public string title { get; set; }
        public string PromptMsg { get; set; }
        public CustomDialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.returnVal = textBox1.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void CustomDialog_Load(object sender, EventArgs e)
        {
            Text = title;
            label1.Text = PromptMsg;
            textBox1.Text = returnVal;
        }
    }
}
