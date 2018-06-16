using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prana.Finance
{
    public enum TypeTaux{ACTUARIEL, PROPORTIONNEL};

    [Serializable]
    public class TauxPeriodique
    {
        #region propriétés ----------------------------------------------------

        private float _Taux;

        public float Taux
        {
            get { return _Taux; }
            set { _Taux = value; }
        }

        private TypePeriode _TypePeriode;

        public TypePeriode TypePeriode
        {
            get { return _TypePeriode; }
            set { _TypePeriode = value; }
        }

        private TypeTaux _TypeTaux;

        public TypeTaux TypeTaux
        {
            get { return _TypeTaux; }
            set { _TypeTaux = value; }
        }

        #endregion ------------------------------------------------------------

        #region constructeurs -------------------------------------------------

        public TauxPeriodique()
        {
            this._Taux = 0;
            this._TypePeriode = Finance.TypePeriode.ANNUEL;
            this._TypeTaux = Finance.TypeTaux.ACTUARIEL;
        }

        public TauxPeriodique(float taux, TypePeriode typePeriode, TypeTaux typeTaux)
        {
            this._Taux = taux;
            this._TypePeriode = typePeriode;
            this._TypeTaux = typeTaux;
        }

        #endregion ------------------------------------------------------------

        #region méthodes ------------------------------------------------------

        /// <summary>
        /// convertit le taux actuel en un taux proportionnel de la période donnée
        /// </summary>
        /// <param name="typePeriode">périodicité du nouveau taux</param>
        /// <returns>le taux proportionnel</returns>
        public float Proportionnel(TypePeriode typePeriode)
        {
            float coef = (float)typePeriode / (float)this.TypePeriode;

            return this._Taux*coef;
        }

        /// <summary>
        /// convertit le taux actuel en un taux actuariel.
        /// </summary>
        /// <param name="typePeriode">Périodicité du nouveau taux</param>
        /// <returns>le taux actuariel</returns>
        public float Actuariel(TypePeriode typePeriode)
        {
            float oldValue = this.Taux / 100;
            float result = 0;

            float source = (float)TypePeriode;
            float dest = (float)typePeriode;
            float coef;

            if (source > dest)
            {
                coef = source / dest;
                result = (float)(( Math.Pow((1+oldValue),(1/coef)))-1);
            }
            else if (source < dest)
            {
                coef = dest / source;
                result = (float)(Math.Pow((1 + oldValue), coef) - 1);
            }
            else
            {
                result = oldValue;
            }

            result *= 100;

            return result;
        }

        public float Convertir(TypePeriode typePeriode, TypeTaux typeTaux)
        {
            float result = 0;

            switch (typeTaux)
            {
                case Finance.TypeTaux.ACTUARIEL:
                    result = this.Actuariel(typePeriode);
                    break;
                default:
                    result = this.Proportionnel(typePeriode);
                    break;
            }

            return result;
        }

        public float Convertir(TypePeriode typePeriode)
        {
            return Convertir(typePeriode, this.TypeTaux);
        }

        #endregion
    }
}
