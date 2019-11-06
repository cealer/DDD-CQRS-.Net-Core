using EVALUACION.DOMAIN.SeedWork;
using System.Threading.Tasks;

namespace EVALUACION.DOMAIN.AggregatesModel.OCAggregate._HP_OC_DET_DET
{
    public interface IHP_OC_DET_DET_REPOSITORY : IRepository<HP_OC_DET>
    {
        HP_OC_DET Add(HP_OC_DET hP_OC_DET);

        void Update(HP_OC_DET hP_OC_DET);

        void Delete(HP_OC_DET hP_OC_DET);

        Task<HP_OC_DET> GetAsync(int N_ID_OC_DET);

    }
}
