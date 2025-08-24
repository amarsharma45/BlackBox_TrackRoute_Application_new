using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TrackRoute_Application.Core.DTO;

namespace TrackRoute_Application.Infrastructure.Entities;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Leave empty OR remove entirely since DI will handle it.
    }
    //public DbSet<User> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
