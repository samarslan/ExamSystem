﻿using System;
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
    public partial class ExamPanel : Form
    {
        int selectedExamId = SuccsesfullLogin.selectedExam;
        string connectionString = "Data Source=localhost;Initial Catalog=ExamSystem;Integrated Security=True";
        public ExamPanel()
        {
            InitializeComponent();
        }

        private void ExamPanel_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT e.id, e.exam_name, e.teacher_id, e.question_ids
                        FROM exams e
                        WHERE e.id = @selectedExam
                          AND e.id IN (
                            SELECT exam_id
                            FROM exam_results
                            WHERE student_id = @studentId
                          )";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@selectedExam", SuccsesfullLogin.selectedExam);
                    command.Parameters.AddWithValue("@studentId", SuccsesfullLogin.id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Exam.id = reader.GetInt32(0);
                            Exam.exam_name = reader.GetString(1);
                            Exam.teacher_id = reader.GetInt32(2);
                            Exam.question_ids = reader.GetString(3);

                            // Populate the List<Question> field
                            Exam.questions = LoadQuestions(Exam.question_ids);
                        }
                    }
                }
            }
        }

        private List<Question> LoadQuestions(string questionIds)
        {
            List<Question> questions = new List<Question>();

            string[] ids = questionIds.Split(',');

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT id, question_text, option1, option2, option3, option4, correct_answer " +
                               "FROM questions " +
                               "WHERE id IN ({0})";

                string parameterPlaceholder = string.Join(",", ids.Select((id, index) => $"@questionId{index}"));
                query = string.Format(query, parameterPlaceholder);

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    for (int i = 0; i < ids.Length; i++)
                    {
                        command.Parameters.AddWithValue($"@questionId{i}", ids[i]);
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Question question = new Question();
                            question.id = reader.GetInt32(0);
                            question.question_text = reader.GetString(1);
                            question.option1 = reader.GetString(2);
                            question.option2 = reader.GetString(3);
                            question.option3 = reader.GetString(4);
                            question.option4 = reader.GetString(5);
                            question.correct_answer = reader.GetString(6);

                            questions.Add(question);
                        }
                    }
                }
            }

            return questions;
        }

        private void btnPreviousQuestion_Click(object sender, EventArgs e)
        {

        }

        private void btnNextQuestion_Click(object sender, EventArgs e)
        {

        }

        private void btnEndExam_Click(object sender, EventArgs e)
        {

        }
    }
}
