namespace AdminApp
{
    partial class Dashboard
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
            userListBox = new ListBox();
            userInfoBtn = new Button();
            userEditBtn = new Button();
            userCreateBtn = new Button();
            userDeleteBtn = new Button();
            SuspendLayout();
            // 
            // userListBox
            // 
            userListBox.FormattingEnabled = true;
            userListBox.ItemHeight = 19;
            userListBox.Location = new Point(12, 12);
            userListBox.Name = "userListBox";
            userListBox.Size = new Size(528, 346);
            userListBox.TabIndex = 0;
            // 
            // userInfoBtn
            // 
            userInfoBtn.Location = new Point(12, 373);
            userInfoBtn.Name = "userInfoBtn";
            userInfoBtn.Size = new Size(129, 65);
            userInfoBtn.TabIndex = 1;
            userInfoBtn.Text = "button1";
            userInfoBtn.UseVisualStyleBackColor = true;
            userInfoBtn.Click += userInfoBtn_Click;
            // 
            // userEditBtn
            // 
            userEditBtn.Location = new Point(147, 373);
            userEditBtn.Name = "userEditBtn";
            userEditBtn.Size = new Size(129, 65);
            userEditBtn.TabIndex = 2;
            userEditBtn.Text = "button2";
            userEditBtn.UseVisualStyleBackColor = true;
            // 
            // userCreateBtn
            // 
            userCreateBtn.Location = new Point(282, 373);
            userCreateBtn.Name = "userCreateBtn";
            userCreateBtn.Size = new Size(129, 65);
            userCreateBtn.TabIndex = 3;
            userCreateBtn.Text = "button3";
            userCreateBtn.UseVisualStyleBackColor = true;
            userCreateBtn.Click += userCreateBtn_Click;
            // 
            // userDeleteBtn
            // 
            userDeleteBtn.Location = new Point(417, 373);
            userDeleteBtn.Name = "userDeleteBtn";
            userDeleteBtn.Size = new Size(129, 65);
            userDeleteBtn.TabIndex = 4;
            userDeleteBtn.Text = "button4";
            userDeleteBtn.UseVisualStyleBackColor = true;
            userDeleteBtn.Click += userDeleteBtn_Click;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(550, 450);
            Controls.Add(userDeleteBtn);
            Controls.Add(userCreateBtn);
            Controls.Add(userEditBtn);
            Controls.Add(userInfoBtn);
            Controls.Add(userListBox);
            Name = "Dashboard";
            Text = "Dashboard";
            Load += Dashboard_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox userListBox;
        private Button userInfoBtn;
        private Button userEditBtn;
        private Button userCreateBtn;
        private Button userDeleteBtn;
    }
}