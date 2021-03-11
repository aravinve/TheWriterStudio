using Microsoft.EntityFrameworkCore;
using UtilityService.Models;

namespace UtilityService.Data
{
    public class UtilityDBContext : DbContext
    {
        public UtilityDBContext(DbContextOptions<UtilityDBContext> options): base(options)
        {

        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
