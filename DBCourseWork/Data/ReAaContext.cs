using System;
using System.Collections.Generic;
using System.Printing;
using DBCourseWork.Models;
using Microsoft.EntityFrameworkCore;

namespace DBCourseWork.Data;

public partial class ReAaContext : DbContext
{
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Models.Task> Tasks { get; set; }
    public DbSet<Furniture> Furnitures { get; set; }
    public DbSet<Team> Teams { get; set; }

    public ReAaContext()
    {
        
        if(Database.EnsureCreated() == true)
        {
            SetUp();
        }

        Roles.Load();
        Users.Load();
        Clients.Load();
        Orders.Load();
        Tasks.Load();
        Furnitures.Load();
        Teams.Load();

    }

    private void SetUp()
    {
        Role Admin = new()
        {
            Name = "admin"
        };
        Role User = new()
        {
            Name= "user"
        };

        Roles.Add(Admin);
        Roles.Add(User);
        SaveChanges();

        User admin = new()
        {
            Name = "admin",
            password = "admin",
            Role = Roles.FirstOrDefault(r => r.Name == "admin")
        };
        User user = new()
        {
            Name = "user",
            password = "user",
            Role = Roles.FirstOrDefault(r => r.Name == "user")
        };

        Users.Add(admin);
        Users.Add(user);
        SaveChanges();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=main.db");
    }
}
