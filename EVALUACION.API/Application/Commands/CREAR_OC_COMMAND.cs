using EVALUACION.API.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace EVALUACION.API.Application.Commands
{
    [DataContract]
    public class CREAR_OC_COMMAND : IRequest<OC_DTO>
    {
        [DataMember]
        public int N_ID_ESTADO { get; set; }
        [DataMember]
        public int N_ID_PROVEEDOR { get; set; }
        [DataMember]
        public List<OC_DET_DTO> oC_DET_DTOs { get; set; }

        public CREAR_OC_COMMAND(int N_ID_ESTADO, int N_ID_PROVEEDOR, List<OC_DET_DTO> oC_DET_DTOs)
        {
            this.oC_DET_DTOs = oC_DET_DTOs;
            this.N_ID_ESTADO = N_ID_ESTADO;
            this.N_ID_PROVEEDOR = N_ID_PROVEEDOR;
            this.oC_DET_DTOs = oC_DET_DTOs;
        }
    }
}
