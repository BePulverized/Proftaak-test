using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proftaak_test.Repository
{
    public class SpoorRepo
    {
        private SpoorDBContext context;

        public SpoorRepo(SpoorDBContext context)
        { 
            this.context = context;
        }

        public List<Spoor> GetAllSporen()
        {
            return context.GetAllSporen();
        }
    }
}