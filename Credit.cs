using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

using Prana.Tools;

namespace Prana.Finance
{
    [Serializable]
    public class Credit
    {
        #region propriétés ----------------------------------------------------

        private List<SequenceCredit> _ListeSequenceCredit;

        public List<SequenceCredit> ListeSequenceCredit
        {
            get { return _ListeSequenceCredit; }
            set { _ListeSequenceCredit = value; }
        }

        // appels de fonds
        private List<Flux> _AppelsFonds;

        public List<Flux> AppelsFonds
        {
            get { return _AppelsFonds; }
            set { _AppelsFonds = value; }
        }


        // remboursements exceptionnels
        private List<Flux> _RemboursementExceptionnels;

        public List<Flux> RemboursementExceptionnels
        {
            get { return _RemboursementExceptionnels; }
            set { _RemboursementExceptionnels = value; }
        }

        // tableau d'amortissement
        private List<SequenceAmortissementCredit> _TableauAmortissement;

        [XmlArray]
        public List<SequenceAmortissementCredit> TableauAmortissement
        {
            get { return _TableauAmortissement; }
            set { _TableauAmortissement = value; }
        }

        public int NombreMois
        {
            get
            {
                int result = 0;

                foreach (SequenceCredit sequence in _ListeSequenceCredit)
                    result += sequence.NombreMois;

                return result;

            }
        }

        #endregion ------------------------------------------------------------

        #region constructeur --------------------------------------------------
        public Credit()
        {
            this._AppelsFonds = new List<Flux>();
            this._RemboursementExceptionnels = new List<Flux>();
            this._ListeSequenceCredit = new List<SequenceCredit>();
            this._TableauAmortissement = new List<SequenceAmortissementCredit>();

        }
        #endregion ------------------------------------------------------------

        #region méthodes ------------------------------------------------------

        public double TotalEmprunte
        {
            get
            {
                double result=0;

                foreach (Flux flux in this.AppelsFonds)
                {
                    result += flux.Valeur;
                }

                return result;
            }
        }

        #endregion ------------------------------------------------------------

        public void ConstruireTableauAmortissement()
        {
            // on vide le tableau existant
            _TableauAmortissement.Clear();

            int dureeTmp = 0;

            // on crée le nouveau tableau
            foreach (SequenceCredit sequence in this._ListeSequenceCredit)
            {
                dureeTmp = sequence.NombreMois;
                for (int i = 0; i < dureeTmp; i++)
                    _TableauAmortissement.Add(new SequenceAmortissementCredit());
            }
            int dureeCredit = this.NombreMois;

            // on ventile les déblocages
            DateTime datePrecedente = _AppelsFonds[0].DateTime;
            DateTime dateCourante;
            int moisCourant = 0;
            foreach (Flux flux in _AppelsFonds)
            {
                if (flux.DateTime >= datePrecedente)
                {
                    dateCourante = flux.DateTime;
                    moisCourant += Date.MonthDiff(datePrecedente,dateCourante);
                    datePrecedente=dateCourante;
                    if (moisCourant<=dureeCredit){
                        _TableauAmortissement[moisCourant].FondsDebloques += flux.Valeur;
                    }
                }
            }

            // on ventile les remboursements exceptionnels
            datePrecedente = AppelsFonds[0].DateTime;
            moisCourant = 0;
            foreach (Flux flux in _RemboursementExceptionnels)
            {
                if (flux.DateTime >= datePrecedente)
                {
                    dateCourante = flux.DateTime;
                    moisCourant += Date.MonthDiff(datePrecedente, dateCourante);
                    if (moisCourant < dureeCredit)
                        _TableauAmortissement[moisCourant].RembousementCapitalExceptionnel += flux.Valeur;
                    datePrecedente = dateCourante;
                }
            }

            // on parcoure les sequences et on determine les echeances
            moisCourant = 0;
            double capitalRestantDu=0;
            double interetsGeneres = 0;
            double interetsPayes = 0;
            float tauxInteret=0;
            double capitalRembourse=0;
            int periodeRestante = 0;
            int nombrePeriode = 0;



            float tauxAssurance = 0;
            double assurance = 0;

            int count = 0;
            foreach (SequenceCredit sequence in _ListeSequenceCredit)
            {
                nombrePeriode = sequence.NombrePeriode;

                for (int i = 0; i < nombrePeriode; i++)
                {
                    // on calcul le restant dû en ajoutant les deblocages de la période
                    capitalRestantDu += this.TableauAmortissement[moisCourant].FondsDebloques;

                    // on convertit le taux d'interet pour la période
                    tauxInteret = sequence.TauxInteret.Convertir(sequence.TypePeriode) / 100;

                    // on calcule les intérêts
                    interetsGeneres = tauxInteret * capitalRestantDu;

                    // idem pour l'assurance
                    tauxAssurance = sequence.TauxAssurance.Convertir(sequence.TypePeriode)/100;
                    assurance=0;

                    periodeRestante = (dureeCredit - moisCourant) / (int)sequence.TypePeriode;
                    switch (sequence.TypeSequenceCredit)
                    {
                            /*
                             * En amortissable, on a des remboursements réguliers.
                             * On doit donc calculer l'échéance totale pour determiner le capital remboursé.
                             * Le calcul doit connaitre le nombre de période restante
                             */
                        case TypeSequenceCredit.AMORTISSABLE:
                            // on doit traiter le cas particulier de l'assurance CRD inclus
                            if (sequence.TypeAssurance == TypeAssurance.SUR_CRD_INCLUS)
                            {
                                tauxInteret+=tauxAssurance;
                                assurance = tauxAssurance * capitalRestantDu;
                            }
                            capitalRembourse = (capitalRestantDu*tauxInteret) / (1-Math.Pow(1+tauxInteret,-periodeRestante));
                            capitalRembourse -= (interetsGeneres+assurance);
                            interetsPayes = interetsGeneres;
                            break;

                            // en differe K on ne rembourse que les intérêts
                        case TypeSequenceCredit.DIFFERE_K:
                            capitalRembourse = 0;
                            interetsPayes = interetsGeneres;
                            break;

                            // en differe K+I les intérêts sont rajoutés au capital restant dû
                        case TypeSequenceCredit.DIFFERE_KI:
                            capitalRembourse = 0;
                            interetsPayes = 0;
                            capitalRestantDu += interetsGeneres;
                            break;
                        case TypeSequenceCredit.PROGRESSIF:
                            interetsPayes = interetsGeneres;
                            if (count ==0) {
                                capitalRembourse = MensualiteProgressive(capitalRestantDu, tauxInteret, sequence.Progressivite, periodeRestante)-interetsGeneres;
                            }
                            else if ((moisCourant % 12) == 0)
                            {
                                capitalRembourse = ((_TableauAmortissement[moisCourant-1].RemboursementCapitalRegulier + _TableauAmortissement[moisCourant-1].InteretsPayes)*(1+(sequence.Progressivite/100)))-interetsGeneres;
                            }
                            else
                            {
                                capitalRembourse = (_TableauAmortissement[moisCourant-1].RemboursementCapitalRegulier + _TableauAmortissement[moisCourant-1].InteretsPayes)-interetsGeneres;
                            }
                            break;

                    }

                    // on calcule l'assurance
                    switch (sequence.TypeAssurance)
                    {
                        case TypeAssurance.SUR_ECHEANCE:
                            assurance = (capitalRembourse + interetsPayes) * tauxAssurance;
                            break;
                        case TypeAssurance.SUR_CRD:
                            assurance = capitalRestantDu * tauxAssurance;
                            break;
                    }

                    // si l'exeptionnel est superieur au CRD on ne prend que le nécessaire
                    double capitalExceptionnel = _TableauAmortissement[moisCourant].RembousementCapitalExceptionnel;
                    capitalExceptionnel = Math.Min(capitalRestantDu - capitalRembourse, capitalExceptionnel);

                    // on impacte le CRD
                    capitalRestantDu -= (capitalRembourse + capitalExceptionnel);

                    _TableauAmortissement[moisCourant].Numero = count;
                    _TableauAmortissement[moisCourant].RemboursementCapitalRegulier = capitalRembourse;
                    _TableauAmortissement[moisCourant].InteretsGeneres = interetsGeneres;
                    _TableauAmortissement[moisCourant].InteretsPayes = interetsPayes;
                    _TableauAmortissement[moisCourant].CapitalRestantDu = capitalRestantDu;
                    _TableauAmortissement[moisCourant].RembousementCapitalExceptionnel = capitalExceptionnel;

                    moisCourant++;

                    /* si la periodicité n'est pas mensuelle, on doit récuperer
                     * les appels de fonds intervenus entre les deux échéances.
                     */
                    for (int j = 1; j < (int)sequence.TypePeriode; j++)
                    {
                        capitalRestantDu += _TableauAmortissement[moisCourant].FondsDebloques;
                        _TableauAmortissement[moisCourant].CapitalRestantDu = capitalRestantDu;
                        moisCourant++;
                    }

                    /* Si on arrive à la derniere echéance et que le capital
                     * n'est pas nul, alors on rembourse le solde
                     */
                    if ((moisCourant==dureeCredit) && (capitalRestantDu>0))
                    {
                        _TableauAmortissement[moisCourant-1].RemboursementCapitalRegulier += capitalRestantDu;
                        _TableauAmortissement[moisCourant - 1].CapitalRestantDu = 0;
                        capitalRestantDu = 0;
                    }

                    count++;
                }
            }
        }

        public double MensualiteProgressive(double montant, float tauxMensuel, float tauxProgressivite, int duree)
        {
            // variables pour les crédits progressifs
            double mensualiteProgressive;
            double annees;
            double mois;
            float txProg = tauxProgressivite / 100;

            // cas des mensualites progressives
            annees = Math.Floor((double)duree / 12);
            mois = this.NombreMois - (annees * 12);
            mensualiteProgressive = Math.Pow(1 + tauxMensuel, duree) * montant / ((Math.Pow(1 + tauxMensuel, 12) - 1) / tauxMensuel * Math.Pow(1 + tauxMensuel, mois)
                * (Math.Pow(1 + tauxMensuel, 12 * annees) - Math.Pow(1 + txProg, annees)) / (Math.Pow(1 + tauxMensuel, 12) - (1 + txProg))
                + Math.Pow(1 + txProg, annees) * (Math.Pow(1 + tauxMensuel, mois) - 1) / tauxMensuel);


            return mensualiteProgressive;
        }

        #region serialisation fichier -----------------------------------------

        public void Sauver(string fileName)
        {
            //OutilsCrypto.SaveObjectToFile(this, fileName);
            FileStream file = File.Open(fileName, FileMode.OpenOrCreate);
            XmlSerializer serializer = new XmlSerializer(typeof(Credit));
            serializer.Serialize(file, this);
            file.Close();
        }

        public static Credit Charger(string fileName)
        {
            FileStream file = File.Open(fileName, FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(Credit));
            Credit credit = (Credit)serializer.Deserialize(file);
            file.Close();
            return credit;
        }

        //private void buttonSauvegarder_Click(object sender, EventArgs e)
        //{
        //    SaveFileDialog boiteSauvegarde = new SaveFileDialog();
        //    boiteSauvegarde.Filter = "Fichier xml(*.xml)|*.xml";
        //    if (boiteSauvegarde.ShowDialog() == DialogResult.OK)
        //    {
        //        carnetAdresses.Sauvegarder(boiteSauvegarde.FileName);
        //    }
        //}

        //private void buttonCharger_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog boiteOuverture = new OpenFileDialog();
        //    boiteOuverture.Filter = "Fichier xml(*.xml)|*.xml";
        //    if (boiteOuverture.ShowDialog() == DialogResult.OK)
        //    {
        //        carnetAdresses = carnetAdresses.Charger(boiteOuverture.FileName);
        //        RemplirListe();
        //    }
        //}

        #endregion
    }
}
