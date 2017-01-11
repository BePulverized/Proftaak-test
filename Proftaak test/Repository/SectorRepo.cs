using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proftaak_test.Repository
{
    public class SectorRepo
    {
        private SectorDBContext context;

        public SectorRepo(SectorDBContext context)
        {
            this.context = context;
        }

        public List<Sector> GetAllSectors()
        {
            return context.GetAllSectors();
        }
    }
}