using Microsoft.EntityFrameworkCore;
using Quizzle.Models;
using Quizzle.Data;
using System.Runtime.InteropServices;

namespace Quizzle.Services

{
    public class QuestionService
    {
        private readonly QuizzleContext _context;

        public QuestionService(QuizzleContext context)
        {
            _context = context;
        }

        // Get all questions asynchronously
        public async Task<IEnumerable<Question>> GetAllQuestionsAsync()
        {
            return await _context.Questions.ToListAsync();
        }

        // Get question by ID asynchronously
        public async Task<Question?> GetQuestionByIdAsync(Guid id)
        {
            return await _context.Questions.FindAsync(id);
        }

        // Add question asynchronously
        public async Task AddQuestionAsync(Question question)
        {
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();
        }

        // Update question asynchronously
        public async Task UpdateQuestionAsync(Question question)
        {
            var existingQuestion = await _context.Questions.FindAsync(question.Id);
            if (existingQuestion != null)
            {
                existingQuestion.QuestionText = question.QuestionText;
                existingQuestion.OptionA = question.OptionA;
                existingQuestion.OptionB = question.OptionB;
                existingQuestion.OptionC = question.OptionC;
                existingQuestion.OptionD = question.OptionD;
                existingQuestion.Answer = question.Answer;

                await _context.SaveChangesAsync();
            }
        }

        // Delete question asynchronously
        public async Task DeleteQuestionAsync(Question question)
        {
            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
        }
    }
}
