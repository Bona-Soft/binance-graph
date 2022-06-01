using MGK.ServiceBase.DAL.Infrastructure.UnitOfWork;
using BSoft.DemoApp.DataAccess.Contexts;
using BSoft.DemoApp.DataAccess.Infrastructure.UnitOfWork;

namespace BSoft.DemoApp.DataAccess.UnitOfWork
{
    public class ProofOfConceptUoW : UnitOfWork<AppContext>, IProofOfConceptUoW
    {
        public ProofOfConceptUoW(AppContext context)
            : base(context)
        {
        }
    }
}
