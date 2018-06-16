using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml.Serialization;

namespace Prana.Finance
{
    /// <summary>
    /// 
    /// <author>Christophe GILBERT</author>
    /// <creationDate>30.10.2010</creationDAte>
    /// </summary>
    [Serializable]
    public class Flux
    {
        #region propriétés ----------------------------------------------------

        private DateTime _DateTime;
        
        public DateTime DateTime
        {
            get
            {
                return _DateTime;
            }
            set
            {
                _DateTime = value;
            }
        }

        private double _Valeur;
        
        public double Valeur
        {
            get { return _Valeur; }
            set { _Valeur = value; }
        }

        private string _Commentaire;

        public string Commentaire
        {
            get { return _Commentaire; }
            set { _Commentaire = value; }
        }

        #endregion

        #region constructeurs -------------------------------------------------

        public Flux()
        {
            this._DateTime = DateTime.Now;
            this._Valeur = 0;
            this._Commentaire = "";
        }

        public Flux(DateTime dateTime, double valeur, string commentaire)
        {
            this._DateTime = dateTime;
            this._Valeur = valeur;
            this._Commentaire = commentaire;
        }
        #endregion
    }
}
