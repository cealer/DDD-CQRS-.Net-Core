using MediatR;
using System.Runtime.Serialization;

namespace EVALUACION.API.Application.Commands
{
    [DataContract]

    public class EDITAR_OC_COMMAND : IRequest<bool>
    {
        [DataMember]
        public int ID_HP_OC { get; set; }
        [DataMember]
        public int N_ID_ESTADO { get; set; }
        [DataMember]
        public int N_ID_PROVEEDOR { get; set; }

        public EDITAR_OC_COMMAND(int ID_HP_OC, int N_ID_ESTADO, int N_ID_PROVEEDOR)
        {
            this.ID_HP_OC = ID_HP_OC;
            this.N_ID_ESTADO = N_ID_ESTADO;
            this.N_ID_PROVEEDOR = N_ID_PROVEEDOR;

        }
    }
}
