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
    /// Interaction logic for InputWindow.xaml
    /// </summary>
    public partial class InputWindow : Window
    {
        public string Result => this.InputTextBox.Text;
        Window Win;
        public InputWindow(Window win, string title, string startText = "")
        {
            InitializeComponent();
            this.Title = title;
            InputTextBox.Text = startText;
            this.Win = win;
            InputTextBox.Focus();
        }

        private void Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                DialogResult = true;
            }
            else
            {
                if (e.Key == Key.Escape)
                {
                    this.Close();
                }
            }
        }
    }
}
