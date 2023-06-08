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

namespace AdminApp
{
    public partial class Dashboard : Form
    {
        string connectionString = "Data Source=localhost;Initial Catalog=ExamSystem;Integrated Security=True";

        public Dashboard()
        {
            InitializeComponent();
        }

        private void PopulateUsers()
        {
            userListBox.Items.Clear();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT id, first_name, last_name, user_type FROM users";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            int studentId = (int)reader["id"];
                            string firstName = reader["first_name"].ToString();
                            string lastName = reader["last_name"].ToString();
                            int userType = (int)reader["user_type"];

                            string userTypeString= GetUserTypeString(userType);

                            userListBox.Items.Add($"{studentId}: {firstName} {lastName}: {userTypeString}");
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

        private void userInfoBtn_Click(object sender, EventArgs e)
        {
            if (userListBox.SelectedIndex != -1)
            {
                // Get the selected user's ID
                string selectedUser = userListBox.SelectedItem.ToString();
                int userId = int.Parse(selectedUser.Split(':')[0].Trim());

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = "SELECT username, password, first_name, last_name, user_type FROM users WHERE id = @userId";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@userId", userId);

                            SqlDataReader reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                string username = reader["username"].ToString();
                                string password = reader["password"].ToString();
                                string firstName = reader["first_name"].ToString();
                                string lastName = reader["last_name"].ToString();
                                int userType = (int)reader["user_type"];

                                string userTypeString = GetUserTypeString(userType);

                                string userInfo = $"Username: {username}\nPassword: {password}\nFirst Name: {firstName}\nLast Name: {lastName}\nUser Type: {userTypeString}";

                                MessageBox.Show(userInfo, "User Information");
                            }
                            reader.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while accessing the database: " + ex.Message);
                }
            }
        }

        private string GetUserTypeString(int userType)
        {
            switch (userType)
            {
                case 0:
                    return "Öğrenci";
                case 1:
                    return "Öğretmen";
                case 2:
                    return "Yönetici";
                default:
                    return "Unknown";
            }
        }


        private void Dashboard_Load(object sender, EventArgs e)
        {
            PopulateUsers();
        }
    }
}
