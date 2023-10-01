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
   public class BookingConfig:BaseConfig<Booking>
    {
        public override void Configure(EntityTypeBuilder<Booking> builder)
        {
            base.Configure(builder);
        }
    }
}
