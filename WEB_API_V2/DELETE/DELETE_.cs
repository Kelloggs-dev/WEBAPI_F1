
using LIB_C_BASE;
using LIB_IBASE;
using Microsoft.AspNetCore.Mvc;

#nullable disable

namespace WEB_API_V2.DELETE
{
    public static class DELETE_
    {

        static IBASE _Base = C_BASE.Instance;

        public static IResult Delete_Driver([FromHeader(Name = "Id")] int P_Id)
        {
            var Delete_Ok = _Base.Delete_Driver(P_Id);

            if (Delete_Ok) return Results.Ok();
            else return Results.NotFound();
        }

        public static IResult Delete_Constructeur([FromHeader(Name = "Id")] int P_Id_Constructeur)
        {
            var Delete_Ok = _Base.Delete_Constructeur(P_Id_Constructeur);

            if (Delete_Ok) return Results.Ok();
            else return Results.NotFound();
        }

    }
}
