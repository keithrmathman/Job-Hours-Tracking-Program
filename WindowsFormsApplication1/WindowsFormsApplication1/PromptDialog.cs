using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class PromptDialog : Form
    {
        string Dialog;
        bool YesOrNo = false;//keep this set to false so that it doesn't trigger an action inadvertently

        public PromptDialog()
        {
            InitializeComponent();
            label1.Text = Dialog;
        }

        public PromptDialog(string Dialog)
        {
            InitializeComponent();
            this.Dialog = Dialog;
            label1.Text = Dialog;
        }

        private void PrompDialog_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        void alignDialogToPrintOnScreen()
        {
            //int length = Dialog.Length;

           // while ()


        }

        public bool getYesOrNO()
        {
            return YesOrNo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            YesOrNo = false; //set to 'No'
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            YesOrNo = true; //set to 'YES'
            this.Close();
        }
    }
}
