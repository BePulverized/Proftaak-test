using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proftaak_test.Repository
{
    public class TramRepo
    {
        private TramDBContext context;

        public TramRepo(TramDBContext context)
        {
            this.context = context;
        }

        public Sector GetDriveInSector()
        {
            return context.GetDriveInSector();
        }

        public List<Tram> GetAllTrams()
        {
            return context.GetAllTrams();
        }

        public Tram GetTrambyID(int id)
        {
            return context.GetTrambyID(id);
        }
    }
}