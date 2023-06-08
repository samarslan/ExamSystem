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
    public partial class UserCreate : Form
    {
        string connectionString = "Data Source=localhost;Initial Catalog=ExamSystem;Integrated Security=True";

        public UserCreate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string firstName = fNameTextBox.Text;
            string lastName = lNameTextBox.Text;
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            int userType = userTypeComboBox.SelectedIndex;

            if (firstName == "" || lastName == "" || username == "" || password == "" || userType == -1)
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
                return;
            }
            else
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string insertQuery = "INSERT INTO users (first_name, last_name, username, password, user_type) VALUES (@firstName, @lastName, @username, @password, @userType)";
                        using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                        {
                            insertCommand.Parameters.AddWithValue("@firstName", firstName);
                            insertCommand.Parameters.AddWithValue("@lastName", lastName);
                            insertCommand.Parameters.AddWithValue("@username", username);
                            insertCommand.Parameters.AddWithValue("@password", password);
                            insertCommand.Parameters.AddWithValue("@userType", userType);

                            int rowsAffected = insertCommand.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("New user inserted successfully.");
                            }
                            else
                            {
                                MessageBox.Show("Failed to insert new user.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while accessing the database: " + ex.Message);
                }
            }
        }
    }
}
