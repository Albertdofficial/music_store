using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MusicStore.Data;
using MusicStore.Models;

namespace MusicStore.Pages.Music
{
    public class UpdateModel : PageModel
    {
        private readonly RecordDbContext context;

        [BindProperty]
        public Record Record { get; set; }
        public UpdateModel(RecordDbContext context)
        {
            this.context = context;
        }

        public async Task OnGet(Guid id)
        {
            // could return  blog or null
            Record = await context.Records.FindAsync(id);
        }

        public async Task<IActionResult> OnPostEdit()
        {
            var existingRecord = await context.Records.FindAsync(Record.Id);

            if (existingRecord != null)
            {
                existingRecord.ArtistName = Record.ArtistName;
                existingRecord.AlbumName = Record.AlbumName;
                existingRecord.Year = Record.Year;

               

            }
            await context.SaveChangesAsync();

            TempData["MessageDescription"] = "Record was Edited successfuly";

            return RedirectToPage("/music/record");

        }

        public async Task<IActionResult> OnPostDelete()
        {
            var existingBook = await context.Records.FindAsync(Record.Id);

            if (existingBook != null)
            {
                context.Records.Remove(existingBook);
                await context.SaveChangesAsync();

                TempData["MessageDescription"] = "Record was deleted successfuly";

            }
            return RedirectToPage("/music/record");

        }

    }
}
