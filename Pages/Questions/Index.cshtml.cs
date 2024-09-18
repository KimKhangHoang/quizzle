using Microsoft.AspNetCore.Mvc.RazorPages;
using Quizzle.Models;
using Quizzle.Services;


namespace Quizzle.Pages.Questions
{
    public class IndexModel : PageModel
    {
        private readonly QuestionService _questionService;

        public IndexModel(QuestionService service)
        {
            _questionService = service;
        }

        public IEnumerable<Question> Questions { get; set; } = new List<Question>();

        public async Task OnGetAsync()
        {
            Questions = await _questionService.GetAllQuestionsAsync();
        }
    }
}
