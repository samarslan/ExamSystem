using System.Data.SqlClient;

namespace ExamApp
{
    public partial class Form1 : Form
    {
        string connectionString = "Data Source=localhost;Initial Catalog=ExamSystem;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT id, first_name, last_name, user_type FROM users WHERE username = @username AND password = @password";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            int userType = Convert.ToInt32(reader["user_type"]);
                            if (userType == 0)
                            {
                                string firstName = reader["first_name"].ToString();
                                string lastName = reader["last_name"].ToString();
                                SuccessfulLogin.id = Convert.ToInt32(reader["id"].ToString());
                                SuccessfulLogin.username = username;
                                SuccessfulLogin.password = password;
                                SuccessfulLogin.firstName = reader["first_name"].ToString();
                                SuccessfulLogin.lastName = reader["last_name"].ToString();
                                Dashboard dashboard = new Dashboard();
                                dashboard.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Bu sistem yaln�zca ��renciler i�in kullan�labilir.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ge�ersiz �ifre.");
                        }

                        reader.Close();
                    }
                }
            }
        }
    }
}
