# Quizzle Application

This is a basic online quiz application built with C# and ASP.NET Core. The application allows users to create, edit, and take quizzes, as well as view their scores after completing the quiz.

## Functional Requirements

### 1. **Question Management**
- **Create Questions**: Users can create multiple choice questions with one answer.
- **Edit Questions**: Users can edit existing questions and modify the answers.
- **List Questions**: A list of all available questions can be displayed for users to attempt in the quiz.

### 2. **Quiz Functionality**
- **Taking a Quiz**: Users can select and start a quiz that will present a series of questions.
- **Answer Submission**: Users submit answers to each question in the quiz.
- **Score Calculation**: The system will automatically calculate the user's score based on the number of correct answers.
- **Score Display**: After completing the quiz, users will be shown their score.

### 3. **Front-End Pages**
- **Homepage**: Provides an overview of the application and basic navigation options.
- **Question Management Page**: Users can access this page to create and edit quiz questions.
- **Quiz Page**: Where users take the quiz, answering questions one by one within the time provided.
- **Score Page**: Displays the user's score after they finish taking the quiz.

## Non-Functional Requirements

- **Usability**: The application should be user-friendly, with a clean and easy-to-navigate interface.
- **Performance**: The quiz process should run smoothly without significant delays or errors.
- **Security**: Basic security measures for data handling, including using `.env` for sensitive data like database connection strings.

## Technologies Used

- **Programming Language**: C# with ASP.NET Core, JavaScript
- **Front-End**: Razor Pages
- **Back-End**: Entity Framework Core
- **Database Provider**: SQL Server
- **Source Control**: Git

## How to run

1. Clone the repository to your local machine.
2. Set up your development environment with the required .NET Core SDK.
3. Set up the database (SQL Server, MySQL, SQLite, etc.) and configure the connection string in the `.env` file.
4. Run the application locally using Visual Studio or the .NET Core CLI.