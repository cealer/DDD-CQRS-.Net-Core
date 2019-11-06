using EVALUACION.DOMAIN.AggregatesModel.OCAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVALUACION.INFRASTRUCTURE.EntityConfigurations
{
    public class HP_OC_EntityTypeConfiguration : IEntityTypeConfiguration<HP_OC_DET>
    {
        public void Configure(EntityTypeBuilder<HP_OC_DET> hp_OC_DETConfiguration)
        {
            hp_OC_DETConfiguration.ToTable("HP_OC_DET", OCContext.DEFAULT_SCHEMA);

            hp_OC_DETConfiguration.
                HasKey(o => o.N_ID_OC_DET).HasName("PK_HP_OC_DET");

            hp_OC_DETConfiguration.Property(o => o.N_ID_OC_DET)
                .ForSqlServerUseSequenceHiLo("HP_OC_DET_seq", OCContext.DEFAULT_SCHEMA);

            hp_OC_DETConfiguration.Property(p => p.N_ID_OC_DET);

            hp_OC_DETConfiguration.Property(o => o.FECHA_ESTIMADA)
                .IsRequired();

            hp_OC_DETConfiguration.Property(o => o.ID_FABRICANTE)
                .IsRequired();

            hp_OC_DETConfiguration.Property(o => o.OBSERVACION)
                .HasColumnType("VARCHAR(100)")
            .IsRequired();

            hp_OC_DETConfiguration.Property(o => o.TURNO)
                                .HasColumnType("VARCHAR(1)")
            .IsRequired();

            hp_OC_DETConfiguration.Property(o => o.ID_PRODUCTO)
            .IsRequired();

            hp_OC_DETConfiguration.HasOne(o => o.HP_OC)
                         .WithMany(x => x.hP_OC_DETs)
                         .HasForeignKey(o => o.ID_HP_OC)
                         .IsRequired();

        }

    }
}
