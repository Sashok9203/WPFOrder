using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        private int _personCount = 1;
        private int personCount
        {
            get => _personCount;
            set
            {
                _personCount = value > 12 || value < 1 ? 1 : value;
                personCountTextBox.Text = personCount.ToString();
            }
        }
        private readonly List<Order> orders;

        public MainWindow()
        {
            orders = new();
            InitializeComponent();
            calendar.DisplayDateStart = DateTime.Now;
        }

        private void OrderButtonClick(object sender, RoutedEventArgs e)
        {
            RadioButton? tmp = rButtons.Children.OfType<RadioButton>().FirstOrDefault(n => (bool)n.IsChecked);
            DateTime[]? dates = calendar.SelectedDates.ToArray();
            if (!fillCheck(tmp, dates)) return;
            Order order = new(nameSurnameTextBox.Text, contactInfoTextBox.Text, personCount,
                Enum.Parse<Order.NQuality>(tmp.Content.ToString()),
                calendar.SelectedDates.ToArray());
            orders.Add(order);
            MessageBox.Show(order.ToString(), "Order"); ;
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            personCount = 1;
            nameSurnameTextBox.Text = string.Empty;
            contactInfoTextBox.Text = string.Empty;
            personCountTextBox.Text = "1";
            accept.IsChecked = false;
            foreach (var item in rButtons.Children.OfType<RadioButton>())
                item.IsChecked = false;
        }

        private void AddButtonClick(object sender, RoutedEventArgs e) => personCount++;


        private bool fillCheck(RadioButton? button, DateTime[]? dates)
        {
            int count = 1;
            string message;
            if (string.IsNullOrEmpty(nameSurnameTextBox.Text)) message = "Enter name and surname";
            else if (string.IsNullOrEmpty(contactInfoTextBox.Text)) message = "Enter contact information";
            else if (!int.TryParse(personCountTextBox.Text, out count) || count > 12 || count < 1) message = "Invalid person count value";
            else if (button == null) message = "Choose room quality";
            else if (dates?.Length == 0) message = "Choose date range";
            else
            {
                personCount = count;
                return true;
            }
            MessageBox.Show(message, "Error");
            personCount = count;
            return false;
        }
       
    } 
}
