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

namespace DBAPP_WPF
{
    /// <summary>
    /// Interaction logic for HomeMainWindow.xaml
    /// </summary>
    public partial class HomeMainWindow : Window
    {
        Window Win;
        User user;
        string DB;
        public HomeMainWindow(Window win, User user, string filenameDB)
        {
            this.Win = win;
            this.user = user;
            this.DB = filenameDB;
            InitializeComponent();
            win.IsEnabled = false;
            win.Hide();
            this.Title = user.Name;
            Config.ConnectDB(filenameDB);
            SetButtons();
        }

        private void SetButtons()
        {
            // Включаем и отключаем кнопки в зависимости от уровн доступа.
        }

        private void AdminPanel2Button_Click(object sender, RoutedEventArgs e)
        {
            if (user.Name == "admin")
            {
                AdminPanelWindow2 adm = new AdminPanelWindow2(this);
                adm.Show();
                return;
            }
            else
            {
                while (true)
                {
                    InputWindow inputWin = new InputWindow(this, (string)FindResource("enterPassword"));
                    inputWin.ShowDialog();
                    if (inputWin.DialogResult == true)
                    {
                        if (Config.CheckAdminPassword(inputWin.Result))
                        {
                            AdminPanelWindow2 adm = new AdminPanelWindow2(this);
                            adm.Show();
                            return;
                        }
                        MessageBox.Show((string)FindResource("incorrectPassword"));
                    }
                    else
                    {
                        return;
                    }
                }
            }

        }

        private void HomeWin_Closed(object sender, EventArgs e)
        {
            Config.myDB.Close();
            Win.IsEnabled = true;
            Win.Show();
        }
    }
}
