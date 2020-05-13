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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SetWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Set<string> Mans;
        public Set<string> Womans;
        public Set<string> Childrens;
        public Set<string> Readers;
        public Set<string> Workers;

        public MainWindow()
        {
            InitializeComponent();
            Mans = new Set<string>(new List<string> { "Gor", "Armen", "Andranik", "Varazdat", "Artur", "Karen", "Erik", "Vardges" });
            Womans = new Set<string>(new List<string> { "Anahit", "Gayane", "Ani", "Karine", "Liana", "Emma", "Narine", "Mari" });
            Childrens = new Set<string>(new List<string> { "Anahit", "Karen", "Ani", "Varazdat", "Liana", "Erik", "Armen", "Mari" });
            Readers = new Set<string>(new List<string> { "Anahit", "Gayane", "Varazdat", "Liana", "Karen" });
            Workers = new Set<string>(new List<string> { "Karen", "Ani", "Emma", "Varazdat" });
        }

        private void EvaluateBtnClick(object sender, RoutedEventArgs e)
        {
            string firstBox = string.Empty;
            string setType = string.Empty;
            string secondBox = string.Empty;
            GetActiveValueFromComboBox(ref firstBox, ref setType, ref secondBox);
            
            Set<string> firstSet = GetSpecificSetFromName(firstBox);
            Set<string> secondSet = GetSpecificSetFromName(secondBox);
            Set<string> resultSet = new Set<string>();
            resultSet = UpdateSetWithSpecificSetType(firstSet, secondSet, setType);
            UpdateListBoxses(resultSet, "ResultList");
            //MessageBox.Show($"{firstBox}, {setType}, {secondBox}");
        }

        private Set<string> UpdateSetWithSpecificSetType(Set<string> firstSet, Set<string> secondSet, string setType)
        {
            switch (setType.ToLower().Replace(" ","")) 
            {
                case "union":
                    return firstSet.Union(secondSet);
                case "intersection":
                    return firstSet.Intersection(secondSet);
                case "difference":
                    return firstSet.Difference(secondSet);
                case "symmetricdifference":
                    return firstSet.SymmetricDifference(secondSet);
            }
            return null;
        }

        private void GetActiveValueFromComboBox(ref string firstBox, ref string setType, ref string secondBox)
        {
            ComboBoxItem typeItem = (ComboBoxItem)FirstBox.SelectedItem;
            firstBox = typeItem.Content.ToString();
            typeItem = (ComboBoxItem)SetType.SelectedItem;
            setType = typeItem.Content.ToString();
            typeItem = (ComboBoxItem)SecondBox.SelectedItem;
            secondBox = typeItem.Content.ToString();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            switch (comboBox.Name)
            {
                case "FirstBox":
                    ComboBoxItem firstItem = (ComboBoxItem)FirstBox.SelectedItem;
                    string firstBox = firstItem.Content.ToString();
                    Set<string> firstSet = GetSpecificSetFromName(firstBox);
                    UpdateListBoxses(firstSet, "FirstList");
                    break;
                case "SecondBox":
                    ComboBoxItem secondItem = (ComboBoxItem)SecondBox.SelectedItem;
                    string secondBox = secondItem.Content.ToString();
                    Set<string> secondSet = GetSpecificSetFromName(secondBox);
                    UpdateListBoxses(secondSet, "SecondList");
                    break;
            }
        }

        private void UpdateListBoxses(Set<string> set, string listName)
        {
            ListBox listBox = (ListBox)FindName(listName);
            listBox.Items.Clear();
            foreach (var item in set)
            {
                listBox.Items.Add(item);
            }
        }

        private Set<string> GetSpecificSetFromName(string activeValue)
        {
            switch (activeValue.ToLower())
            {
                case "mans":
                    return Mans;
                case "womans":
                    return Womans;
                case "childrens":
                    return Childrens;
                case "readers":
                    return Readers;
                case "workers":
                    return Workers;
            }
            return null;
        }
    }
}
