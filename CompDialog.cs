using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InCompleteSkylineUI
{
    public partial class CompDialog : Form
    {
        public string DataType;
        public string Increment;
        public LinkedList<ResultList> AlgList;
        public StreamReader ResultFile;
        public long maxcompnum;
        public double maxcputime;
        public CompDialog()
        {
            InitializeComponent();
            maxcompnum = 0;
            maxcputime = 0;
            AlgList = new LinkedList<ResultList>();
        }

        private void CompDialog_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            DataType = "K";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            DataType = "dimensionality";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            DataType = "cardinality";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            DataType = "incomplete rate";
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            Increment = IncrementText.Text;
            this.DialogResult = DialogResult.OK;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileDialog.ShowDialog();
            string filepath = FileDialog.FileName;
            string algname = Path.GetFileNameWithoutExtension(filepath);
            NameText.Text = algname;
            ResultFile = new StreamReader(filepath);
            AddButton.Enabled = true;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            FileList.Items.Add(NameText.Text);
            string line;
            string[] s;
            ResultList resultlist = new ResultList();
            resultlist.AlgName = NameText.Text;
            while ((line = ResultFile.ReadLine()) != null)
            {
                s = line.Split(new char[]{' '});
                resultlist.RList.AddLast(new ResultType(s[0], s[1]));
                if (long.Parse(s[0]) > maxcompnum) maxcompnum = long.Parse(s[0]);
                if (double.Parse(s[1]) > maxcputime) maxcputime = double.Parse(s[1]);
            }
            AlgList.AddLast(resultlist);
        }

        private void FileDialog_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
