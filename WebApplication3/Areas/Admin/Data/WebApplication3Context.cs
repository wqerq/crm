using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Admin.Data
{
    public class WebApplication3Context2: DbContext
    {
        public WebApplication3Context2 (DbContextOptions<WebApplication3Context2> options)
            : base(options)
        {
        }

        public DbSet<WebApplication3.Admin.Models.Group> Group { get; set; } = default!;
        public DbSet<WebApplication3.Admin.Models.Lesson> Lesson { get; set; } = default!;
        public DbSet<WebApplication3.Admin.Models.Professor> Professor { get; set; } = default!;
        public DbSet<WebApplication3.Admin.Models.Room> Room { get; set; } = default!;
        public DbSet<WebApplication3.Admin.Models.Student> Student { get; set; } = default!;
        public DbSet<WebApplication3.Admin.Models.Subject> Subject { get; set; } = default!;
    }
}
