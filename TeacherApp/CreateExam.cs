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
    public partial class CreateExam : Form
    {
        string connectionString = "Data Source=localhost;Initial Catalog=ExamSystem;Integrated Security=True";

        public CreateExam()
        {
            InitializeComponent();
        }

        private void CreateExam_Load(object sender, EventArgs e)
        {
            PopulateStudents();
            PopulateQuestions();
        }

        private void PopulateStudents()
        {
            studentsCheckedListBox.Items.Clear();
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
                    }
                    studentsReader.Close();
                }
            }
        }

        public void PopulateQuestions()
        {
            questionsCheckedListBox.Items.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Populate questionsCheckedListBox
                connection.Open();
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
            QuestionEditDialog questionEditDialog = new QuestionEditDialog();
            questionEditDialog.ShowDialog();
            PopulateQuestions();
        }

        private void crtQstnBtn_Click(object sender, EventArgs e)
        {
            QuestionCreation questionCreation = new QuestionCreation();
            questionCreation.ShowDialog();
            PopulateQuestions();
        }

        private void applChgnsBtn_Click(object sender, EventArgs e)
        {
            // Get the checked students
            List<int> checkedStudents = new List<int>();
            foreach (var item in studentsCheckedListBox.CheckedItems)
            {
                string studentInfo = item.ToString();
                int studentId = int.Parse(studentInfo.Split(':')[0]);
                checkedStudents.Add(studentId);
            }

            // Create a string of checked student IDs separated by commas
            string checkedStudentIds = string.Join(",", checkedStudents);

            // Get the checked questions
            List<int> checkedQuestions = new List<int>();
            foreach (var item in questionsCheckedListBox.CheckedItems)
            {
                string questionInfo = item.ToString();
                int questionId = int.Parse(questionInfo.Split(':')[0]);
                checkedQuestions.Add(questionId);
            }

            // Create a string of checked question IDs separated by commas
            string checkedQuestionIds = string.Join(",", checkedQuestions);

            // Get the teacher ID from SuccsesfullLogin.id
            int teacherId = SuccsesfullLogin.id; // Replace with the actual teacher ID

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Insert a new exam into the exams table
                string insertExamQuery = "INSERT INTO exams (exam_name, teacher_id, eligible_student_ids, question_ids) VALUES (@examName, @teacherId, @eligibleStudentIds, @questionIds); SELECT SCOPE_IDENTITY();";
                using (SqlCommand insertExamCommand = new SqlCommand(insertExamQuery, connection))
                {
                    insertExamCommand.Parameters.AddWithValue("@examName", textBox1.Text); // Get the exam name from textBox1
                    insertExamCommand.Parameters.AddWithValue("@teacherId", teacherId);
                    insertExamCommand.Parameters.AddWithValue("@eligibleStudentIds", checkedStudentIds);
                    insertExamCommand.Parameters.AddWithValue("@questionIds", checkedQuestionIds);

                    // Get the newly inserted exam ID
                    int examId = Convert.ToInt32(insertExamCommand.ExecuteScalar());

                    if (examId > 0)
                    {
                        // Insert entries into the exam_results table
                        string insertResultsQuery = "INSERT INTO exam_results (exam_id, student_id) VALUES (@examId, @studentId)";
                        using (SqlCommand insertResultsCommand = new SqlCommand(insertResultsQuery, connection))
                        {
                            insertResultsCommand.Parameters.AddWithValue("@examId", examId);
                            foreach (int studentId in checkedStudents)
                            {
                                insertResultsCommand.Parameters.Clear();
                                insertResultsCommand.Parameters.AddWithValue("@examId", examId);
                                insertResultsCommand.Parameters.AddWithValue("@studentId", studentId);
                                insertResultsCommand.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Exam created successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to create the exam.");
                    }
                }
            }
        }

    }
}
