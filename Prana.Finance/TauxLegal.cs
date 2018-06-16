using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prana.Finance
{

    public static class TauxLegal
    {
        public struct TauxPeriode
        {
            public int Annee;
            public int Semestre;
            public float TauxParticulier;
            public float TauxProfessionnel;
            public float TauxMajoration;
        }

        public static List<TauxPeriode> TauxPeriodes;

        /// <summary>
        /// COnstructeur static appelé à la première utilisation de la classe
        /// </summary>
        static TauxLegal()
        {
            TauxPeriodes = new List<TauxPeriode>();

            TauxPeriodes.Add(new TauxPeriode { Annee = 1991, Semestre = 1, TauxParticulier = 10.26F, TauxProfessionnel = 10.26F, TauxMajoration = 5 });
            TauxPeriodes.Add(new TauxPeriode { Annee = 1991, Semestre = 2, TauxParticulier = 10.26F, TauxProfessionnel = 10.26F, TauxMajoration = 5 });

            TauxPeriodes.Add(new TauxPeriode { Annee = 1992, Semestre = 1, TauxParticulier = 9.69F, TauxProfessionnel = 9.69F, TauxMajoration = 5 });
            TauxPeriodes.Add(new TauxPeriode { Annee = 1992, Semestre = 2, TauxParticulier = 9.69F, TauxProfessionnel = 9.69F, TauxMajoration = 5 });

            TauxPeriodes.Add(new TauxPeriode { Annee = 1993, Semestre = 1, TauxParticulier = 10.40F, TauxProfessionnel = 10.40F, TauxMajoration = 5 });
            TauxPeriodes.Add(new TauxPeriode { Annee = 1993, Semestre = 2, TauxParticulier = 10.40F, TauxProfessionnel = 10.40F, TauxMajoration = 5 });

            TauxPeriodes.Add(new TauxPeriode { Annee = 1994, Semestre = 1, TauxParticulier = 8.40F, TauxProfessionnel = 8.40F, TauxMajoration = 5 });
            TauxPeriodes.Add(new TauxPeriode { Annee = 1994, Semestre = 2, TauxParticulier = 8.40F, TauxProfessionnel = 8.40F, TauxMajoration = 5 });

            TauxPeriodes.Add(new TauxPeriode { Annee = 1995, Semestre = 1, TauxParticulier = 5.82F, TauxProfessionnel = 5.82F, TauxMajoration = 5 });
            TauxPeriodes.Add(new TauxPeriode { Annee = 1995, Semestre = 2, TauxParticulier = 5.82F, TauxProfessionnel = 5.82F, TauxMajoration = 5 });

            TauxPeriodes.Add(new TauxPeriode { Annee = 1996, Semestre = 1, TauxParticulier = 6.65F, TauxProfessionnel = 6.65F, TauxMajoration = 5 });
            TauxPeriodes.Add(new TauxPeriode { Annee = 1996, Semestre = 2, TauxParticulier = 6.65F, TauxProfessionnel = 6.65F, TauxMajoration = 5 });

            TauxPeriodes.Add(new TauxPeriode { Annee = 1997, Semestre = 1, TauxParticulier = 3.87F, TauxProfessionnel = 3.87F, TauxMajoration = 5 });
            TauxPeriodes.Add(new TauxPeriode { Annee = 1997, Semestre = 2, TauxParticulier = 3.87F, TauxProfessionnel = 3.87F, TauxMajoration = 5 });

            TauxPeriodes.Add(new TauxPeriode { Annee = 1998, Semestre = 1, TauxParticulier = 3.36F, TauxProfessionnel = 3.36F, TauxMajoration = 5 });
            TauxPeriodes.Add(new TauxPeriode { Annee = 1998, Semestre = 2, TauxParticulier = 3.36F, TauxProfessionnel = 3.36F, TauxMajoration = 5 });

            TauxPeriodes.Add(new TauxPeriode { Annee = 1999, Semestre = 1, TauxParticulier = 3.47F, TauxProfessionnel = 3.47F, TauxMajoration = 5 });
            TauxPeriodes.Add(new TauxPeriode { Annee = 1999, Semestre = 2, TauxParticulier = 3.47F, TauxProfessionnel = 3.47F, TauxMajoration = 5 });

            TauxPeriodes.Add(new TauxPeriode { Annee = 2000, Semestre = 1, TauxParticulier = 2.74F, TauxProfessionnel = 2.74F, TauxMajoration = 5 });
            TauxPeriodes.Add(new TauxPeriode { Annee = 2000, Semestre = 2, TauxParticulier = 2.74F, TauxProfessionnel = 2.74F, TauxMajoration = 5 });

            TauxPeriodes.Add(new TauxPeriode { Annee = 2001, Semestre = 1, TauxParticulier = 4.26F, TauxProfessionnel = 4.26F, TauxMajoration = 5 });
            TauxPeriodes.Add(new TauxPeriode { Annee = 2001, Semestre = 2, TauxParticulier = 4.26F, TauxProfessionnel = 4.26F, TauxMajoration = 5 });

            TauxPeriodes.Add(new TauxPeriode { Annee = 2002, Semestre = 1, TauxParticulier = 4.26F, TauxProfessionnel = 4.26F, TauxMajoration = 5 });
            TauxPeriodes.Add(new TauxPeriode { Annee = 2002, Semestre = 2, TauxParticulier = 4.26F, TauxProfessionnel = 4.26F, TauxMajoration = 5 });

            TauxPeriodes.Add(new TauxPeriode { Annee = 2003, Semestre = 1, TauxParticulier = 3.29F, TauxProfessionnel = 3.29F, TauxMajoration = 5 });
            TauxPeriodes.Add(new TauxPeriode { Annee = 2003, Semestre = 2, TauxParticulier = 3.29F, TauxProfessionnel = 3.29F, TauxMajoration = 5 });

            TauxPeriodes.Add(new TauxPeriode { Annee = 2004, Semestre = 1, TauxParticulier = 2.27F, TauxProfessionnel = 2.27F, TauxMajoration = 5 });
            TauxPeriodes.Add(new TauxPeriode { Annee = 2004, Semestre = 2, TauxParticulier = 2.27F, TauxProfessionnel = 2.27F, TauxMajoration = 5 });

            TauxPeriodes.Add(new TauxPeriode { Annee = 2005, Semestre = 1, TauxParticulier = 2.05F, TauxProfessionnel = 2.05F, TauxMajoration = 5 });
            TauxPeriodes.Add(new TauxPeriode { Annee = 2005, Semestre = 2, TauxParticulier = 2.05F, TauxProfessionnel = 2.05F, TauxMajoration = 5 });

            TauxPeriodes.Add(new TauxPeriode { Annee = 2006, Semestre = 1, TauxParticulier = 2.11F, TauxProfessionnel = 2.11F, TauxMajoration = 5 });
            TauxPeriodes.Add(new TauxPeriode { Annee = 2006, Semestre = 2, TauxParticulier = 2.11F, TauxProfessionnel = 2.11F, TauxMajoration = 5 });

            TauxPeriodes.Add(new TauxPeriode { Annee = 2007, Semestre = 1, TauxParticulier = 2.95F, TauxProfessionnel = 2.95F, TauxMajoration = 5 });
            TauxPeriodes.Add(new TauxPeriode { Annee = 2007, Semestre = 2, TauxParticulier = 2.95F, TauxProfessionnel = 2.95F, TauxMajoration = 5 });

            TauxPeriodes.Add(new TauxPeriode { Annee = 2008, Semestre = 1, TauxParticulier = 3.99F, TauxProfessionnel = 3.99F, TauxMajoration = 5 });
            TauxPeriodes.Add(new TauxPeriode { Annee = 2008, Semestre = 2, TauxParticulier = 3.99F, TauxProfessionnel = 3.99F, TauxMajoration = 5 });

            TauxPeriodes.Add(new TauxPeriode { Annee = 2009, Semestre = 1, TauxParticulier = 3.79F, TauxProfessionnel = 3.79F, TauxMajoration = 5 });
            TauxPeriodes.Add(new TauxPeriode { Annee = 2009, Semestre = 2, TauxParticulier = 3.79F, TauxProfessionnel = 3.79F, TauxMajoration = 5 });

            TauxPeriodes.Add(new TauxPeriode { Annee = 2010, Semestre = 1, TauxParticulier = 0.65F, TauxProfessionnel = 0.65F, TauxMajoration = 5 });
            TauxPeriodes.Add(new TauxPeriode { Annee = 2010, Semestre = 2, TauxParticulier = 0.65F, TauxProfessionnel = 0.65F, TauxMajoration = 5 });

            TauxPeriodes.Add(new TauxPeriode { Annee = 2011, Semestre = 1, TauxParticulier = 0.38F, TauxProfessionnel = 0.38F, TauxMajoration = 5 });
            TauxPeriodes.Add(new TauxPeriode { Annee = 2011, Semestre = 2, TauxParticulier = 0.38F, TauxProfessionnel = 0.38F, TauxMajoration = 5 });

            TauxPeriodes.Add(new TauxPeriode { Annee = 2012, Semestre = 1, TauxParticulier = 0.71F, TauxProfessionnel = 0.71F, TauxMajoration = 5 });
            TauxPeriodes.Add(new TauxPeriode { Annee = 2012, Semestre = 2, TauxParticulier = 0.71F, TauxProfessionnel = 0.71F, TauxMajoration = 5 });

            TauxPeriodes.Add(new TauxPeriode { Annee = 2013, Semestre = 1, TauxParticulier = 0.04F, TauxProfessionnel = 0.04F, TauxMajoration = 5 });
            TauxPeriodes.Add(new TauxPeriode { Annee = 2013, Semestre = 2, TauxParticulier = 0.04F, TauxProfessionnel = 0.04F, TauxMajoration = 5 });

            TauxPeriodes.Add(new TauxPeriode { Annee = 2014, Semestre = 1, TauxParticulier = 0.04F, TauxProfessionnel = 0.04F, TauxMajoration = 5 });
            TauxPeriodes.Add(new TauxPeriode { Annee = 2014, Semestre = 2, TauxParticulier = 0.04F, TauxProfessionnel = 0.04F, TauxMajoration = 5 });

            // mise en place de la réforme 2014
            TauxPeriodes.Add(new TauxPeriode { Annee = 2015, Semestre = 1, TauxParticulier = 4.06F, TauxProfessionnel = 0.93F, TauxMajoration = 5 });
            TauxPeriodes.Add(new TauxPeriode { Annee = 2015, Semestre = 2, TauxParticulier = 4.29F, TauxProfessionnel = 0.99F, TauxMajoration = 5 });

            TauxPeriodes.Add(new TauxPeriode { Annee = 2016, Semestre = 1, TauxParticulier = 4.54F, TauxProfessionnel = 1.01F, TauxMajoration = 5 });
            TauxPeriodes.Add(new TauxPeriode { Annee = 2016, Semestre = 2, TauxParticulier = 4.35F, TauxProfessionnel = 0.93F, TauxMajoration = 5 });

            TauxPeriodes.Add(new TauxPeriode { Annee = 2017, Semestre = 1, TauxParticulier = 4.16F, TauxProfessionnel = 0.90F, TauxMajoration = 5 });
            TauxPeriodes.Add(new TauxPeriode { Annee = 2017, Semestre = 2, TauxParticulier = 3.94F, TauxProfessionnel = 0.90F, TauxMajoration = 5 });

            TauxPeriodes.Add(new TauxPeriode { Annee = 2018, Semestre = 1, TauxParticulier = 3.73F, TauxProfessionnel = 0.99F, TauxMajoration = 5 });
//            TauxPeriodes.Add(new TauxPeriode { Annee = 2018, Semestre = 2, TauxParticulier = 3.73F, TauxProfessionnel = 0.99F, TauxMajoration = 5 });
        }
    }
}
