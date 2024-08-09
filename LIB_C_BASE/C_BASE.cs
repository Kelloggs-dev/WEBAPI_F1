using Dapper;
using LIB_IBASE;
using System.Data.SqlClient;

namespace LIB_C_BASE
{

    public class C_BASE : IBASE
    {
#if DEBUG
        const string Chaine_Connexion = @"Data Source=PC-JP;Initial Catalog=Formul_1;Integrated Security=True;Connect Timeout=60;Encrypt=False";
#else
        const string Chaine_Connexion = @"Server=tcp:rg-f1.database.windows.net,1433;Initial Catalog=BDD_F1;Persist Security Info=False;User ID=USER_BDD;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
#endif

        public C_BASE()
        {

        }

        private static C_BASE _Instance;

        public static C_BASE Instance
        {
            get
            {
                if (_Instance != null) return _Instance;
                else return _Instance = new C_BASE();
            }
        }

        public IEnumerable<IDRIVER> Get_All_Driver()
        {
            using SqlConnection La_Connexion = new(Chaine_Connexion);

            La_Connexion.Open();

            var Result = La_Connexion.Query<C_DRIVER>("select * from Drivers");

            return Result;
        }

        public IEnumerable<ICONSTRUTEUR> Get_All_Constructeur()
        {
            using SqlConnection La_Connexion = new(Chaine_Connexion);

            La_Connexion.Open();

            var Result = La_Connexion.Query<C_CONSTRUCTEUR>("select * from Constructeurs ");

            return Result;
        }

        public IEnumerable<IDRIVER> Get_Driver_By_Constructeur(int P_Id)
        {
            using SqlConnection La_Connexion = new(Chaine_Connexion);

            La_Connexion.Open();

            var Result = La_Connexion.Query<C_DRIVER>("select * from Drivers where Id_Constructeur = @Id", new { Id = P_Id });

            return Result;
        }

        public IEnumerable<ICHAMPIONNAT_CONSTRUCTEUR> Get_Point_By_Constructeur(int P_IdConstructeur)
        {
            using SqlConnection La_Connexion = new(Chaine_Connexion);

            La_Connexion.Open();

            var Trouver = La_Connexion.Query<C_CHAMPIONNAT_CONSTRUCTEUR>("select * from Championnat_Constructeurs where Id_Constructeur = @ID", new { ID = P_IdConstructeur });

            if (Trouver != null) return Trouver;
            else return null;

        }

        public IEnumerable<ICHAMPIONNAT_PILOTE> Get_Point_By_Pilote(int P_IdDriver)
        {
            using SqlConnection La_Connexion = new(Chaine_Connexion);

            La_Connexion.Open();

            var Trouver = La_Connexion.Query<C_CHAMPIONNAT_PILOTE>("select * from Championat_Pilotes where Id_Driver = @ID ", new { ID = P_IdDriver });

            if (Trouver != null) return Trouver;
            else return null;

        }

        public bool Add_Driver(int P_Id_Constructeur, string P_Nom, string P_Prenom)
        {
            using SqlConnection La_Connexion = new(Chaine_Connexion);

            La_Connexion.Open();

            var trouver = La_Connexion.Query<C_DRIVER>("select * from Drivers where Nom = @Nom and Prenom = @Prenom", new { Nom = P_Nom, Prenom = P_Prenom });

            if (trouver.Count() == 0)
            {
                La_Connexion.Query<IDRIVER>("insert into Drivers(Id_Constructeur,Nom,Prenom) values(@Id_Constructeur,@Nom,@Prenom)", new { Id_Constructeur = P_Id_Constructeur, Nom = P_Nom, Prenom = P_Prenom });

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Add_Constructeur(string P_Nom)
        {
            using SqlConnection La_Connexion = new(Chaine_Connexion);

            La_Connexion.Open();

            var Trouver = La_Connexion.Query<C_CONSTRUCTEUR>("select * from Constructeurs where Nom = @Nom", new { Nom = P_Nom });

            if (Trouver.Count() == 0)
            {
                La_Connexion.Query<C_CONSTRUCTEUR>("insert into Constructeurs(Nom) values(@Nom)", new { Nom = P_Nom });

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update_Driver(int P_Id, int P_Id_Constructeur, string P_Nom, string P_Prenom)
        {
            using SqlConnection La_Connexion = new(Chaine_Connexion);

            La_Connexion.Open();

            var trouver = La_Connexion.Query<C_DRIVER>("select * from Drivers where Id = @Id", new { Id = P_Id });

            if (trouver.Count() != 0)
            {
                La_Connexion.Query<IDRIVER>("update Drivers set Id_Constructeur = @Id_Constructeur, Nom = @Nom, Prenom = @Prenom where Id = @Id", new { Id = P_Id, Id_Constructeur = P_Id_Constructeur, Nom = P_Nom, Prenom = P_Prenom });

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update_Constructeur(int P_Id, string P_Nom)
        {
            using SqlConnection La_Connexion = new(Chaine_Connexion);

            La_Connexion.Open();

            var Trouver = La_Connexion.Query<C_CONSTRUCTEUR>("select * from Constructeurs where Id = @Id ", new { Id = P_Id });

            if (Trouver.Count() != 0)
            {
                La_Connexion.Query<C_CONSTRUCTEUR>("update Constructeurs set Nom = @Nom where Id = @Id", new { Id = P_Id, Nom = P_Nom });

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete_Driver(int P_Id)
        {
            using SqlConnection La_Connexion = new(Chaine_Connexion);

            La_Connexion.Open();

            var Trouver = La_Connexion.Query<C_DRIVER>("select * from Drivers where Id = @ID", new { ID = P_Id });

            if (Trouver.Count() != 0)
            {
                La_Connexion.Query<C_DRIVER>("delete from Drivers where Id = @ID", new { ID = P_Id });
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool Delete_Constructeur(int P_Id)
        {
            using SqlConnection La_Connexion = new(Chaine_Connexion);

            La_Connexion.Open();

            var Trouver = La_Connexion.Query<C_CONSTRUCTEUR>("select * from Constructeurs where Id = @ID", new { ID = P_Id });

            var Trouver_2 = Get_Driver_By_Constructeur(P_Id);

            if (Trouver.Count() != 0)
            {
                if (Trouver_2 != null)
                {
                    foreach (var Driver in Trouver_2)
                    {
                        Delete_Driver(Driver.Id);
                    }
                }

                La_Connexion.Query<C_CONSTRUCTEUR>("delete from Constructeurs where Id = @ID", new { ID = P_Id });
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}

