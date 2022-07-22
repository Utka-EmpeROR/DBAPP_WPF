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
    /// Interaction logic for AdminPanelWindow1.xaml
    /// </summary>
    public partial class AdminPanelWindow1 : Window
    {
        Window LastWin;
        public AdminPanelWindow1(Window win)
        {
            LastWin = win;
            win.IsEnabled = false;
            win.Hide();
            InitializeComponent();
            LoadData();
        }

        private void Adm1_Closed(object sender, EventArgs e)
        {
            LastWin.Show();
            LastWin.IsEnabled = true;
        }

        private void LoadData()
        {
            Functions1CheckedListBox.Items.Clear();
            Functions2CheckedListBox.Items.Clear();
            ChangeAccessLevelListBox.Items.Clear();
            AccessLevelTextBox.Clear();
            DeleteLvlButton.IsEnabled = false;
            SaveLvlChangesButton.IsEnabled = false;
            Functions1CheckedListBox.IsEnabled = false;
            foreach (var func in Config.AvailableFunctions)
            {
                Functions1CheckedListBox.Items.Add(func);
                Functions2CheckedListBox.Items.Add(func);
            }

            Password1TextBox.Clear();
            UsernameTextBox.Clear();
            Password2TextBox.Clear();
            AccessLevel1ListBox.Items.Clear();
            AccessLevel2ListBox.Items.Clear();
            UsernameListBox.Items.Clear();
            DeleteUserButton.IsEnabled = false;
            SaveChangesUserButton.IsEnabled = false;
            Password1TextBox.IsEnabled = false;
            AccessLevel1ListBox.IsEnabled = false;
            foreach (var user in Config.Users)
            {
                UsernameListBox.Items.Add(user.Name);
            }
            foreach (var lvl in Config.AccesLevels)
            {
                AccessLevel1ListBox.Items.Add(lvl.Id);
                AccessLevel2ListBox.Items.Add(lvl.Id);
                ChangeAccessLevelListBox.Items.Add(lvl.Id);
            }
        }

        private void CreateUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsernameTextBox.Text.Trim().Split(' ').Length > 1 ||
                UsernameTextBox.Text.Trim() == "" ||
                Config.Users.Exists(user => user.Name == UsernameTextBox.Text))
            {
                MessageBox.Show((string)FindResource("incorrectUsernameFormat"));
                return;
            }
            if (Password2TextBox.Text.Trim() == "" ||
                Password2TextBox.Text.Trim().Split(' ').Length > 1)
            {
                MessageBox.Show((string)FindResource("incorrectPasswordFormat"));
                return;
            }
            if (AccessLevel2ListBox.SelectedIndex == -1)
            {
                MessageBox.Show((string)FindResource("lvlNotSelected"));
                return;
            }
            MessageBox.Show((string)FindResource("createdUser") + " " + UsernameTextBox.Text);
            Config.Users.Add(new User(UsernameTextBox.Text, Password2TextBox.Text,
                Config.AccesLevels.Find(lvl => lvl.Id ==
                int.Parse(AccessLevel2ListBox.SelectedItem.ToString()))));
            LoadData();
        }

        private void UsernameListBox_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (UsernameListBox.SelectedIndex == -1)
            {
                return;
            }
            User user = Config.Users.Find(user => user.Name ==
            (UsernameListBox.SelectedItem.ToString()));
            Password1TextBox.Text = user.Password;
            AccessLevel1ListBox.SelectedItem = user.AccessLvl.Id;
            if (UsernameListBox.SelectedItem.ToString() != "admin")
            {
                DeleteUserButton.IsEnabled = true;
                SaveChangesUserButton.IsEnabled = true;
                Password1TextBox.IsEnabled = true;
                AccessLevel1ListBox.IsEnabled = true;
            }
            else
            {
                DeleteUserButton.IsEnabled = false;
                SaveChangesUserButton.IsEnabled = false;
                Password1TextBox.IsEnabled = false;
                AccessLevel1ListBox.IsEnabled = false;
            }
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show((string)FindResource("deleteUserQuestion"),
                (string)FindResource("deletingUser"),
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Config.DeleteUser(UsernameListBox.SelectedItem.ToString());
                LoadData();
            }
        }

        private void SaveChangesUserButton_Click(object sender, RoutedEventArgs e)
        {
            if(Password1TextBox.Text.Trim().Split(' ').Length > 1)
            {
                MessageBox.Show((string)FindResource("incorrectPasswordFormat"));
                return;
            }
            User user = Config.Users.Find(user => user.Name ==
            (UsernameListBox.SelectedItem.ToString()));
            user.SetPassword(Password1TextBox.Text);
            user.SetAccessLevel(Config.AccesLevels.Find(lvl => lvl.Id == (int)AccessLevel1ListBox.SelectedItem));
            LoadData();
        }

        private void CreateLvlButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            if (!int.TryParse(AccessLevelTextBox.Text, out id) ||
                Config.AccesLevels.Exists(lvl => lvl.Id == id))
            {
                MessageBox.Show((string)FindResource("incorrectLvlFormat"));
                return;
            }
            if (Functions2CheckedListBox.SelectedItems.Count == 0)
            {
                MessageBox.Show((string)FindResource("functionsNotSelected"));
                return;
            }
            MessageBox.Show((string)FindResource("createdLvl") + " " + AccessLevelTextBox.Text);
            List<string> func = new List<string>();
            foreach (var item in Functions2CheckedListBox.SelectedItems)
            {
                func.Add(item.ToString());
            }
            Config.AccesLevels.Add(new AccessLevel(id, func));
            LoadData();
        }

        private void ChangeAccessLevelListBox_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (ChangeAccessLevelListBox.SelectedIndex == -1)
            {
                return;
            }
            AccessLevel lvl = Config.AccesLevels.Find(lvl => lvl.Id ==
            (int)ChangeAccessLevelListBox.SelectedItem);
            foreach (var item in Functions1CheckedListBox.Items)
            {
                if (lvl.PermittedFunctions.Contains(item))
                {
                    Functions1CheckedListBox.SelectedItems.Add(item);
                }
                else
                {
                    Functions1CheckedListBox.SelectedItems.Remove(item);
                }
            }
            if ((int)ChangeAccessLevelListBox.SelectedItem != 1)
            {
                DeleteLvlButton.IsEnabled = true;
                SaveLvlChangesButton.IsEnabled = true;
                Functions1CheckedListBox.IsEnabled = true;
            }
            else
            {
                DeleteLvlButton.IsEnabled = false;
                SaveLvlChangesButton.IsEnabled = false;
                Functions1CheckedListBox.IsEnabled = false;
            }
        }

        private void DeleteLvlButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show((string)FindResource("deleteLvlQuestion"), (string)FindResource("deletingLvl"),
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Config.DeleteAccessLevel((int)ChangeAccessLevelListBox.SelectedItem);
                LoadData();
            }
        }

        private void SaveLvlChangesButton_Click(object sender, RoutedEventArgs e)
        {
            AccessLevel lvl = Config.AccesLevels.Find(lvl => lvl.Id ==
            (int)ChangeAccessLevelListBox.SelectedItem);
            List<string> func = new List<string>();
            foreach (var item in Functions1CheckedListBox.SelectedItems)
            {
                func.Add(item.ToString());
            }
            lvl.FuncSet(func);
            LoadData();
        }
    }
}
