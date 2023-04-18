using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicStore.Data;
using MusicStore.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace MusicStore.Pages.Music
{
    [BindProperties(SupportsGet = true)]
    public class AddRecordModel : PageModel
    {
        private readonly RecordDbContext context;

        public string ArtistName { get; set; }
        public string AlbumName { get; set; }
        public int Year { get; set; }

        public AddRecordModel(RecordDbContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                var record = new Record()
                {
                    ArtistName = ArtistName,
                    AlbumName = AlbumName,
                    Year = Year
                };

                await context.Records.AddAsync(record);
                await context.SaveChangesAsync();

                TempData["MessageDescription"] = "Album was added successfuly";

                return RedirectToPage("/music/record");
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
