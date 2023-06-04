namespace TeacherApp
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
            studentsListBox = new ListBox();
            createExamBtn = new Button();
            examInfoBtn = new Button();
            examsListBox = new ListBox();
            examsGroupBox = new GroupBox();
            editExamBtn = new Button();
            studentsGroupBox = new GroupBox();
            stdntInfoBtn = new Button();
            examsGroupBox.SuspendLayout();
            studentsGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // studentsListBox
            // 
            studentsListBox.FormattingEnabled = true;
            studentsListBox.ItemHeight = 19;
            studentsListBox.Location = new Point(6, 25);
            studentsListBox.Name = "studentsListBox";
            studentsListBox.Size = new Size(438, 365);
            studentsListBox.TabIndex = 3;
            // 
            // createExamBtn
            // 
            createExamBtn.Location = new Point(309, 396);
            createExamBtn.Name = "createExamBtn";
            createExamBtn.Size = new Size(144, 89);
            createExamBtn.TabIndex = 2;
            createExamBtn.Text = "button1";
            createExamBtn.UseVisualStyleBackColor = true;
            // 
            // examInfoBtn
            // 
            examInfoBtn.Location = new Point(6, 396);
            examInfoBtn.Name = "examInfoBtn";
            examInfoBtn.Size = new Size(144, 89);
            examInfoBtn.TabIndex = 1;
            examInfoBtn.Text = "Sınav Bilgisi";
            examInfoBtn.UseVisualStyleBackColor = true;
            examInfoBtn.Click += examInfoBtn_Click;
            // 
            // examsListBox
            // 
            examsListBox.FormattingEnabled = true;
            examsListBox.ItemHeight = 19;
            examsListBox.Location = new Point(6, 25);
            examsListBox.Name = "examsListBox";
            examsListBox.Size = new Size(447, 365);
            examsListBox.TabIndex = 0;
            // 
            // examsGroupBox
            // 
            examsGroupBox.Controls.Add(editExamBtn);
            examsGroupBox.Controls.Add(examsListBox);
            examsGroupBox.Controls.Add(examInfoBtn);
            examsGroupBox.Controls.Add(createExamBtn);
            examsGroupBox.Location = new Point(12, 12);
            examsGroupBox.Name = "examsGroupBox";
            examsGroupBox.Size = new Size(459, 502);
            examsGroupBox.TabIndex = 4;
            examsGroupBox.TabStop = false;
            examsGroupBox.Text = "Exams";
            // 
            // editExamBtn
            // 
            editExamBtn.Location = new Point(159, 396);
            editExamBtn.Name = "editExamBtn";
            editExamBtn.Size = new Size(144, 89);
            editExamBtn.TabIndex = 3;
            editExamBtn.Text = "button1";
            editExamBtn.UseVisualStyleBackColor = true;
            editExamBtn.Click += editExamBtn_Click;
            // 
            // studentsGroupBox
            // 
            studentsGroupBox.Controls.Add(stdntInfoBtn);
            studentsGroupBox.Controls.Add(studentsListBox);
            studentsGroupBox.Location = new Point(477, 12);
            studentsGroupBox.Name = "studentsGroupBox";
            studentsGroupBox.Size = new Size(459, 502);
            studentsGroupBox.TabIndex = 5;
            studentsGroupBox.TabStop = false;
            studentsGroupBox.Text = "Students";
            // 
            // stdntInfoBtn
            // 
            stdntInfoBtn.Location = new Point(6, 396);
            stdntInfoBtn.Name = "stdntInfoBtn";
            stdntInfoBtn.Size = new Size(438, 89);
            stdntInfoBtn.TabIndex = 4;
            stdntInfoBtn.Text = "Öğrenci Bilgisi";
            stdntInfoBtn.UseVisualStyleBackColor = true;
            stdntInfoBtn.Click += stdntInfoBtn_Click;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(949, 526);
            Controls.Add(studentsGroupBox);
            Controls.Add(examsGroupBox);
            Name = "Dashboard";
            Text = "Dashboard";
            Load += Dashboard_Load;
            examsGroupBox.ResumeLayout(false);
            studentsGroupBox.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private ListBox studentsListBox;
        private Button createExamBtn;
        private Button examInfoBtn;
        private ListBox examsListBox;
        private GroupBox examsGroupBox;
        private GroupBox studentsGroupBox;
        private Button stdntInfoBtn;
        private Button editExamBtn;
    }
}