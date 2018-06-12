using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prana.Finance
{
    public enum TypeSequenceCredit {AMORTISSABLE, DIFFERE_K, DIFFERE_I, DIFFERE_KI, PROGRESSIF};
    public enum TypeAssurance {SUR_CRD, SUR_CRD_INCLUS, SUR_ECHEANCE}

    [Serializable]
    public class SequenceCredit
    {
        #region propriétés ----------------------------------------------------

        private TauxPeriodique _TauxInteret;

        public TauxPeriodique TauxInteret
        {
            get { return _TauxInteret; }
            set { _TauxInteret = value; }
        }

        private float _Progressivite;

        public float Progressivite
        {
            get { return _Progressivite; }
            set { _Progressivite = value; }
        }

        private TypeSequenceCredit _TypeSequenceCredit;

        public TypeSequenceCredit TypeSequenceCredit
        {
            get { return _TypeSequenceCredit; }
            set { _TypeSequenceCredit = value; }
        }

        private TypePeriode _TypePeriode;

        public TypePeriode TypePeriode
        {
            get { return _TypePeriode; }
            set { _TypePeriode = value; }
        }

        private int _NombrePeriode;

        public int NombrePeriode
        {
          get { return _NombrePeriode; }
          set { _NombrePeriode = value; }
        }

        public int NombreMois
        {
            get
            {
                return ((int)this._TypePeriode * _NombrePeriode);
            }
        }

        // assurance
        private TypeAssurance _TypeAssurance;

        public TypeAssurance TypeAssurance
        {
          get { return _TypeAssurance; }
          set { _TypeAssurance = value; }
        }

        private TauxPeriodique _TauxAssurance;

        public TauxPeriodique TauxAssurance
        {
          get { return _TauxAssurance; }
          set { _TauxAssurance = value; }
        }

        #endregion ------------------------------------------------------------

        #region constructeur --------------------------------------------------

        public SequenceCredit()
        {
            _TauxInteret = new TauxPeriodique(0, TypePeriode.ANNUEL, TypeTaux.PROPORTIONNEL);
            _TypeSequenceCredit = TypeSequenceCredit.AMORTISSABLE;
            _TypePeriode = TypePeriode.MENSUEL;
            _NombrePeriode=0;
            _TypeAssurance = Finance.TypeAssurance.SUR_CRD_INCLUS;
            _TauxAssurance = new TauxPeriodique(0, Finance.TypePeriode.ANNUEL, TypeTaux.PROPORTIONNEL);
            _Progressivite = 0;
        }

        #endregion ------------------------------------------------------------

    }
}
