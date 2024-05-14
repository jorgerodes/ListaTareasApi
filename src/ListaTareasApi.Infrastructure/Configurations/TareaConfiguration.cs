using ListaTareasApi.Domain.Tareas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaTareasApi.Infrastructure.Configurations
{
    internal sealed class TareaConfiguration : IEntityTypeConfiguration<Tarea>
    {
        public void Configure(EntityTypeBuilder<Tarea> builder)
        {
            builder.ToTable("tareas");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasConversion(x => x!.Value, value => new TareaId(value));

            builder.Property(x => x.Nombre)
                .HasMaxLength(200)
                .HasConversion(x => x!.Value, value => new Nombre(value));

            builder.Property(x => x.Orden)
                .HasConversion(x => x!.Value, value => new Orden(value));
        }
    }
}
