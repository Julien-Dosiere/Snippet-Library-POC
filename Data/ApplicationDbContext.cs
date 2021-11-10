using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_App.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_App.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<DataUser> DataUsers { get; set; }
        public DbSet<Tag> Tags{ get; set; }
        public DbSet<Snippet> Snippets{ get; set; }

    }
}
