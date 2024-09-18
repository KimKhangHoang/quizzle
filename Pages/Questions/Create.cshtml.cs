using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Quizzle.Services;
using Quizzle.Models;

namespace Quizzle.Pages.Questions
{
    public class CreateModel : PageModel
    {
        private readonly QuestionService _questionService;

        public CreateModel(QuestionService service)
        {
            _questionService = service;
        }

        [BindProperty]
        public Question Question { get; set; } = new Question();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _questionService.AddQuestionAsync(Question);

            return RedirectToPage("./Index");
        }
    }
}
