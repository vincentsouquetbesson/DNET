using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormationPOEwebADN
{
    public class Base
    {
        private String symbol;
        private String name;
        private String appariement;


        public Base(String type)
        {
            switch (type)
            {
                case "A":
                    this.symbol = "A";
                    this.name = "Adénine";
                    this.appariement = "T";
                    break;
                case "C":
                    this.symbol = "C";
                    this.name = "Cytosine";
                    this.appariement = "G";
                    break;
                case "G":
                    this.symbol = "G";
                    this.name = "Guanine";
                    this.appariement = "C";
                    break;
                case "T":
                    this.symbol = "T";
                    this.name = "Thymine";
                    this.appariement = "A";
                    break;
                case "U":
                    this.symbol = "U";
                    this.name = "Uracile";
                    this.appariement = "A";
                    break;
                default:
                    Console.WriteLine("Erreur");
                    break;

            }
        }


        public String toString()
        {
            return name;
        }

        public String getAppariement()
        {
            return appariement;
        }

        public String getSymbol()
        {
            return symbol;
        }
    }
}