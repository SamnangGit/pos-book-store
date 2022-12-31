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

namespace BookStoreDBFirst
{
    /// <summary>
    /// Interaction logic for CustomerViewWindow.xaml
    /// </summary>
    public partial class CustomerViewWindow : Window
    {
        private BookstoreDBEntities db = new BookstoreDBEntities();
        private List<Customer> CustomerList = new List<Customer>();
        public CustomerOPWindow customerOP;

        public class CustomerData
        {
            public string Id { set; get; }
            public string Name { set; get; }
            public string Phone { set; get; }
            public string Email { set; get; }
            public string Address { set; get; }
        }
        public CustomerViewWindow()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void frmCustomer_Loaded(object sender, RoutedEventArgs e)
        {
            foreach(Customer c in db.Customers)
            {
                CustomerData customerData = new CustomerData { Id = c.Id.ToString(), Name = c.Name, Phone = c.Phone_number, Email = c.Email, Address = c.Address };
                dgCustomer.Items.Add(customerData);
                CustomerList.Add(c);
                //MessageBox.Show(c.Id.ToString());
            }
            //dgCustomer.ItemsSource = Customers;

        }

        private void dgCustomer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //DataGridRow row = sender as DataGridRow;
            //DataGridRow.MouseDoubleClickEvent = new RoutedEvent;
            //dgCustomer.SelectedCells.IndexOf(dgCustomer.SelectedCells[dgCustomer.SelectedIndex]);
            //MessageBox.Show(dgCustomer.SelectedIndex.ToString());
            //customerOP.pullDataFromView(CustomerList[dgCustomer.SelectedIndex]);
            if(customerOP != null)
                customerOP.pullDataFromView(CustomerList[dgCustomer.SelectedCells.IndexOf(dgCustomer.SelectedCells[dgCustomer.SelectedIndex])]);
            else
            {
                CustomerOPWindow customerOP = new CustomerOPWindow();
                customerOP.pullDataFromView(CustomerList[dgCustomer.SelectedCells.IndexOf(dgCustomer.SelectedCells[dgCustomer.SelectedIndex])]);
                customerOP.ShowDialog();
            }
            this.Close();
            
        }

    }
}
