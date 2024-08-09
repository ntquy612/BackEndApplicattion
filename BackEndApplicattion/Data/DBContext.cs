using BackEndApplicattion.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEndApplicattion.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
