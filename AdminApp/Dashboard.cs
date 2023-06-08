using System.Data.SqlClient;

namespace AdminApp
{
    public partial class Dashboard : Form
    {
        string connectionString = "Data Source=localhost;Initial Catalog=ExamSystem;Integrated Security=True";
        int selectedUserType;

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

                            string userTypeString = GetUserTypeString(userType);

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

        private void userCreateBtn_Click(object sender, EventArgs e)
        {
            UserCreate userCreateForm = new UserCreate();
            userCreateForm.ShowDialog();
            PopulateUsers();
        }

        private void userDeleteBtn_Click(object sender, EventArgs e)
        {
            // Check if a user is selected in the userListBox
            if (userListBox.SelectedIndex != -1)
            {
                // Get the selected user's ID
                string selectedUser = userListBox.SelectedItem.ToString();
                int userId = int.Parse(selectedUser.Split(':')[0].Trim());

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT user_type FROM users WHERE id = @userId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userId", userId);

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            selectedUserType = (int)reader["user_type"];
                        }
                        reader.Close();
                    }
                }

                if (selectedUserType == 2 && userId != SuccsesfullLogin.id)
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string deleteQuery = "DELETE FROM users WHERE id = @userId";
                            using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                            {
                                deleteCommand.Parameters.AddWithValue("@userId", userId);

                                int rowsAffected = deleteCommand.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("User deleted successfully.");
                                    PopulateUsers();
                                }
                                else
                                {
                                    MessageBox.Show("Failed to delete user.");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while accessing the database: " + ex.Message);
                    }
                }
                else if (selectedUserType == 1)
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string userDeleteQuery = "DELETE FROM users WHERE id = @userId";

                            using (SqlCommand deleteCommand = new SqlCommand(userDeleteQuery, connection))
                            {
                                deleteCommand.Parameters.AddWithValue("@userId", userId);

                                int rowsAffected = deleteCommand.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("User deleted successfully.");
                                    PopulateUsers();
                                }
                                else
                                {
                                    MessageBox.Show("Failed to delete user.");
                                }
                            }

                            List<int> examIds = new List<int>();
                            string examIdQuery = "SELECT id FROM exams WHERE teacher_id = @userId";

                            using (SqlCommand command = new SqlCommand(examIdQuery, connection))
                            {
                                command.Parameters.AddWithValue("@userId", userId);

                                SqlDataReader reader = command.ExecuteReader();
                                while (reader.Read())
                                {
                                    int examId = (int)reader["id"];
                                    examIds.Add(examId);
                                }
                                reader.Close();
                            }

                            string examDeleteQuery = "DELETE FROM exams WHERE teacher_id = @userId";

                            using (SqlCommand command = new SqlCommand(examDeleteQuery, connection))
                            {
                                command.Parameters.AddWithValue("@userId", userId);

                                int rowsAffected = command.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("User deleted successfully.");
                                    PopulateUsers();
                                }
                                else
                                {
                                    MessageBox.Show("Failed to delete user.");
                                }
                            }

                            string examResultDeleteQuery = "DELETE FROM exam_results WHERE exam_id = @examId";

                            using (SqlCommand command = new SqlCommand(examResultDeleteQuery, connection))
                            {
                                foreach (int examId in examIds)
                                {
                                    command.Parameters.AddWithValue("@examId", examId);

                                    int rowsAffected = command.ExecuteNonQuery();
                                    if (rowsAffected > 0)
                                    {
                                        MessageBox.Show("User deleted successfully.");
                                        PopulateUsers();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Failed to delete user.");
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while accessing the database: " + ex.Message);
                    }
                }
                else if (selectedUserType == 0)
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            List<int> examIds = new List<int>();

                            string examIdsQuerry = "SELECT DISTINCT exam_id FROM exam_results WHERE student_id = @userId";

                            using (SqlCommand command = new SqlCommand(examIdsQuerry, connection))
                            {
                                command.Parameters.AddWithValue("@userId", userId);

                                SqlDataReader reader = command.ExecuteReader();


                                while (reader.Read())
                                {
                                    int examId = (int)reader["exam_id"];
                                    examIds.Add(examId);
                                }

                                reader.Close();
                            }


                            foreach (int examId in examIds)
                            {
                                string getEligibleStudentsIds = "SELECT eligible_student_ids from exams Where id=@examid";

                                using (SqlCommand command = new SqlCommand(getEligibleStudentsIds, connection))
                                {
                                    command.Parameters.AddWithValue("@examid", examId);

                                    SqlDataReader reader = command.ExecuteReader();

                                    string eligibleStudentIds = "";
                                    if (reader.Read())
                                    {
                                        eligibleStudentIds = (string)reader["eligible_student_ids"];
                                    }

                                    reader.Close();

                                    string[] eligibleStudentIdsArray = eligibleStudentIds.Split(',');

                                    string newEligibleStudentIds = "";

                                    foreach (string eligibleStudentId in eligibleStudentIdsArray)
                                    {
                                        if (eligibleStudentId != userId.ToString())
                                        {
                                            newEligibleStudentIds += eligibleStudentId + ",";
                                        }
                                    }

                                    newEligibleStudentIds = newEligibleStudentIds.TrimEnd(',');

                                    string updateEligibleStudentIdsQuery = "UPDATE exams SET eligible_student_ids = @eligibleStudentIds WHERE id = @examId";

                                    using (SqlCommand updateCommand = new SqlCommand(updateEligibleStudentIdsQuery, connection))
                                    {
                                        updateCommand.Parameters.AddWithValue("@eligibleStudentIds", newEligibleStudentIds);
                                        updateCommand.Parameters.AddWithValue("@examId", examId);

                                        int rowsAffected = updateCommand.ExecuteNonQuery();

                                        if (rowsAffected > 0)
                                        {
                                            MessageBox.Show("Student ID deleted from eligible_student_ids successfully.");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Failed to delete student ID from eligible_student_ids.");
                                        }
                                    }
                                }
                            }


                            string deleteExamResultsQuery = "DELETE FROM exam_results WHERE student_id = @userId";

                            using (SqlCommand command = new SqlCommand(deleteExamResultsQuery, connection))
                            {
                                command.Parameters.AddWithValue("@userId", userId);

                                int rowsAffected = command.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Öğrencinin Sınavları Silindi.");
                                }
                                else
                                {
                                    MessageBox.Show("Öğrencinin Sınavları Silinemedi.");
                                }
                            }


                            string deleteQuery = "DELETE FROM users WHERE id = @userId";
                            using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                            {
                                deleteCommand.Parameters.AddWithValue("@userId", userId);

                                int rowsAffected = deleteCommand.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("User deleted successfully.");
                                    PopulateUsers();
                                }
                                else
                                {
                                    MessageBox.Show("Failed to delete user.");
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
            else
            {
                MessageBox.Show("Please select a user to delete.");
            }
        }

    }
}
