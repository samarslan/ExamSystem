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
    public partial class QuestionEditDialog : Form
    {
        string connectionString = "Data Source=localhost;Initial Catalog=ExamSystem;Integrated Security=True";

        public QuestionEditDialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedQuestion = listBox1.SelectedItem.ToString();
                string[] questionInfo = selectedQuestion.Split(':');
                EditedQuestion.questionId = int.Parse(questionInfo[0].Trim());

                string query = "SELECT question_text, option1, option2, option3, option4, correct_answer FROM questions WHERE id = @questionId";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@questionId", EditedQuestion.questionId);
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            EditedQuestion.questionText = reader["question_text"].ToString();
                            EditedQuestion.option1 = reader["option1"].ToString();
                            EditedQuestion.opiton2 = reader["option2"].ToString();
                            EditedQuestion.opiton3 = reader["option3"].ToString();
                            EditedQuestion.opiton4 = reader["option4"].ToString();
                            EditedQuestion.correctAnswer = reader["correct_answer"].ToString();
                        }
                        reader.Close();
                    }
                }
            }
            QuestionEdit questionEdit = new QuestionEdit();
            questionEdit.ShowDialog();
        }

        private void QuestionEditDialog_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT id, question_text FROM questions";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int questionId = (int)reader["id"];
                        string questionText = reader["question_text"].ToString();
                        listBox1.Items.Add($"{questionId}: {questionText}");
                    }
                    reader.Close();
                }
            }
        }
    }
}
