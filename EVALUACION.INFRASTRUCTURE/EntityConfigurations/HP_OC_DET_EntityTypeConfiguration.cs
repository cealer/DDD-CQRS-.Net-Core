using EVALUACION.DOMAIN.AggregatesModel.OCAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVALUACION.INFRASTRUCTURE.EntityConfigurations
{
    public class HP_OC_DET_EntityTypeConfiguration : IEntityTypeConfiguration<HP_OC>
    {
        public void Configure(EntityTypeBuilder<HP_OC> hp_OCConfiguration)
        {
            hp_OCConfiguration.ToTable("HP_OC", OCContext.DEFAULT_SCHEMA);

            hp_OCConfiguration.
                HasKey(o => o.ID_HP_OC).HasName("PK_ID_HP_OC");

            hp_OCConfiguration.Property(o => o.ID_HP_OC)
                .ForSqlServerUseSequenceHiLo("HP_OC_seq", OCContext.DEFAULT_SCHEMA);

            hp_OCConfiguration.Property(p => p.ID_HP_OC);

            hp_OCConfiguration.Property(o => o.FECHA_REGISTRO)
                .IsRequired();

            hp_OCConfiguration.Property(o => o.N_ID_ESTADO)
                .IsRequired();

            hp_OCConfiguration.Property(o => o.N_ID_PROVEEDOR)
                .IsRequired();

        }

    }
}
