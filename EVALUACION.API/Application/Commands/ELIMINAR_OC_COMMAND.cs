using MediatR;
using System.Runtime.Serialization;

namespace EVALUACION.API.Application.Commands
{
    [DataContract]
    public class ELIMINAR_OC_COMMAND : IRequest<bool>
    {
        [DataMember]
        public int ID_HP_OC { get; private set; }

        public ELIMINAR_OC_COMMAND(int ID_HP_OC)
        {
            this.ID_HP_OC = ID_HP_OC;
        }

    }

}
