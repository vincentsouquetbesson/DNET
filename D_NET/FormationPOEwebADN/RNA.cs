using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormationPOEwebADN
{
    public class RNA : AcideNucleotide
    {
        public RNA( List<Base> baseList)
        {
            base.setBaseList(baseList);

        }

    }
}