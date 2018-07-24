using ChalangeYourself.Data.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChalangeYourself.Services.Database
{
    public class ChalangeDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Chalange> Chalanges { get; set; }
        public DbSet<ChalangePrice> ChalangePrices { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<ProposalChalange> ProposalChalanges { get; set; }
        public DbSet<UserChalangeHistory> UserChalangeHistories { get; set; }
        //public DbSet<ApplicationUser> Users { get; set; }

        public ChalangeDbContext()
            : base("ChalangeYourselfConStr", throwIfV1Schema: false)
        {
        }
        //public ChalangeDbContext()
        //    : base("DefaultConnection", throwIfV1Schema: false)
        //{
        //}

        public static ChalangeDbContext Create()
        {
            return new ChalangeDbContext();
        }
    }
}
