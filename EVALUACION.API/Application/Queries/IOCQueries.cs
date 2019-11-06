using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVALUACION.API.Application.Queries
{
    public interface IOCQueries
    {
        Task<OCViewModel> ObtenerOCAsync(int id);
        Task<IEnumerable<OCViewModel>> ListarAsync();
    }
}
