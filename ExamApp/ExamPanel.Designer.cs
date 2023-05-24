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
            comboBox1 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            richTextBox1 = new RichTextBox();
            label3 = new Label();
            richTextBox2 = new RichTextBox();
            richTextBox3 = new RichTextBox();
            richTextBox4 = new RichTextBox();
            richTextBox5 = new RichTextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            btnNextQuestion = new Button();
            btnEndExam = new Button();
            btnPreviousQuestion = new Button();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.Enabled = false;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 242);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(45, 27);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 220);
            label2.Name = "label2";
            label2.Size = new Size(40, 19);
            label2.TabIndex = 2;
            label2.Text = "Soru:";
            // 
            // richTextBox1
            // 
            richTextBox1.Enabled = false;
            richTextBox1.Location = new Point(194, 12);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(497, 77);
            richTextBox1.TabIndex = 3;
            richTextBox1.Text = "";
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
            // richTextBox2
            // 
            richTextBox2.Enabled = false;
            richTextBox2.Location = new Point(194, 137);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(497, 77);
            richTextBox2.TabIndex = 5;
            richTextBox2.Text = "";
            // 
            // richTextBox3
            // 
            richTextBox3.Enabled = false;
            richTextBox3.Location = new Point(194, 220);
            richTextBox3.Name = "richTextBox3";
            richTextBox3.Size = new Size(497, 77);
            richTextBox3.TabIndex = 6;
            richTextBox3.Text = "";
            // 
            // richTextBox4
            // 
            richTextBox4.Enabled = false;
            richTextBox4.Location = new Point(194, 303);
            richTextBox4.Name = "richTextBox4";
            richTextBox4.Size = new Size(497, 77);
            richTextBox4.TabIndex = 7;
            richTextBox4.Text = "";
            // 
            // richTextBox5
            // 
            richTextBox5.Location = new Point(194, 386);
            richTextBox5.Name = "richTextBox5";
            richTextBox5.Size = new Size(497, 77);
            richTextBox5.TabIndex = 8;
            richTextBox5.Text = "";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(143, 168);
            label4.Name = "label4";
            label4.Size = new Size(22, 19);
            label4.TabIndex = 9;
            label4.Text = "A)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(143, 250);
            label5.Name = "label5";
            label5.Size = new Size(21, 19);
            label5.TabIndex = 10;
            label5.Text = "B)";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(143, 334);
            label6.Name = "label6";
            label6.Size = new Size(22, 19);
            label6.TabIndex = 11;
            label6.Text = "C)";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(143, 416);
            label7.Name = "label7";
            label7.Size = new Size(23, 19);
            label7.TabIndex = 12;
            label7.Text = "D)";
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
            // ExamPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(702, 549);
            Controls.Add(btnPreviousQuestion);
            Controls.Add(btnEndExam);
            Controls.Add(btnNextQuestion);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(richTextBox5);
            Controls.Add(richTextBox4);
            Controls.Add(richTextBox3);
            Controls.Add(richTextBox2);
            Controls.Add(label3);
            Controls.Add(richTextBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Name = "ExamPanel";
            Text = "ExamPanel";
            Load += ExamPanel_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private Label label1;
        private Label label2;
        private RichTextBox richTextBox1;
        private Label label3;
        private RichTextBox richTextBox2;
        private RichTextBox richTextBox3;
        private RichTextBox richTextBox4;
        private RichTextBox richTextBox5;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button btnNextQuestion;
        private Button btnEndExam;
        private Button btnPreviousQuestion;
    }
}