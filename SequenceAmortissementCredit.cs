using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml.Serialization;

namespace Prana.Finance
{
    [Serializable]
    public class SequenceAmortissementCredit
    {
        #region propriétés ----------------------------------------------------

        private int _Numero;

        [XmlAttribute]
        public int Numero
        {
            get { return _Numero; }
            set { _Numero = value; }
        }

        // capital
        private double _RemboursementCapitalRegulier;

        public double RemboursementCapitalRegulier
        {
            get { return _RemboursementCapitalRegulier; }
            set { _RemboursementCapitalRegulier = value; }
        }

        private double _RembousementCapitalExceptionnel;

        public double RembousementCapitalExceptionnel
        {
            get { return _RembousementCapitalExceptionnel; }
            set { _RembousementCapitalExceptionnel = value; }
        }

        private double _CapitalRestantDu;

        public double CapitalRestantDu
        {
            get { return _CapitalRestantDu; }
            set { _CapitalRestantDu = value; }
        }

        private double _FondsDebloques;

        public double FondsDebloques
        {
            get { return _FondsDebloques; }
            set { _FondsDebloques = value; }
        }

        // intérêts
        private double _InteretsGeneres;

        public double InteretsGeneres
        {
            get { return _InteretsGeneres; }
            set { _InteretsGeneres = value; }
        }

        private double _InteretsPayes;

        public double InteretsPayes
        {
            get { return _InteretsPayes; }
            set { _InteretsPayes = value; }
        }

        // assurance
        private double _Assurance;

        public double Assurance
        {
            get { return _Assurance; }
            set { _Assurance = value; }
        }

        // commentaires
        private string _Commentaires;

        public string Commentaires
        {
            get { return _Commentaires; }
            set { _Commentaires = value; }
        }

        // autres
        public double RemboursementCapitalTotal
        {
            get { return (this._RemboursementCapitalRegulier + this._RembousementCapitalExceptionnel); }
        }

        public double MontantPeriodique
        {
            get {return (this._RemboursementCapitalRegulier+this._InteretsPayes+this._Assurance); }
        }
        #endregion ------------------------------------------------------------

        #region constructeurs -------------------------------------------------

        public SequenceAmortissementCredit()
        {
            this._Numero = 0;
            this._Assurance = 0;
            this._CapitalRestantDu = 0;
            this._Commentaires = "";
            this._FondsDebloques = 0;
            this._InteretsGeneres = 0;
            this._InteretsPayes = 0;
            this._RemboursementCapitalRegulier = 0;
            this._RembousementCapitalExceptionnel = 0;
        }

        #endregion ------------------------------------------------------------
    }
}
