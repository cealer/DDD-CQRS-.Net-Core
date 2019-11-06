using EVALUACION.DOMAIN.AggregatesModel.OCAggregate;
using EVALUACION.DOMAIN.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EVALUACION.INFRASTRUCTURE.Repositories
{
    public class HP_OC_Repository : IHP_OC_REPOSITORY
    {
        private readonly OCContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public HP_OC_Repository(OCContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public HP_OC Add(HP_OC hP_OC)
        {
            return _context.HP_OC.Add(hP_OC).Entity;
        }

        public void Update(HP_OC hP_OC)
        {
            _context.Entry(hP_OC).State = EntityState.Modified;
        }

        public void Delete(HP_OC hP_OC)
        {
            _context.Entry(hP_OC).State = EntityState.Deleted;
        }

        public async Task<HP_OC> GetAsync(int ID_HP_OC)
        {
            var hp_oc = await _context.HP_OC.FindAsync(ID_HP_OC);
            return hp_oc;
        }
    }
}
