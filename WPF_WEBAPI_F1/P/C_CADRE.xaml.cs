using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_WEBAPI_F1.C;
using WPF_WEBAPI_F1.P;

#nullable disable

namespace WPF_WEBAPI_F1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class C_CADRE : Window
{
    C_COORDINATION La_Coordination;

    public C_CADRE()
    {

        try
        {
            InitializeComponent();

            La_Coordination = C_COORDINATION.Instance;
            DataContext = La_Coordination;

        }catch(Exception P_Erreur)
        {
            MessageBox.Show(P_Erreur.Message);
        }
    }

    private void LST_Constructeur_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        La_Coordination.Afficher_Drivers();
        
    }

    private void LST_Driver_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // Afficher en detaille le championat pilotes
        
    }

    private void BTN_Ajoute_Click(object sender, RoutedEventArgs e)
    {
        La_Coordination.Ajouter_Driver();
    }

    private void BTN_Ajouter_Constructeur_Click(object sender, RoutedEventArgs e)
    {
        La_Coordination.Ajouter_Constructeur();
    }

    private void LST_Constructeur_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        var Cadre_Modif_ = new C_CADRE_MODIF_CONSTRUCTEUR();
        La_Coordination.Debut_Modif_Constructeur();
        Cadre_Modif_.Show();
    }

    private void LST_Driver_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        var Cadre_Modif = new C_CADRE_MODIFIER_DRIVER();
        La_Coordination.Debut_Modif_Driver();
        Cadre_Modif.Show();
    }

    private void MI_Supprimer_Click(object sender, RoutedEventArgs e)
    {
        La_Coordination.Supprimer_Constructeur();
    }

    private void MI_Supprimer_2_Click(object sender, RoutedEventArgs e)
    {
        La_Coordination.Supprimer_Driver();
    }
}