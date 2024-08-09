using LIB_C_BASE;

namespace TEST_LIB_CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            C_BASE La_Base = new();

            //var List_Drivers = La_Base.Get_All_Driver();

            //foreach (var Drivers in List_Drivers)
            //{
            //    Console.WriteLine(Drivers.ToString());
            //}

            //var List_Constructeur = La_Base.Get_All_Constructeur();

            //foreach (var Constructeur in List_Constructeur)
            //{
            //    Console.WriteLine(Constructeur.ToString());
            //}

            //La_Base.Add_Driver(5,"Sainz","Carlos");
            //La_Base.Add_Constructeur("REDBULL");
            La_Base.Update_Constructeur(7, "REDBULL");

        }
    }
}
