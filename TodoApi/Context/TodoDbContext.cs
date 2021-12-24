using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Context
{
    public class TodoDbContext : DbContext
    {
       
        
        public TodoDbContext(DbContextOptions options) :base(options) { }
        public DbSet<Todo> Todos { get; set; }
         
    }
}


