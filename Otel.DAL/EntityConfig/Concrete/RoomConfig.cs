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
 public class RoomConfig:BaseConfig<Room>
    {
        public override void Configure(EntityTypeBuilder<Room> builder)
        {
            base.Configure(builder);
         
            builder.Property(p => p.RoomNo).HasMaxLength(50);
            builder.Property(p => p.RoomType).HasMaxLength(50);
           

        }
    }
}
