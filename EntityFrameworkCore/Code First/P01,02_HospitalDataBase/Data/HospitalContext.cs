using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Configurations;
using P01_HospitalDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {

        }

        public HospitalContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<PatientMedicament> PatientMedicaments { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity =>
            {
                entity
                    .Property(p => p.Email)
                    .IsUnicode(false)
                    .HasMaxLength(80);

                entity
                    .HasMany(p => p.Visitations)
                    .WithOne(v => v.Patient)
                    .HasForeignKey(v => v.PatientId);

                entity
                    .HasMany(p => p.Diagnoses)
                    .WithOne(d => d.Patient)
                    .HasForeignKey(d => d.PatientId);

                entity
                    .HasMany(p => p.Prescriptions)
                    .WithOne(pm => pm.Patient)
                    .HasForeignKey(pm => pm.PatientId);
            });

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity
                    .HasMany(m => m.Prescriptions)
                    .WithOne(pm => pm.Medicament)
                    .HasForeignKey(pm => pm.MedicamentId);
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity
                    .HasMany(d => d.Visitations)
                    .WithOne(v => v.Doctor)
                    .HasForeignKey(v => v.DoctorId);
            });

            modelBuilder.Entity<PatientMedicament>(entity =>
            {
                entity.HasKey(pm => new { pm.PatientId, pm.MedicamentId });
            });
        }
    }
}
