using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

public partial class NascarDBContext : DbContext
{
    public NascarDBContext()
    {
    }

    public NascarDBContext(DbContextOptions<NascarDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CupSeries> CupSeries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("SERVER=(localdb)\\MSSQLLocalDB;DATABASE= nascardb;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CupSeries>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cup seri__3213E83F2E5FB9AD");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
