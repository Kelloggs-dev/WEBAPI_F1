using WEB_API_V2.GET;
namespace WEB_API_V2.MAPPING
{
    public static class MAPPING_GET
    {

        public static void Creation_Mapping_Get_Driver(this WebApplication P_Application)
        {
            P_Application.MapGet("/GetDriver", GET_.Get_Drivers);
        }

        public static void Creation_Mapping_Get_Constructeur(this WebApplication P_Application)
        {
            P_Application.MapGet("/GetConstructeur", GET_.Get_Constructeur);
        }
    }
}
