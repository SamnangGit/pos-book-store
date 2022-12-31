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
    /// Interaction logic for SaleRecordViewWindow.xaml
    /// </summary>
    public partial class SaleRecordViewWindow : Window
    {
        BookstoreDBEntities db = new BookstoreDBEntities();
        List<SaleData> SaleDataList = new List<SaleData>();
        List<Sale> dbSaleList = new List<Sale>();
        public POSSellWindow pOSSell;

        private class SaleData
        {
            public int Id { get; set; }
            public decimal Total_price { get; set; }
            public decimal Total_paid { get; set; }
            public decimal Total_remain { get; set; }
            public string Employee { get; set; }
            public string Customer { get; set; }

        }
        public SaleRecordViewWindow()
        {
            InitializeComponent();
        }

        private void addDataToSaleView()
        {
            foreach (Sale s in db.Sales)
            {
                SaleData sd = new SaleData
                {
                    Id = s.Id,
                    Total_price = s.Total_price,
                    Total_paid = s.Total_paid,
                    Total_remain = s.Total_remain,
                    Employee = s.Employee.Name,
                    Customer = s.Customer.Name
                };
                SaleDataList.Add(sd);
                dbSaleList.Add(s);
                dgSale.Items.Add(sd);
            }
        }
        private void frmSaleRecord_Loaded(object sender, RoutedEventArgs e)
        {
            addDataToSaleView();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
