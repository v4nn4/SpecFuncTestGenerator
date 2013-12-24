namespace SpecFuncTestGenerator
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
            this.callButton = new System.Windows.Forms.Button();
            this.inputValueMin = new System.Windows.Forms.TextBox();
            this.precDigits = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.isCpp = new System.Windows.Forms.RadioButton();
            this.isCSharp = new System.Windows.Forms.RadioButton();
            this.inputValueMax = new System.Windows.Forms.TextBox();
            this.registeredFunc = new System.Windows.Forms.ComboBox();
            this.parameter1 = new System.Windows.Forms.TextBox();
            this.parameter2 = new System.Windows.Forms.TextBox();
            this.parameter3 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // callButton
            // 
            this.callButton.Location = new System.Drawing.Point(254, 243);
            this.callButton.Name = "callButton";
            this.callButton.Size = new System.Drawing.Size(100, 23);
            this.callButton.TabIndex = 0;
            this.callButton.Text = "Generate unit test";
            this.callButton.UseVisualStyleBackColor = true;
            this.callButton.Click += new System.EventHandler(this.Button1Click);
            // 
            // inputValueMin
            // 
            this.inputValueMin.Location = new System.Drawing.Point(40, 23);
            this.inputValueMin.Name = "inputValueMin";
            this.inputValueMin.Size = new System.Drawing.Size(44, 20);
            this.inputValueMin.TabIndex = 2;
            // 
            // precDigits
            // 
            this.precDigits.Location = new System.Drawing.Point(99, 87);
            this.precDigits.Name = "precDigits";
            this.precDigits.Size = new System.Drawing.Size(44, 20);
            this.precDigits.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Precision digits";
            // 
            // isCpp
            // 
            this.isCpp.AutoSize = true;
            this.isCpp.Location = new System.Drawing.Point(19, 37);
            this.isCpp.Name = "isCpp";
            this.isCpp.Size = new System.Drawing.Size(70, 17);
            this.isCpp.TabIndex = 6;
            this.isCpp.TabStop = true;
            this.isCpp.Text = "C++ gtest";
            this.isCpp.UseVisualStyleBackColor = true;
            // 
            // isCSharp
            // 
            this.isCSharp.AutoSize = true;
            this.isCSharp.Location = new System.Drawing.Point(19, 60);
            this.isCSharp.Name = "isCSharp";
            this.isCSharp.Size = new System.Drawing.Size(69, 17);
            this.isCSharp.TabIndex = 7;
            this.isCSharp.TabStop = true;
            this.isCSharp.Text = "C# NUnit";
            this.isCSharp.UseVisualStyleBackColor = true;
            // 
            // inputValueMax
            // 
            this.inputValueMax.Location = new System.Drawing.Point(150, 23);
            this.inputValueMax.Name = "inputValueMax";
            this.inputValueMax.Size = new System.Drawing.Size(44, 20);
            this.inputValueMax.TabIndex = 8;
            // 
            // registeredFunc
            // 
            this.registeredFunc.FormattingEnabled = true;
            this.registeredFunc.Location = new System.Drawing.Point(112, 10);
            this.registeredFunc.Name = "registeredFunc";
            this.registeredFunc.Size = new System.Drawing.Size(242, 21);
            this.registeredFunc.TabIndex = 9;
            this.registeredFunc.SelectedIndexChanged += new System.EventHandler(this.RegisteredFuncSelectedIndexChanged);
            // 
            // parameter1
            // 
            this.parameter1.Location = new System.Drawing.Point(6, 19);
            this.parameter1.Name = "parameter1";
            this.parameter1.Size = new System.Drawing.Size(100, 20);
            this.parameter1.TabIndex = 10;
            // 
            // parameter2
            // 
            this.parameter2.Location = new System.Drawing.Point(6, 45);
            this.parameter2.Name = "parameter2";
            this.parameter2.Size = new System.Drawing.Size(100, 20);
            this.parameter2.TabIndex = 11;
            // 
            // parameter3
            // 
            this.parameter3.Location = new System.Drawing.Point(6, 71);
            this.parameter3.Name = "parameter3";
            this.parameter3.Size = new System.Drawing.Size(100, 20);
            this.parameter3.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.parameter1);
            this.groupBox1.Controls.Add(this.parameter3);
            this.groupBox1.Controls.Add(this.parameter2);
            this.groupBox1.Location = new System.Drawing.Point(239, 122);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(115, 100);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parameters";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.inputValueMin);
            this.groupBox2.Controls.Add(this.inputValueMax);
            this.groupBox2.Location = new System.Drawing.Point(19, 122);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(201, 100);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Values";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(126, 53);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(42, 17);
            this.radioButton2.TabIndex = 11;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Bell";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(56, 53);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(54, 17);
            this.radioButton1.TabIndex = 10;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Linear";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Mode";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(113, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "xmax";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "xmin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Maxima function :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 278);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.registeredFunc);
            this.Controls.Add(this.isCSharp);
            this.Controls.Add(this.isCpp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.precDigits);
            this.Controls.Add(this.callButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button callButton;
        private System.Windows.Forms.TextBox inputValueMin;
        private System.Windows.Forms.TextBox precDigits;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton isCpp;
        private System.Windows.Forms.RadioButton isCSharp;
        private System.Windows.Forms.TextBox inputValueMax;
        private System.Windows.Forms.ComboBox registeredFunc;
        private System.Windows.Forms.TextBox parameter1;
        private System.Windows.Forms.TextBox parameter2;
        private System.Windows.Forms.TextBox parameter3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

