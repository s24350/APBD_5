using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Zadanie7.ContextModels;

public partial class S24350Context : DbContext
{
    public S24350Context()
    {
    }

    public S24350Context(DbContextOptions<S24350Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Animal> Animals { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Budzet> Budzets { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientTrip> ClientTrips { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Dept> Depts { get; set; }

    public virtual DbSet<Emp> Emps { get; set; }

    public virtual DbSet<Magazyn> Magazyns { get; set; }

    public virtual DbSet<Miejscowosc> Miejscowoscs { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Powiat> Powiats { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductWarehouse> ProductWarehouses { get; set; }

    public virtual DbSet<Projekt> Projekts { get; set; }

    public virtual DbSet<RejestrRyzyka> RejestrRyzykas { get; set; }

    public virtual DbSet<RodzajUruch> RodzajUruches { get; set; }

    public virtual DbSet<Salgrade> Salgrades { get; set; }

    public virtual DbSet<Transze> Transzes { get; set; }

    public virtual DbSet<Trip> Trips { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    public virtual DbSet<Wojewodztwo> Wojewodztwos { get; set; }

    public virtual DbSet<WskaznikiGu> WskaznikiGus { get; set; }

    public virtual DbSet<Wycena> Wycenas { get; set; }

    public virtual DbSet<WycenaSkorygowana> WycenaSkorygowanas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=db-mssql16;Initial Catalog=s24350;Integrated Security=True;TrustServerCertificate=true");
        //.LogTo(Console.WriteLine, LogLevel.Information);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Animal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Animals_pk");

            entity.Property(e => e.Area).HasMaxLength(200);
            entity.Property(e => e.Category).HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Books_Id");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Author)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Genre)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Published)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.Rating).HasColumnType("decimal(2, 1)");
            entity.Property(e => e.Title)
                .HasMaxLength(140)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Budzet>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("budzet");

            entity.Property(e => e.Wartosc).HasColumnName("wartosc");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient).HasName("Client_pk");

            entity.ToTable("Client", "trip");

            entity.Property(e => e.IdClient).ValueGeneratedNever();
            entity.Property(e => e.Email).HasMaxLength(120);
            entity.Property(e => e.FirstName).HasMaxLength(120);
            entity.Property(e => e.LastName).HasMaxLength(120);
            entity.Property(e => e.Pesel).HasMaxLength(120);
            entity.Property(e => e.Telephone).HasMaxLength(120);
        });

        modelBuilder.Entity<ClientTrip>(entity =>
        {
            entity.HasKey(e => new { e.IdClient, e.IdTrip }).HasName("Client_Trip_pk");

            entity.ToTable("Client_Trip", "trip");

            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.RegisteredAt).HasColumnType("datetime");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.ClientTrips)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Table_5_Client");

            entity.HasOne(d => d.IdTripNavigation).WithMany(p => p.ClientTrips)
                .HasForeignKey(d => d.IdTrip)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Table_5_Trip");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.IdCountry).HasName("Country_pk");

            entity.ToTable("Country", "trip");

            entity.Property(e => e.IdCountry).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(120);

            entity.HasMany(d => d.IdTrips).WithMany(p => p.IdCountries)
                .UsingEntity<Dictionary<string, object>>(
                    "CountryTrip",
                    r => r.HasOne<Trip>().WithMany()
                        .HasForeignKey("IdTrip")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Country_Trip_Trip"),
                    l => l.HasOne<Country>().WithMany()
                        .HasForeignKey("IdCountry")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Country_Trip_Country"),
                    j =>
                    {
                        j.HasKey("IdCountry", "IdTrip").HasName("Country_Trip_pk");
                        j.ToTable("Country_Trip", "trip");
                    });
        });

        modelBuilder.Entity<Dept>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DEPT");

            entity.Property(e => e.Deptno).HasColumnName("DEPTNO");
            entity.Property(e => e.Dname)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("DNAME");
            entity.Property(e => e.Loc)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("LOC");
        });

        modelBuilder.Entity<Emp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("EMP");

            entity.Property(e => e.Comm).HasColumnName("COMM");
            entity.Property(e => e.Deptno).HasColumnName("DEPTNO");
            entity.Property(e => e.Empno).HasColumnName("EMPNO");
            entity.Property(e => e.Ename)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ENAME");
            entity.Property(e => e.Hiredate)
                .HasColumnType("datetime")
                .HasColumnName("HIREDATE");
            entity.Property(e => e.Job)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("JOB");
            entity.Property(e => e.Mgr).HasColumnName("MGR");
            entity.Property(e => e.Sal).HasColumnName("SAL");
        });

        modelBuilder.Entity<Magazyn>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Magazyn");

            entity.Property(e => e.Nazwa)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Miejscowosc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Miejscowosc_pk");

            entity.ToTable("Miejscowosc");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.LiczbaMieszkancow).HasColumnName("Liczba_mieszkancow");
            entity.Property(e => e.Nazwa)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PowiatId).HasColumnName("Powiat_ID");

            entity.HasOne(d => d.Powiat).WithMany(p => p.Miejscowoscs)
                .HasForeignKey(d => d.PowiatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Miejscowosc_Lokalizacja");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder).HasName("Order_pk");

            entity.ToTable("Order");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.FulfilledAt).HasColumnType("datetime");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Receipt_Product");
        });

        modelBuilder.Entity<Powiat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Powiat_pk");

            entity.ToTable("Powiat");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Powiat1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Powiat");
            entity.Property(e => e.WojewodztwoNazwa)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Wojewodztwo_Nazwa");

            entity.HasOne(d => d.WojewodztwoNazwaNavigation).WithMany(p => p.Powiats)
                .HasForeignKey(d => d.WojewodztwoNazwa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Lokalizacja_Wojewodztwo");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("Product_pk");

            entity.ToTable("Product");

            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Price).HasColumnType("numeric(25, 2)");
        });

        modelBuilder.Entity<ProductWarehouse>(entity =>
        {
            entity.HasKey(e => e.IdProductWarehouse).HasName("Product_Warehouse_pk");

            entity.ToTable("Product_Warehouse");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("numeric(25, 2)");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.ProductWarehouses)
                .HasForeignKey(d => d.IdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Product_Warehouse_Order");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.ProductWarehouses)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("_Product");

            entity.HasOne(d => d.IdWarehouseNavigation).WithMany(p => p.ProductWarehouses)
                .HasForeignKey(d => d.IdWarehouse)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("_Warehouse");
        });

        modelBuilder.Entity<Projekt>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Projekt_pk");

            entity.ToTable("Projekt");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.MiejscowoscId).HasColumnName("Miejscowosc_ID");
            entity.Property(e => e.Nazwa)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Portfel)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.Miejscowosc).WithMany(p => p.Projekts)
                .HasForeignKey(d => d.MiejscowoscId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Projekt_Miejscowosc");
        });

        modelBuilder.Entity<RejestrRyzyka>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Rejestr_ryzyka_pk");

            entity.ToTable("Rejestr_ryzyka");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.DataRejestracji)
                .HasColumnType("date")
                .HasColumnName("data_rejestracji");
            entity.Property(e => e.NazwaRyzyka)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nazwa_ryzyka");
            entity.Property(e => e.ProjektId).HasColumnName("Projekt_ID");
            entity.Property(e => e.Status)
                .HasMaxLength(16)
                .IsUnicode(false);

            entity.HasOne(d => d.Projekt).WithMany(p => p.RejestrRyzykas)
                .HasForeignKey(d => d.ProjektId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Rejestr_ryzyka_Projekt");
        });

        modelBuilder.Entity<RodzajUruch>(entity =>
        {
            entity.HasKey(e => e.Nazwa).HasName("rodzaj_uruch_pk");

            entity.ToTable("rodzaj_uruch");

            entity.Property(e => e.Nazwa)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.MaxKwota)
                .HasColumnType("money")
                .HasColumnName("max_kwota");
        });

        modelBuilder.Entity<Salgrade>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SALGRADE");

            entity.Property(e => e.Grade).HasColumnName("GRADE");
            entity.Property(e => e.Hisal).HasColumnName("HISAL");
            entity.Property(e => e.Losal).HasColumnName("LOSAL");
        });

        modelBuilder.Entity<Transze>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Transze_pk");

            entity.ToTable("Transze", tb => tb.HasTrigger("wyzwalacz_2"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.DataUruchomienia)
                .HasColumnType("date")
                .HasColumnName("data_uruchomienia");
            entity.Property(e => e.Kwota)
                .HasColumnType("money")
                .HasColumnName("kwota");
            entity.Property(e => e.NrUruchomienia).HasColumnName("nr_uruchomienia");
            entity.Property(e => e.ProjektId).HasColumnName("Projekt_ID");
            entity.Property(e => e.RodzajUruchNazwa)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("rodzaj_uruch_Nazwa");

            entity.HasOne(d => d.Projekt).WithMany(p => p.Transzes)
                .HasForeignKey(d => d.ProjektId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Uruchomienie_srodkow_Projekt");

            entity.HasOne(d => d.RodzajUruchNazwaNavigation).WithMany(p => p.Transzes)
                .HasForeignKey(d => d.RodzajUruchNazwa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Transze_rodzaj_uruch");
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.HasKey(e => e.IdTrip).HasName("Trip_pk");

            entity.ToTable("Trip", "trip");

            entity.Property(e => e.IdTrip).ValueGeneratedNever();
            entity.Property(e => e.DateFrom).HasColumnType("datetime");
            entity.Property(e => e.DateTo).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(220);
            entity.Property(e => e.Name).HasMaxLength(120);
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => e.IdWarehouse).HasName("Warehouse_pk");

            entity.ToTable("Warehouse");

            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<Wojewodztwo>(entity =>
        {
            entity.HasKey(e => e.Nazwa).HasName("Wojewodztwo_pk");

            entity.ToTable("Wojewodztwo");

            entity.Property(e => e.Nazwa)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WskaznikiGu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Wskazniki_GUS_pk");

            entity.ToTable("Wskazniki_GUS");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Wartosc).HasColumnType("decimal(5, 3)");
        });

        modelBuilder.Entity<Wycena>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Wycena_pk");

            entity.ToTable("Wycena", tb =>
                {
                    tb.HasTrigger("wyzwalacz_1");
                    tb.HasTrigger("wyzwalacz_3");
                });

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.DataWyceny)
                .HasColumnType("date")
                .HasColumnName("Data_wyceny");
            entity.Property(e => e.Etap)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.ProjektId).HasColumnName("Projekt_ID");
            entity.Property(e => e.Pum)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("PUM");
            entity.Property(e => e.Puu)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("PUU");
            entity.Property(e => e.SredniaLiczbaKond)
                .HasColumnType("decimal(3, 1)")
                .HasColumnName("Srednia_liczba_kond");
            entity.Property(e => e.Wartosc).HasColumnType("money");

            entity.HasOne(d => d.Projekt).WithMany(p => p.Wycenas)
                .HasForeignKey(d => d.ProjektId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Wycena_Projekt");
        });

        modelBuilder.Entity<WycenaSkorygowana>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Wycena_skorygowana_pk");

            entity.ToTable("Wycena_skorygowana");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.DataWycenySk)
                .HasColumnType("date")
                .HasColumnName("Data_wyceny_sk");
            entity.Property(e => e.WskaznikiGusId).HasColumnName("Wskazniki_GUS_ID");
            entity.Property(e => e.WycenaId).HasColumnName("Wycena_ID");

            entity.HasOne(d => d.WskaznikiGus).WithMany(p => p.WycenaSkorygowanas)
                .HasForeignKey(d => d.WskaznikiGusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("wyc_skor_wsk_gus");

            entity.HasOne(d => d.Wycena).WithMany(p => p.WycenaSkorygowanas)
                .HasForeignKey(d => d.WycenaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Wycena_skorygowana_Wycena");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
