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
    /// Interaction logic for CustomerOPWindow.xaml
    /// </summary>
    public partial class CustomerOPWindow : Window
    {
        private BookstoreDBEntities db = new BookstoreDBEntities();
        public CustomerOPWindow()
        {
            InitializeComponent();
        }

        private void frmCustomerOP_Loaded(object sender, RoutedEventArgs e)
        {
            txtId.Text = getLatestCustomerId().ToString();
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void clear()
        {
            txtId.Clear();
            txtName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtAddress.Clear();

            txtId.Text = getLatestCustomerId().ToString();
        }

        private int getLatestCustomerId()
        {
            Customer customer = db.Customers.OrderByDescending(c => c.Id).FirstOrDefault();
            if(customer != null)
                return customer.Id + 1;
            return 1;
        }
        public void pullDataFromView(Customer customer)
        {
            txtId.Text = customer.Id.ToString();
            txtName.Text = customer.Name;
            txtPhone.Text = customer.Phone_number;
            txtEmail.Text = customer.Email;
            txtAddress.Text = customer.Address;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = new Customer();
            customer.Id = getLatestCustomerId();
            customer.Name = txtName.Text;
            customer.Phone_number = txtPhone.Text;
            customer.Email = txtEmail.Text;
            customer.Address = txtAddress.Text;
            db.Customers.Add(customer);
            db.SaveChanges();
            MessageBox.Show("*Customer has been added successgully*");
            clear();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int CustomerId = int.Parse(txtId.Text);
            Customer customer = db.Customers.Where(c => c.Id == CustomerId).FirstOrDefault();
            if(customer != null)
            {
                customer.Name = txtName.Text;
                customer.Phone_number = txtPhone.Text;
                customer.Email = txtEmail.Text;
                customer.Address = txtAddress.Text;
                db.SaveChanges();
                MessageBox.Show("*Customer has been updated successgully*");
                clear();
            }
        }
        
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int CustomerId = int.Parse(txtId.Text);
            Customer customer = db.Customers.Where(c => c.Id == CustomerId).FirstOrDefault();
            if( customer != null )
            {
                db.Customers.Remove(customer);
                db.SaveChanges();
                MessageBox.Show("*Customer has been deleted successgully*");
                clear();
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            clear();
            txtId.Text = getLatestCustomerId().ToString(); 
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            CustomerViewWindow customerViewWindow = new CustomerViewWindow();
            customerViewWindow.customerOP = this;
            customerViewWindow.ShowDialog();
        }
    }
}
