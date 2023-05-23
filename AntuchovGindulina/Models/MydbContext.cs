using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AntuchovGindulina.Models;

public partial class MydbContext : DbContext
{
    public MydbContext()
    {
    }

    public MydbContext(DbContextOptions<MydbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CashDesk> CashDesks { get; set; }

    public virtual DbSet<Check> Checks { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Guest> Guests { get; set; }

    public virtual DbSet<Record> Records { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomType> RoomTypes { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServicesCheck> ServicesChecks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=127.0.0.1;User=root;Database=mydb");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CashDesk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("cash_desks");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Check>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("checks");

            entity.HasIndex(e => e.CashDeskId, "fk_Cheque_Cash1_idx");

            entity.HasIndex(e => e.EmployeesId, "fk_Cheque_Employees1_idx");

            entity.HasIndex(e => e.RecordId, "fk_Cheque_Record1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CashDeskId).HasColumnName("cash_desk_id");
            entity.Property(e => e.DateAndTime)
                .HasMaxLength(255)
                .HasColumnName("date_and_time");
            entity.Property(e => e.EmployeesId).HasColumnName("employees_id");
            entity.Property(e => e.RecordId).HasColumnName("record_id");
            entity.Property(e => e.TotalCost)
                .HasMaxLength(255)
                .HasColumnName("total_cost");

            entity.HasOne(d => d.CashDesk).WithMany(p => p.Checks)
                .HasForeignKey(d => d.CashDeskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Cheque_Cash1");

            entity.HasOne(d => d.Employees).WithMany(p => p.Checks)
                .HasForeignKey(d => d.EmployeesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Cheque_Employees1");

            entity.HasOne(d => d.Record).WithMany(p => p.Checks)
                .HasForeignKey(d => d.RecordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Cheque_Record1");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("employees");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Data)
                .HasMaxLength(255)
                .HasColumnName("data");
            entity.Property(e => e.Fullmame)
                .HasMaxLength(255)
                .HasColumnName("fullmame");
            entity.Property(e => e.Login)
                .HasMaxLength(255)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .HasColumnName("password");
            entity.Property(e => e.Post)
                .HasMaxLength(255)
                .HasColumnName("post");
        });

        modelBuilder.Entity<Guest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("guests");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fullname)
                .HasMaxLength(255)
                .HasComment("Рузана")
                .HasColumnName("fullname");
            entity.Property(e => e.Passport)
                .HasMaxLength(255)
                .HasColumnName("passport");
            entity.Property(e => e.PhoneNumer)
                .HasMaxLength(20)
                .HasColumnName("phone_numer");
        });

        modelBuilder.Entity<Record>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("records");

            entity.HasIndex(e => e.GuestsId, "fk_Records_Guests1_idx");

            entity.HasIndex(e => e.RoomsId, "fk_records_rooms1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ArrivalDate)
                .HasColumnType("datetime")
                .HasColumnName("arrival_date");
            entity.Property(e => e.DateOfDeparture)
                .HasMaxLength(255)
                .HasColumnName("date_of_departure");
            entity.Property(e => e.GuestsId).HasColumnName("guests_id");
            entity.Property(e => e.RoomsId).HasColumnName("rooms_id");

            entity.HasOne(d => d.Guests).WithMany(p => p.Records)
                .HasForeignKey(d => d.GuestsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Records_Guests1");

            entity.HasOne(d => d.Rooms).WithMany(p => p.Records)
                .HasForeignKey(d => d.RoomsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_records_rooms1");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("rooms");

            entity.HasIndex(e => e.RoomTypesId, "fk_rooms_room_types1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cost)
                .HasMaxLength(255)
                .HasColumnName("cost");
            entity.Property(e => e.RoomTypesId).HasColumnName("room_types_id");

            entity.HasOne(d => d.RoomTypes).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.RoomTypesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_rooms_room_types1");
        });

        modelBuilder.Entity<RoomType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("room_types");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RoomType1)
                .HasMaxLength(45)
                .HasColumnName("room_type");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("services");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cost)
                .HasMaxLength(255)
                .HasColumnName("cost");
        });

        modelBuilder.Entity<ServicesCheck>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("services_checks");

            entity.HasIndex(e => e.ServiceId, "fk_Service-Receipt_Service1_idx");

            entity.HasIndex(e => e.ChecksId, "fk_services_checks_checks1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ChecksId).HasColumnName("checks_id");
            entity.Property(e => e.ServiceCost)
                .HasMaxLength(255)
                .HasColumnName("service_cost");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");

            entity.HasOne(d => d.Checks).WithMany(p => p.ServicesChecks)
                .HasForeignKey(d => d.ChecksId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_services_checks_checks1");

            entity.HasOne(d => d.Service).WithMany(p => p.ServicesChecks)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Service-Receipt_Service1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
