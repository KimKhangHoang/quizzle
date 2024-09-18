using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Quizzle.Models;
using Quizzle.Services;

namespace Quizzle.Pages.Questions
{
    public class EditModel : PageModel
    {
        private readonly QuestionService _questionService;

        public EditModel(QuestionService questionService)
        {
            _questionService = questionService;
        }

        [BindProperty]
        public Question Question { get; set; } = new Question();

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Question = await _questionService.GetQuestionByIdAsync(id.Value) ?? throw new InvalidOperationException("Question not found.");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _questionService.UpdateQuestionAsync(Question);

            return RedirectToPage("./Index");
        }
    }
}
