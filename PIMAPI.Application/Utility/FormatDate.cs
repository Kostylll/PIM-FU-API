using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMAPI.Application.Utility
{
    public static class FormatDate
    {
      
        public static string FormatDateUtility(string dateString)
        {
            DateTime date = DateTime.Parse(dateString);

           
            return date.ToString("dd/MM/yyyy");
        }
    }

}
