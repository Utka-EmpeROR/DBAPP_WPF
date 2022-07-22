using System;
using System.Data.OleDb;
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
    /// Interaction logic for AdminPanelWindow2.xaml
    /// </summary>
    public partial class AdminPanelWindow2 : Window
    {
        Window Win;

        List<Material> ShownMaterials;
        Material current;
        List<Material> Materials;
        List<string> Units;
        List<EquipmentType> MatsTypes;
        public AdminPanelWindow2(Window win)
        {
            this.Win = win;
            Win.IsEnabled = false;
            Win.Hide();
            InitializeComponent();

            LoadData();

        }
        private void LoadData()
        {
            LoadMaterials();
        }

        private void LoadMaterials()
        {
            SaveChangesMatsButton.IsEnabled = false;
            DeleteMatsButton.IsEnabled = false;
            Units = new List<String>();
            string str = "SELECT * FROM Units";
            OleDbCommand command = new OleDbCommand(str, Config.myDB);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Units.Add(reader.GetString(1));
            }
            reader.Close();
            MatsTypes = new List<EquipmentType>();
            str = "SELECT * FROM Equipment_types";
            command = new OleDbCommand(str, Config.myDB);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                MatsTypes.Add(new EquipmentType(reader.GetString(0),
                    reader.GetString(1), reader.GetInt16(2)));
            }
            reader.Close();
            Materials = new List<Material>();
            str = "SELECT * FROM Materials";
            command = new OleDbCommand(str, Config.myDB);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Materials.Add(new Material(reader.GetString(0), reader.GetString(1),
                    reader.GetString(2), reader.GetString(3), reader.GetString(4),
                    reader.GetDouble(5), reader.GetString(6), reader.GetInt32(7),
                    reader.GetString(8)));
            }
            reader.Close();
            UnitsMatsComboBox.Items.Clear();
            foreach (var unit in Units)
            {
                this.UnitsMatsComboBox.Items.Add(unit);
            }
            TypeMatsComboBox.Items.Clear();
            foreach (var type in MatsTypes)
            {
                this.TypeMatsComboBox.Items.Add(type.TypeName);
            }
            ShownMaterials = new List<Material>();
            MaterialsDataGrid.ItemsSource = ShownMaterials;
            ZipAllMaterialsDataGrid.ItemsSource = ShownMaterials;
            UpdateMaterials();
        }

        private void LoadZips()
        {

        }

        private void UpdateMaterials()
        {
            ShownMaterials.Clear();
            foreach (var mat in Materials)
            {
                ShownMaterials.Add(mat);
            }
            SearchMatsTextBox.Clear();
            MaterialsDataGrid.ItemsSource = "";
            MaterialsDataGrid.ItemsSource = ShownMaterials;
            ArticleMatsTextBox.Text = "";
            CountryMatsTextBox.Text = "";
            NameRuMatsTextBox.Text = "";
            NameEnMatsTextBox.Text = "";
            FirmMatsTextBox.Text = "";
            CostMatsTextBox.Text = "";
            MinMatsTextBox.Text = "";
            TypeMatsComboBox.Text = "";
            UnitsMatsComboBox.Text = "";
            SaveChangesMatsButton.IsEnabled = false;
            DeleteMatsButton.IsEnabled = false;
        }

        private void Adm2_Closed(object sender, EventArgs e)
        {
            Win.IsEnabled = true;
            Win.Show();
        }

        private void MaterialsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            current = (Material)MaterialsDataGrid.SelectedItem;
            if (current == null)
            {
                return;
            }
            ArticleMatsTextBox.Text = current.article;
            CountryMatsTextBox.Text = current.country;
            NameRuMatsTextBox.Text = current.nameRu;
            NameEnMatsTextBox.Text = current.nameEn;
            FirmMatsTextBox.Text = current.firm;
            CostMatsTextBox.Text = current.cost.ToString();
            MinMatsTextBox.Text = current.minNumber.ToString();
            TypeMatsComboBox.Text = current.matsType;
            UnitsMatsComboBox.Text = current.units;
            SaveChangesMatsButton.IsEnabled = true;
            DeleteMatsButton.IsEnabled = true;
        }

        private void SaveChangesMatsButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsMatCorrect())
            {
                DeleteMat(true);
                NewMatsButton_Click(sender, e);
            }
            else
            {
                MessageBox.Show((string)FindResource("cannotSaveChangesMat"));
            }
        }

        private void NewMatsButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsMatCorrect())
            {
                try
                {
                    string article = ArticleMatsTextBox.Text;
                    string nameRu = NameRuMatsTextBox.Text;
                    string nameEn = NameEnMatsTextBox.Text == "" ? "-" : NameEnMatsTextBox.Text;
                    string country = CountryMatsTextBox.Text == "" ? "-" : CountryMatsTextBox.Text;
                    string units = UnitsMatsComboBox.Text == "" ? "-" : UnitsMatsComboBox.Text;
                    double cost = (CostMatsTextBox.Text != "" &&
                        double.TryParse(CostMatsTextBox.Text, out double matCost)) ? matCost : 0;
                    string matsType = TypeMatsComboBox.Text == "" ? "-" : TypeMatsComboBox.Text;
                    int minMatNum = MinMatsTextBox.Text != "" &&
                        int.TryParse(MinMatsTextBox.Text, out int matNum) ? matNum : 0;
                    string firm = FirmMatsTextBox.Text == "" ? "-" : FirmMatsTextBox.Text;
                    Material newMat = new Material(article, nameRu, nameEn, country,
                        units, cost, matsType, minMatNum, firm);

                    string str = "INSERT INTO Materials (mats_article, mats_name_ru, mats_name_en, mats_country, mats_units," +
                    " mats_cost, mats_type, mats_min_number, mats_firm) VALUES (@mats_article, @mats_name_ru, @mats_name_en," +
                    " @mats_country, @mats_units, @mats_cost, @mats_type, @mats_min_number, @mats_firm)";
                    OleDbCommand cmd = new OleDbCommand(str, Config.myDB);
                    cmd.Parameters.AddWithValue("@mats_article", newMat.article);
                    cmd.Parameters.AddWithValue("@mats_name_ru", newMat.nameRu);
                    cmd.Parameters.AddWithValue("@mats_name_en", newMat.nameEn);
                    cmd.Parameters.AddWithValue("@mats_country", newMat.country);
                    cmd.Parameters.AddWithValue("@mats_units", newMat.units);
                    cmd.Parameters.AddWithValue("@mats_cost", newMat.cost);
                    cmd.Parameters.AddWithValue("@mats_type", newMat.matsType);
                    cmd.Parameters.AddWithValue("@mats_min_number", newMat.minNumber);
                    cmd.Parameters.AddWithValue("@mats_firm", newMat.firm);
                    cmd.ExecuteNonQuery();

                    Materials.Add(newMat);
                    UpdateMaterials();
                }
                catch (InvalidCastException)
                {
                    MessageBox.Show("Error occured (create new mat)");
                }
            }
            else
            {
                MessageBox.Show((string)FindResource("cannotCreateNewMat"));
            }
        }

        private void DeleteMatsButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteMat();
        }

        private void DeleteMat(bool skipQuestion = false)
        {
            if (skipQuestion || MessageBox.Show((string)FindResource("deleteMatQuestion"),
                "???", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    string str = "DELETE FROM Materials WHERE (mats_article='" + current.article + "')";
                    OleDbCommand cmd = Config.myDB.CreateCommand();
                    cmd.CommandText = str;
                    cmd.ExecuteNonQuery();
                    Materials.Remove(current);
                    if (!skipQuestion)
                    {
                        UpdateMaterials();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error occured (delete mat)");
                }
            }
        }

        private bool IsMatCorrect()
        {
            if (ArticleMatsTextBox.Text == "" ||
                (Materials.Exists(mat => mat.article == ArticleMatsTextBox.Text) &&
                Materials.Find(mat => mat.article == ArticleMatsTextBox.Text) != current))
            {
                return false;
            }
            if (NameRuMatsTextBox.Text == "" || UnitsMatsComboBox.Text == "" ||
                TypeMatsComboBox.Text == "")
            {
                return false;
            }
            if (CostMatsTextBox.Text != "" && !double.TryParse(CostMatsTextBox.Text, out double cost))
            {
                return false;
            }
            return true;
        }

        private void SearchMatsTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateMaterials();
            ShownMaterials.RemoveAll(mat => !mat.nameRu.Contains(SearchMatsTextBox.Text) &&
            !mat.article.Contains(SearchMatsTextBox.Text) && !mat.nameEn.Contains(SearchMatsTextBox.Text));
        }

        private void UpdateZips()
        {
            ZipAllMaterialsDataGrid.IsEnabled = false;
            ZipSearchMatsTextBox.Clear();
            ZipRemoveMatButton.IsEnabled = false;
            ZipMatCountTextBox.IsEnabled = false;
            ZipDeleteButton.IsEnabled = false;
            ZipAddMatButton.IsEnabled = false;
            ZipRenameButton.IsEnabled = false;
            ZipMatCountTextBox.Text = "";

            ShownMaterials.Clear();
            foreach (var mat in Materials)
            {
                ShownMaterials.Add(mat);
            }
        }

        private void Tab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateMaterials();
            UpdateZips();
        }

        private void ZipSearchMatsTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShownMaterials.Clear();
            foreach (var mat in Materials)
            {
                ShownMaterials.Add(mat);
            }
            ZipAddMatButton.IsEnabled = false;

            ShownMaterials.RemoveAll(mat => !mat.nameRu.Contains(ZipSearchMatsTextBox.Text) &&
            !mat.article.Contains(ZipSearchMatsTextBox.Text) && !mat.nameEn.Contains(ZipSearchMatsTextBox.Text));
            ZipAllMaterialsDataGrid.ItemsSource = "";
            ZipAllMaterialsDataGrid.ItemsSource = ShownMaterials;
        }
    }
}
