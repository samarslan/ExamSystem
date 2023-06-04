using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeacherApp
{
    public partial class EditExam : Form
    {
        string connectionString = "Data Source=localhost;Initial Catalog=ExamSystem;Integrated Security=True";

        public EditExam()
        {
            InitializeComponent();
        }

        private void EditExam_Load(object sender, EventArgs e)
        {
            textBox1.Text = SelectedExam.exam_name;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Populate studentsCheckedListBox
                string studentsQuery = "SELECT id, first_name, last_name FROM users WHERE user_type = 0";
                using (SqlCommand studentsCommand = new SqlCommand(studentsQuery, connection))
                {
                    SqlDataReader studentsReader = studentsCommand.ExecuteReader();
                    while (studentsReader.Read())
                    {
                        int studentId = (int)studentsReader["id"];
                        string firstName = studentsReader["first_name"].ToString();
                        string lastName = studentsReader["last_name"].ToString();
                        string studentInfo = $"{studentId}: {firstName} {lastName}";
                        studentsCheckedListBox.Items.Add(studentInfo);

                        // Check if the student's ID is in the eligible_students list
                        if (SelectedExam.eligible_students.Contains(studentId.ToString()))
                        {
                            int index = studentsCheckedListBox.Items.Count - 1;
                            studentsCheckedListBox.SetItemChecked(index, true);
                        }
                    }
                    studentsReader.Close();
                }

                // Populate questionsCheckedListBox
                string questionsQuery = "SELECT id, question_text FROM questions";
                using (SqlCommand questionsCommand = new SqlCommand(questionsQuery, connection))
                {
                    SqlDataReader questionsReader = questionsCommand.ExecuteReader();
                    while (questionsReader.Read())
                    {
                        int questionId = (int)questionsReader["id"];
                        string questionText = questionsReader["question_text"].ToString();
                        string questionInfo = $"{questionId}: {questionText}";
                        questionsCheckedListBox.Items.Add(questionInfo);

                        // Check if the question's ID is in the questions list
                        if (SelectedExam.questions.Contains(questionId.ToString()))
                        {
                            int index = questionsCheckedListBox.Items.Count - 1;
                            questionsCheckedListBox.SetItemChecked(index, true);
                        }
                    }
                    questionsReader.Close();
                }
            }


        }

        private void qstnInfoBtn_Click(object sender, EventArgs e)
        {
            QuestionInfoDialog questionInfoDialog = new QuestionInfoDialog();
            questionInfoDialog.ShowDialog();
        }

        private void edtQstnBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
