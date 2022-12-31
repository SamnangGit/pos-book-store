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
    /// Interaction logic for POSSellWindow.xaml
    /// </summary>
    public partial class POSSellWindow : Window
    {
        private BookstoreDBEntities db = new BookstoreDBEntities();
        List<Sale_detail> SaleDetailList = new List<Sale_detail>();
        List<Book> dbBookList = new List<Book>();
        List<BookForSellData> BookForSellDataList = new List<BookForSellData>();
        public Book currentBook = null;
        public Sale currentSale  = null;
        private class SaleDetailData
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Quantity { get; set; }
            public decimal Total_price { get; set; }
        }

        private class BookForSellData
        {
            public string Name { get; set; }
            public decimal? Unit_price { get; set; }
            public int Id { get; set; }
            public int Quantity { get; set; }
            public int? Discount { get; set; }
            public decimal Total_price { get; set; }
        }
        public POSSellWindow()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void fillcmbCustomer_Employee()
        {
            foreach (Employee emp in db.Employees)
            {
                if (emp != null)
                {
                    cmbEmployee.Items.Add(emp.Name);
                }
            }

            foreach (Customer cus in db.Customers)
            {
                if (cus != null)
                {
                    cmbCustomer.Items.Add(cus.Name);
                }
            }
        }

        private void clear()
        {
            txtName.Clear();
            txtQuantity.Clear();
            txtDiscount.Clear();
            txtUnitPrice.Clear();
            txtTotalPrice.Clear();
            txtInvoiceId.Text = getLatestSaleId().ToString();
            //MessageBox.Show(DateTime.Today.ToString());
        }

        private int getLatestSaleId()
        {
            Sale s = db.Sales.OrderByDescending(ss => ss.Id).FirstOrDefault();
            if (s != null)
            {
                return s.Id + 1 ;
            }
            return 1;
        }

        private int getLatestSaleDetailId()
        {
            Sale_detail sd = db.Sale_detail.OrderByDescending(sdd => sdd.Id).FirstOrDefault();  
            if (sd != null)
            {
                return sd.Id + 1 ;
            }
            return 1;
        }

        public void refreshProductList()
        {
            dgPOSSell.Items.Clear();
            //int id = 1;
            foreach(BookForSellData bsd in BookForSellDataList)
            {
                //BookForSellData bsd = new BookForSellData
                //{
                //    Name = currentBook.Name,
                //    Unit_price = (decimal)currentBook.Selling_price,
                //    Total_price = sd.Total_price,
                //    Quantity = sd.Quantity,
                //    Id = SaleDetailList.Count
                //};
                
                dgPOSSell.Items.Add(bsd);
                //id++;
                //SaleDetailList.Add(sd);
                txtAllTotalPrice.Text = getAllTotalPrice().ToString();
            }
        }
        public void pullDataFromView(BookViewWindow.BookData b)
        {
            //Book bb = getCurrentBook();
            txtName.Text = b.Title;
            int Quantity = 1;
            txtQuantity.Text = Quantity.ToString();
            txtUnitPrice.Text = b.Sell_price.ToString();
            decimal? TotalPrice;
            if (isDiscount() != null)
            {
                TotalPrice = ((Quantity * b.Sell_price) * (100 - isDiscount().Discount)) / 100;
                txtDiscount.Text = isDiscount().Discount.ToString();
            }
            else
                TotalPrice = Quantity * b.Sell_price;

            txtTotalPrice.Text = TotalPrice.ToString();

        }
        private void frmPOSSell_Loaded(object sender, RoutedEventArgs e)
        {
            fillcmbCustomer_Employee();
            txtInvoiceId.Text = getLatestSaleId().ToString();
            FocusManager.SetFocusedElement(frmPOSSell, txtBarcode);

            //string bCode = txtBarcode.Text;
            //if(compareBarcode(bCode) == true && )
            //{
            //    MessageBox.Show("Found");
            //}
        }

        private void dgPOSSell_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
        BookViewWindow bookViewWindow;
        private void btnBrowseProduct_Click(object sender, RoutedEventArgs e)
        {
            if (bookViewWindow == null)
            {
                bookViewWindow = new BookViewWindow();
                bookViewWindow.pOSSell = this;
                bookViewWindow.ShowDialog();
                bookViewWindow = null;
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void btnClearAll_Click(object sender, RoutedEventArgs e)
        {
            clearAll();
        }

        //private Book getCurrentBook()
        //{
        //    foreach (Book b in db.Books)
        //    {
        //        if (b.Name == txtName.Text)
        //        {
        //            return b;
        //        }
        //    }
        //    return null;
        //}

        private void txtQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int Quantity = int.Parse(txtQuantity.Text);
                decimal? UnitPrice = currentBook.Selling_price;
                decimal? TotalPrice;
                if (isDiscount() != null)
                {
                    TotalPrice = ((Quantity * currentBook.Selling_price) * (100 - isDiscount().Discount)) / 100;
                    txtDiscount.Text = isDiscount().Discount.ToString();
                }
                else
                    TotalPrice = Quantity * currentBook.Selling_price;
                txtTotalPrice.Text = TotalPrice.ToString();
            }catch (Exception ex)
            {
                return;
            }

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (isExitingBook())
            {
                refreshProductList();
                txtBarcode.Text = "";
                FocusManager.SetFocusedElement(frmPOSSell, txtBarcode);
            }
            else
            {
                txtBarcode.Text = "";
                FocusManager.SetFocusedElement(frmPOSSell, txtBarcode);

                Sale_detail sd = new Sale_detail();
                sd.Book_id = currentBook.Id;
                sd.Quantity = int.Parse(txtQuantity.Text);
                sd.Total_price = decimal.Parse(txtTotalPrice.Text);
                SaleDetailList.Add(sd);

                int? discountAmount;
                if (isDiscount() != null)
                    discountAmount = isDiscount().Discount;
                else
                    discountAmount = 0;

                BookForSellData bsd = new BookForSellData
                {
                    Id = SaleDetailList.Count,
                    Name = currentBook.Name,
                    Unit_price = (decimal)currentBook.Selling_price,
                    Discount = discountAmount,
                    Total_price = sd.Total_price,
                    Quantity = sd.Quantity,
                };
                dgPOSSell.Items.Add(bsd);
                BookForSellDataList.Add(bsd);
            }
            clear();
            txtAllTotalPrice.Text = getAllTotalPrice().ToString();
        }

        private bool isExitingBook()
        {
            foreach(BookForSellData bsd in BookForSellDataList)
            {
                if(bsd.Name == currentBook.Name)
                {
                    if (!string.IsNullOrEmpty(txtQuantity.Text))
                    {
                        bsd.Quantity += int.Parse(txtQuantity.Text);
                        bsd.Total_price += decimal.Parse(txtTotalPrice.Text);
                        return true;
                    }
                }
            }
            return false;
        }

        private decimal? getAllTotalPrice()
        {
            decimal? total = 0;
            foreach (BookForSellData bsd in BookForSellDataList)
            {
                total += bsd.Total_price;
            }
            return total;
        }

        private Flash_sale isDiscount()
        {
            Flash_sale fs = db.Flash_sale.Where(fss => fss.Book_id == currentBook.Id).FirstOrDefault();
            if (fs != null && fs.End_date >= DateTime.Today)
                return fs;
           return null;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Sale sale = new Sale();
            sale.Id = getLatestSaleId();
            sale.Total_price = Decimal.Parse(txtAllTotalPrice.Text);
            sale.Total_paid = Decimal.Parse(txtAllTotalPrice.Text);
            sale.Total_remain = 0;
            sale.Customer_id = db.Customers.Where(c => c.Name == cmbCustomer.Text).FirstOrDefault().Id;
            sale.Employee_id = db.Employees.Where(em => em.Name == cmbEmployee.Text).FirstOrDefault().Id;
            db.Sales.Add(sale);
            db.SaveChanges();

            foreach(Sale_detail sd in SaleDetailList)
            {
                sd.Sale_id = getLatestSaleId()-1;
                db.Sale_detail.Add(sd);
                db.SaveChanges();
            }

            foreach(BookForSellData bsd in BookForSellDataList)
            {
                Stock s = db.Stocks.Where(ss => ss.Book.Name == bsd.Name).FirstOrDefault();
                s.Quantity -= bsd.Quantity;
                db.SaveChanges();
            }

            MessageBox.Show("*Record saved successfully*");
            clearAll();
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            SaleViewWindow saleViewWindow = new SaleViewWindow();
            saleViewWindow.pOSSell = this;
            saleViewWindow.ShowDialog();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = dgPOSSell.SelectedIndex;
            if (selectedIndex != -1)
            {
                BookForSellDataList.RemoveAt(selectedIndex);
                SaleDetailList.RemoveAt(selectedIndex);
                refreshProductList();
            }
        }
        private void clearAll()
        {
            txtInvoiceId.Clear();
            cmbCustomer.Text = "";
            cmbEmployee.Text = "";
            txtAllTotalPrice.Clear();
            dgPOSSell.Items.Clear();
            clear();
            BookForSellDataList.Clear();
            SaleDetailList.Clear();
            enableOperationButton();
        }

        public void pullDataFromSale(Sale s)
        {
            clearAll();
            Book b;
            int? discountAmount;
            int i = 1;
            foreach (Sale_detail sd in db.Sale_detail.Where(sdd => sdd.Sale_id == s.Id))
            {
                b = db.Books.Where(bb => bb.Id == sd.Book_id).FirstOrDefault();
                discountAmount = db.Flash_sale.Where(fs => fs.Book_id == b.Id).FirstOrDefault().Discount;
                BookForSellData bsd = new BookForSellData
                {
                    Id = i,
                    Name = b.Name,
                    Unit_price = b.Selling_price,
                    Discount = discountAmount,
                    Total_price = sd.Total_price,
                    Quantity = sd.Quantity,
                };
                dgPOSSell.Items.Add(bsd);
                BookForSellDataList.Add(bsd);
                i++;
            }
            txtAllTotalPrice.Text = getAllTotalPrice().ToString();
            disableOperationButton();
        }

        private void disableOperationButton()
        {
            btnAdd.IsEnabled = false;
            btnRemove.IsEnabled = false;
            btnSave.IsEnabled = false;
            btnClear.IsEnabled = false;
            btnBrowseProduct.IsEnabled = false;
            cmbCustomer.IsEnabled = false;
            cmbEmployee.IsEnabled = false; 
        }

        private void enableOperationButton()
        {
            btnAdd.IsEnabled = true;
            btnRemove.IsEnabled = true;
            btnSave.IsEnabled = true;
            btnClear.IsEnabled = true;
            btnBrowseProduct.IsEnabled = true;
            cmbEmployee.IsEnabled = true;
            cmbCustomer.IsEnabled = true;
        }

        private Book compareBarcode(string barcode)
        {
           Book b = db.Books.Where(bb => bb.Barcode == txtBarcode.Text).FirstOrDefault();
            if (b == null)
                return null;
            return b;
        }

        private void getFinalBarcode()
        {
            if(btnAdd.Focusable == true)
            {
                txtBarcode.Text = String.Empty;
            }
        }

        private void txtBarcode_TextChanged(object sender, TextChangedEventArgs e)
        {
            string barcode = "";
            barcode = txtBarcode.Text;
            if (compareBarcode(barcode) != null)
            {
                currentBook = compareBarcode(barcode);
                txtName.Text = compareBarcode(barcode).Name;
                txtUnitPrice.Text  = compareBarcode(barcode).Selling_price.ToString();
                txtQuantity.Text = "1";
                txtTotalPrice.Text = compareBarcode(barcode).Selling_price.ToString();
                txtDiscount.Text = "0";

                btnAdd_Click(sender, e);

            }
        }
    }
}
