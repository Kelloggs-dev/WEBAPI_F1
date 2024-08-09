using LIB_IBASE;

namespace LIB_C_BASE
{
    public class C_DRIVER : IDRIVER
    {
        public int Id { get; set; }
        public int Id_Constructeur { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public override string ToString()
        {
            return $" {Id_Constructeur,3} {Nom,3} {Prenom,3}";
        }
    }
}
