using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebPhoneEcommerce.Models.Entity;

public partial class PhoneEcommerceContext : DbContext
{
    public PhoneEcommerceContext()
    {
    }

    public PhoneEcommerceContext(DbContextOptions<PhoneEcommerceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=connectString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC0708AA8ABB");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
