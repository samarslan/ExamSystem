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
    }
}
