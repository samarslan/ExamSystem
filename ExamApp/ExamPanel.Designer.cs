namespace ExamApp
{
    partial class ExamPanel
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
            label1 = new Label();
            questionRichTextBox = new RichTextBox();
            label3 = new Label();
            option1RichTextBox = new RichTextBox();
            option2RichTextBox = new RichTextBox();
            option3RichTextBox = new RichTextBox();
            option4RichTextBox = new RichTextBox();
            btnNextQuestion = new Button();
            btnEndExam = new Button();
            btnPreviousQuestion = new Button();
            option1RadioBtn = new RadioButton();
            option2RadioBtn = new RadioButton();
            option3RadioBtn = new RadioButton();
            option4RadioBtn = new RadioButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 4);
            label1.Name = "label1";
            label1.Size = new Size(45, 19);
            label1.TabIndex = 1;
            label1.Text = "label1";
            // 
            // questionRichTextBox
            // 
            questionRichTextBox.Enabled = false;
            questionRichTextBox.Location = new Point(194, 12);
            questionRichTextBox.Name = "questionRichTextBox";
            questionRichTextBox.Size = new Size(497, 77);
            questionRichTextBox.TabIndex = 3;
            questionRichTextBox.Text = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(148, 42);
            label3.Name = "label3";
            label3.Size = new Size(40, 19);
            label3.TabIndex = 4;
            label3.Text = "Soru:";
            // 
            // option1RichTextBox
            // 
            option1RichTextBox.Enabled = false;
            option1RichTextBox.Location = new Point(194, 137);
            option1RichTextBox.Name = "option1RichTextBox";
            option1RichTextBox.Size = new Size(497, 77);
            option1RichTextBox.TabIndex = 5;
            option1RichTextBox.Text = "";
            // 
            // option2RichTextBox
            // 
            option2RichTextBox.Enabled = false;
            option2RichTextBox.Location = new Point(194, 220);
            option2RichTextBox.Name = "option2RichTextBox";
            option2RichTextBox.Size = new Size(497, 77);
            option2RichTextBox.TabIndex = 6;
            option2RichTextBox.Text = "";
            // 
            // option3RichTextBox
            // 
            option3RichTextBox.Enabled = false;
            option3RichTextBox.Location = new Point(194, 303);
            option3RichTextBox.Name = "option3RichTextBox";
            option3RichTextBox.Size = new Size(497, 77);
            option3RichTextBox.TabIndex = 7;
            option3RichTextBox.Text = "";
            // 
            // option4RichTextBox
            // 
            option4RichTextBox.Enabled = false;
            option4RichTextBox.Location = new Point(194, 386);
            option4RichTextBox.Name = "option4RichTextBox";
            option4RichTextBox.Size = new Size(497, 77);
            option4RichTextBox.TabIndex = 8;
            option4RichTextBox.Text = "";
            // 
            // btnNextQuestion
            // 
            btnNextQuestion.Location = new Point(414, 469);
            btnNextQuestion.Name = "btnNextQuestion";
            btnNextQuestion.Size = new Size(135, 68);
            btnNextQuestion.TabIndex = 13;
            btnNextQuestion.Text = "Sonraki Soru";
            btnNextQuestion.UseVisualStyleBackColor = true;
            btnNextQuestion.Click += btnNextQuestion_Click;
            // 
            // btnEndExam
            // 
            btnEndExam.Location = new Point(555, 469);
            btnEndExam.Name = "btnEndExam";
            btnEndExam.Size = new Size(135, 68);
            btnEndExam.TabIndex = 14;
            btnEndExam.Text = "Sınavı Bitir";
            btnEndExam.UseVisualStyleBackColor = true;
            btnEndExam.Click += btnEndExam_Click;
            // 
            // btnPreviousQuestion
            // 
            btnPreviousQuestion.Location = new Point(273, 469);
            btnPreviousQuestion.Name = "btnPreviousQuestion";
            btnPreviousQuestion.Size = new Size(135, 68);
            btnPreviousQuestion.TabIndex = 15;
            btnPreviousQuestion.Text = "Önceki Soru";
            btnPreviousQuestion.UseVisualStyleBackColor = true;
            btnPreviousQuestion.Click += btnPreviousQuestion_Click;
            // 
            // option1RadioBtn
            // 
            option1RadioBtn.AutoSize = true;
            option1RadioBtn.Location = new Point(148, 164);
            option1RadioBtn.Name = "option1RadioBtn";
            option1RadioBtn.Size = new Size(40, 23);
            option1RadioBtn.TabIndex = 16;
            option1RadioBtn.TabStop = true;
            option1RadioBtn.Text = "A)";
            option1RadioBtn.UseVisualStyleBackColor = true;
            // 
            // option2RadioBtn
            // 
            option2RadioBtn.AutoSize = true;
            option2RadioBtn.Location = new Point(149, 251);
            option2RadioBtn.Name = "option2RadioBtn";
            option2RadioBtn.Size = new Size(39, 23);
            option2RadioBtn.TabIndex = 17;
            option2RadioBtn.TabStop = true;
            option2RadioBtn.Text = "B)";
            option2RadioBtn.UseVisualStyleBackColor = true;
            // 
            // option3RadioBtn
            // 
            option3RadioBtn.AutoSize = true;
            option3RadioBtn.Location = new Point(148, 330);
            option3RadioBtn.Name = "option3RadioBtn";
            option3RadioBtn.Size = new Size(40, 23);
            option3RadioBtn.TabIndex = 18;
            option3RadioBtn.TabStop = true;
            option3RadioBtn.Text = "C)";
            option3RadioBtn.UseVisualStyleBackColor = true;
            // 
            // option4RadioBtn
            // 
            option4RadioBtn.AutoSize = true;
            option4RadioBtn.Location = new Point(149, 411);
            option4RadioBtn.Name = "option4RadioBtn";
            option4RadioBtn.Size = new Size(41, 23);
            option4RadioBtn.TabIndex = 19;
            option4RadioBtn.TabStop = true;
            option4RadioBtn.Text = "D)";
            option4RadioBtn.UseVisualStyleBackColor = true;
            // 
            // ExamPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(702, 549);
            Controls.Add(option4RadioBtn);
            Controls.Add(option3RadioBtn);
            Controls.Add(option2RadioBtn);
            Controls.Add(option1RadioBtn);
            Controls.Add(btnPreviousQuestion);
            Controls.Add(btnEndExam);
            Controls.Add(btnNextQuestion);
            Controls.Add(option4RichTextBox);
            Controls.Add(option3RichTextBox);
            Controls.Add(option2RichTextBox);
            Controls.Add(option1RichTextBox);
            Controls.Add(label3);
            Controls.Add(questionRichTextBox);
            Controls.Add(label1);
            Name = "ExamPanel";
            Text = "ExamPanel";
            Load += ExamPanel_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private RichTextBox questionRichTextBox;
        private Label label3;
        private RichTextBox option1RichTextBox;
        private RichTextBox option2RichTextBox;
        private RichTextBox option3RichTextBox;
        private RichTextBox option4RichTextBox;
        private Button btnNextQuestion;
        private Button btnEndExam;
        private Button btnPreviousQuestion;
        private RadioButton option1RadioBtn;
        private RadioButton option2RadioBtn;
        private RadioButton option3RadioBtn;
        private RadioButton option4RadioBtn;
    }
}