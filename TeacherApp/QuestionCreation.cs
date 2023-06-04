using System.Data.SqlClient;

namespace TeacherApp
{
    public partial class QuestionCreation : Form
    {
        string connectionString = "Data Source=localhost;Initial Catalog=ExamSystem;Integrated Security=True";

        public QuestionCreation()
        {
            InitializeComponent();
        }

        private void qstnCrtnBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(qstnTextBox.Text) &&
    !string.IsNullOrEmpty(option1TextBox.Text) &&
    !string.IsNullOrEmpty(option2TextBox.Text) &&
    !string.IsNullOrEmpty(option3TextBox.Text) &&
    !string.IsNullOrEmpty(option4TextBox.Text) &&
    (option1RadioBtn.Checked || option2RadioBtn.Checked || option3RadioBtn.Checked || option4RadioBtn.Checked))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string questionText = qstnTextBox.Text;
                    string option1 = option1TextBox.Text;
                    string option2 = option2TextBox.Text;
                    string option3 = option3TextBox.Text;
                    string option4 = option4TextBox.Text;
                    string correctAnswer = "";

                    if (option1RadioBtn.Checked)
                        correctAnswer = option1TextBox.Text;
                    else if (option2RadioBtn.Checked)
                        correctAnswer = option2TextBox.Text;
                    else if (option3RadioBtn.Checked)
                        correctAnswer = option3TextBox.Text;
                    else if (option4RadioBtn.Checked)
                        correctAnswer = option4TextBox.Text;

                    string query = "INSERT INTO questions (question_text, option1, option2, option3, option4, correct_answer) " +
                                   "VALUES (@questionText, @option1, @option2, @option3, @option4, @correctAnswer)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@questionText", questionText);
                        command.Parameters.AddWithValue("@option1", option1);
                        command.Parameters.AddWithValue("@option2", option2);
                        command.Parameters.AddWithValue("@option3", option3);
                        command.Parameters.AddWithValue("@option4", option4);
                        command.Parameters.AddWithValue("@correctAnswer", correctAnswer);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // The row was successfully inserted
                            MessageBox.Show("Question added successfully!");
                        }
                        else
                        {
                            // Failed to insert the row
                            MessageBox.Show("Failed to add the question.");
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("Please fill all the fields.");
            }

        }
    }
}
