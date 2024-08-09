using WEB_API_V2.UPDATE;

#nullable disable

namespace WEB_API_V2.MAPPING
{
    public static class MAPPING_UPDATE
    {
        public static void Creation_Mapping_Update_Driver(this WebApplication P_Application)
        {
            P_Application.MapGet("/UpdateDriver", UPDATE_.Update_Driver);
        }

        public static void Creation_Mapping_Update_Constructeur(this WebApplication P_Application)
        {
            P_Application.MapGet("/UpdateConstructeur", UPDATE_.Update_Constructeur);
        }
    }
}
