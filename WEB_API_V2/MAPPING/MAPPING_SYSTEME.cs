using WEB_API_V2.SYSTEME;

namespace WEB_API_V2.MAPPING
{
    public static class MAPPING_SYSTEME
    {
        public static void Creation_Mapping_GET_DATE(this WebApplication P_Application)
        {
            P_Application.MapGet("/GetDate", SYSTEME.SYSTEME.Get_Date);
        }

        public static void Creation_Mapping_Get_Ip(this WebApplication P_Application)
        {
            P_Application.MapGet("/GetIp", SYSTEME.SYSTEME.Get_Ip);
        }

        public static void Creation_Mapping_Get_Info_OS(this WebApplication P_Application)
        {
            P_Application.MapGet("/GetInfoOS", SYSTEME.SYSTEME.Get_Info_OS);
        }
        public static void Creation_Mapping_Get_Info_CPU(this WebApplication P_Application)
        {
            P_Application.MapGet("/GetInfoCPU", SYSTEME.SYSTEME.Get_Info_CPU);
        }
        
    }
}
