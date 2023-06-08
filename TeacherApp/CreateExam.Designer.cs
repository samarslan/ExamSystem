namespace TeacherApp
{
    partial class CreateExam
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
            qstnInfoBtn = new Button();
            edtQstnBtn = new Button();
            crtQstnBtn = new Button();
            applChgnsBtn = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            studentsCheckedListBox = new CheckedListBox();
            questionsCheckedListBox = new CheckedListBox();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // qstnInfoBtn
            // 
            qstnInfoBtn.Location = new Point(11, 50);
            qstnInfoBtn.Name = "qstnInfoBtn";
            qstnInfoBtn.Size = new Size(187, 90);
            qstnInfoBtn.TabIndex = 20;
            qstnInfoBtn.Text = "Soru Bilgisi";
            qstnInfoBtn.UseVisualStyleBackColor = true;
            qstnInfoBtn.Click += qstnInfoBtn_Click;
            // 
            // edtQstnBtn
            // 
            edtQstnBtn.Location = new Point(11, 144);
            edtQstnBtn.Name = "edtQstnBtn";
            edtQstnBtn.Size = new Size(187, 90);
            edtQstnBtn.TabIndex = 19;
            edtQstnBtn.Text = "Soru Düzenle";
            edtQstnBtn.UseVisualStyleBackColor = true;
            edtQstnBtn.Click += edtQstnBtn_Click;
            // 
            // crtQstnBtn
            // 
            crtQstnBtn.Location = new Point(11, 240);
            crtQstnBtn.Name = "crtQstnBtn";
            crtQstnBtn.Size = new Size(187, 90);
            crtQstnBtn.TabIndex = 18;
            crtQstnBtn.Text = "Soru Oluştur";
            crtQstnBtn.UseVisualStyleBackColor = true;
            crtQstnBtn.Click += crtQstnBtn_Click;
            // 
            // applChgnsBtn
            // 
            applChgnsBtn.Location = new Point(11, 336);
            applChgnsBtn.Name = "applChgnsBtn";
            applChgnsBtn.Size = new Size(187, 90);
            applChgnsBtn.TabIndex = 17;
            applChgnsBtn.Text = "Kaydet";
            applChgnsBtn.UseVisualStyleBackColor = true;
            applChgnsBtn.Click += applChgnsBtn_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(541, 4);
            label3.Name = "label3";
            label3.Size = new Size(72, 19);
            label3.TabIndex = 16;
            label3.Text = "Öğrenciler";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(204, 1);
            label2.Name = "label2";
            label2.Size = new Size(52, 19);
            label2.TabIndex = 15;
            label2.Text = "Sorular";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(-1, 25);
            label1.Name = "label1";
            label1.Size = new Size(68, 19);
            label1.TabIndex = 14;
            label1.Text = "Sınav Adı:";
            // 
            // studentsCheckedListBox
            // 
            studentsCheckedListBox.FormattingEnabled = true;
            studentsCheckedListBox.Location = new Point(542, 23);
            studentsCheckedListBox.Name = "studentsCheckedListBox";
            studentsCheckedListBox.Size = new Size(245, 403);
            studentsCheckedListBox.TabIndex = 13;
            // 
            // questionsCheckedListBox
            // 
            questionsCheckedListBox.FormattingEnabled = true;
            questionsCheckedListBox.Location = new Point(204, 23);
            questionsCheckedListBox.Name = "questionsCheckedListBox";
            questionsCheckedListBox.Size = new Size(332, 403);
            questionsCheckedListBox.TabIndex = 12;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(74, 23);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(124, 26);
            textBox1.TabIndex = 11;
            // 
            // CreateExam
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
            Name = "CreateExam";
            Text = "CreateExam";
            Load += CreateExam_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button qstnInfoBtn;
        private Button edtQstnBtn;
        private Button crtQstnBtn;
        private Button applChgnsBtn;
        private Label label3;
        private Label label2;
        private Label label1;
        private CheckedListBox studentsCheckedListBox;
        private CheckedListBox questionsCheckedListBox;
        private TextBox textBox1;
    }
}