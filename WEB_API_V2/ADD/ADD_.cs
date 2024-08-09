#nullable disable

using LIB_C_BASE;
using LIB_IBASE;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WEB_API_V2;

namespace WEB_API_V2.ADD
{
    public static class ADD_
    {
        static IBASE _Base = C_BASE.Instance;
        public static IResult Add_Driver([FromHeader (Name ="Id")] int P_Id_Constructeur, [FromHeader(Name = "Nom")] string P_Nom, [FromHeader(Name = "Prenom")] string P_Prenom)
        {
            var Nouveau_Driver = _Base.Add_Driver(P_Id_Constructeur, P_Nom, P_Prenom);

            if (Nouveau_Driver != false) return Results.Ok();
            else return Results.NoContent();
        }
        public static IResult Add_Constructeur([FromHeader(Name = "Nom")] string P_Nom)
        {
            var Nouveau_Constructeur = _Base.Add_Constructeur(P_Nom);

            if (Nouveau_Constructeur != false) return Results.Ok();
            else return Results.NoContent();
        }
    }
}
