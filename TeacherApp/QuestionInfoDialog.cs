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
    public partial class QuestionInfoDialog : Form
    {
        string connectionString = "Data Source=localhost;Initial Catalog=ExamSystem;Integrated Security=True";

        public QuestionInfoDialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedQuestion = listBox1.SelectedItem.ToString();
                string[] questionInfo = selectedQuestion.Split(':');
                int questionId = int.Parse(questionInfo[0].Trim());

                // Retrieve question information from the database
                string query = "SELECT question_text, option1, option2, option3, option4, correct_answer FROM questions WHERE id = @questionId";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@questionId", questionId);
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            string questionText = reader["question_text"].ToString();
                            string option1 = reader["option1"].ToString();
                            string option2 = reader["option2"].ToString();
                            string option3 = reader["option3"].ToString();
                            string option4 = reader["option4"].ToString();
                            string correctAnswer = reader["correct_answer"].ToString();

                            string message = $"Question ID: {questionId}\nQuestion Text: {questionText}\n\nOptions:\n1. {option1}\n2. {option2}\n3. {option3}\n4. {option4}\n\nCorrect Answer: {correctAnswer}";

                            MessageBox.Show(message, "Question Information");
                        }
                        reader.Close();
                    }
                }
            }
        }

        private void QuestionInfoDialog_Load(object sender, EventArgs e)
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
