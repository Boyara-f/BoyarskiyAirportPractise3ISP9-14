using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BoyarskiyAirport.DB;

namespace BoyarskiyAirport.Helper
{
    
    public class ClassHelper
    {
        public static bool isAdmin = false;
        public static int currentUserID ;
        public static AirportEntities Context { get; } = new AirportEntities();
    }
}
