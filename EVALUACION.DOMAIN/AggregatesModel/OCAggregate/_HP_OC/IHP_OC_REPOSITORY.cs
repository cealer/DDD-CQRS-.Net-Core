using EVALUACION.DOMAIN.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EVALUACION.DOMAIN.AggregatesModel.OCAggregate
{
    public interface IHP_OC_REPOSITORY : IRepository<HP_OC>
    {
        HP_OC Add(HP_OC hP_OC);

        void Update(HP_OC hP_OC);

        void Delete(HP_OC hP_OC);

        Task<HP_OC> GetAsync(int ID_HP_OC);

    }
}
