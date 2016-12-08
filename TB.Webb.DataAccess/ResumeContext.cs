using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TB.Webb.Models;

namespace TB.Webb.DataAccess
{
    public class ResumeContext : DbContext
    {
        public ResumeContext() : base("LocalContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Resume>()
                .HasMany(f => f.ResumeSections);

            modelBuilder.Entity<ResumeSection>()
                .HasMany(f => f.Entries);

            modelBuilder.Entity<ResumeEntry>()
                .HasMany(f => f.Tags)
                .WithMany(o => o.ResumeEntries);

            modelBuilder.Entity<ResumeTag>()
                .HasMany(f => f.ResumeEntries)
                .WithMany(o => o.Tags);

        }

        public DbSet<Resume> Resumes { get; set; }

        public DbSet<ResumeSection> ResumeSections { get; set; }

        public DbSet<ResumeEntry> ResumeEntries { get; set; }

        public DbSet<ResumeContactInfo> ResumeContactInfos { get; set; }

        public DbSet<ResumeTag> ResumeTags { get; set; }
    }
}
