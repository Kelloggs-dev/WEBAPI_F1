using WEB_API_V2.ADD;

namespace WEB_API_V2.MAPPING
{
    public static class MAPPING_ADD
    {
        public static void Creation_Mapping_Add_Driver(this WebApplication P_Application)
        {
            P_Application.MapGet("/AddDriver", ADD_.Add_Driver);
        }

        public static void Creation_Mapping_Add_Constructeur(this WebApplication P_Application)
        {
            P_Application.MapGet("/AddConstructeur", ADD_.Add_Constructeur);
        }
    }
}
