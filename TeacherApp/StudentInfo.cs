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
    public partial class StudentInfo : Form
    {
        string connectionString = "Data Source=localhost;Initial Catalog=ExamSystem;Integrated Security=True";

        public StudentInfo()
        {
            InitializeComponent();
        }

        private void StudentInfo_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT first_name, last_name FROM users WHERE id = @selectedStudentId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@selectedStudentId", SuccsesfullLogin.selectedStudent);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    string firstName = reader["first_name"].ToString();
                    string lastName = reader["last_name"].ToString();
                    reader.Close();
                    label1.Text = $"{firstName} {lastName} isimli öğrencinin bilgileri.";
                }
            }
            PopulateExams();
        }

        private void PopulateExams()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT id, exam_name FROM exams WHERE eligible_student_ids LIKE '%' + @selectedStudentId + '%'";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@selectedStudentId", SuccsesfullLogin.selectedStudent.ToString());
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            int examId = (int)reader["id"];
                            string examName = reader["exam_name"].ToString();
                            listBox1.Items.Add($"{examId}: {examName}");
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

        private void stdntExamInfoBtn_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                // ListBox'tan seçili sınavın ID'sini ve adını alın
                string selectedExam = listBox1.SelectedItem.ToString();
                int examId = Convert.ToInt32(selectedExam.Split(':')[0]);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Giriş yapmış kullanıcı için sınav ayrıntılarını ve öğretmen adını almak için sorgu
                    string query = @"SELECT exams.id, exams.teacher_id, exams.exam_name, exam_results.score, users.first_name, users.last_name
                             FROM exams
                             LEFT JOIN exam_results ON exams.id = exam_results.exam_id
                             LEFT JOIN users ON exams.teacher_id = users.id
                             WHERE exams.id = @examId AND exam_results.student_id = @userId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@examId", examId);
                        command.Parameters.AddWithValue("@userId", SuccsesfullLogin.selectedStudent);

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            int examIdResult = Convert.ToInt32(reader["id"]);
                            int teacherId = Convert.ToInt32(reader["teacher_id"]);
                            string examName = reader["exam_name"].ToString();
                            float? score = 0;
                            Boolean hasValue = false;
                            if (!reader.IsDBNull(reader.GetOrdinal("score")))
                            {
                                score = (float)reader.GetDouble(reader.GetOrdinal("score"));
                                hasValue = true;
                            }
                            string teacherFirstName = reader["first_name"].ToString();
                            string teacherLastName = reader["last_name"].ToString();

                            string message;
                            if (hasValue)
                            {
                                message = $"Sınav ID: {examIdResult}\nSınav Adı: {examName}\nÖğretmen: {teacherFirstName} {teacherLastName}\nPuan: {score}";
                            }
                            else
                            {
                                message = $"Sınav ID: {examIdResult}\nSınav Adı: {examName}\nÖğretmen: {teacherFirstName} {teacherLastName}\nPuan: Bu sınavı çözmülmemiş.";
                            }

                            MessageBox.Show(message);
                        }
                        else
                        {
                            MessageBox.Show("Seçilmiş kullanıcı için sınav ayrıntıları bulunamadı.");
                        }

                        reader.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Hiçbir sınav seçilmedi.");
            }
        }
    }
}
