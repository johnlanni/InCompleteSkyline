using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InCompleteSkylineUI
{
    public partial class DrawDialog : Form
    {
        public Boolean iscar;
        public int ytype;
        public string increment;
        public string bound;
        public int unit;
        public DrawDialog(string _v1,string _v2,string _increment,Boolean _iscar)
        {
            InitializeComponent();
            unit = 1;
            v1.Text = _v1;
            v2.Text = _v2;
            // textBox1.Text = _increment;
            iscar = _iscar;
            if (iscar)
            {
                u1.Enabled = u2.Enabled = u3.Enabled = true;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            unit = 1;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            increment = textBox1.Text;
            bound = textBox3.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ytype = 0;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ytype = 1;
        }

        private void u1_CheckedChanged(object sender, EventArgs e)
        {
            unit = 1000;
        }

        private void u3_CheckedChanged(object sender, EventArgs e)
        {
            unit = 1000000;
        }
    }
}
