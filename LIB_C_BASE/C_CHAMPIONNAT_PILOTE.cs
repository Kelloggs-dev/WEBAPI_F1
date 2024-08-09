using LIB_IBASE;

namespace LIB_C_BASE
{
    public class C_CHAMPIONNAT_PILOTE : ICHAMPIONNAT_PILOTE
    {
        public int Id { get; set; }
        public int Id_Driver { get; set; }
        public int Points { get; set; }
    }
}
