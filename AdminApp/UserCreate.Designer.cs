namespace AdminApp
{
    partial class UserCreate
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
            fNameTextBox = new TextBox();
            lNameTextBox = new TextBox();
            usernameTextBox = new TextBox();
            passwordTextBox = new TextBox();
            userTypeComboBox = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // fNameTextBox
            // 
            fNameTextBox.Location = new Point(94, 12);
            fNameTextBox.Name = "fNameTextBox";
            fNameTextBox.Size = new Size(139, 26);
            fNameTextBox.TabIndex = 0;
            // 
            // lNameTextBox
            // 
            lNameTextBox.Location = new Point(94, 44);
            lNameTextBox.Name = "lNameTextBox";
            lNameTextBox.Size = new Size(139, 26);
            lNameTextBox.TabIndex = 1;
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(94, 76);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(139, 26);
            usernameTextBox.TabIndex = 2;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(94, 108);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(139, 26);
            passwordTextBox.TabIndex = 3;
            // 
            // userTypeComboBox
            // 
            userTypeComboBox.FormattingEnabled = true;
            userTypeComboBox.Items.AddRange(new object[] { "Öğrenci", "Öğretmen", "Yönetici" });
            userTypeComboBox.Location = new Point(94, 140);
            userTypeComboBox.Name = "userTypeComboBox";
            userTypeComboBox.Size = new Size(139, 27);
            userTypeComboBox.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(2, 14);
            label1.Name = "label1";
            label1.Size = new Size(29, 19);
            label1.TabIndex = 5;
            label1.Text = "Ad:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(2, 46);
            label2.Name = "label2";
            label2.Size = new Size(49, 19);
            label2.TabIndex = 6;
            label2.Text = "Soyad:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(2, 78);
            label3.Name = "label3";
            label3.Size = new Size(85, 19);
            label3.TabIndex = 7;
            label3.Text = "Kullanıcı Adı:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(2, 110);
            label4.Name = "label4";
            label4.Size = new Size(38, 19);
            label4.TabIndex = 8;
            label4.Text = "Şifre:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(2, 143);
            label5.Name = "label5";
            label5.Size = new Size(86, 19);
            label5.TabIndex = 9;
            label5.Text = "Kullanıcı Tipi:";
            // 
            // button1
            // 
            button1.Location = new Point(3, 175);
            button1.Name = "button1";
            button1.Size = new Size(230, 58);
            button1.TabIndex = 10;
            button1.Text = "Kullanıcı Oluştur";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // UserCreate
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(238, 239);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(userTypeComboBox);
            Controls.Add(passwordTextBox);
            Controls.Add(usernameTextBox);
            Controls.Add(lNameTextBox);
            Controls.Add(fNameTextBox);
            Name = "UserCreate";
            Text = "UserCreate";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox fNameTextBox;
        private TextBox lNameTextBox;
        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private ComboBox userTypeComboBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button button1;
    }
}