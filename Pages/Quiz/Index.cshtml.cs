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
        public Dictionary<Guid, string> Answers { get; set; } = new Dictionary<Guid, string>();

        public async Task OnGetAsync()
        {
            Questions = await _questionService.GetAllQuestionsAsync(); // Get questions
            Questions = Questions.OrderBy(q => Guid.NewGuid()).ToList(); // Shuffle questions
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Questions == null || !Questions.Any())
            {
                Questions = await _questionService.GetAllQuestionsAsync(); // Get questions if not already loaded
            }

            int score = 0;
            foreach (var question in Questions)
            {
                if (Answers.ContainsKey(question.Id) && Answers[question.Id] == question.Answer)
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