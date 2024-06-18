using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace BookingDentist.DataAccess
{
    public class BookingDentistDataContext : DbContext
    {
        public BookingDentistDataContext() { }

        public BookingDentistDataContext(DbContextOptions<BookingDentistDataContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<ChatBox> ChatBoxes { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<ClinicAccount> ClinicAccounts { get; set; }
        public DbSet<ClinicService> ClinicServices { get; set; }
        public DbSet<Dentist> Dentists { get; set; }
        public DbSet<DentistService> DentistServices { get; set; }
        public DbSet<RegistrationLicense> RegistrationLicenses { get; set; }
        public DbSet<RegistrationPackage> RegistrationPackages { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string root = Directory.GetParent(Directory.GetCurrentDirectory())?.FullName ?? "";
                string apiDirectory = Path.Combine(root, "BookingDentist");
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(apiDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString ?? "");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasKey(a => a.Id);
            modelBuilder.Entity<Appointment>().HasKey(a => a.Id);
            modelBuilder.Entity<ChatBox>().HasKey(c => c.Id);
            modelBuilder.Entity<Clinic>().HasKey(c => c.Id);
            modelBuilder.Entity<ClinicAccount>().HasKey(ca => ca.Id);
            modelBuilder.Entity<ClinicService>().HasKey(cs => cs.Id);
            modelBuilder.Entity<Dentist>().HasKey(d => d.Id);
            modelBuilder.Entity<DentistService>().HasKey(ds => ds.Id);
            modelBuilder.Entity<RegistrationLicense>().HasKey(rl => rl.Id);
            modelBuilder.Entity<RegistrationPackage>().HasKey(rp => rp.Id);
            modelBuilder.Entity<Service>().HasKey(s => s.Id);
            modelBuilder.Entity<Transaction>().HasKey(t => t.Id);

            // Define relationships and constraints
            modelBuilder.Entity<ClinicAccount>()
                .HasOne(ca => ca.Account)
                .WithMany()
                .HasForeignKey(ca => ca.RegisterId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ClinicAccount>()
                .HasOne(ca => ca.Clinic)
                .WithMany()
                .HasForeignKey(ca => ca.ClinicId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Account)
                .WithMany()
                .HasForeignKey(a => a.AccountId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Service)
                .WithMany()
                .HasForeignKey(a => a.ServiceId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Dentist)
                .WithMany()
                .HasForeignKey(a => a.DentistId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ChatBox>()
                .HasOne(cb => cb.Account)
                .WithMany()
                .HasForeignKey(cb => cb.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ChatBox>()
                .HasOne(cb => cb.Dentist)
                .WithMany()
                .HasForeignKey(cb => cb.DentistId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Clinic>()
                .HasOne(c => c.RegistrationPackage)
                .WithMany()
                .HasForeignKey(c => c.RegistrationPackageId)
                .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<ClinicService>()
            //    .HasOne(cs => cs.Clinic)
            //    .WithMany(c => c.ClinicServices)
            //    .HasForeignKey(cs => cs.ClinicId)
            //    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ClinicService>()
                .HasOne(cs => cs.Service)
                .WithMany()
                .HasForeignKey(cs => cs.ServiceId)
                .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<DentistService>()
            //    .HasOne(ds => ds.Dentist)
            //    .WithMany(d => d.DentistServices)
            //    .HasForeignKey(ds => ds.DentistId)
            //    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DentistService>()
                .HasOne(ds => ds.Service)
                .WithMany()
                .HasForeignKey(ds => ds.ServiceId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<RegistrationLicense>()
                .HasOne(rl => rl.RegistrationPackage)
                .WithMany()
                .HasForeignKey(rl => rl.RegistrationPackageId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Clinic)
                .WithMany()
                .HasForeignKey(t => t.ClinicId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.RegistrationPackage)
                .WithMany()
                .HasForeignKey(t => t.PackageId)
                .OnDelete(DeleteBehavior.NoAction);

           // modelBuilder.Entity<Dentist>()
           //.HasOne(d => d.Clinic)
           //.WithMany(c => c.Dentists)
           //.HasForeignKey(d => d.ClinicId)
           //.OnDelete(DeleteBehavior.NoAction);
        }
    }
}
