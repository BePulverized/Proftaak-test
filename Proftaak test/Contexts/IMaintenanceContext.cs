using System.Collections.Generic;
using Proftaak_test;

namespace ICT4Rails
{
    public interface IMaintenanceContext {
        List<TramOnderhoud> Maintenances
        {
            get;
        }

        void Create(TramOnderhoud maintenance);
        List<TramOnderhoud> GetAll();
        void Update(TramOnderhoud maintenance);
        void Delete(TramOnderhoud maintenance);
    }
}