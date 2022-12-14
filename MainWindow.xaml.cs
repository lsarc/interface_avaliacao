using interface_avaliacao.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace interface_avaliacao
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Context context;
        User newUser = new();
        public MainWindow(Context context)
        {
            this.context = context;
            InitializeComponent();
            LoginGrid.DataContext = newUser;

        }

        private void CheckUser(object sender, RoutedEventArgs e)
        {
            foreach (User user in context.Users.ToList())
            {
                if ((user.Email != newUser.Email) || (user.Password != newUser.Password)){
                    this.Opacity = 0.5;
                    logInText.Text = "Credenciais inválidas!";
                    logInPopup.IsOpen = true;
                    Title = "D7 - Avaliação - Erro";

                }
                else
                {
                    this.Opacity = 0.5;
                    logInText.Text = "Usuário autenticado!";
                    logInPopup.IsOpen = true;
                    Title = "D7 - Avaliação - Sucesso";
                }
            }
        }

        private void popClosed(object sender, EventArgs e)
        {
            this.Opacity = 1;
            logInPopup.IsOpen = false;
            Title = "D7 - Avaliação";
           
        }
    }
}
