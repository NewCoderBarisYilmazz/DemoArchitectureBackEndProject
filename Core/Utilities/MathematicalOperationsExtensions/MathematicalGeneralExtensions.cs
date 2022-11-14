using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.MathematicalOperationsExtensions
{
    public static class MathematicalGeneralExtensions
    {

        public static  decimal ConvertLongToMbMethod( this long deger)
        {
            return  Convert.ToDecimal(deger * 0.000001);
        }

    }
}
