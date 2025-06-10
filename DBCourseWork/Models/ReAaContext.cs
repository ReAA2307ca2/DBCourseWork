using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DBCourseWork.Models;

public partial class ReAaContext : DbContext
{
    public ReAaContext()
    {
    }

    public ReAaContext(DbContextOptions<ReAaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Consumable> Consumables { get; set; }

    public virtual DbSet<ConsumablesType> ConsumablesTypes { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Furniture> Furnitures { get; set; }

    public virtual DbSet<Machine> Machines { get; set; }

    public virtual DbSet<Operation> Operations { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Part> Parts { get; set; }

    public virtual DbSet<Site> Sites { get; set; }

    public virtual DbSet<Stage> Stages { get; set; }

    public virtual DbSet<StageConsumable> StageConsumables { get; set; }

    public virtual DbSet<Storage> Storages { get; set; }

    public virtual DbSet<StorageCell> StorageCells { get; set; }

    public virtual DbSet<StorageRack> StorageRacks { get; set; }

    public virtual DbSet<StorageRoom> StorageRooms { get; set; }

    public virtual DbSet<StorageSection> StorageSections { get; set; }

    public virtual DbSet<StorageStockpile> StorageStockpiles { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<TeamLeader> TeamLeaders { get; set; }

    public virtual DbSet<Technote> Technotes { get; set; }

    public virtual DbSet<WorkType> WorkTypes { get; set; }

    public virtual DbSet<Workplace> Workplaces { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DBSRV\\vip2024; Database=ReAA;TrustServerCertificate=True;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Client__3214EC07233FDF73");

            entity.ToTable("Client");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Consumable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Consumab__3214EC07DFFCB6C0");

            entity.ToTable("Consumable");

            entity.Property(e => e.FkStorageCell).HasColumnName("FK_Storage_Cell");
            entity.Property(e => e.FkType).HasColumnName("FK_Type");
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.FkStorageCellNavigation).WithMany(p => p.Consumables)
                .HasForeignKey(d => d.FkStorageCell)
                .HasConstraintName("FK__Consumabl__FK_St__695C9DA1");

            entity.HasOne(d => d.FkTypeNavigation).WithMany(p => p.Consumables)
                .HasForeignKey(d => d.FkType)
                .HasConstraintName("FK__Consumabl__FK_Ty__3C89F72A");
        });

        modelBuilder.Entity<ConsumablesType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Consumab__3214EC07E90A65F6");

            entity.ToTable("Consumables_Type");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC07038F8E91");

            entity.ToTable("Employee");

            entity.Property(e => e.FkTeam).HasColumnName("FK_Team");
            entity.Property(e => e.FkWorkplace).HasColumnName("FK_Workplace");
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.FkTeamNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.FkTeam)
                .HasConstraintName("FK__Employee__FK_Tea__1C1D2798");

            entity.HasOne(d => d.FkWorkplaceNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.FkWorkplace)
                .HasConstraintName("FK__Employee__FK_Wor__278EDA44");
        });

        modelBuilder.Entity<Furniture>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Furnitur__3214EC0731BBF250");

            entity.ToTable("Furniture");

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.FkOrder).HasColumnName("FK_Order");

            entity.HasOne(d => d.FkOrderNavigation).WithMany(p => p.Furnitures)
                .HasForeignKey(d => d.FkOrder)
                .HasConstraintName("FK__Furniture__FK_Or__573DED66");
        });

        modelBuilder.Entity<Machine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Machine__3214EC07DB8640D8");

            entity.ToTable("Machine");

            entity.Property(e => e.FkWorkplace).HasColumnName("FK_Workplace");
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.FkWorkplaceNavigation).WithMany(p => p.Machines)
                .HasForeignKey(d => d.FkWorkplace)
                .HasConstraintName("FK__Machine__FK_Work__2A6B46EF");
        });

        modelBuilder.Entity<Operation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Operatio__3214EC077F187D30");

            entity.ToTable("Operation");

            entity.Property(e => e.FkConsumables).HasColumnName("FK_Consumables");
            entity.Property(e => e.FkEmployee).HasColumnName("FK_Employee");
            entity.Property(e => e.FkMachine).HasColumnName("FK_Machine");
            entity.Property(e => e.FkStage).HasColumnName("FK_Stage");
            entity.Property(e => e.StartTime)
                .HasColumnType("datetime")
                .HasColumnName("Start_Time");

            entity.HasOne(d => d.FkConsumablesNavigation).WithMany(p => p.Operations)
                .HasForeignKey(d => d.FkConsumables)
                .HasConstraintName("FK__Operation__FK_Co__6F1576F7");

            entity.HasOne(d => d.FkEmployeeNavigation).WithMany(p => p.Operations)
                .HasForeignKey(d => d.FkEmployee)
                .HasConstraintName("FK__Operation__FK_Em__6E2152BE");

            entity.HasOne(d => d.FkMachineNavigation).WithMany(p => p.Operations)
                .HasForeignKey(d => d.FkMachine)
                .HasConstraintName("FK__Operation__FK_Ma__6D2D2E85");

            entity.HasOne(d => d.FkStageNavigation).WithMany(p => p.Operations)
                .HasForeignKey(d => d.FkStage)
                .HasConstraintName("FK__Operation__FK_St__6C390A4C");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Order__3214EC070681A8E2");

            entity.ToTable("Order");

            entity.Property(e => e.Description).HasMaxLength(1);
            entity.Property(e => e.FkClient).HasColumnName("FK_Client");

            entity.HasOne(d => d.FkClientNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.FkClient)
                .HasConstraintName("FK__Order__FK_Client__4CC05EF3");
        });

        modelBuilder.Entity<Part>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Part__3214EC07D28C9A73");

            entity.ToTable("Part");

            entity.Property(e => e.FkOrder).HasColumnName("FK_Order");
            entity.Property(e => e.FkStorageCell).HasColumnName("FK_Storage_Cell");
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.FkOrderNavigation).WithMany(p => p.Parts)
                .HasForeignKey(d => d.FkOrder)
                .HasConstraintName("FK__Part__FK_Order__34E8D562");

            entity.HasOne(d => d.FkStorageCellNavigation).WithMany(p => p.Parts)
                .HasForeignKey(d => d.FkStorageCell)
                .HasConstraintName("FK__Part__FK_Storage__68687968");
        });

        modelBuilder.Entity<Site>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Site__3214EC070DBAC85E");

            entity.ToTable("Site");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Stage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Stage__3214EC07D080BB29");

            entity.ToTable("Stage");

            entity.Property(e => e.FkTeam).HasColumnName("FK_Team");
            entity.Property(e => e.FkTechnode).HasColumnName("FK_Technode");

            entity.HasOne(d => d.FkTeamNavigation).WithMany(p => p.Stages)
                .HasForeignKey(d => d.FkTeam)
                .HasConstraintName("FK__Stage__FK_Team__4F9CCB9E");

            entity.HasOne(d => d.FkTechnodeNavigation).WithMany(p => p.Stages)
                .HasForeignKey(d => d.FkTechnode)
                .HasConstraintName("FK__Stage__FK_Techno__5090EFD7");
        });

        modelBuilder.Entity<StageConsumable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StageCon__3214EC0742FF1C0F");

            entity.Property(e => e.FkConsumable).HasColumnName("FK_Consumable");
            entity.Property(e => e.FkStage).HasColumnName("FK_Stage");

            entity.HasOne(d => d.FkConsumableNavigation).WithMany(p => p.StageConsumables)
                .HasForeignKey(d => d.FkConsumable)
                .HasConstraintName("FK__StageCons__FK_Co__546180BB");

            entity.HasOne(d => d.FkStageNavigation).WithMany(p => p.StageConsumables)
                .HasForeignKey(d => d.FkStage)
                .HasConstraintName("FK__StageCons__FK_St__536D5C82");
        });

        modelBuilder.Entity<Storage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Storage__3214EC0770A89DD8");

            entity.ToTable("Storage");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<StorageCell>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Storage___3214EC07E7177F5B");

            entity.ToTable("Storage_Cell");

            entity.Property(e => e.FkRack).HasColumnName("FK_Rack");

            entity.HasOne(d => d.FkRackNavigation).WithMany(p => p.StorageCells)
                .HasForeignKey(d => d.FkRack)
                .HasConstraintName("FK__Storage_C__FK_Ra__6774552F");
        });

        modelBuilder.Entity<StorageRack>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Storage___3214EC076EBA3A16");

            entity.ToTable("Storage_Rack");

            entity.Property(e => e.FkStockpile).HasColumnName("FK_Stockpile");

            entity.HasOne(d => d.FkStockpileNavigation).WithMany(p => p.StorageRacks)
                .HasForeignKey(d => d.FkStockpile)
                .HasConstraintName("FK__Storage_R__FK_St__6497E884");
        });

        modelBuilder.Entity<StorageRoom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Storage___3214EC075A6371A7");

            entity.ToTable("Storage_Room");

            entity.Property(e => e.FkStorage).HasColumnName("FK_Storage");

            entity.HasOne(d => d.FkStorageNavigation).WithMany(p => p.StorageRooms)
                .HasForeignKey(d => d.FkStorage)
                .HasConstraintName("FK__Storage_R__FK_St__5C02A283");
        });

        modelBuilder.Entity<StorageSection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Storage___3214EC07D46E5404");

            entity.ToTable("Storage_Section");

            entity.Property(e => e.FkRoom).HasColumnName("FK_Room");

            entity.HasOne(d => d.FkRoomNavigation).WithMany(p => p.StorageSections)
                .HasForeignKey(d => d.FkRoom)
                .HasConstraintName("FK__Storage_S__FK_Ro__5EDF0F2E");
        });

        modelBuilder.Entity<StorageStockpile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Storage___3214EC074547AE8E");

            entity.ToTable("Storage_Stockpile");

            entity.Property(e => e.FkSection).HasColumnName("FK_Section");

            entity.HasOne(d => d.FkSectionNavigation).WithMany(p => p.StorageStockpiles)
                .HasForeignKey(d => d.FkSection)
                .HasConstraintName("FK__Storage_S__FK_Se__61BB7BD9");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Team__3214EC072A6E2CD4");

            entity.ToTable("Team");

            entity.Property(e => e.FkTeamLeader).HasColumnName("FK_Team_Leader");
            entity.Property(e => e.FkWorkType).HasColumnName("FK_Work_Type");

            entity.HasOne(d => d.FkTeamLeaderNavigation).WithMany(p => p.Teams)
                .HasForeignKey(d => d.FkTeamLeader)
                .HasConstraintName("FK__Team__FK_Team_Le__1EF99443");

            entity.HasOne(d => d.FkWorkTypeNavigation).WithMany(p => p.Teams)
                .HasForeignKey(d => d.FkWorkType)
                .HasConstraintName("FK__Team__FK_Work_Ty__21D600EE");
        });

        modelBuilder.Entity<TeamLeader>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Team_Lea__3214EC075A552F22");

            entity.ToTable("Team_Leader");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Technote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Technote__3214EC07AE011ED0");

            entity.ToTable("Technote");

            entity.Property(e => e.Description).HasMaxLength(1);
            entity.Property(e => e.FkOrder).HasColumnName("FK_Order");

            entity.HasOne(d => d.FkOrderNavigation).WithMany(p => p.Technotes)
                .HasForeignKey(d => d.FkOrder)
                .HasConstraintName("FK__Technote__FK_Ord__4BCC3ABA");
        });

        modelBuilder.Entity<WorkType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__work_typ__3214EC07A376EC92");

            entity.ToTable("work_type");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Workplace>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Workplac__3214EC076D2A8131");

            entity.ToTable("Workplace");

            entity.Property(e => e.FkSite).HasColumnName("FK_Site");

            entity.HasOne(d => d.FkSiteNavigation).WithMany(p => p.Workplaces)
                .HasForeignKey(d => d.FkSite)
                .HasConstraintName("FK__Workplace__FK_Si__269AB60B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
