using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MusicStore.Data;
using MusicStore.Models;

namespace MusicStore.Pages.Music
{
    public class RecordModel : PageModel
    {
        private readonly RecordDbContext context;

        public List<Record> Records { get; set; }

        public RecordModel(RecordDbContext context)
        {
            this.context = context;
        }


        public async Task OnGet()
        {
            Records = await context.Records.ToListAsync();

            // check for any notification coming from another page
            var messageDescription = (string)TempData["MessageDescription"];

            if (!string.IsNullOrWhiteSpace(messageDescription))
            {
                ViewData["MessageDescription"] = messageDescription;
            }

        }
    }
}
