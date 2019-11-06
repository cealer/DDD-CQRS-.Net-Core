using EVALUACION.DOMAIN.SeedWork;
using System;

namespace EVALUACION.DOMAIN.AggregatesModel.OCAggregate
{
    public class HP_OC_DET : IAggregateRoot
    {
        public int N_ID_OC_DET { get; private set; }
        public int ID_HP_OC { get; private set; }
        public virtual HP_OC HP_OC { get; private set; }
        public int ID_PRODUCTO { get; private set; }
        public string TURNO { get; private set; }
        public DateTime FECHA_ESTIMADA { get; private set; }
        public string OBSERVACION { get; private set; }
        public int ID_FABRICANTE { get; private set; }

        public HP_OC_DET(int ID_HP_OC, int ID_PRODUCTO, string TURNO, DateTime FECHA_ESTIMADA,
            string OBSERVACION, int ID_FABRICANTE)
        {
            this.ID_HP_OC = ID_HP_OC;
            this.ID_PRODUCTO = ID_PRODUCTO;
            this.TURNO = TURNO;
            this.FECHA_ESTIMADA = FECHA_ESTIMADA;
            this.OBSERVACION = OBSERVACION;
            this.ID_FABRICANTE = ID_FABRICANTE;
        }

    }
}
