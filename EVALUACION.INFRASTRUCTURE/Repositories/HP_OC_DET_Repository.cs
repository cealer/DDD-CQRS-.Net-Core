using EVALUACION.DOMAIN.AggregatesModel.OCAggregate;
using EVALUACION.DOMAIN.AggregatesModel.OCAggregate._HP_OC_DET_DET;
using EVALUACION.DOMAIN.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EVALUACION.INFRASTRUCTURE.Repositories
{
    public class HP_OC_DET_Repository : IHP_OC_DET_DET_REPOSITORY
    {
        private readonly OCContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public HP_OC_DET_Repository(OCContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public HP_OC_DET Add(HP_OC_DET hP_OC_DET)
        {
            return _context.HP_OC_DET.Add(hP_OC_DET).Entity;
        }

        public void Update(HP_OC_DET hP_OC_DET)
        {
            _context.Entry(hP_OC_DET).State = EntityState.Modified;
        }

        public void Delete(HP_OC_DET hP_OC_DET)
        {
            _context.Entry(hP_OC_DET).State = EntityState.Deleted;
        }

        public async Task<HP_OC_DET> GetAsync(int ID_HP_OC)
        {
            var hp_oc = await _context.HP_OC_DET.FindAsync(ID_HP_OC);
            if (hp_oc != null)
            {
                await _context.Entry(hp_oc)
                    .Reference(i => i.HP_OC).LoadAsync();
            }
            return hp_oc;
        }

    }
}
