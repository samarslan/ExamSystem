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
    public partial class QuestionEdit : Form
    {
        string connectionString = "Data Source=localhost;Initial Catalog=ExamSystem;Integrated Security=True";

        public QuestionEdit()
        {
            InitializeComponent();
        }

        private void QuestionEdit_Load(object sender, EventArgs e)
        {
            option1TextBox.Text = EditedQuestion.option1;
            option2TextBox.Text = EditedQuestion.opiton2;
            option3TextBox.Text = EditedQuestion.opiton3;
            option4TextBox.Text = EditedQuestion.opiton4;
            qstnTextBox.Text = EditedQuestion.questionText;

            if (EditedQuestion.correctAnswer == option1TextBox.Text)
            {
                option1RadioBtn.Checked = true;
            }
            else if (EditedQuestion.correctAnswer == option2TextBox.Text)
            {
                option2RadioBtn.Checked = true;
            }
            else if (EditedQuestion.correctAnswer == option3TextBox.Text)
            {
                option3RadioBtn.Checked = true;
            }
            else if (EditedQuestion.correctAnswer == option4TextBox.Text)
            {
                option4RadioBtn.Checked = true;
            }
        }

        private void qstnCrtnBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE questions SET question_text = @questionText, option1 = @option1, option2 = @option2, option3 = @option3, option4 = @option4, correct_answer = @correctAnswer WHERE id = @questionId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@questionText", qstnTextBox.Text);
                    command.Parameters.AddWithValue("@option1", option1TextBox.Text);
                    command.Parameters.AddWithValue("@option2", option2TextBox.Text);
                    command.Parameters.AddWithValue("@option3", option3TextBox.Text);
                    command.Parameters.AddWithValue("@option4", option4TextBox.Text);

                    if (option1RadioBtn.Checked)
                        command.Parameters.AddWithValue("@correctAnswer", option1TextBox.Text);
                    else if (option2RadioBtn.Checked)
                        command.Parameters.AddWithValue("@correctAnswer", option2TextBox.Text);
                    else if (option3RadioBtn.Checked)
                        command.Parameters.AddWithValue("@correctAnswer", option3TextBox.Text);
                    else if (option4RadioBtn.Checked)
                        command.Parameters.AddWithValue("@correctAnswer", option4TextBox.Text);

                    command.Parameters.AddWithValue("@questionId", EditedQuestion.questionId);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Question updated successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to update the question.");
                    }
                }
            }

        }
    }
}
