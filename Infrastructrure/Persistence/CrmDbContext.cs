using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructrure.Persistence
{
    public class CrmDbContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Domain.Entities.TaskStatus> TaskStatus { get; set; }
        public DbSet<CampaignTypes> CampaignTypes { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<InteractionTypes> InteractionTypes { get; set; }
        public DbSet<Interactions> Interactions { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public CrmDbContext(DbContextOptions<CrmDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(e => e.UserID);
                entity.Property(e => e.UserID).ValueGeneratedOnAdd();
                entity.Property(c => c.Name).HasMaxLength(255).IsRequired().IsUnicode();
                entity.Property(z => z.Email).HasMaxLength(255).IsRequired().IsUnicode();
            });

            modelBuilder.Entity<Domain.Entities.TaskStatus>(entity =>
            {
                entity.ToTable("TaskStatus");
                entity.HasKey(e => e.Id);
                entity.Property(t => t.Id).ValueGeneratedOnAdd();
                entity.Property(c => c.Name).HasMaxLength(25).IsRequired();
            });

            modelBuilder.Entity<CampaignTypes>(entity =>
            {
                entity.ToTable("CampaignTypes");
                entity.HasKey(e => e.Id);
                entity.Property(t => t.Id).ValueGeneratedOnAdd();
                entity.Property(c => c.Name).HasMaxLength(25).IsRequired();
            });
            modelBuilder.Entity<InteractionTypes>(entity =>
            {
                entity.ToTable("InteractionTypes");
                entity.HasKey(e => e.Id);
                entity.Property(t => t.Id).ValueGeneratedOnAdd();
                entity.Property(k =>  k.Name).HasMaxLength(25).IsRequired().IsUnicode();
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
                entity.Property(p => p.Address).IsRequired();
                entity.Property(u => u.CreateDate).IsRequired();
            });

            modelBuilder.Entity<Interactions>(entity =>
            {
                entity.ToTable("Interactions");
                entity.HasKey(e => e.InteractionID);
                entity.Property(t => t.InteractionID).ValueGeneratedOnAdd();
                entity.Property(d => d.Date).IsRequired();
                entity.Property(n => n.Notes).IsRequired();

                entity.HasOne(p => p.InteractionTypes)
                .WithMany() // Si InteractionTypes no tiene una colección inversa
                .HasForeignKey(p => p.InteractionType) // Indica que InteractionType es la clave foránea
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Projects>(entity =>
            {
                entity.ToTable("Projects");
                entity.HasKey(e => e.ProjectID);
                entity.Property(t => t.ProjectID).ValueGeneratedOnAdd();
                entity.Property(p => p.ProjectName).HasMaxLength(255).IsRequired();
                entity.Property(s => s.StartDate).IsRequired();
                entity.Property(c => c.EndDate).IsRequired();
                entity.Property(x => x.CreateDate).IsRequired();
                entity.Property(j => j.UpdateDate).IsRequired();

                entity.HasOne(p => p.CampaignTypes)
                .WithMany() // Si CampaignTypes no tiene una colección inversa
                .HasForeignKey(p => p.CampaignType ) // Indica que CampaignType es la clave foránea
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.Clients)  // Relación con la tabla 'Clients'
                .WithMany()// Un cliente puede tener muchos proyectos
                .HasForeignKey(p => p.ClientID) // La clave foránea es 'ClientID'
                .OnDelete(DeleteBehavior.Restrict); // Comportamiento al eliminar un cliente

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
                entity.Property(n => n.Name).IsRequired().IsUnicode();
                entity.Property(d => d.DueDate).IsRequired();
                entity.Property(k => k.CreateDate).IsRequired();
                entity.Property(z => z.UpdateDate).IsRequired();

                entity.HasOne(p => p.Users)
                .WithMany() // Si Users no tiene una colección inversa
                .HasForeignKey(p => p.AssignedTo) // Indica que AssignedTo es la clave foránea
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.TaskStatus)
                .WithMany() // Si TaskStatus no tiene una colección inversa
                .HasForeignKey(p => p.Status) // Indica que Status es la clave foránea
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Users>().HasData
                (
                new Users
                {
                    UserID = 1,
                    Name = "Joe Done",
                    Email = "jdone@marketing.com"
                },
                new Users
                {
                    UserID = 2,
                    Name = "Nill Amstrong",
                    Email = "namstrong@marketing.com"
                },
                new Users
                {
                    UserID = 3,
                    Name = "Marlyn Morales",
                    Email = "mmorales@marketing.com"
                },
                new Users
                {
                    UserID = 4,
                    Name = "Antony Orué",
                    Email = "aorue@marketing.com"
                },
                new Users
                {
                    UserID = 5,
                    Name = "Jazmin Fernandez",
                    Email = "jfernandez@marketing.com"
                }
                );

            modelBuilder.Entity<Domain.Entities.TaskStatus>().HasData
                (
                new Domain.Entities.TaskStatus
                {
                    Id = 1,
                    Name = "Pending"
                },
                new Domain.Entities.TaskStatus
                {
                    Id = 2,
                    Name = "In Progress"
                },
                new Domain.Entities.TaskStatus
                {
                    Id = 3,
                    Name = "Blocked"
                },
                new Domain.Entities.TaskStatus
                {
                    Id = 4,
                    Name = "Done"
                },
                new Domain.Entities.TaskStatus
                {
                    Id = 5,
                    Name = "Cancel"
                }
                );

            modelBuilder.Entity<InteractionTypes>().HasData
                (
                new InteractionTypes
                {
                    Id = 1,
                    Name = "Initial Meeting"
                },
                new InteractionTypes
                {
                    Id = 2,
                    Name = "Phone call"
                },
                new InteractionTypes
                {
                    Id = 3,
                    Name = "Email"
                },
                new InteractionTypes
                {
                    Id = 4,
                    Name = "Presentation of Results"
                }
                );

            modelBuilder.Entity<CampaignTypes>().HasData
                (
                new CampaignTypes 
                { 
                    Id  = 1,
                    Name = "SEO"
                },
                new CampaignTypes
                {
                    Id = 2,
                    Name = "PPC"
                },
                new CampaignTypes
                {
                    Id = 3,
                    Name = "Social Media"
                },
                new CampaignTypes
                {
                    Id = 4,
                    Name = "Email Marketing"
                }
                );

            modelBuilder.Entity<Clients>().HasData
                (
                new Clients
                {
                    ClientID = 1,
                    Name = "Juan lopez",
                    Email = "juan@gmail.com",
                    Company = "Xenon",
                    Phone = "12345678",
                    Address = "Av libertador n°123",
                    CreateDate = DateTime.Now
                },
                new Clients
                {
                    ClientID = 2,
                    Name = "Martina lopez",
                    Email = "martina@gmail.com",
                    Company = "xSpace",
                    Phone = "87654321",
                    Address = "Av libertador n°123",
                    CreateDate = DateTime.Now
                },
                new Clients
                {
                    ClientID = 3,
                    Name = "Javiera Godoy",
                    Email = "javiera@gmail.com",
                    Company = "NatamZ",
                    Phone = "12121212",
                    Address = "Av Salsedo n°321",
                    CreateDate = DateTime.Now

                },
                new Clients
                {
                    ClientID = 4,
                    Name = "Roberto Kempes",
                    Email = "roberto@gmail.com",
                    Company = "RepublicHall",
                    Phone = "99999999",
                    Address = "Av costa rica n°199",
                    CreateDate = DateTime.Now
                },
                new Clients
                {
                    ClientID = 5,
                    Name = "Dario Juarez",
                    Email = "dario@gmail.com",
                    Company = "Intercontinental",
                    Phone = "666666666",
                    Address = "Av luxemburgo n°132",
                    CreateDate = DateTime.Now
                }
                );
        }
    }
}
