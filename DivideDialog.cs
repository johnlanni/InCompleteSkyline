using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataSet_gen;
using IncompleteSkyLine;

namespace InCompleteSkylineUI
{
    public partial class DivideDialog : Form
    {

        public DivideDialog()
        {
            newfN = "";
            InitializeComponent();
        }
        private long totalcar;
        private int totaldim;
        private string newfN;
        private string datasetname;
        private void dimension_CheckedChanged(object sender, EventArgs e)
        {
            Indim.ReadOnly = false;
            Incar.ReadOnly = true;
            Incar.Text = "";
            Numcar.Text = "";
            p1.ReadOnly = true;
            p2.ReadOnly = true;
            p3.ReadOnly = true;
            p4.ReadOnly = true;
            p5.ReadOnly = true;
            numtext.ReadOnly = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DivideDialog_Load(object sender, EventArgs e)
        {

        }

        private void Numcar_Click(object sender, EventArgs e)
        {

        }

        private void Numdim_Click(object sender, EventArgs e)
        {

        }

        private void Incar_TextChanged(object sender, EventArgs e)
        {

        }

        private void Indim_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            string fN = fbd.SelectedPath;                     //获得选择的文件夹路径
            textBox1.Text = fN;
            DirectoryInfo di = new DirectoryInfo(fN);          
            for (int i = 0; i < fN.Length; i++)
            {
                newfN += fN[i];
                if (fN[i] == '\\') newfN += '\\';
            }
            datasetname = di.Name;
            newfN = newfN + "\\" + datasetname;           
            Global.inputFile = new StreamReader(newfN + ".dat");/////////////////////
            Global.infoFile = new StreamReader(newfN + ".info");
            Global.bitmapFile = new StreamReader(newfN + ".b");//////////////////////////
            string tmp = Global.infoFile.ReadLine();         
            long cnt = 0;
            while (Global.inputFile.ReadLine() != null)
            {
                cnt++;
            }
            totalcar = cnt;
            totaldim = Convert.ToInt32(tmp);
            Toldim.Text = tmp;
            Tolcar.Text = totalcar.ToString();
            Global.inputFile.Close();
            Global.infoFile.Close();
            Global.bitmapFile.Close();
            

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Tolcar_Click(object sender, EventArgs e)
        {

        }

        private void Toldim_Click(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                Global.inputFile.Close();
                Global.infoFile.Close();
                Global.bitmapFile.Close();
            }
            catch (NullReferenceException nullexc)
            {
                Console.WriteLine("...");
            }
            this.Close();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            fbd.ShowDialog();
            string fN = fbd.SelectedPath;                     //获得选择的文件夹路径
            string folderName = @fN;
            string pathString;
            if (cardinality.Checked == true)
            {
                long step = long.Parse(Incar.Text);
                int n = int.Parse(Numcar.Text);
                pathString = System.IO.Path.Combine(folderName, "C" + step + " " + datasetname + " divide by cardinality");
                System.IO.Directory.CreateDirectory(pathString);
                string newfoldname;
                string newfilename;
                for (int i = 1; i <= n; i++)
                {
                    newfoldname = System.IO.Path.Combine(pathString, i + " of " + datasetname);
                    newfilename = System.IO.Path.Combine(newfoldname, i + " of " + datasetname);
                    System.IO.Directory.CreateDirectory(newfoldname);
                    Global.inputFile = new StreamReader(newfN + ".dat");/////////////////////                    
                    Global.bitmapFile = new StreamReader(newfN + ".b");//////////////////////////
                    StreamWriter newinputFile = new StreamWriter(newfilename + ".dat");
                    StreamWriter newbitmapFile = new StreamWriter(newfilename + ".b");
                    StreamWriter newinfoFile = new StreamWriter(newfilename + ".info");
                    newinfoFile.WriteLine(totaldim.ToString());
                    long count = i * step;
                    while ((count--) != 0)
                    {
                        newinputFile.WriteLine(Global.inputFile.ReadLine());
                        newbitmapFile.WriteLine(Global.bitmapFile.ReadLine());
                    }
                    newinputFile.Close();
                    newbitmapFile.Close();
                    newinfoFile.Close();
                    Global.inputFile.Close();
                    Global.bitmapFile.Close();
                }

            }
            else if (dimension.Checked == true)
            {
                int step = int.Parse(Indim.Text);
                int n = int.Parse(Numdim.Text);
                pathString = System.IO.Path.Combine(folderName, "D" + step + " " + datasetname + " divide by Dimensionality");
                System.IO.Directory.CreateDirectory(pathString);
                string newfoldname;
                string newfilename;
                for (int i = 1; i <= n; i++)
                {
                    newfoldname = System.IO.Path.Combine(pathString, i + " of " + datasetname);
                    newfilename = System.IO.Path.Combine(newfoldname, i + " of " + datasetname);
                    System.IO.Directory.CreateDirectory(newfoldname);
                    Global.inputFile = new StreamReader(newfN + ".dat");/////////////////////                    
                    Global.bitmapFile = new StreamReader(newfN + ".b");//////////////////////////
                    StreamWriter newinputFile = new StreamWriter(newfilename + ".dat");
                    StreamWriter newbitmapFile = new StreamWriter(newfilename + ".b");
                    StreamWriter newinfoFile = new StreamWriter(newfilename + ".info");
                    newinfoFile.WriteLine((i * step).ToString());
                    int count = i * step;
                    string line;
                    while ((line = Global.inputFile.ReadLine()) != null)
                    {
                        int tcnt = 0;
                        string inputline = "";
                        int j = 0;
                        while (tcnt <= count)
                        {
                            inputline += line[j];
                            if (line[j] == '\t') tcnt++;
                            j++;

                        }
                        newinputFile.WriteLine(inputline);
                        line = Global.bitmapFile.ReadLine().Substring(0, count * 2 - 1);
                        newbitmapFile.WriteLine(line);

                    }
                    newinputFile.Close();
                    newbitmapFile.Close();
                    newinfoFile.Close();
                    Global.inputFile.Close();
                    Global.bitmapFile.Close();
                }
            }
            else
            {
                int dims = int.Parse(p1.Text);
                int size = int.Parse(p2.Text);
                int skyline_size = int.Parse(p3.Text);
                int bitmapno = int.Parse(p4.Text);
                float ratio = float.Parse(p5.Text);
                int setsnum = int.Parse(numtext.Text);
                pathString = System.IO.Path.Combine(folderName, "I" + (int)(ratio*100) + "% " + "Synthetic" + " with different incomplete ratio");
                System.IO.Directory.CreateDirectory(pathString);
                string newfoldname;
                string newfilename;
                int dense = (int)(dims * ratio);
                for (int i = 1; i <= setsnum; i++)
                {
                    newfoldname = System.IO.Path.Combine(pathString, i + " of " + "Synthetic");
                    newfilename = System.IO.Path.Combine(newfoldname, i + " of " + "Synthetic");
                    System.IO.Directory.CreateDirectory(newfoldname);
                    //Global.inputFile = new StreamReader(newfN + ".dat");/////////////////////                    
                   // Global.bitmapFile = new StreamReader(newfN + ".b");//////////////////////////
                    StreamWriter newinputFile = new StreamWriter(newfilename + ".dat");
                    StreamWriter newbitmapFile = new StreamWriter(newfilename + ".b");
                    StreamWriter newinfoFile = new StreamWriter(newfilename + ".info");
                    newinfoFile.WriteLine(dims.ToString());
                    generator g = new generator();
                    g.generate(dims, size, skyline_size, bitmapno, dense * i);
                    for (int j = 0; j < g.points.Count; j++)
                    {
                        ArrayList p = (ArrayList)g.points[j];

                        ArrayList bitmap = (ArrayList)g.bitmaps[(int)p[p.Count - 1]];
                        newinputFile.Write(j + "\t");
                        for (int k = 0; k < p.Count - 1; k++)
                        {

                            newinputFile.Write((int)p[k]);
                            if (k != p.Count - 2) newinputFile.Write("\t");
                        }
                        newinputFile.WriteLine();
                        for (int k = 0; k < p.Count - 1; k++)
                        {
                            if (bitmap.Contains(k))
                                newbitmapFile.Write(1);
                            else newbitmapFile.Write(0);
                            if (k != p.Count - 2) newbitmapFile.Write("\t");
                        }
                        newbitmapFile.WriteLine();
                    }
                    //newinputFile.WriteLine(Global.inputFile.ReadLine());
                    //newbitmapFile.WriteLine(Global.bitmapFile.ReadLine());



                    newinputFile.Close();
                    newbitmapFile.Close();
                    newinfoFile.Close();
                   // Global.inputFile.Close();
                   // Global.bitmapFile.Close();

                }

                this.Close();

            }
        }

        private void cardinality_CheckedChanged(object sender, EventArgs e)
        {
            Incar.ReadOnly = false;
            Indim.ReadOnly = true;
            Indim.Text = "";
            Numdim.Text = "";
            p1.ReadOnly = true;
            p2.ReadOnly = true;
            p3.ReadOnly = true;
            p4.ReadOnly = true;
            p5.ReadOnly = true;
            numtext.ReadOnly = true;
            
        }

        private void Incar_KeyUp(object sender, KeyEventArgs e)
        {
            string text = Incar.Text;
            if (IsOnlyNumber(text))
            {
                long increment = long.Parse(text);
                if (increment!=0)
                {
                    long num = totalcar / increment ;
                    Numcar.Text = num.ToString();
                }
            }
        }
        private  bool IsOnlyNumber(string value)
        {
            Regex r = new Regex(@"^[0-9]+$");

            return r.Match(value).Success;
        }

        private void Indim_KeyUp(object sender, KeyEventArgs e)
        {
            string text = Indim.Text;
            if (IsOnlyNumber(text))
            {
                int increment = int.Parse(text);
                if (increment != 0)
                {
                    int num = totaldim / increment ;
                    Numdim.Text = num.ToString();
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void generate_CheckedChanged(object sender, EventArgs e)
        {
            Incar.ReadOnly = true;     
            Indim.Text = "";
            Numdim.Text = "";
            Indim.ReadOnly = true;     
            Incar.Text = "";
            Numcar.Text = "";
            p1.ReadOnly = false;
            p2.ReadOnly = false;
            p3.ReadOnly = false;
            p4.ReadOnly = false;
            p5.ReadOnly = false;
            numtext.ReadOnly = false;
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
