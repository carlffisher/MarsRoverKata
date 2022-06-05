namespace MarsKataProject
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.output = new System.Windows.Forms.TextBox();
            this.testBtn = new System.Windows.Forms.Button();
            this.userinput = new System.Windows.Forms.TextBox();
            this.moreTestsBtn = new System.Windows.Forms.Button();
            this.complexTestsBtn = new System.Windows.Forms.Button();
            this.nameinput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericalTestsBtn = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.yinput = new System.Windows.Forms.TextBox();
            this.xinput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(12, 180);
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.output.Size = new System.Drawing.Size(410, 110);
            this.output.TabIndex = 0;
            this.output.Text = "\r\n";
            this.output.TextChanged += new System.EventHandler(this.output_TextChanged);
            // 
            // testBtn
            // 
            this.testBtn.Location = new System.Drawing.Point(203, 34);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(219, 23);
            this.testBtn.TabIndex = 1;
            this.testBtn.Text = "Enter Dimensions of Area: ";
            this.testBtn.UseVisualStyleBackColor = true;
            this.testBtn.Click += new System.EventHandler(this.testBtn_Click);
            // 
            // userinput
            // 
            this.userinput.Location = new System.Drawing.Point(236, 362);
            this.userinput.Name = "userinput";
            this.userinput.Size = new System.Drawing.Size(190, 20);
            this.userinput.TabIndex = 2;
            this.userinput.TextChanged += new System.EventHandler(this.userinput_TextChanged);
            // 
            // moreTestsBtn
            // 
            this.moreTestsBtn.Location = new System.Drawing.Point(16, 394);
            this.moreTestsBtn.Name = "moreTestsBtn";
            this.moreTestsBtn.Size = new System.Drawing.Size(103, 23);
            this.moreTestsBtn.TabIndex = 3;
            this.moreTestsBtn.Text = "Do More Tests";
            this.moreTestsBtn.UseVisualStyleBackColor = true;
            this.moreTestsBtn.Click += new System.EventHandler(this.moreTestsBtn_Click);
            // 
            // complexTestsBtn
            // 
            this.complexTestsBtn.Location = new System.Drawing.Point(16, 423);
            this.complexTestsBtn.Name = "complexTestsBtn";
            this.complexTestsBtn.Size = new System.Drawing.Size(103, 23);
            this.complexTestsBtn.TabIndex = 4;
            this.complexTestsBtn.Text = "Complex Tests";
            this.complexTestsBtn.UseVisualStyleBackColor = true;
            this.complexTestsBtn.Click += new System.EventHandler(this.complexTestsBtn_Click);
            // 
            // nameinput
            // 
            this.nameinput.Location = new System.Drawing.Point(234, 393);
            this.nameinput.Name = "nameinput";
            this.nameinput.Size = new System.Drawing.Size(190, 20);
            this.nameinput.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 365);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Enter message:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 396);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Enter your name:";
            // 
            // numericalTestsBtn
            // 
            this.numericalTestsBtn.Location = new System.Drawing.Point(144, 423);
            this.numericalTestsBtn.Name = "numericalTestsBtn";
            this.numericalTestsBtn.Size = new System.Drawing.Size(103, 23);
            this.numericalTestsBtn.TabIndex = 8;
            this.numericalTestsBtn.Text = "Numerical Tests";
            this.numericalTestsBtn.UseVisualStyleBackColor = true;
            this.numericalTestsBtn.Click += new System.EventHandler(this.numericalTestsBtn_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // yinput
            // 
            this.yinput.Location = new System.Drawing.Point(144, 37);
            this.yinput.Name = "yinput";
            this.yinput.Size = new System.Drawing.Size(37, 20);
            this.yinput.TabIndex = 9;
            // 
            // xinput
            // 
            this.xinput.Location = new System.Drawing.Point(45, 37);
            this.xinput.Name = "xinput";
            this.xinput.Size = new System.Drawing.Size(37, 20);
            this.xinput.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Enter Dimensions of Exploration Area: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(211, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "X:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(121, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Y:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 575);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.xinput);
            this.Controls.Add(this.yinput);
            this.Controls.Add(this.numericalTestsBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameinput);
            this.Controls.Add(this.complexTestsBtn);
            this.Controls.Add(this.moreTestsBtn);
            this.Controls.Add(this.userinput);
            this.Controls.Add(this.testBtn);
            this.Controls.Add(this.output);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.Button testBtn;
        private System.Windows.Forms.TextBox userinput;
        private System.Windows.Forms.Button moreTestsBtn;
        private System.Windows.Forms.Button complexTestsBtn;
        private System.Windows.Forms.TextBox nameinput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button numericalTestsBtn;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.TextBox yinput;
        private System.Windows.Forms.TextBox xinput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

