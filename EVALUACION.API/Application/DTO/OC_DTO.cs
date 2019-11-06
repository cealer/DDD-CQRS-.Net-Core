using System.Collections.Generic;

namespace EVALUACION.API.Application.DTO
{
    public class OC_DTO
    {
        public int N_ID_ESTADO { get; set; }
        public int N_ID_PROVEEDOR { get; set; }
        public List<OC_DET_DTO> oC_DET_DTOs { get; set; }

    }
}
