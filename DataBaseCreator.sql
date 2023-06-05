CREATE TABLE users (
  id INT IDENTITY(1, 1) PRIMARY KEY,
  username VARCHAR(50) NOT NULL,
  password VARCHAR(255) NOT NULL,
  first_name VARCHAR(50) NOT NULL,
  last_name VARCHAR(50) NOT NULL,
  user_type INT NOT NULL
);

CREATE TABLE questions (
  id INT IDENTITY(1, 1) PRIMARY KEY,
  question_text VARCHAR(MAX) NOT NULL,
  option1 VARCHAR(MAX) NOT NULL,
  option2 VARCHAR(MAX) NOT NULL,
  option3 VARCHAR(MAX) NOT NULL,
  option4 VARCHAR(MAX) NOT NULL,
  correct_answer VARCHAR(MAX) NOT NULL
);

CREATE TABLE exams (
  id INT IDENTITY(1, 1) PRIMARY KEY,
  exam_name VARCHAR(50) NOT NULL,
  teacher_id INT NOT NULL,
  eligible_student_ids VARCHAR(MAX) NOT NULL,
  question_ids VARCHAR(MAX) NOT NULL,
  FOREIGN KEY (teacher_id) REFERENCES users(id)
);

CREATE TABLE exam_results (
  id INT IDENTITY(1, 1) PRIMARY KEY,
  exam_id INT NOT NULL,
  student_id INT NOT NULL,
  score FLOAT,
  FOREIGN KEY (exam_id) REFERENCES exams(id),
  FOREIGN KEY (student_id) REFERENCES users(id)
);

-- Insert data into the users table
INSERT INTO users (username, password, first_name, last_name, user_type)
VALUES
  ('johnDoe', 'password1', 'John', 'Doe', 1),
  ('janeSmith', 'password2', 'Jane', 'Smith', 0),
  ('alexGreen', 'password3', 'Alex', 'Green', 0),
  ('adminUser', 'password4', 'Admin', 'User', 2);

-- Insert data into the questions table
INSERT INTO questions (question_text, option1, option2, option3, option4, correct_answer)
VALUES
  ('What is the capital of France?', 'Paris', 'London', 'Madrid', 'Rome', 'Paris'),
  ('What is the largest planet in our solar system?', 'Jupiter', 'Saturn', 'Mars', 'Neptune', 'Jupiter'),
  ('Who painted the Mona Lisa?', 'Leonardo da Vinci', 'Pablo Picasso', 'Vincent van Gogh', 'Michelangelo', 'Leonardo da Vinci');

-- Insert data into the exams table
INSERT INTO exams (exam_name, teacher_id, eligible_student_ids, question_ids)
VALUES
  ('Pop-Culture-1-Midterm', 1, '3', '1,2'),
  ('Pop-Culture-2-Midterm', 1, '2,3', '2,3');

-- Insert data into the exam_results table
INSERT INTO exam_results (exam_id, student_id)
VALUES
  (1, 3),
  (2, 2),
  (2, 3);
