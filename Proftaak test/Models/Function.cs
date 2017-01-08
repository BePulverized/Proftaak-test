using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Proftaak_test
{
    public class Function
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Rights Rights { get; set; }

        public Function(int id, string name, Rights rights)
        {
            ID = id;
            Name = name;
            Rights = rights;
        }

    }
}