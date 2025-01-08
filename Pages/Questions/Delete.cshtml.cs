using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Quizzle.Models;
using Quizzle.Services;

namespace Quizzle.Pages.Questions
{
    public class DeleteModel : PageModel
    {
        private readonly QuestionService _questionService;

        public DeleteModel(QuestionService service)
        {
            _questionService = service;
        }

        [BindProperty]
        public Question? Question { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            Question = await _questionService.GetQuestionByIdAsync(id);

            if (Question == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Question == null || Question.Id == Guid.Empty)
            {
                return NotFound();
            }

            await _questionService.DeleteQuestionAsync(Question);

            return RedirectToPage("./Index");
        }
    }
}
