using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UsineAPI.Models;

namespace UsineAPI.Data
{
    public class UsineAPIContext : DbContext
    {
        public UsineAPIContext (DbContextOptions<UsineAPIContext> options)
            : base(options)
        {
        }

        public DbSet<UsineAPI.Models.ChefEquipe> ChefEquipe { get; set; }

        public DbSet<UsineAPI.Models.Employe> Employe { get; set; }

        public DbSet<UsineAPI.Models.Role> Role { get; set; }

        public DbSet<UsineAPI.Models.SuperUser> SuperUser { get; set; }
    }
}
