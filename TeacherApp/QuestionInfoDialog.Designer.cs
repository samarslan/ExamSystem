﻿namespace TeacherApp
{
    partial class QuestionInfoDialog
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
            listBox1 = new ListBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 19;
            listBox1.Location = new Point(10, 9);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(322, 289);
            listBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(10, 304);
            button1.Name = "button1";
            button1.Size = new Size(321, 68);
            button1.TabIndex = 1;
            button1.Text = "Soru Bilgisi";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // QuestionInfoDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(343, 384);
            Controls.Add(button1);
            Controls.Add(listBox1);
            Name = "QuestionInfoDialog";
            Text = "QuestionInfoDialog";
            Load += QuestionInfoDialog_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBox1;
        private Button button1;
    }
}