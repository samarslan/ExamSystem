namespace TeacherApp
{
    partial class StudentInfo
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
            stdntExamInfoBtn = new Button();
            label2 = new Label();
            listBox1 = new ListBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // stdntExamInfoBtn
            // 
            stdntExamInfoBtn.Location = new Point(12, 231);
            stdntExamInfoBtn.Name = "stdntExamInfoBtn";
            stdntExamInfoBtn.Size = new Size(305, 79);
            stdntExamInfoBtn.TabIndex = 9;
            stdntExamInfoBtn.Text = "Sınav Bilgileri";
            stdntExamInfoBtn.UseVisualStyleBackColor = true;
            stdntExamInfoBtn.Click += stdntExamInfoBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 28);
            label2.Name = "label2";
            label2.Size = new Size(59, 19);
            label2.TabIndex = 7;
            label2.Text = "Sınavları";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 19;
            listBox1.Location = new Point(12, 50);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(305, 175);
            listBox1.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(45, 19);
            label1.TabIndex = 5;
            label1.Text = "label1";
            // 
            // StudentInfo
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(336, 320);
            Controls.Add(stdntExamInfoBtn);
            Controls.Add(label2);
            Controls.Add(listBox1);
            Controls.Add(label1);
            Name = "StudentInfo";
            Text = "StudentInfo";
            Load += StudentInfo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button stdntExamInfoBtn;
        private Label label2;
        private ListBox listBox1;
        private Label label1;
    }
}