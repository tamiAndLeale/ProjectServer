using System;

using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DL
{
    public partial class CTContext : DbContext
    {
        public CTContext()
        {
        }

        public CTContext(DbContextOptions<CTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DocumentType> DocumentTypes { get; set; }
        public virtual DbSet<Folder> Folders { get; set; }
        public virtual DbSet<InputDocument> InputDocuments { get; set; }
        public virtual DbSet<OutputDocument> OutputDocuments { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Portfolio> Portfolio { get; set; }
        public virtual DbSet<PortfolioFolder> PortfolioFolders { get; set; }
        public virtual DbSet<PortfolioType> PortfolioTypes { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-R5RADSP;Database=CT;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.ToTable("DocumentType");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.PortfolioTypeId).HasColumnName("portfolioTypeId");

                entity.Property(e => e.Required).HasColumnName("required");

                entity.Property(e => e.RequiredArchitecturalApproval).HasColumnName("requiredArchitecturalApproval");

                entity.HasOne(d => d.PortfolioType)
                    .WithMany(p => p.DocumentTypes)
                    .HasForeignKey(d => d.PortfolioTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentType_PortfolioType1");
            });

            modelBuilder.Entity<Folder>(entity =>
            {
                entity.ToTable("Folder");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("name")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<InputDocument>(entity =>
            {
                entity.ToTable("Input_Document");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateOfSubmission)
                    .HasColumnType("date")
                    .HasColumnName("dateOfSubmission");

                entity.Property(e => e.DocumentTypeId).HasColumnName("documentTypeId");

                entity.Property(e => e.PortfolioId).HasColumnName("portfolioId");

                entity.Property(e => e.Submitted).HasColumnName("submitted");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("url");

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.InputDocuments)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Input_Document_DocumentType");

                entity.HasOne(d => d.Portfolio)
                    .WithMany(p => p.InputDocuments)
                    .HasForeignKey(d => d.PortfolioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Input_Document_Portfolio");
            });

            modelBuilder.Entity<OutputDocument>(entity =>
            {
                entity.ToTable("Output_document");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("name");
                entity.Property(e => e.RequiresApproval).HasColumnName("requiresApproval");

                entity.Property(e => e.PortfolioFolderId).HasColumnName("portfolioFolderId");

                entity.Property(e => e.PortfolioId).HasColumnName("portfolioId");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("url");
                

                entity.HasOne(d => d.PortfolioFolder)
                    .WithMany(p => p.OutputDocuments)
                    .HasForeignKey(d => d.PortfolioFolderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Output_document_PortfolioFolder");

                entity.HasOne(d => d.Portfolio)
                    .WithMany(p => p.OutputDocuments)
                    .HasForeignKey(d => d.PortfolioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Output_document_Portfolio");
            });

            

            modelBuilder.Entity<Portfolio>(entity =>
            {
                entity.ToTable("Portfolio");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateOfOpen)
                    .HasColumnType("date")
                    .HasColumnName("dateOfOpen");

                entity.Property(e => e.Dedline)
                    .HasColumnType("date")
                    .HasColumnName("dedline");

                entity.Property(e => e.StatusId).HasColumnName("statusId");

                entity.Property(e => e.TypeId).HasColumnName("typeId");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Portfolios)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Portfolio_Status");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Portfolios)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Portfolio_PortfolioType");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Portfolios)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Portfolio_User");
            });

            modelBuilder.Entity<PortfolioFolder>(entity =>
            {
                entity.ToTable("PortfolioFolder");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FolderId).HasColumnName("folderId");

                entity.Property(e => e.PortfolioTypeId).HasColumnName("portfolioTypeId");

                entity.HasOne(d => d.Folder)
                    .WithMany(p => p.PortfolioFolders)
                    .HasForeignKey(d => d.FolderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PortfolioFolder_Folder");

                entity.HasOne(d => d.portfolioType)
                    .WithMany(p => p.PortfolioFolders)
                    .HasForeignKey(d => d.PortfolioTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PortfolioFolder_PortfolioType");
            });

            modelBuilder.Entity<PortfolioType>(entity =>
            {
                entity.ToTable("PortfolioType");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("name")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsManager).HasColumnName("isManager");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("password")
                    .IsFixedLength(true);

                entity.Property(e => e.PersonId).HasColumnName("personId");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName");
                    //.IsFixedLength(true);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Person");
            });

          
        
        
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("RATING");

                entity.Property(e => e.RatingId).HasColumnName("RATING_ID");

                entity.Property(e => e.Host)
                    .HasMaxLength(50)
                    .HasColumnName("HOST");

                entity.Property(e => e.Method)
                    .HasMaxLength(10)
                    .HasColumnName("METHOD")
                    .IsFixedLength(true);

                entity.Property(e => e.Path)
                    .HasMaxLength(50)
                    .HasColumnName("PATH");

                entity.Property(e => e.RecordDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Record_Date");

                entity.Property(e => e.Referer)
                    .HasMaxLength(100)
                    .HasColumnName("REFERER");

                entity.Property(e => e.UserAgent).HasColumnName("USER_AGENT");
            });

            OnModelCreatingPartial(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ApartmentNumber).HasColumnName("apartmentNumber");

                entity.Property(e => e.City)
                    .HasMaxLength(15)
                    .HasColumnName("city")
                    .IsFixedLength(true);

                entity.Property(e => e.Country)
                    .HasMaxLength(15)
                    .HasColumnName("country")
                    .IsFixedLength(true);

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .HasColumnName("email")
                    .IsFixedLength(true);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(10)
                    .HasColumnName("firstName")
                    .IsFixedLength(true);

                entity.Property(e => e.HouseNumber).HasColumnName("houseNumber");

                entity.Property(e => e.Identity)
                    .HasMaxLength(9)
                    .HasColumnName("identity")
                    .IsFixedLength(true);

                entity.Property(e => e.LastName)
                    .HasMaxLength(10)
                    .HasColumnName("lastName")
                    .IsFixedLength(true);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .HasColumnName("phone")
                    .IsFixedLength(true);

                entity.Property(e => e.Street)
                    .HasMaxLength(20)
                    .HasColumnName("street")
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }



        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
