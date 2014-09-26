using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using IncompleteSkyLine;

namespace InCompleteSkylineUI
{
    public partial class mainWindow : Form
    {
        private int SingleAlgNo;
        private string repeat;
        private Boolean isRunning;
        private Boolean isMulti;
        private Thread AlgThread;
        private string[] arg = new string[6];
        private string multifold;
        private string multipath;
        private DrawObj drawobj;
        private System.Drawing.Bitmap bitmap;
        public string v1;
        public string v2;
        delegate void SetTextDelegate(string Text);
        public mainWindow()
        {
            InitializeComponent();
            SingleAlgNo = 0;
            drawobj = null;
            isRunning = false;
            isMulti = false;
            repeat = "";
            arg[0] = "";
            arg[1] = "improved_iskyband";//        
            arg[3] = "10";//limit
            arg[4] = "-1";//forceDim  
        }
        public void SetButtonText(string Text)
        {
            if (stopButton.InvokeRequired == true)
            {
                stopButton.Invoke(new SetTextDelegate(SetButtonText), Text);
            }
            else
            {
                stopButton.Text = Text;
            }
        }
        public void SetTextView(string Text)
        {
            if (EditText.InvokeRequired == true)
            {
                EditText.Invoke(new SetTextDelegate(SetTextView), Text);
            }
            else
            {
                if(repeat!=Text)
                   EditText.AppendText(Text);
                repeat = Text;
            }
        }
        public void SetTotelTextView(string Text)
        {
            if (EditText.InvokeRequired == true)
            {
                EditText.Invoke(new SetTextDelegate(SetTotelTextView), Text);
            }
            else
            {
                EditText.Text=Text;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
   

        private void drawButton_Click(object sender, EventArgs e)
        {
            PsaveButton.Enabled = true;
            DrawDialog drawdialog;
            if (drawobj.DataType == "cardinality")
            {
                drawdialog = new DrawDialog(v1, v2, drawobj.Increment, true);
            }
            else
            {
                drawdialog = new DrawDialog(v1, v2, drawobj.Increment, false);
            }
            drawdialog.ShowDialog();
            if (drawdialog.DialogResult == DialogResult.OK)//确认form2的（按钮2）已点击
            {
                
                int unit = drawdialog.unit;
                string increment = drawdialog.increment;
                string bound = drawdialog.bound;
                int ytype = drawdialog.ytype;
                drawdialog.Close();//关闭form2
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(520, 360);
                //DrawPanel.Controls.Clear();
                Graphics graph = DrawPanel.CreateGraphics();
                Graphics bg = Graphics.FromImage(bmp);
                System.Drawing.SolidBrush WhiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
                bg.FillRectangle(WhiteBrush,0,0,520,360);
                graph.DrawImage(bmp, 0, 0);
                Pen p = new Pen(Color.Black, 0);
                //p.DashStyle = DashStyle.Custom;
                Rectangle rta = new Rectangle(40, 40, 400, 280);
                bg.DrawRectangle(p, rta);            
                System.Drawing.Font drawFont = new System.Drawing.Font("Calibri", 13);
                System.Drawing.Font drawFont1 = new System.Drawing.Font("Calibri", 8);
                System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                float ydivnum;
                float ydivlength;
                if (ytype == 0)
                {
                    string drawString = "number of comparisons (M)";
                    System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat(StringFormatFlags.DirectionVertical | StringFormatFlags.DirectionRightToLeft);
                    bg.DrawString(drawString, drawFont, drawBrush, 20, 80, drawFormat);
                    int increment_v = int.Parse(increment);
                    int bound_v = int.Parse(bound);
                    ydivnum = bound_v / increment_v;
                    ydivlength = 280 / ydivnum;
                    System.Drawing.StringFormat drawFormat1 = new System.Drawing.StringFormat(StringFormatFlags.DirectionRightToLeft);
                    bg.DrawString("0", drawFont, drawBrush, 40,305,drawFormat1);
                    while (ydivnum != 0)
                    {
                        bg.DrawString((ydivnum * increment_v).ToString(), drawFont, drawBrush, 40, 310 - ydivnum * ydivlength, drawFormat1);
                        bg.DrawLine(p, 40, 320 - ydivnum * ydivlength, 45, 320 - ydivnum * ydivlength);
                        ydivnum--;
                    }
                }
                else
                {
                    string drawString = "CPU time (kilo-sec)";
                    System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat(StringFormatFlags.DirectionVertical | StringFormatFlags.DirectionRightToLeft);
                    bg.DrawString(drawString, drawFont, drawBrush, 20, 110, drawFormat);
                    float increment_v = float.Parse(increment);
                    float bound_v = float.Parse(bound);
                    ydivnum = bound_v / increment_v;
                    ydivlength = 280 / ydivnum;
                    System.Drawing.StringFormat drawFormat1 = new System.Drawing.StringFormat(StringFormatFlags.DirectionRightToLeft);
                    bg.DrawString("0", drawFont1, drawBrush, 40, 310, drawFormat1);;
                    while (ydivnum != 0)                    {
                        bg.DrawString(Math.Round((ydivnum * increment_v),3).ToString(), drawFont1, drawBrush, 40, 315 - ydivnum * ydivlength, drawFormat1);
                        bg.DrawLine(p, 40, 320 - ydivnum * ydivlength, 45, 320 - ydivnum * ydivlength);
                        ydivnum--;
                    }
                   
                }
                if (drawobj.DataType == "K")
                {
                    string drawString = "K";
                    bg.DrawString(drawString, drawFont, drawBrush, 220, 340);
                }
                else
                {
                    string drawString = drawobj.DataType;
                    bg.DrawString(drawString, drawFont, drawBrush, 200, 340);
                }
                int xdivnum = drawobj.AlgList.First.Value.RList.Count-1;
                System.Drawing.PointF[] points = new System.Drawing.PointF[xdivnum + 1];
                float xdivlength = 400 / xdivnum;
                if (unit == 1000)
                    bg.DrawString((int.Parse(drawobj.Increment) / unit).ToString() + "K", drawFont, drawBrush, 30, 320);
                else if (unit == 1000000)
                    bg.DrawString((int.Parse(drawobj.Increment) / unit).ToString() + "M", drawFont, drawBrush, 30, 320);
                else
                    bg.DrawString((int.Parse(drawobj.Increment) / unit).ToString(), drawFont, drawBrush, 30, 320);
                points[0].X = 40;
                while (xdivnum != 0)
                {
                    points[xdivnum].X = 40 + xdivnum * xdivlength;
                    bg.DrawLine(p, 40 + xdivnum * xdivlength, 320, 40 + xdivnum * xdivlength,310);
                    if (unit == 1000)
                        bg.DrawString((int.Parse(drawobj.Increment) * (xdivnum + 1) / unit).ToString() + "K", drawFont, drawBrush, 30 + xdivnum * xdivlength, 320);
                    else if (unit == 1000000)
                        bg.DrawString((int.Parse(drawobj.Increment) * (xdivnum + 1) / unit).ToString() + "M", drawFont, drawBrush, 30 + xdivnum * xdivlength, 320);
                    else
                        bg.DrawString((int.Parse(drawobj.Increment) * (xdivnum + 1) / unit).ToString(), drawFont, drawBrush, 30 + xdivnum * xdivlength, 320);
                    xdivnum--;
                }
                
                    int algcount = 0;
                    Pen p1 = new Pen(Color.Black, 1);
                    p1.DashStyle = DashStyle.Solid;
                    LinkedListNode<ResultList> alglistnode = drawobj.AlgList.First;
                    GraphicsPath rectangle = new GraphicsPath();
                    GraphicsPath triangle = new GraphicsPath();                   
                    GraphicsPath round = new GraphicsPath();
                    GraphicsPath rectangle1 = new GraphicsPath();
                    GraphicsPath triangle1 = new GraphicsPath();
                    GraphicsPath round1 = new GraphicsPath();
                    Rectangle rect = new Rectangle(-8, -8, 16, 16);
                    Rectangle rect1 = new Rectangle(-4, -4, 8, 8);
                    rectangle.AddRectangle(rect);
                    rectangle1.AddRectangle(rect1);
                    PointF[] trig = new PointF[3];
                    trig[0].X = -6; trig[0].Y = -(float)(6 * Math.Sqrt(3));
                    trig[1].X = 12; trig[1].Y = 0;
                    trig[2].X = -6; trig[2].Y = (float)(6 * Math.Sqrt(3));
                    PointF[] trig1 = new PointF[3];
                    trig1[0].X = -3; trig1[0].Y = -(float)(3* Math.Sqrt(3));
                    trig1[1].X = 6; trig1[1].Y = 0;
                    trig1[2].X = -3; trig1[2].Y = (float)(3 * Math.Sqrt(3));
                    triangle.AddClosedCurve(trig, 0);
                    triangle1.AddClosedCurve(trig1,0);
                    round.AddEllipse(rect);
                    round1.AddEllipse(rect1);
                
                    while (algcount != drawobj.AlgList.Count())
                    {
                        string algname = alglistnode.Value.AlgName;
                        switch (algcount)
                        {
                            case 0: CustomLineCap HookCap = new CustomLineCap(null,rectangle);
                                HookCap.WidthScale = 1.0f;
                                HookCap.SetStrokeCaps(LineCap.Round, LineCap.Round);
                                p1.StartCap = LineCap.Flat;
                                p1.CustomEndCap = HookCap;
                                bg.DrawString(algname, drawFont1, drawBrush, 460, 40); 
                                bg.DrawLine(p1,460,60,480,60);break;
                            case 1: HookCap = new CustomLineCap(null, triangle);
                                HookCap.WidthScale = 1.0f;
                                HookCap.SetStrokeCaps(LineCap.Round, LineCap.Round);
                                p1.StartCap = LineCap.Flat;
                                p1.CustomEndCap = HookCap;
                                bg.DrawString(algname, drawFont1, drawBrush, 460, 80);
                                bg.DrawLine(p1, 460, 100, 480, 100); break;
                            case 2: HookCap = new CustomLineCap(null, round);
                                HookCap.WidthScale = 1.0f;
                                HookCap.SetStrokeCaps(LineCap.Round, LineCap.Round);
                                p1.StartCap = LineCap.Flat;
                                p1.CustomEndCap = HookCap;
                                bg.DrawString(algname, drawFont1, drawBrush, 460, 120);
                                bg.DrawLine(p1, 460, 140, 480, 140); break;
                            case 3: HookCap = new CustomLineCap(rectangle1,null);
                                HookCap.WidthScale = 1.0f;
                                HookCap.SetStrokeCaps(LineCap.Round, LineCap.Round);
                                p1.StartCap = LineCap.Flat;
                                p1.CustomEndCap = HookCap;
                                bg.DrawString(algname, drawFont1, drawBrush, 460, 160);
                                bg.DrawLine(p1, 460, 180, 480, 180); break;
                            case 4: HookCap = new CustomLineCap(triangle1, null);
                                HookCap.WidthScale = 1.0f;
                                HookCap.SetStrokeCaps(LineCap.Round, LineCap.Round);
                                p1.StartCap = LineCap.Flat;
                                p1.CustomEndCap = HookCap;
                                bg.DrawString(algname, drawFont1, drawBrush, 460, 200);
                                bg.DrawLine(p1, 460, 220, 480, 220); break;
                            default: HookCap = new CustomLineCap(round1, null);
                                HookCap.WidthScale = 1.0f;
                                HookCap.SetStrokeCaps(LineCap.Round, LineCap.Round);
                                p1.StartCap = LineCap.Flat;
                                p1.CustomEndCap = HookCap;
                                bg.DrawString(algname, drawFont1, drawBrush, 460, 240);
                                bg.DrawLine(p1, 460, 260, 480, 260); break;
                        }
                        LinkedListNode<ResultType> resultlistnode = alglistnode.Value.RList.First;
                        int nodecount = 0;
                        int total = alglistnode.Value.RList.Count;
                        while (total-- != 0)
                        {
                            float y;
                            if (ytype == 0)
                            {
                                float bound_v = float.Parse(bound) * 1000000;
                                y = 320 - (float.Parse(resultlistnode.Value.CompNum) / bound_v * 280);
                            }
                            else 
                            {
                                float bound_v = float.Parse(bound) * 1000;
                                y = 320 - (float.Parse(resultlistnode.Value.CpuTime) / bound_v * 280);
                            }
 
                            points[nodecount].Y = y;
                            resultlistnode = resultlistnode.Next;
                            nodecount++;
                        }
                        int pointcount = points.GetLength(0);
                        int i = 0;
                        while (pointcount-- != 1)
                        {
                            bg.DrawLine(p1, points[i],points[++i]);
                        }
                        alglistnode = alglistnode.Next;
                        algcount++;
                    }

                bitmap = bmp;
                graph.DrawImage(bmp, 0, 0);
                
            }

        }

        private void chart_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void PsaveButton_Click(object sender, EventArgs e)
        {
            savebmpdialog.ShowDialog();
            string filepath = savebmpdialog.FileName;
            if(savebmpdialog.FilterIndex==1)
                bitmap.Save(filepath, ImageFormat.Jpeg);
            if(savebmpdialog.FilterIndex==2)
                bitmap.Save(filepath, ImageFormat.Bmp);
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if ((arg[0] == "" || SingleAlgNo == 0)&&isMulti==false)
            {
                MessageBox.Show("Please choose the correct dataset and algorithm.");
                return;
            }
            else if (isRunning == false&&isMulti==false)
            {
                isRunning = true;
                stopButton.Text = "Stop";
                EditText.Text = "...\n";
                if (SingleAlgNo == 1)
                {
                   AlgThread = new Thread(IncompleteSkyLine.AlgProgram.runSkyband1);
                   AlgThread.Start(arg);
                   IncompleteSkyLine.AlgProgram.ChangeButton += new IncompleteSkyLine.ChangestopButton(AlgProgram_ChangeButton);
                   IncompleteSkyLine.AlgProgram.ChangeText +=  new IncompleteSkyLine.ChangeTextView(AlgProgram_ChangeText);
                   IncompleteSkyLine.AlgProgram.ChangeTotelText += new IncompleteSkyLine.ChangeTextView(AlgProgram_ChangeTotelText);
                }
                else if (SingleAlgNo == 2)
                {
                    AlgThread = new Thread(IncompleteSkyLine.AlgProgram.runSkyband);
                    AlgThread.Start(arg);
                    IncompleteSkyLine.AlgProgram.ChangeButton += new IncompleteSkyLine.ChangestopButton(AlgProgram_ChangeButton);
                    IncompleteSkyLine.AlgProgram.ChangeText += new IncompleteSkyLine.ChangeTextView(AlgProgram_ChangeText);
                    IncompleteSkyLine.AlgProgram.ChangeTotelText += new IncompleteSkyLine.ChangeTextView(AlgProgram_ChangeTotelText);
                }
                else if (SingleAlgNo == 3)
                {
                    IncompleteSkyLine.AlgProgram.runSkyband2(arg);
                }
                else MessageBox.Show("Please choose the correct algorithm.");
            }
            else if (isRunning == true && isMulti == false)
            {
                isRunning = false;
                try
                {
                    AlgThread.Interrupt();
                }

                catch (ThreadInterruptedException thrinexc)
                {
                    Console.WriteLine("Algthread interrupted.");
                }

                if (IncompleteSkyLine.AlgProgram.sw != null)
                    IncompleteSkyLine.AlgProgram.sw.Close();
                if (IncompleteSkyLine.AlgProgram.swout != null)
                    IncompleteSkyLine.AlgProgram.swout.Close();
                Bitmaps.HtBitmap = new Hashtable();
                AlgProgram.GS = new ArrayList();
                AlgProgram.CGS = new ArrayList();
                IncompleteSkyLine.Global.cleanUp();
                IncompleteSkyLine.Global.EOF = false;
                IncompleteSkyLine.Point._index = -1;
                stopButton.Text = "Run";
            }
            else
            {
                stopButton.Text = "Stop";
                stopButton.Enabled = false;
                DirectoryInfo folder = new DirectoryInfo(multipath);

                DirectoryInfo[] chldFolders = folder.GetDirectories();
                int count = 1;
                EditText.Text = "Start executing on the mutli-datasets.\n";
                if (SingleAlgNo == 1)
                {
                    string filestring = System.IO.Path.Combine(multipath, "kISB.txt");
                    StreamWriter ResultFile = new StreamWriter(filestring);
                    foreach (DirectoryInfo chldFolder in chldFolders)
                      {
                        string pathString = System.IO.Path.Combine(chldFolder.FullName, chldFolder.Name);
                        arg[0] = pathString;                   
                       
                        EditText.AppendText("The No. "+chldFolder.Name[0]+" dataset:\n");                       
                        //AlgThread.Start(arg);
                        IncompleteSkyLine.AlgProgram.ChangeButton += new IncompleteSkyLine.ChangestopButton(AlgProgram_ChangeButton);
                        IncompleteSkyLine.AlgProgram.ChangeText += new IncompleteSkyLine.ChangeTextView(AlgProgram_ChangeText);
                        IncompleteSkyLine.AlgProgram.ChangeTotelText += new IncompleteSkyLine.ChangeTextView(AlgProgram_ChangeTotelText);
                        IncompleteSkyLine.AlgProgram.runSkyband1((object)arg);
                        
                        ResultFile.WriteLine(IncompleteSkyLine.Global.comparsionNo + " " + IncompleteSkyLine.Global.time.TotalSeconds);
                        //AlgThread.Join();
                       }
                    ResultFile.Close();
                    
                 }
                else if (SingleAlgNo == 2)
                {
                    string filestring = System.IO.Path.Combine(multipath, "Baseline.txt");
                    StreamWriter ResultFile = new StreamWriter(filestring);
                    foreach (DirectoryInfo chldFolder in chldFolders)
                    {
                        string pathString = System.IO.Path.Combine(chldFolder.FullName, chldFolder.Name);
                        arg[0] = pathString;

                        EditText.AppendText("The No. " + chldFolder.Name[0] + " dataset:\n");
                        //AlgThread.Start(arg);
                        IncompleteSkyLine.AlgProgram.ChangeButton += new IncompleteSkyLine.ChangestopButton(AlgProgram_ChangeButton);
                        IncompleteSkyLine.AlgProgram.ChangeText += new IncompleteSkyLine.ChangeTextView(AlgProgram_ChangeText);
                        IncompleteSkyLine.AlgProgram.ChangeTotelText += new IncompleteSkyLine.ChangeTextView(AlgProgram_ChangeTotelText);
                        IncompleteSkyLine.AlgProgram.runSkyband((object)arg);

                        ResultFile.WriteLine(IncompleteSkyLine.Global.comparsionNo + " " + IncompleteSkyLine.Global.time.TotalSeconds);
                        //AlgThread.Join();
                    }
                    ResultFile.Close();

                }
                stopButton.Text = "Run";
                stopButton.Enabled = true;
                
            }
        }

        void AlgProgram_ChangeTotelText(string text)
        {
            SetTotelTextView(text);
        }

        void AlgProgram_ChangeText(string text)
        {
             try
             {
                 SetTextView(text);
             }

             catch (ThreadInterruptedException thrinexc)
             {
                 Console.WriteLine("Algthread interrupted.");
             }
        } 
        void AlgProgram_ChangeButton(bool isRunning)
        {
            SetButtonText("Run");
        }

        private void singleSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isMulti = false;
            fbd.ShowDialog();
            string fN = fbd.SelectedPath; 
            //获得选择的文件夹路径
            string newfN = "";
            for (int i = 0; i < fN.Length; i++)
            {
                newfN += fN[i];
                if (fN[i] == '\\') newfN += '\\';
            }     
            DirectoryInfo di;
            try
            {
                di = new DirectoryInfo(fN);
                arg[0] = newfN + "\\" + di.Name;
            }

            catch (ArgumentException argexc)
            {
                Console.WriteLine("...");
            }         
        }

        private void bitmapbasedskylinevariantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KKDialog kkdialog = new KKDialog();
            kkdialog.ShowDialog();
            arg[5] = kkdialog.k;
            SingleCheck(sender);
            SingleAlgNo = 1;
        }


        private void bucketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KKDialog kkdialog = new KKDialog();
            kkdialog.ShowDialog();
            arg[5] = kkdialog.k;
            SingleCheck(sender);
            SingleAlgNo = 2;
        }
        

        private void vPbasedskylinevariantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SingleCheck(sender);
            SingleAlgNo = 3;
        }
        private void SingleCheck(object sender)   //单选菜单 
        {
            alg1.Checked = false;
            alg2.Checked = false;
            alg3.Checked = false;
            ((ToolStripMenuItem)sender).Checked = true;
        }

        private void divideDatasetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DivideDialog divdialog = new DivideDialog();
            divdialog.ShowDialog();

        }

       /* private void bitmapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            algorithmComparisonToolStripMenuItem.ShowDropDown();
            skyBandToolStripMenuItem.ShowDropDown();
        }

        private void skyBandToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void bucketToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            algorithmComparisonToolStripMenuItem.ShowDropDown();
            skyBandToolStripMenuItem.ShowDropDown();
        }

        private void vPbasedskylinevariantToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            algorithmComparisonToolStripMenuItem.ShowDropDown();
            skyBandToolStripMenuItem.ShowDropDown();
        }*/

        private void demonstrateRealDataToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mutliSetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            fbd.ShowDialog();
            string fN = fbd.SelectedPath;                     //获得选择的文件夹路径
            string folderName = @fN;
            DirectoryInfo di;
            try
            {
                di = new DirectoryInfo(fN);
                if (di.Name[0] != 'D' && di.Name[0] != 'C' && di.Name[0] != 'I')
                {
                    MessageBox.Show("Please choose the correct Mutli-Datasets.");
                }
                multipath = folderName;
                multifold = di.Name;
                isMulti = true;
               
            }

            catch (ArgumentException argexc)
            {
                Console.WriteLine("...");
            }

        }

        private void EditText_TextChanged(object sender, EventArgs e)
        {

        }

        private void skyBandToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void algorithmComparisonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompDialog cmpdialog = new CompDialog();
            cmpdialog.ShowDialog();
            if (cmpdialog.DialogResult == DialogResult.OK)//确认form2的（按钮2）已点击
            {
                drawobj = new DrawObj();
                drawobj.DataType = cmpdialog.DataType;
                drawobj.Increment = cmpdialog.Increment;
                drawobj.AlgList = cmpdialog.AlgList;
                v1 = ((cmpdialog.maxcompnum+500000)/1000000).ToString();
                v2 = (cmpdialog.maxcputime/1000).ToString();
                cmpdialog.Close();//关闭form2
                PdrawButton.Enabled = true;
            }
        }

    }
}
