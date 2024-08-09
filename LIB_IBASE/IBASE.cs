namespace LIB_IBASE
{
    public interface IBASE
    {
        IEnumerable<IDRIVER> Get_All_Driver();
        IEnumerable<ICONSTRUTEUR> Get_All_Constructeur();
        IEnumerable<IDRIVER> Get_Driver_By_Constructeur(int P_Id);
        IEnumerable<ICHAMPIONNAT_CONSTRUCTEUR> Get_Point_By_Constructeur(int P_IdConstructeur);
        IEnumerable<ICHAMPIONNAT_PILOTE> Get_Point_By_Pilote(int P_IdDriver);
        bool Add_Driver(int P_Id_Constructeur, string P_Nom, string P_Prenom);
        bool Add_Constructeur(string P_Nom);
        bool Update_Driver(int P_Id,int P_Id_Constructeur, string P_Nom, string P_Prenom);
        bool Update_Constructeur(int P_Id,string P_Nom);
        bool Delete_Driver(int P_Id);
        bool Delete_Constructeur(int P_Id);
        
    }
}
