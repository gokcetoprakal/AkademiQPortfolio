
using System;
using System.Collections.Generic;
using AkademiQPortfolio.Entities;
using Microsoft.EntityFrameworkCore;

namespace AkademiQPortfolio.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<About> Abouts { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Education> Educations { get; set; }

    public virtual DbSet<Experience> Experiences { get; set; }

    public virtual DbSet<Hobby> Hobbys { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }
    public virtual DbSet<Project> Projects { get; set; }
    public virtual DbSet<Reference> References { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=AkademiQPortfolio;integrated security=true;trustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<About>(entity =>
        {
            entity.Property(e => e.AboutId).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.ImageUrl).HasMaxLength(50);
            entity.Property(e => e.NameSurname).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.Property(e => e.ContactId).ValueGeneratedNever();
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<Education>(entity =>
        {
            entity.Property(e => e.EducationId).ValueGeneratedNever();
            entity.Property(e => e.Department).HasMaxLength(50);
            entity.Property(e => e.EducationDate).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<Experience>(entity =>
        {
            entity.Property(e => e.ExperienceId).ValueGeneratedNever();
            entity.Property(e => e.CompanyName).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(50);
            entity.Property(e => e.WorkDate).HasMaxLength(50);
        });

        modelBuilder.Entity<Hobby>(entity =>
        {
            entity.Property(e => e.HobbyId).ValueGeneratedNever();
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.Property(e => e.MessageId)
           .ValueGeneratedOnAdd();

            entity.Property(e => e.MessageText).HasMaxLength(50);
            entity.Property(e => e.SendDate).HasColumnType("datetime");
            entity.Property(e => e.SenderEmail).HasMaxLength(50);
            entity.Property(e => e.SenderName).HasMaxLength(50);
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.Property(e => e.SkillId).HasMaxLength(50);
            entity.Property(e => e.SkillTitle).HasMaxLength(50);
            entity.Property(e => e.SkillValue).HasMaxLength(50);
        });
        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProjectId);
            entity.Property(e => e.Title)
                  .HasMaxLength(50)
                  .IsRequired();
            entity.Property(e => e.Category)
                  .HasMaxLength(50);
            entity.Property(e => e.Description)
                  .HasColumnType("nvarchar(max)");
            entity.Property(e => e.PublishDate)
                  .HasColumnType("datetime");
        });
        modelBuilder.Entity<Reference>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.ReferenceName)
                  .HasMaxLength(50)
                  .IsRequired();
            entity.Property(e => e.Phone)
                  .HasMaxLength(50);
            entity.Property(e => e.Mail)
                  .HasColumnType("nvarchar(max)");
            entity.Property(e => e.Description)
                  .HasColumnType("nvarchar(max)");

        });
        OnModelCreatingPartial(modelBuilder);
    }
    

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
