using LIB_C_BASE;
using LIB_IBASE;
using Microsoft.AspNetCore.Mvc;

#nullable disable

namespace WEB_API_V2.UPDATE
{
    public static class UPDATE_
    {
        static IBASE _Base = C_BASE.Instance;
        public static IResult Update_Driver([FromHeader(Name = "Id")] int P_Id, [FromHeader(Name = "IdC")] int P_Id_Constructeur, [FromHeader(Name = "Nom")] string P_Nom, [FromHeader(Name = "Prenom")] string P_Prenom)
        {
            var Update_Ok = _Base.Update_Driver(P_Id, P_Id_Constructeur, P_Nom, P_Prenom);

            if (Update_Ok != false) return Results.Ok();
            else return Results.NoContent();
        }
        public static IResult Update_Constructeur([FromHeader(Name = "Id")] int P_Id_Constructeur, [FromHeader(Name = "Nom")] string P_Nom)
        {
            var Update_Ok = _Base.Update_Constructeur(P_Id_Constructeur, P_Nom);

            if (Update_Ok != false) return Results.Ok();
            else return Results.NoContent();
        }
    }
}
