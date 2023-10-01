using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Otel.DAL.EntityConfig.Abstract;
using Otel.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.DAL.EntityConfig.Concrete
{
 public class HotelConfig:BaseConfig<Hotel>
    {
        public override void Configure(EntityTypeBuilder<Hotel> builder)
        {
            base.Configure(builder);
            
            builder.Property(p => p.PostaCode).HasMaxLength(50);
            builder.Property(p => p.Adres).HasMaxLength(200);
           


            builder.Property(p => p.HotelName).HasMaxLength(100);
            //Ayni birimden ikinci kayit olmasin
            builder.HasIndex(p => p.HotelName).IsUnique();
         


        }
    }
}
