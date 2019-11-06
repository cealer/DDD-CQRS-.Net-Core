using EVALUACION.DOMAIN.Exceptions;
using EVALUACION.DOMAIN.SeedWork;
using System;
using System.Collections.Generic;

namespace EVALUACION.DOMAIN.AggregatesModel.OCAggregate
{
    public class HP_OC : IAggregateRoot
    {
        public int ID_HP_OC { get; private set; }
        public int N_ID_ESTADO { get; private set; }
        public int N_ID_PROVEEDOR { get; private set; }
        public DateTime FECHA_REGISTRO { get; private set; }
        public IEnumerable<HP_OC_DET> hP_OC_DETs { get; set; }

        public HP_OC(int N_ID_ESTADO, int N_ID_PROVEEDOR)
        {
            this.N_ID_ESTADO = N_ID_ESTADO > 0 ? N_ID_ESTADO : throw new OCDomainException($"{nameof(N_ID_ESTADO)} no espeficiado");
            this.N_ID_PROVEEDOR = N_ID_PROVEEDOR > 0 ? N_ID_PROVEEDOR : throw new OCDomainException($"{nameof(N_ID_PROVEEDOR)} no espeficiado"); ;
            this.FECHA_REGISTRO = DateTime.Now;
            this.hP_OC_DETs = new HashSet<HP_OC_DET>();
        }

        public void Modificar(int N_ID_ESTADO, int N_ID_PROVEEDOR)
        {
            this.N_ID_ESTADO = N_ID_ESTADO;
            this.N_ID_PROVEEDOR = N_ID_PROVEEDOR;
        }

    }
}
