using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormationPOEwebADN
{
    public abstract class DNA : AcideNucleotide
    {
        private List<Base> baseList;
        private List<Base> complementaryList;  //getter
        private RNA rna;




        public void getDNA(String brin)
        {
            baseList = base.getBaseList(brin);
            complementaryList = base.getComplementaryList();

            Console.WriteLine(baseList);
            Console.WriteLine(complementaryList);
        }



        public String toString()
        {
            String reponse = "";
            for (int i = 0; i < baseList.Count(); i++)
            {
                reponse = reponse + baseList[i].toString() + " ";
            }
            return "brin:                 " + reponse;
        }


        public RNA getRNA()
        {
            Console.WriteLine(baseList.Count());
            rna = new RNA(baseList);
            return rna;
        }
    }
}