using NS_WS;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

#nullable disable

namespace WPF_WEBAPI_F1.C
{
    public class C_COORDINATION : C_NOTIFIABLE
    {
        C_WEBAPI WebApi;

        private static C_COORDINATION _Instance;

        public static C_COORDINATION Instance
        {
            get
            {
                if (_Instance != null) return _Instance;
                else return _Instance = new();
            }
        }

        public C_COORDINATION()
        {
            HttpClient La_Connexion = new();

            WebApi = new("https://gr-srv-webapi-formule1.azurewebsites.net/", La_Connexion);

            try
            {

                Initialise();

            }
            catch (ApiException P_Erreur)
            {
                MessageBox.Show(P_Erreur.Message);
            }
        }

        private List<C_CONSTRUCTEUR> _List_Constructeur;

        public List<C_CONSTRUCTEUR> List_Constructeur
        {
            get { return _List_Constructeur; }
            set { _List_Constructeur = value; Signale_Changeent(); }
        }

        private List<C_DRIVER> _List_Driver;

        public List<C_DRIVER> List_Driver
        {
            get { return _List_Driver; }
            set { _List_Driver = value; Signale_Changeent(); }
        }

        private C_CONSTRUCTEUR _Select_Constructeur = null;

        public C_CONSTRUCTEUR Select_Constructeur
        {
            get { return _Select_Constructeur; }
            set { _Select_Constructeur = value; Signale_Changeent(); }
        }
        private C_DRIVER _Select_Driver = null;

        public C_DRIVER Select_Driver
        {
            get { return _Select_Driver; }
            set { _Select_Driver = value; Signale_Changeent(); }
        }

        private C_DRIVER _Copie_Driver;

        public C_DRIVER Copie_Driver
        {
            get { return _Copie_Driver; }
            set { _Copie_Driver = value; Signale_Changeent(); }
        }

        private C_CONSTRUCTEUR _Copie_Constructeur;

        public C_CONSTRUCTEUR Copie_Constructeur
        {
            get { return _Copie_Constructeur; }
            set { _Copie_Constructeur = value; Signale_Changeent(); }
        }



        private string _Nouveau_Nom = "";

        public string Nouveau_Nom
        {
            get { return _Nouveau_Nom; }
            set { _Nouveau_Nom = value.ToUpper(); Signale_Changeent(); }
        }

        private string _Nouveau_Prenom = "";

        public string Nouveau_Prenom
        {
            get { return _Nouveau_Prenom; }
            set { _Nouveau_Prenom = value; Signale_Changeent(); }
        }

        private string _Nouveau_Constructeur = "";

        public string Nouveau_Constructeur
        {
            get { return _Nouveau_Constructeur; }
            set { _Nouveau_Constructeur = value.ToUpper(); Signale_Changeent(); }
        }



        public void Initialise()
        {
            try
            {
                List_Constructeur = WebApi.GetConstructeur().ToList();
            }
            catch (ApiException P_Erreur)
            {
                MessageBox.Show(P_Erreur.Message);
            }
        }

        public void Mise_A_Jour_Driver()
        {
            try
            {
                List_Driver = WebApi.GetDriver(Select_Constructeur.Id).ToList();

            }
            catch (ApiException P_Erreur)
            {
                MessageBox.Show(P_Erreur.Message);
            }
        }

        public void Mise_A_Jour_Constructeur()
        {
            Initialise();
        }

        public void Afficher_Drivers()
        {
            if (Select_Constructeur != null)
            {
                try
                {
                    Mise_A_Jour_Driver();

                }
                catch (ApiException P_Erreur)
                {
                    MessageBox.Show(P_Erreur.Message);
                }
            }
        }

        public void Ajouter_Driver()
        {
            

            if (Select_Constructeur != null)
            {
                if (Nouveau_Nom != "" && Nouveau_Prenom != "")
                {

                    char[] Caractere = new char[Nouveau_Prenom.Length];
                    Caractere[0] = (char)(Nouveau_Prenom[0] & ~(32));
                    for (int Index = 1; Index < Nouveau_Prenom.Length; Index++)
                    {
                        Caractere[Index] = (char)(Nouveau_Prenom[Index] | 32);
                    }

                    var Prenom = new string(Caractere);


                    try
                    {

                        WebApi.AddDriver(Select_Constructeur.Id, Nouveau_Nom,Prenom);
                        Nouveau_Nom = "";
                        Nouveau_Prenom = "";
                        Mise_A_Jour_Driver();

                    }
                    catch (ApiException P_Erreur)
                    {
                        MessageBox.Show(P_Erreur.Message);
                    }
                }
            }
        }

        public void Ajouter_Constructeur()
        {
            if (Nouveau_Constructeur != "")
            {

                try
                {

                    WebApi.AddConstructeur(Nouveau_Constructeur);
                    Nouveau_Constructeur = "";
                    Mise_A_Jour_Constructeur();

                }
                catch (ApiException P_Erreur)
                {
                    MessageBox.Show(P_Erreur.Message);
                }
            }
        }

        public void Debut_Modif_Constructeur()
        {
            if (Select_Constructeur != null)
            {
                Copie_Driver = null;
                Copie_Constructeur = new() { Id = Select_Constructeur.Id, Nom = Select_Constructeur.Nom };
            }
        }

        public void Debut_Modif_Driver()
        {
            if (Select_Driver != null) Copie_Driver = new() { Id = Select_Driver.Id, Id_Constructeur = Select_Driver.Id_Constructeur, Nom = Select_Driver.Nom, Prenom = Select_Driver.Prenom };
        }

        public void Modifier_Driver()
        {
            if (Copie_Driver != null)
            {
                try
                {

                    WebApi.UpdateDriver(Copie_Driver.Id, Copie_Driver.Id_Constructeur, Copie_Driver.Nom, Copie_Driver.Prenom);
                    Copie_Driver = null;

                }
                catch (ApiException P_Erreur)
                {
                    MessageBox.Show(P_Erreur.Message);
                }
                finally
                {
                    Mise_A_Jour_Driver();
                }
            }
        }

        public void Modifier_Constructeur()
        {
            if (Copie_Constructeur != null)
            {
                try
                {

                    WebApi.UpdateConstructeur(Copie_Constructeur.Id, Copie_Constructeur.Nom);
                    Copie_Constructeur = null;

                }
                catch (ApiException P_Erreur)
                {
                    MessageBox.Show(P_Erreur.Message);
                }
                finally
                {
                    Mise_A_Jour_Constructeur();
                }
            }
        }

        public void Supprimer_Constructeur()
        {
            if (Select_Constructeur != null)
            {
                try
                {

                   WebApi.DeleteConstructeur(Select_Constructeur.Id);

                }
                catch (ApiException P_Erreur)
                {
                    MessageBox.Show(P_Erreur.Message);
                }
                finally
                {
                    Mise_A_Jour_Constructeur();
                    List_Driver = null;
                }
            }
        }

        public void Supprimer_Driver()
        {
            if (Select_Driver != null)
            {
                try
                {

                    WebApi.DeleteDriver(Select_Driver.Id);

                }
                catch (ApiException P_Erreur)
                {
                    MessageBox.Show(P_Erreur.Message);
                }
                finally
                {
                    Mise_A_Jour_Driver();
                }
            }
        }
    }
}
