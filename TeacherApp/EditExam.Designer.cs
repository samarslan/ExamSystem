namespace TeacherApp
{
    partial class EditExam
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
            textBox1 = new TextBox();
            questionsCheckedListBox = new CheckedListBox();
            studentsCheckedListBox = new CheckedListBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            applChgnsBtn = new Button();
            crtQstnBtn = new Button();
            edtQstnBtn = new Button();
            qstnInfoBtn = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(75, 23);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(124, 26);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // questionsCheckedListBox
            // 
            questionsCheckedListBox.FormattingEnabled = true;
            questionsCheckedListBox.Location = new Point(205, 23);
            questionsCheckedListBox.Name = "questionsCheckedListBox";
            questionsCheckedListBox.Size = new Size(332, 403);
            questionsCheckedListBox.TabIndex = 2;
            questionsCheckedListBox.SelectedIndexChanged += questionsCheckedListBox_SelectedIndexChanged;
            // 
            // studentsCheckedListBox
            // 
            studentsCheckedListBox.FormattingEnabled = true;
            studentsCheckedListBox.Location = new Point(543, 23);
            studentsCheckedListBox.Name = "studentsCheckedListBox";
            studentsCheckedListBox.Size = new Size(245, 403);
            studentsCheckedListBox.TabIndex = 3;
            studentsCheckedListBox.SelectedIndexChanged += studentsCheckedListBox_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 25);
            label1.Name = "label1";
            label1.Size = new Size(68, 19);
            label1.TabIndex = 4;
            label1.Text = "Sınav Adı:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(205, 1);
            label2.Name = "label2";
            label2.Size = new Size(52, 19);
            label2.TabIndex = 5;
            label2.Text = "Sorular";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(542, 4);
            label3.Name = "label3";
            label3.Size = new Size(72, 19);
            label3.TabIndex = 6;
            label3.Text = "Öğrenciler";
            label3.Click += label3_Click;
            // 
            // applChgnsBtn
            // 
            applChgnsBtn.Location = new Point(12, 336);
            applChgnsBtn.Name = "applChgnsBtn";
            applChgnsBtn.Size = new Size(187, 90);
            applChgnsBtn.TabIndex = 7;
            applChgnsBtn.Text = "Kaydet";
            applChgnsBtn.UseVisualStyleBackColor = true;
            applChgnsBtn.Click += applChgnsBtn_Click;
            // 
            // crtQstnBtn
            // 
            crtQstnBtn.Location = new Point(12, 240);
            crtQstnBtn.Name = "crtQstnBtn";
            crtQstnBtn.Size = new Size(187, 90);
            crtQstnBtn.TabIndex = 8;
            crtQstnBtn.Text = "Soru Oluştur";
            crtQstnBtn.UseVisualStyleBackColor = true;
            crtQstnBtn.Click += crtQstnBtn_Click;
            // 
            // edtQstnBtn
            // 
            edtQstnBtn.Location = new Point(12, 144);
            edtQstnBtn.Name = "edtQstnBtn";
            edtQstnBtn.Size = new Size(187, 90);
            edtQstnBtn.TabIndex = 9;
            edtQstnBtn.Text = "Soru Düzenle";
            edtQstnBtn.UseVisualStyleBackColor = true;
            edtQstnBtn.Click += edtQstnBtn_Click;
            // 
            // qstnInfoBtn
            // 
            qstnInfoBtn.Location = new Point(12, 50);
            qstnInfoBtn.Name = "qstnInfoBtn";
            qstnInfoBtn.Size = new Size(187, 90);
            qstnInfoBtn.TabIndex = 10;
            qstnInfoBtn.Text = "Soru Bilgisi";
            qstnInfoBtn.UseVisualStyleBackColor = true;
            qstnInfoBtn.Click += qstnInfoBtn_Click;
            // 
            // EditExam
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 438);
            Controls.Add(qstnInfoBtn);
            Controls.Add(edtQstnBtn);
            Controls.Add(crtQstnBtn);
            Controls.Add(applChgnsBtn);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(studentsCheckedListBox);
            Controls.Add(questionsCheckedListBox);
            Controls.Add(textBox1);
            Name = "EditExam";
            Text = "EditExam";
            Load += EditExam_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private CheckedListBox questionsCheckedListBox;
        private CheckedListBox studentsCheckedListBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button applChgnsBtn;
        private Button crtQstnBtn;
        private Button edtQstnBtn;
        private Button qstnInfoBtn;
    }
}