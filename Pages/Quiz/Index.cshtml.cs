using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Quizzle.Models;
using Quizzle.Services;

namespace Quizzle.Pages.Quiz
{
    public class IndexModel : PageModel
    {
        private readonly QuestionService _questionService;

        public IndexModel(QuestionService questionService)
        {
            _questionService = questionService;
        }

        public IEnumerable<Question> Questions { get; set; } = new List<Question>();

        [BindProperty]
        public Dictionary<string, string> Answers { get; set; } = new Dictionary<string, string>();

        public async Task OnGetAsync()
        {
            Questions = await _questionService.GetAllQuestionsAsync(); // Get questions
            Questions = Questions.OrderBy(q => Guid.NewGuid()).ToList(); // Shuffle questions
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Get questions if not already loaded
            if (Questions == null || !Questions.Any())
            {
                Questions = await _questionService.GetAllQuestionsAsync();
            }

            int score = 0;

            // If no answers are selected, just skip scoring and return score of 0
            if (Answers == null || !Answers.Any())
            {
                TempData["Score"] = score;
                TempData["TotalQuestions"] = Questions.Count();
                return RedirectToPage("/Scores/Index");
            }

            // Process answers if they exist
            foreach (var question in Questions)
            {
                if (Answers.TryGetValue(question.Id.ToString(), out var selectedAnswer) && selectedAnswer == question.Answer)
                {
                    score++;
                }
            }

            TempData["Score"] = score;
            TempData["TotalQuestions"] = Questions.Count();
            return RedirectToPage("/Scores/Index");
        }
    }
}