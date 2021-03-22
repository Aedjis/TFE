using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tour0Suisse.Model;

namespace Tour0Suisse.Web.Data
{
    public class APIcontext : DbContext
    {
       

        public APIcontext(DbContextOptions<APIcontext> options)
            : base(options)
        {
        }
        public DbSet<Utilisateur> Utilisateur { get; set; }
        public DbSet<Tournoi> Tournoi { get; set; }
        public DbSet<Jeu> Jeu { get; set; }
    }
}
