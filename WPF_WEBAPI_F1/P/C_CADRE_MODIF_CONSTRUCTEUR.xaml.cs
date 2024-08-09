using NS_WS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_WEBAPI_F1.C;

#nullable disable

namespace WPF_WEBAPI_F1.P
{
    /// <summary>
    /// Logique d'interaction pour C_CADRE_MODIF_CONSTRUCTEUR.xaml
    /// </summary>
    public partial class C_CADRE_MODIF_CONSTRUCTEUR : Window
    {
        C_COORDINATION La_Coordination;

        public C_CADRE_MODIF_CONSTRUCTEUR()
        {
            try
            {
                InitializeComponent();
                La_Coordination = C_COORDINATION.Instance;
                DataContext = La_Coordination;

            }catch(ApiException P_Erreur)
            {
                MessageBox.Show(P_Erreur.Message);
            }
        }

        private void BTN_Valider_Click(object sender, RoutedEventArgs e)
        {
            La_Coordination.Modifier_Constructeur();
            Close();
        }

        private void BTN_Annuler_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
