using Microsoft.EntityFrameworkCore;
using MusicStore.Models;

namespace MusicStore.Data
{
    public class RecordDbContext:DbContext
    {

        public RecordDbContext(DbContextOptions<RecordDbContext> options): base(options)
        {

        }

        public DbSet<Record> Records { get; set; }

    }
}
