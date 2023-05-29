namespace TeacherApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(99, 102);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(212, 26);
            textBox1.TabIndex = 0;
            textBox1.Text = "johnDoe";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(99, 134);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(212, 26);
            textBox2.TabIndex = 1;
            textBox2.Text = "password1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 105);
            label1.Name = "label1";
            label1.Size = new Size(85, 19);
            label1.TabIndex = 2;
            label1.Text = "Kullanıcı Adı:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(55, 137);
            label2.Name = "label2";
            label2.Size = new Size(38, 19);
            label2.TabIndex = 3;
            label2.Text = "Şifre:";
            // 
            // button1
            // 
            button1.Location = new Point(99, 200);
            button1.Name = "button1";
            button1.Size = new Size(145, 66);
            button1.TabIndex = 4;
            button1.Text = "Giriş Yap";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(55, 9);
            label3.Name = "label3";
            label3.Size = new Size(244, 19);
            label3.TabIndex = 5;
            label3.Text = "Öğretmen Sınav Sistemine Hoşgeldiniz";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(99, 52);
            label4.Name = "label4";
            label4.Size = new Size(116, 19);
            label4.TabIndex = 6;
            label4.Text = "Lütfen Giriş Yapın";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(331, 292);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private Button button1;
        private Label label3;
        private Label label4;
    }
}