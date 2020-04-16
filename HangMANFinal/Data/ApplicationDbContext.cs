using System;
using System.Collections.Generic;
using System.Text;
using HangMANFinal.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HangMANFinal.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Uzivatel> uzivatele { get; set; }
        public DbSet<Slovo> slova { get; set; }
    }
}
