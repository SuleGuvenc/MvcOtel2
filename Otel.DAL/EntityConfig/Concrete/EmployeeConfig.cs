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
public class EmployeeConfig:BaseConfig<Employee>
    {
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.Gsm).HasMaxLength
                (50);
            builder.Property(p => p.Mail).HasMaxLength(50);
            builder.Property(p => p.Surname).HasMaxLength(50);
            builder.Property(p => p.Name).HasMaxLength(50);


            
           
            builder.HasIndex(p => p.Mail).IsUnique();
            builder.HasIndex(p => p.Gsm).IsUnique();

        }

    }
}
