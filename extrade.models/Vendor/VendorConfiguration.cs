﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace UmbrellaTrading.Models
{
    public class VendorConfiguration : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> builder)
        {
            builder.ToTable("Vendor");
            builder.HasKey(v => v.UserID);
            builder.Property(v => v.BrandName).HasMaxLength(30).IsRequired();
            builder.Property(v => v.VendorStatus).IsRequired().HasDefaultValue(VendorStatus.pending);
            builder.Property(v => v.IsDeleted).HasDefaultValue(false);


        }
    }
}
