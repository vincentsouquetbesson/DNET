using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormationPOEwebADN
{
    public class AcideNucleotide
    {
        private List<Base> complementaryList;
        private List<Base> baseList;

        public List<Base> getBaseList(String brin)
        {
            baseList = new List<Base>();
            complementaryList = new List<Base>();
            for (int i = 0; i < brin.Length; i++)
            {
                baseList.Add(new Base(brin.substring(i, i + 1)));
                complementaryList.Add(new Base(baseList[i].getAppariement()));
            }
            return baseList;
        }

        public void setBaseList(List<Base> baseList)
        {
            this.baseList = baseList;
        }

        public List<Base> getBaseList()
        {
            return baseList;
        }

        public List<Base> getComplementaryList()
        {
            return complementaryList;
        }
    }
}