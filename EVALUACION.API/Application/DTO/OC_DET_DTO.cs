using System;

namespace EVALUACION.API.Application.DTO
{
    public class OC_DET_DTO
    {
        public int ID_HP_OC { get; set; }
        public int ID_PRODUCTO { get; set; }
        public string TURNO { get; set; }
        public string OBSERVACION { get; set; }
        public int ID_FABRICANTE { get; set; }
        public DateTime FECHAESTIMADA { get; set; }
    }
}
