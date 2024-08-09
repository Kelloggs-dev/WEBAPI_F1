using LIB_IBASE;

namespace LIB_C_BASE
{
    public class C_CONSTRUCTEUR : ICONSTRUTEUR
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        public override string ToString()
        {
            return $"{Nom}";
        }
    }
}
