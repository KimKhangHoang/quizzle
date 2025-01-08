using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Quizzle.Pages.Scores
{
    public class IndexModel : PageModel
    {
        public int Score { get; set; }
        public int TotalQuestions { get; set; }

        public void OnGet()
        {
            if (TempData.ContainsKey("Score"))
            {
                Score = TempData["Score"] as int? ?? 0;
                TotalQuestions = TempData["TotalQuestions"] as int? ?? 0;
            }
        }
    }
}