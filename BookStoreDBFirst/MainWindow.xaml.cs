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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCustomerView_Click(object sender, RoutedEventArgs e)
        {
            //this.Close();
            CustomerViewWindow customerViewWindow = new CustomerViewWindow();
            customerViewWindow.ShowDialog();
        }

        private void btnBookView_Click(object sender, RoutedEventArgs e)
        {
            //this.Close()
            BookViewWindow bookViewWindow = new BookViewWindow();
            bookViewWindow.ShowDialog();
        }

        private void btnEmployeeView_Click(object sender, RoutedEventArgs e)
        {
            EmployeeViewWindow employeeViewWindow = new EmployeeViewWindow();
            employeeViewWindow.ShowDialog();
        }

        private void btnAuthorView_Click(object sender, RoutedEventArgs e)
        {
            AuthorViewWindow authorViewWindow = new AuthorViewWindow();
            authorViewWindow.ShowDialog();
        }

        private void btnCustomerOP_Click(object sender, RoutedEventArgs e)
        {
            CustomerOPWindow customerOPWindow = new CustomerOPWindow();
            customerOPWindow.ShowDialog();
        }

        private void btnPOSSell_Click(object sender, RoutedEventArgs e)
        {
            POSSellWindow pOSSellWindow = new POSSellWindow();
            pOSSellWindow.ShowDialog();
        }

        private void btnEmployeeOP_Click(object sender, RoutedEventArgs e)
        {
            EmployeeOPWindow employeeOPWindow = new EmployeeOPWindow();
            employeeOPWindow.ShowDialog();
        }

        private void btnAuthorOP_Click(object sender, RoutedEventArgs e)
        {
            return;
        }

        private void btnBookOP_Click(object sender, RoutedEventArgs e)
        {
            BookOPWindow bookOPWindow = new BookOPWindow();
            bookOPWindow.ShowDialog();
        }

        private void btnRecordView_Click(object sender, RoutedEventArgs e)
        {
            SaleRecordViewWindow saleRecordViewWindow = new SaleRecordViewWindow();
            saleRecordViewWindow.ShowDialog();
        }
    }
}
