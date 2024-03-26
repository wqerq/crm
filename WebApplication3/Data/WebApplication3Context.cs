using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Data
{
    public class WebApplication3Context : DbContext
    {
        public WebApplication3Context (DbContextOptions<WebApplication3Context> options)
            : base(options)
        {
        }

        public DbSet<WebApplication3.Models.Group> Group { get; set; } = default!;
        public DbSet<WebApplication3.Models.Lesson> Lesson { get; set; } = default!;
        public DbSet<WebApplication3.Models.Professor> Professor { get; set; } = default!;
        public DbSet<WebApplication3.Models.Room> Room { get; set; } = default!;
        public DbSet<WebApplication3.Models.Student> Student { get; set; } = default!;
        public DbSet<WebApplication3.Models.Subject> Subject { get; set; } = default!;
    }
}
