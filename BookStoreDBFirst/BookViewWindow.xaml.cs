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
    /// Interaction logic for BookViewWindow.xaml
    /// </summary>
    public partial class BookViewWindow : Window
    {
        private BookstoreDBEntities db = new BookstoreDBEntities();
        private List<BookData> BookList = new List<BookData>();
        private List<Book> dbBookList = new List<Book>();
        //private List<Stock> StockList = new List<Stock>(); 
        //private List<Publisher> PublisherList = new List<Publisher>();
        //private List<Author> AuthorList = new List<Author>();
        //private List<Category> CategoryList = new List<Category>();

        public BookOPWindow bookOP;
        public POSSellWindow pOSSell;
        public class BookData
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public int Pages { get; set; }
            public string Category { get; set; }
            public string Author { get; set; }
            public string Publisher { get; set; }
            public int Quantity { get; set; }
            public string Description { get; set; }
            public decimal Sell_price { get; set; }
            public decimal Cost_price { get; set; }
            public string Barcode { get; set; }

        }
        public BookViewWindow()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void frmBook_Loaded(object sender, RoutedEventArgs e)
        {
            foreach(Book b in db.Books)
            {
                if(b != null)
                {
                    BookData bookData = new BookData
                    {
                        Id = b.Id,
                        Title = b.Name,
                        Pages = b.Number_of_page,
                        Description = b.Description,
                        Category = b.Category.Name,
                        Author = b.Author.Name,
                        Publisher = b.Publisher.Name,
                        Quantity = db.Stocks.Where(ss => ss.Book_id == b.Id).FirstOrDefault().Quantity,
                        Cost_price = (decimal)b.Cost_price,
                        Sell_price = (decimal)b.Selling_price,
                        Barcode = b.Barcode
                    };
                    dgBook.Items.Add(bookData);
                    BookList.Add(bookData);
                    dbBookList.Add(b);
                }
            }
        }

        private void dgBook_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            if (bookOP != null)
                bookOP.pullDataFromView(BookList[dgBook.SelectedIndex]);
            //else
            //{
            //    BookOPWindow bookOPWindow = new BookOPWindow();
            //    bookOPWindow.pullDataFromView(BookList[dgBook.SelectedIndex]);
            //    bookOPWindow.ShowDialog();
            //}
            if (pOSSell != null)
            {
                pOSSell.currentBook = dbBookList[dgBook.SelectedIndex];
                pOSSell.pullDataFromView(BookList[dgBook.SelectedIndex]);
            }
            this.Close();

        }
    }
}
