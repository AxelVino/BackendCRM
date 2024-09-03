using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructrure.Persistence
{
    public class CrmDbContext: DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Domain.Entities.TaskStatus> TaskStatus { get; set; }
        public DbSet<CampaignTypes> CampaignTypes { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<InteractionTypes> InteractionTypes { get; set; }
        public DbSet<Interactions> Interactions { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Projects> Projects { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");
                entity.HasKey(e => e.UserID);
                entity.Property(t => t.UserID).ValueGeneratedOnAdd();
                entity.Property(c => c.Name).HasMaxLength(255).IsRequired();
                entity.Property(z => z.Email).HasMaxLength(255).IsRequired();
                entity.HasMany<Tasks>(k => k.Tasks)
                .WithOne(ad => ad.Users)
                .HasForeignKey(p => p.AssignedTo);
            });
            modelBuilder.Entity<Domain.Entities.TaskStatus>(entity =>
            {
            entity.ToTable("TaskStatus");
            entity.HasKey(e => e.Id);
            entity.Property(t => t.Id).ValueGeneratedOnAdd();
            entity.Property(c => c.Name).HasMaxLength(25).IsRequired();
                entity.HasMany<Tasks>(z => z.Tasks)
                .WithOne(s => s.TaskStatus)
                .HasForeignKey(d => d.Status);
            });
            modelBuilder.Entity<CampaignTypes>(entity =>
            {
                entity.ToTable("CampaignTypes");
                entity.HasKey(e => e.Id);
                entity.Property(t => t.Id).ValueGeneratedOnAdd();
                entity.Property(c => c.Name).HasMaxLength(25).IsRequired();
                entity.HasMany<Projects>(h => h.Projects)
                .WithOne(j => j.CampaignType)
                .HasForeignKey(s => s.Id);
            });
            modelBuilder.Entity<InteractionTypes>(entity =>
            {
                entity.ToTable("InteractionTypes");
                entity.HasKey(e => e.Id);
                entity.Property(t => t.Id).ValueGeneratedOnAdd();
                entity.Property(k =>  k.Name).HasMaxLength(25).IsRequired();
                entity.HasMany<Interactions>(h => h.Interactions)
                .WithOne(v => v.InteractionTypes)
                .HasForeignKey(s => s.Id);
            });
            modelBuilder.Entity<Clients>(entity =>
            {
                entity.ToTable("Clients");
                entity.HasKey(c => c.ClientID);
                entity.Property(a => a.ClientID).ValueGeneratedOnAdd();
                entity.Property(r => r.Name).HasMaxLength(255).IsRequired();
                entity.Property(l => l.Email).HasMaxLength(255).IsRequired();
                entity.Property(i => i.Phone).HasMaxLength(255).IsRequired();
                entity.Property(s => s.Company).HasMaxLength(100).IsRequired();
                entity.Property(p => p.Adress).IsRequired();
                entity.Property(u => u.CreateDate).IsRequired();
                entity.HasMany<Projects>(t => t.Projects)
                .WithOne(o => o.Clients)
                .HasForeignKey(s => s.ClientID);
            });
            modelBuilder.Entity<Interactions>(entity =>
            {
                entity.ToTable("Interactions");
                entity.HasKey(e => e.InteractionID);
                entity.Property(t => t.InteractionID).ValueGeneratedOnAdd();
                entity.Property(d => d.Date).IsRequired();
                entity.Property(n => n.Notes).IsRequired();
            });
            modelBuilder.Entity<Projects>(entity =>
            {
                entity.ToTable("Projects");
                entity.HasKey(e => e.ProyectID);
                entity.Property(t => t.ProyectID).ValueGeneratedOnAdd();
                entity.Property(p => p.ProjectName).HasMaxLength(255).IsRequired();
                entity.Property(s => s.StartDate).IsRequired();
                entity.Property(c => c.EndDate).IsRequired();
                entity.Property(x => x.CreateDate).IsRequired();
                entity.Property(j => j.UpdateDate).IsRequired();
                entity.HasMany<Tasks>(z => z.Tasks)
                .WithOne(a => a.Projects)
                .HasForeignKey(u => u.ProjectID);
                entity.HasMany<Interactions>(n => n.Interactions)
                .WithOne(d => d.Projects)
                .HasForeignKey(w => w.ProjectID);
            });
            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.ToTable("Tasks");
                entity.HasKey(e => e.TaskID);
                entity.Property(t => t.TaskID).ValueGeneratedOnAdd();
                entity.Property(n => n.Name).IsRequired();
                entity.Property(d => d.DueDate).IsRequired();
                entity.Property(k => k.CreateDate).IsRequired();
                entity.Property(z => z.UpdateDate).IsRequired();
            });
        }
    }
}
