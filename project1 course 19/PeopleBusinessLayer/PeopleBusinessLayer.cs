using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeopleDataAccessLayer;

namespace PeopleBusinessLayer
{
    public class clsPeopleBusinessLayer
    {
        public static DataTable GetAllCountries()
        {
            return PeopleDataAccess.GetAllCountries();

        }
        public static DataTable GetAllPeople()
        {
            return PeopleDataAccess.GetAllPeople();

        }
      
           
        
    }
}
