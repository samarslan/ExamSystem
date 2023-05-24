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
    public partial class Dashboard : Form
    {
        string connectionString = "Data Source=localhost;Initial Catalog=ExamSystem;Integrated Security=True";

        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            label1.Text = $"{SuccsesfullLogin.firstName} {SuccsesfullLogin.lastName}, Sınav Sistemine Hoşgeldin";

            PopulateExams();
        }

        private void PopulateExams()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT id, exam_name FROM exams";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
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

        private void button2_Click(object sender, EventArgs e)
        {
            // ListBox'ta seçili bir sınavın olup olmadığını kontrol edin
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
                        command.Parameters.AddWithValue("@userId", SuccsesfullLogin.id);

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            int examIdResult = Convert.ToInt32(reader["id"]);
                            int teacherId = Convert.ToInt32(reader["teacher_id"]);
                            string examName = reader["exam_name"].ToString();
                            float? score = reader["score"] as float?;
                            string teacherFirstName = reader["first_name"].ToString();
                            string teacherLastName = reader["last_name"].ToString();

                            string message;
                            if (score.HasValue)
                            {
                                message = $"Sınav ID: {examIdResult}\nSınav Adı: {examName}\nÖğretmen: {teacherFirstName} {teacherLastName}\nPuan: {score}";
                            }
                            else
                            {
                                message = $"Sınav ID: {examIdResult}\nSınav Adı: {examName}\nÖğretmen: {teacherFirstName} {teacherLastName}\nPuan: Bu sınavı çözmüş değilsiniz.";
                            }

                            MessageBox.Show(message);
                        }
                        else
                        {
                            MessageBox.Show("Giriş yapmış kullanıcı için sınav ayrıntıları bulunamadı.");
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
