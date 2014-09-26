namespace InCompleteSkylineUI
{
    partial class DivideDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cardinality = new System.Windows.Forms.RadioButton();
            this.dimension = new System.Windows.Forms.RadioButton();
            this.generate = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.Incar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.carNum = new System.Windows.Forms.Label();
            this.Numcar = new System.Windows.Forms.Label();
            this.Numdim = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Indim = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.LoadButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.Tolcar = new System.Windows.Forms.Label();
            this.Toldim = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
            this.label8 = new System.Windows.Forms.Label();
            this.p1 = new System.Windows.Forms.TextBox();
            this.p2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.p3 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.p4 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.p5 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.numtext = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cardinality
            // 
            this.cardinality.AutoSize = true;
            this.cardinality.Location = new System.Drawing.Point(12, 147);
            this.cardinality.Name = "cardinality";
            this.cardinality.Size = new System.Drawing.Size(131, 16);
            this.cardinality.TabIndex = 0;
            this.cardinality.TabStop = true;
            this.cardinality.Text = "Cardinality Divide";
            this.cardinality.UseVisualStyleBackColor = true;
            this.cardinality.CheckedChanged += new System.EventHandler(this.cardinality_CheckedChanged);
            // 
            // dimension
            // 
            this.dimension.AutoSize = true;
            this.dimension.Location = new System.Drawing.Point(12, 229);
            this.dimension.Name = "dimension";
            this.dimension.Size = new System.Drawing.Size(149, 16);
            this.dimension.TabIndex = 1;
            this.dimension.TabStop = true;
            this.dimension.Text = "Dimensionality Divide";
            this.dimension.UseVisualStyleBackColor = true;
            this.dimension.CheckedChanged += new System.EventHandler(this.dimension_CheckedChanged);
            // 
            // generate
            // 
            this.generate.AutoSize = true;
            this.generate.Location = new System.Drawing.Point(12, 311);
            this.generate.Name = "generate";
            this.generate.Size = new System.Drawing.Size(167, 16);
            this.generate.TabIndex = 2;
            this.generate.TabStop = true;
            this.generate.Text = "Generate synthetic sets ";
            this.generate.UseVisualStyleBackColor = true;
            this.generate.CheckedChanged += new System.EventHandler(this.generate_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Increment:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Incar
            // 
            this.Incar.Location = new System.Drawing.Point(99, 184);
            this.Incar.Name = "Incar";
            this.Incar.Size = new System.Drawing.Size(100, 21);
            this.Incar.TabIndex = 4;
            this.Incar.TextChanged += new System.EventHandler(this.Incar_TextChanged);
            this.Incar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Incar_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Number of set:";
            // 
            // carNum
            // 
            this.carNum.AutoSize = true;
            this.carNum.Location = new System.Drawing.Point(324, 187);
            this.carNum.Name = "carNum";
            this.carNum.Size = new System.Drawing.Size(0, 12);
            this.carNum.TabIndex = 6;
            // 
            // Numcar
            // 
            this.Numcar.AutoSize = true;
            this.Numcar.Location = new System.Drawing.Point(324, 187);
            this.Numcar.Name = "Numcar";
            this.Numcar.Size = new System.Drawing.Size(0, 12);
            this.Numcar.TabIndex = 7;
            this.Numcar.Click += new System.EventHandler(this.Numcar_Click);
            // 
            // Numdim
            // 
            this.Numdim.AutoSize = true;
            this.Numdim.Location = new System.Drawing.Point(324, 268);
            this.Numdim.Name = "Numdim";
            this.Numdim.Size = new System.Drawing.Size(0, 12);
            this.Numdim.TabIndex = 12;
            this.Numdim.Click += new System.EventHandler(this.Numdim_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(324, 268);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 12);
            this.label4.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(230, 268);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "Number of set:";
            // 
            // Indim
            // 
            this.Indim.Location = new System.Drawing.Point(99, 265);
            this.Indim.Name = "Indim";
            this.Indim.Size = new System.Drawing.Size(100, 21);
            this.Indim.TabIndex = 9;
            this.Indim.TextChanged += new System.EventHandler(this.Indim_TextChanged);
            this.Indim.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Indim_KeyUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 268);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "Increment:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "Load a single dataset:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(153, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(154, 21);
            this.textBox1.TabIndex = 14;
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(313, 23);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(54, 23);
            this.LoadButton.TabIndex = 15;
            this.LoadButton.Text = "...";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "Total Cardinality:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // Tolcar
            // 
            this.Tolcar.AutoSize = true;
            this.Tolcar.Location = new System.Drawing.Point(147, 63);
            this.Tolcar.Name = "Tolcar";
            this.Tolcar.Size = new System.Drawing.Size(0, 12);
            this.Tolcar.TabIndex = 17;
            this.Tolcar.Click += new System.EventHandler(this.Tolcar_Click);
            // 
            // Toldim
            // 
            this.Toldim.AutoSize = true;
            this.Toldim.Location = new System.Drawing.Point(165, 105);
            this.Toldim.Name = "Toldim";
            this.Toldim.Size = new System.Drawing.Size(0, 12);
            this.Toldim.TabIndex = 19;
            this.Toldim.Click += new System.EventHandler(this.Toldim_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(131, 12);
            this.label9.TabIndex = 18;
            this.label9.Text = "Total Dimensionality:";
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(189, 501);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 20;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Location = new System.Drawing.Point(292, 501);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(75, 23);
            this.ConfirmButton.TabIndex = 21;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // fbd
            // 
            this.fbd.Description = "Select the save path";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(208, 354);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 22;
            this.label8.Text = "dims:";
            // 
            // p1
            // 
            this.p1.Location = new System.Drawing.Point(252, 351);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(55, 21);
            this.p1.TabIndex = 23;
            // 
            // p2
            // 
            this.p2.Location = new System.Drawing.Point(123, 351);
            this.p2.Name = "p2";
            this.p2.Size = new System.Drawing.Size(58, 21);
            this.p2.TabIndex = 25;
            this.p2.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(56, 354);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 24;
            this.label10.Text = "totalsize:";
            // 
            // p3
            // 
            this.p3.Location = new System.Drawing.Point(123, 387);
            this.p3.Name = "p3";
            this.p3.Size = new System.Drawing.Size(58, 21);
            this.p3.TabIndex = 27;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(34, 390);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 12);
            this.label11.TabIndex = 26;
            this.label11.Text = "skyline_size:";
            // 
            // p4
            // 
            this.p4.Location = new System.Drawing.Point(251, 387);
            this.p4.Name = "p4";
            this.p4.Size = new System.Drawing.Size(55, 21);
            this.p4.TabIndex = 29;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(187, 390);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 12);
            this.label12.TabIndex = 28;
            this.label12.Text = "bitmapno:";
            // 
            // p5
            // 
            this.p5.Location = new System.Drawing.Point(123, 427);
            this.p5.Name = "p5";
            this.p5.Size = new System.Drawing.Size(58, 21);
            this.p5.TabIndex = 31;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(-4, 430);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(125, 12);
            this.label13.TabIndex = 30;
            this.label13.Text = "   incomplete ratio:";
            // 
            // numtext
            // 
            this.numtext.Location = new System.Drawing.Point(252, 427);
            this.numtext.Name = "numtext";
            this.numtext.Size = new System.Drawing.Size(54, 21);
            this.numtext.TabIndex = 33;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(175, 430);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 12);
            this.label14.TabIndex = 32;
            this.label14.Text = "   setsnum:";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // DivideDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 536);
            this.Controls.Add(this.numtext);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.p5);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.p4);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.p3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.p2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.p1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.Toldim);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Tolcar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Numdim);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Indim);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Numcar);
            this.Controls.Add(this.carNum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Incar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.generate);
            this.Controls.Add(this.dimension);
            this.Controls.Add(this.cardinality);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "DivideDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Divide Dataset";
            this.Load += new System.EventHandler(this.DivideDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton cardinality;
        private System.Windows.Forms.RadioButton dimension;
        private System.Windows.Forms.RadioButton generate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Incar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label carNum;
        private System.Windows.Forms.Label Numcar;
        private System.Windows.Forms.Label Numdim;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Indim;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label Tolcar;
        private System.Windows.Forms.Label Toldim;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.FolderBrowserDialog fbd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox p1;
        private System.Windows.Forms.TextBox p2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox p3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox p4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox p5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox numtext;
        private System.Windows.Forms.Label label14;
    }
}