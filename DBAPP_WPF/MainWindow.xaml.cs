using System;
using Microsoft.Win32;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DBAPP_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private static void Language_Load(string lang)
        {
            ResourceDictionary dict = new ResourceDictionary();
            dict.Source = new Uri("Resources/lang." + lang + ".xaml", UriKind.Relative);
            ResourceDictionary oldDict = (from d in Application.Current.Resources.MergedDictionaries
                                          where d.Source != null && d.Source.OriginalString.StartsWith("Resources/lang.")
                                          select d).First();
            int ind = Application.Current.Resources.MergedDictionaries.IndexOf(oldDict);
            Application.Current.Resources.MergedDictionaries.Remove(oldDict);
            Application.Current.Resources.MergedDictionaries.Insert(ind, dict);
        }

        private void UsernameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.PasswordTextBox.Focus();
            }
        }

        private void PasswordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LogInButton_Click(sender, e);
            }
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            User user;
            if (!Config.CheckUser(UsernameTextBox.Text, PasswordTextBox.Text, out user))
            {
                MessageBox.Show((string)FindResource("incorrectUserOrPassword"));
                return;
            }
            if (!File.Exists(LastDBTextBox.Text)){
                MessageBox.Show((string)FindResource("DBNotExist"));
                return;
            }
            HomeMainWindow win = new HomeMainWindow(this, user, LastDBTextBox.Text);
            win.Show();
        }

        private void Win_Loaded(object sender, RoutedEventArgs e)
        {
            Config.GetConfig();
            LangComboBox.SelectedItem = Config.Language;
            if (LangComboBox.SelectedItem == null)
            {
                LangComboBox.SelectedIndex = 0;
            }
            LastDBTextBox.Text = Config.LastUsedDB;
        }

        private void Language_Changed(object sender, SelectionChangedEventArgs e)
        {
            Language_Load(LangComboBox.SelectedItem.ToString());
            Config.Language = LangComboBox.SelectedItem.ToString();
        }

        private void Win_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Config.SaveConfig();
        }

        private void LoadDBButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == true)
            {
                if (System.IO.Path.GetExtension(dlg.FileName).ToLower() != ".mdb")
                {
                    MessageBox.Show((string)FindResource("incorrectDB"));
                    return;
                }
                LastDBTextBox.Text = dlg.FileName;
                Config.LastUsedDB = dlg.FileName;
            }
        }

        private void AdminPanelButton_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                InputWindow inputWin = new InputWindow(this, (string)FindResource("enterPassword"));
                inputWin.ShowDialog();
                if (inputWin.DialogResult == true)
                {
                    if (Config.CheckAdminPassword(inputWin.Result))
                    {
                        AdminPanelWindow1 adm = new AdminPanelWindow1(this);
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
}
