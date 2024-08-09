using LIB_C_BASE;
using LIB_IBASE;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WEB_API_V2.GET
{
    public static class GET_
    {
        static IBASE _Base = C_BASE.Instance;

        public static List<C_DRIVER> Get_Drivers([FromHeader(Name ="Id")] int P_Id_Constructeur) => (List<C_DRIVER>)_Base.Get_Driver_By_Constructeur(P_Id_Constructeur);

        public static List<C_CONSTRUCTEUR> Get_Constructeur() => (List<C_CONSTRUCTEUR>)_Base.Get_All_Constructeur();


    }
}
