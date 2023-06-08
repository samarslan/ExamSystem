using System.Data.SqlClient;

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

                        // Check if the student's ID is in the eligible_students list
                        if (SelectedExam.eligible_students.Contains(studentId.ToString()))
                        {
                            int index = studentsCheckedListBox.Items.Count - 1;
                            studentsCheckedListBox.SetItemChecked(index, true);
                        }
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

            // Update the question_ids field of SelectedExam
            SelectedExam.questions = checkedQuestionIds;

            // Update the question_ids in the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string updateQuery = "UPDATE exams SET question_ids = @questionIds WHERE id = @examId";
                using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                {
                    updateCommand.Parameters.AddWithValue("@questionIds", checkedQuestionIds);
                    updateCommand.Parameters.AddWithValue("@examId", SelectedExam.id);

                    int rowsAffected = updateCommand.ExecuteNonQuery();
                }

                // Delete unchecked students' exam results
                string deleteQuery = "DELETE FROM exam_results WHERE exam_id = @examId AND student_id = @student_id";
                using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                {
                    foreach (var item in studentsCheckedListBox.Items)
                    {
                        string studentInfo = item.ToString();
                        int studentId = int.Parse(studentInfo.Split(':')[0]);

                        // Check if the student is checked
                        bool isChecked = studentsCheckedListBox.CheckedItems.Contains(item);
                        if (!isChecked)
                        {
                            deleteCommand.Parameters.Clear();
                            deleteCommand.Parameters.AddWithValue("@examId", SelectedExam.id);
                            deleteCommand.Parameters.AddWithValue("@student_id", studentId);
                            RemoveEligibleStudent(studentId);
                            deleteCommand.ExecuteNonQuery();
                        }
                    }
                }

                // Insert checked students' exam results
                string insertQuery = "INSERT INTO exam_results (exam_id, student_id) VALUES (@examId, @student_id)";
                using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                {
                    foreach (var item in studentsCheckedListBox.CheckedItems)
                    {
                        string studentInfo = item.ToString();
                        int studentId = int.Parse(studentInfo.Split(':')[0]);

                        // Check if the student is already present
                        bool isPresent = SelectedExam.eligible_students.Contains(studentId.ToString());
                        if (!isPresent)
                        {
                            insertCommand.Parameters.Clear();
                            insertCommand.Parameters.AddWithValue("@examId", SelectedExam.id);
                            insertCommand.Parameters.AddWithValue("@student_id", studentId);
                            AddEligibleStudent(studentId);
                            insertCommand.ExecuteNonQuery();
                        }
                    }
                }

                string updateEligibleStudentsQuery = "UPDATE exams SET eligible_student_ids = @eligible_students WHERE id = @examId";
                using (SqlCommand updateEligibleStudentsCommand = new SqlCommand(updateEligibleStudentsQuery, connection))
                {
                    updateEligibleStudentsCommand.Parameters.AddWithValue("@eligible_students", SelectedExam.eligible_students);
                    updateEligibleStudentsCommand.Parameters.AddWithValue("@examId", SelectedExam.id);
                    updateEligibleStudentsCommand.ExecuteNonQuery();
                }
            }
        }

        private void AddEligibleStudent(int id)
        {
            int[] eligibleStudents = SelectedExam.eligible_students.Split(',').Select(int.Parse).ToArray();
            List<int> eligibleStudentsList = eligibleStudents.ToList();
            eligibleStudentsList.Add(id);
            SelectedExam.eligible_students = string.Join(",", eligibleStudentsList);
        }
        private void RemoveEligibleStudent(int id)
        {
            int index = SelectedExam.eligible_students.IndexOf(id.ToString());
            int[] eligibleStudents = SelectedExam.eligible_students.Split(',').Select(int.Parse).ToArray();
            List<int> eligibleStudentsList = eligibleStudents.ToList();
            eligibleStudentsList.RemoveAt(index);
            SelectedExam.eligible_students = string.Join(",", eligibleStudentsList);
        }

        private void questionsCheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void studentsCheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
