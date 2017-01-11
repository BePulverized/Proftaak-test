using System;
using System.Collections.Generic;
using ICT4Rails;

namespace Proftaak_test
{
    class MaintenanceMemoryContext : IMaintenanceContext
    {
        public List<TramOnderhoud> Maintenances { get; private set; }

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public MaintenanceMemoryContext()
        {
            GetAll();
        }

        public void Delete(TramOnderhoud maintenance)
        {
            Maintenances.Remove(maintenance);
        }

        public void Create(TramOnderhoud maintenance)
        {
            Maintenances.Add(maintenance);
        }

        public List<TramOnderhoud> GetAll()
        {
            Maintenances = new List<TramOnderhoud>()
            {
                new TramOnderhoud()
                {
                    Id = 0,
                    DatumTijdstip = DateTime.MinValue,
                    BeschikbaarDatum = DateTime.MaxValue,
                    Onderhoudstypeid = 1

                }
            };
            return Maintenances;
        }

        public void Update(TramOnderhoud maintenance)
        {

        }
    }
}