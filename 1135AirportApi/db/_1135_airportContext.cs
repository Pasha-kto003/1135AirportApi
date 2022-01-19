using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace _1135AirportApi.db
{
    public partial class _1135_airportContext : DbContext
    {
        public _1135_airportContext()
        {
        }

        public _1135_airportContext(DbContextOptions<_1135_airportContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AddExpenseType> AddExpenseTypes { get; set; }
        public virtual DbSet<Aircompany> Aircompanies { get; set; }
        public virtual DbSet<Airport> Airports { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<CrossAddExpense> CrossAddExpenses { get; set; }
        public virtual DbSet<CrossTarifAddExpense> CrossTarifAddExpenses { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Passport> Passports { get; set; }
        public virtual DbSet<Tarif> Tarifs { get; set; }
        public virtual DbSet<Transfer> Transfers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=192.168.1.14\\sqlexpress;Initial Catalog=1135_airport;User=student;password=student;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<AddExpenseType>(entity =>
            {
                entity.ToTable("AddExpenseType");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddCost).HasColumnType("money");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Aircompany>(entity =>
            {
                entity.ToTable("Aircompany");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Airport>(entity =>
            {
                entity.ToTable("Airport");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdCity).HasColumnName("idCity");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCityNavigation)
                    .WithMany(p => p.Airports)
                    .HasForeignKey(d => d.IdCity)
                    .HasConstraintName("FK_Airport_City1");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UtcAdd).HasColumnName("utcAdd");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdPassport).HasColumnName("idPassport");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Patronymic)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPassportNavigation)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.IdPassport)
                    .HasConstraintName("FK_Client_Passport");
            });

            modelBuilder.Entity<CrossAddExpense>(entity =>
            {
                entity.ToTable("CrossAddExpense");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdTransfer).HasColumnName("idTransfer");

                entity.Property(e => e.IdTypeExpense).HasColumnName("idTypeExpense");

                entity.HasOne(d => d.IdTransferNavigation)
                    .WithMany(p => p.CrossAddExpenses)
                    .HasForeignKey(d => d.IdTransfer)
                    .HasConstraintName("FK_CrossAddExpense_Transfer");

                entity.HasOne(d => d.IdTypeExpenseNavigation)
                    .WithMany(p => p.CrossAddExpenses)
                    .HasForeignKey(d => d.IdTypeExpense)
                    .HasConstraintName("FK_CrossAddExpense_AddExpenseType");
            });

            modelBuilder.Entity<CrossTarifAddExpense>(entity =>
            {
                entity.ToTable("CrossTarifAddExpense");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdTarif).HasColumnName("idTarif");

                entity.Property(e => e.IdTypeExpense).HasColumnName("idTypeExpense");

                entity.HasOne(d => d.IdTarifNavigation)
                    .WithMany(p => p.CrossTarifAddExpenses)
                    .HasForeignKey(d => d.IdTarif)
                    .HasConstraintName("FK_CrossTarifAddExpense_Tarif");

                entity.HasOne(d => d.IdTypeExpenseNavigation)
                    .WithMany(p => p.CrossTarifAddExpenses)
                    .HasForeignKey(d => d.IdTypeExpense)
                    .HasConstraintName("FK_CrossTarifAddExpense_AddExpenseType");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateBuy)
                    .HasColumnType("date")
                    .HasColumnName("dateBuy");

                entity.Property(e => e.IdClient).HasColumnName("idClient");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdClient)
                    .HasConstraintName("FK_Order_Client");
            });

            modelBuilder.Entity<Passport>(entity =>
            {
                entity.ToTable("Passport");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GainDate).HasColumnType("date");

                entity.Property(e => e.Nomer)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Seria)
                    .HasMaxLength(5)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Tarif>(entity =>
            {
                entity.ToTable("Tarif");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Transfer>(entity =>
            {
                entity.ToTable("Transfer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.DateEndUtc)
                    .HasColumnType("date")
                    .HasColumnName("dateEndUTC");

                entity.Property(e => e.DateStartUtc)
                    .HasColumnType("date")
                    .HasColumnName("dateStartUTC");

                entity.Property(e => e.IdAirCompany).HasColumnName("idAirCompany");

                entity.Property(e => e.IdAirportEnd).HasColumnName("idAirportEnd");

                entity.Property(e => e.IdAirportStart).HasColumnName("idAirportStart");

                entity.Property(e => e.IdOrder).HasColumnName("idOrder");

                entity.Property(e => e.IdTarif).HasColumnName("idTarif");

                entity.Property(e => e.Sit)
                    .HasMaxLength(2)
                    .HasColumnName("sit")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdAirCompanyNavigation)
                    .WithMany(p => p.Transfers)
                    .HasForeignKey(d => d.IdAirCompany)
                    .HasConstraintName("FK_Transfer_Aircompany");

                entity.HasOne(d => d.IdAirportEndNavigation)
                    .WithMany(p => p.TransferIdAirportEndNavigations)
                    .HasForeignKey(d => d.IdAirportEnd)
                    .HasConstraintName("FK_Transfer_Airport1");

                entity.HasOne(d => d.IdAirportStartNavigation)
                    .WithMany(p => p.TransferIdAirportStartNavigations)
                    .HasForeignKey(d => d.IdAirportStart)
                    .HasConstraintName("FK_Transfer_Airport");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany(p => p.Transfers)
                    .HasForeignKey(d => d.IdOrder)
                    .HasConstraintName("FK_Transfer_Order");

                entity.HasOne(d => d.IdTarifNavigation)
                    .WithMany(p => p.Transfers)
                    .HasForeignKey(d => d.IdTarif)
                    .HasConstraintName("FK_Transfer_Tarif");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
