namespace AdminApp
{
    partial class UserEdit
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
            button1 = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            passwordTextBox = new TextBox();
            usernameTextBox = new TextBox();
            lNameTextBox = new TextBox();
            fNameTextBox = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(5, 137);
            button1.Name = "button1";
            button1.Size = new Size(230, 58);
            button1.TabIndex = 21;
            button1.Text = "Kaydet";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(4, 107);
            label4.Name = "label4";
            label4.Size = new Size(38, 19);
            label4.TabIndex = 19;
            label4.Text = "Şifre:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(4, 75);
            label3.Name = "label3";
            label3.Size = new Size(85, 19);
            label3.TabIndex = 18;
            label3.Text = "Kullanıcı Adı:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(4, 43);
            label2.Name = "label2";
            label2.Size = new Size(49, 19);
            label2.TabIndex = 17;
            label2.Text = "Soyad:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(4, 11);
            label1.Name = "label1";
            label1.Size = new Size(29, 19);
            label1.TabIndex = 16;
            label1.Text = "Ad:";
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(96, 105);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(139, 26);
            passwordTextBox.TabIndex = 14;
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(96, 73);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(139, 26);
            usernameTextBox.TabIndex = 13;
            // 
            // lNameTextBox
            // 
            lNameTextBox.Location = new Point(96, 41);
            lNameTextBox.Name = "lNameTextBox";
            lNameTextBox.Size = new Size(139, 26);
            lNameTextBox.TabIndex = 12;
            // 
            // fNameTextBox
            // 
            fNameTextBox.Location = new Point(96, 9);
            fNameTextBox.Name = "fNameTextBox";
            fNameTextBox.Size = new Size(139, 26);
            fNameTextBox.TabIndex = 11;
            // 
            // UserEdit
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(238, 201);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(passwordTextBox);
            Controls.Add(usernameTextBox);
            Controls.Add(lNameTextBox);
            Controls.Add(fNameTextBox);
            Name = "UserEdit";
            Text = "UserEdit";
            Load += UserEdit_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox passwordTextBox;
        private TextBox usernameTextBox;
        private TextBox lNameTextBox;
        private TextBox fNameTextBox;
    }
}