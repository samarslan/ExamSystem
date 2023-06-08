using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeacherApp
{
    public partial class Dashboard : Form
    {
        string connectionString = "Data Source=localhost;Initial Catalog=ExamSystem;Integrated Security=True";
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            PopulateExams();
            PopulateStudents();
        }

        private void PopulateExams()
        {
            examsListBox.Items.Clear();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT id, exam_name FROM exams where teacher_id = @teacherID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@teacherID", SuccsesfullLogin.id);
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            int examId = (int)reader["id"];
                            string examName = reader["exam_name"].ToString();
                            examsListBox.Items.Add($"{examId}: {examName}");
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanına bağlanırken bir hata oluştu: " + ex.Message);
            }
        }

        private void PopulateStudents()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT id, first_name, last_name FROM users where user_type = 0";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            int studentId = (int)reader["id"];
                            string firstName = reader["first_name"].ToString();
                            string lastName = reader["last_name"].ToString();
                            studentsListBox.Items.Add($"{studentId}: {firstName} {lastName}");
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanına bağlanırken bir hata oluştu: " + ex.Message);
            }
        }

        private void examInfoBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "Select id, exam_name, teacher_id, eligible_student_ids, question_ids from exams Where id=@examid";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@examid", int.Parse(examsListBox.SelectedItem.ToString().Split(':')[0]));
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            SelectedExam.id = (int)reader["id"];
                            SelectedExam.exam_name = reader["exam_name"].ToString();
                            SelectedExam.teacher_id = (int)reader["teacher_id"];
                            SelectedExam.eligible_students = reader["eligible_student_ids"].ToString();
                            SelectedExam.questions = reader["question_ids"].ToString();
                            SelectedExam.number_of_questions = SelectedExam.questions.Split(',').Length;
                            SelectedExam.number_of_students = SelectedExam.eligible_students.Split(',').Length;
                        }
                        reader.Close();
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanına bağlanırken bir hata oluştu: " + ex.Message);
            }

            string message = $"Sınav id: {SelectedExam.id}\nSınav adı: {SelectedExam.exam_name}\nSoru sayısı: {SelectedExam.number_of_questions}\nSoru idleri: {SelectedExam.questions}\nÖğrenci sayısı: {SelectedExam.number_of_students}\nÖğrenci idleri: {SelectedExam.eligible_students}";
            MessageBox.Show(message);

        }

        private void stdntInfoBtn_Click(object sender, EventArgs e)
        {
            if (studentsListBox.SelectedItem != null)
            {
                SuccsesfullLogin.selectedStudent = int.Parse(studentsListBox.SelectedItem.ToString().Split(':')[0]);

                this.Hide();

                StudentInfo studentInfo = new StudentInfo();
                studentInfo.Show();
            }
            else
            {
                MessageBox.Show("Lütfen bir öğrenci seçiniz");
            }
        }

        private void editExamBtn_Click(object sender, EventArgs e)
        {
            if (examsListBox.SelectedItem!=null)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "Select id, exam_name, teacher_id, eligible_student_ids, question_ids from exams Where id=@examid";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@examid", int.Parse(examsListBox.SelectedItem.ToString().Split(':')[0]));
                            SqlDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                SelectedExam.id = (int)reader["id"];
                                SelectedExam.exam_name = reader["exam_name"].ToString();
                                SelectedExam.teacher_id = (int)reader["teacher_id"];
                                SelectedExam.eligible_students = reader["eligible_student_ids"].ToString();
                                SelectedExam.questions = reader["question_ids"].ToString();
                                SelectedExam.number_of_questions = SelectedExam.questions.Split(',').Length;
                                SelectedExam.number_of_students = SelectedExam.eligible_students.Split(',').Length;
                            }
                            reader.Close();
                        }

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanına bağlanırken bir hata oluştu: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir sınav seçiniz");
            }
            this.Hide();

            EditExam editExam = new EditExam();
            editExam.ShowDialog();
            PopulateExams();
        }

        private void createExamBtn_Click(object sender, EventArgs e)
        {
            CreateExam createExam = new CreateExam();
            createExam.ShowDialog();
            PopulateExams();
        }
    }
}
