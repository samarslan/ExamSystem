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

namespace ExamApp
{
    public partial class ExamPanel : Form
    {
        int selectedExamId = SuccsesfullLogin.selectedExam;
        string connectionString = "Data Source=localhost;Initial Catalog=ExamSystem;Integrated Security=True";
        string[] givenAnswers;
        int questionCounter = 0;
        public ExamPanel()
        {
            InitializeComponent();
        }

        private void ExamPanel_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT e.id, e.exam_name, e.teacher_id, e.question_ids
                        FROM exams e
                        WHERE e.id = @selectedExam
                          AND e.id IN (
                            SELECT exam_id
                            FROM exam_results
                            WHERE student_id = @studentId
                          )";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@selectedExam", SuccsesfullLogin.selectedExam);
                    command.Parameters.AddWithValue("@studentId", SuccsesfullLogin.id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Exam.id = reader.GetInt32(0);
                            Exam.exam_name = reader.GetString(1);
                            Exam.teacher_id = reader.GetInt32(2);
                            Exam.question_ids = reader.GetString(3);

                            // Populate the List<Question> field
                            Exam.questions = LoadQuestions(Exam.question_ids);
                        }
                    }
                }
            }
            PopulateQuestion(questionCounter);
            givenAnswers = new string[Exam.questions.Count];
            label1.Text = $"{Exam.exam_name}";
        }

        private List<Question> LoadQuestions(string questionIds)
        {
            List<Question> questions = new List<Question>();

            string[] ids = questionIds.Split(',');

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT id, question_text, option1, option2, option3, option4, correct_answer " +
                               "FROM questions " +
                               "WHERE id IN ({0})";

                string parameterPlaceholder = string.Join(",", ids.Select((id, index) => $"@questionId{index}"));
                query = string.Format(query, parameterPlaceholder);

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    for (int i = 0; i < ids.Length; i++)
                    {
                        command.Parameters.AddWithValue($"@questionId{i}", ids[i]);
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Question question = new Question();
                            question.id = reader.GetInt32(0);
                            question.question_text = reader.GetString(1);
                            question.option1 = reader.GetString(2);
                            question.option2 = reader.GetString(3);
                            question.option3 = reader.GetString(4);
                            question.option4 = reader.GetString(5);
                            question.correct_answer = reader.GetString(6);

                            questions.Add(question);
                        }
                    }
                }
            }

            return questions;
        }

        private void PopulateQuestion(int qID)
        {
            Question question = Exam.questions[qID];
            questionRichTextBox.Text = question.question_text;
            option1RichTextBox.Text = question.option1;
            option2RichTextBox.Text = question.option2;
            option3RichTextBox.Text = question.option3;
            option4RichTextBox.Text = question.option4;
        }

        private void btnPreviousQuestion_Click(object sender, EventArgs e)
        {
            questionCounter--;
            option1RadioBtn.Checked = false;
            option2RadioBtn.Checked = false;
            option3RadioBtn.Checked = false;
            option4RadioBtn.Checked = false;
            PopulateQuestion(questionCounter);
            btnNextQuestion.Enabled = true;
            if(questionCounter == 0)
            {
                btnPreviousQuestion.Enabled = false;
            }
        }

        private void btnNextQuestion_Click(object sender, EventArgs e)
        {
            questionCounter++;
            option1RadioBtn.Checked = false;
            option2RadioBtn.Checked = false;
            option3RadioBtn.Checked = false;
            option4RadioBtn.Checked = false;
            PopulateQuestion(questionCounter);
            if (questionCounter == Exam.questions.Count - 1)
            {
                btnNextQuestion.Enabled = false;
            }
        }

        private void btnEndExam_Click(object sender, EventArgs e)
        {
            int correctAnswers = 0;
            int wrongAnswers = 0;
            int score = 0;
            for (int i = 0; i < givenAnswers.Length; i++)
            {
                if (givenAnswers[i] == Exam.questions[i].correct_answer)
                {
                    correctAnswers++;
                }
                else
                {
                    wrongAnswers++;
                }
            }
            score = correctAnswers * 100 / Exam.questions.Count;
            MessageBox.Show($"Doğru Cevap: {correctAnswers}\nYanlış Cevap: {wrongAnswers}\nPuanınız: {score}");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"UPDATE exam_results
                         SET score = @score
                         WHERE exam_id = @examId
                         AND student_id = @studentId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@score", score);
                    command.Parameters.AddWithValue("@examId", Exam.id);
                    command.Parameters.AddWithValue("@studentId", SuccsesfullLogin.id);

                    command.ExecuteNonQuery();
                }
            }
            this.Hide();
            Dashboard dashboardForm = new Dashboard();
            dashboardForm.Show();
        }

        private void option1RadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (option1RadioBtn.Checked)
            {
                givenAnswers[questionCounter] = option1RichTextBox.Text;
            }
        }

        private void option2RadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (option2RadioBtn.Checked)
            {
                givenAnswers[questionCounter] = option2RichTextBox.Text;
            }
        }

        private void option3RadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (option3RadioBtn.Checked)
            {
                givenAnswers[questionCounter] = option3RichTextBox.Text;
            }
        }

        private void option4RadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (option4RadioBtn.Checked)
            {
                givenAnswers[questionCounter] = option4RichTextBox.Text;
            }
        }
    }
}
