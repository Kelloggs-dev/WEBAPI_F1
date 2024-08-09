using WEB_API_V2.DELETE;

#nullable disable

namespace WEB_API_V2.MAPPING
{
    public static class MAPPING_DELETE
    {
        public static void Creation_Mapping_Delete_Driver(this WebApplication P_Application)
        {
            P_Application.MapGet("/DeleteDriver", DELETE_.Delete_Driver);
        }

        public static void Creation_Mapping_Delete_Constructeur(this WebApplication P_Application)
        {
            P_Application.MapGet("/DeleteConstructeur", DELETE_.Delete_Constructeur);
        }
    }
}
