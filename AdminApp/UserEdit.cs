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
    public partial class UserEdit : Form
    {
        string connectionString = "Data Source=localhost;Initial Catalog=ExamSystem;Integrated Security=True";

        public UserEdit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string firstName = fNameTextBox.Text;
            string lastName = lNameTextBox.Text;
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            if(firstName != null && lastName != null && username != null && password != null)
            {
                using(SqlConnection connection=new SqlConnection(connectionString))
                {
                    connection.Open();

                    string updateQuery = "UPDATE users SET first_name=@firstName, last_name=@lastName, username=@username, password=@password WHERE id=@id";
                    using(SqlCommand updateCommand=new SqlCommand(updateQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@firstName", firstName);
                        updateCommand.Parameters.AddWithValue("@lastName", lastName);
                        updateCommand.Parameters.AddWithValue("@username", username);
                        updateCommand.Parameters.AddWithValue("@password", password);
                        updateCommand.Parameters.AddWithValue("@id", SuccsesfullLogin.selectedUserId);

                        int rowsAffected = updateCommand.ExecuteNonQuery();
                        if(rowsAffected > 0)
                        {
                            MessageBox.Show("Kullanıcı başarıyla güncellendi.");
                        }
                        else
                        {
                            MessageBox.Show("Hata.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
            }
        }

        private void UserEdit_Load(object sender, EventArgs e)
        {
            using(SqlConnection connection=new SqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT * FROM users WHERE id=@id";
                using(SqlCommand selectCommand=new SqlCommand(selectQuery, connection))
                {
                    selectCommand.Parameters.AddWithValue("@id", SuccsesfullLogin.selectedUserId);

                    using(SqlDataReader reader=selectCommand.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            fNameTextBox.Text = reader["first_name"].ToString();
                            lNameTextBox.Text = reader["last_name"].ToString();
                            usernameTextBox.Text = reader["username"].ToString();
                            passwordTextBox.Text = reader["password"].ToString();
                        }
                    }
                }
            }
        }
    }
}
