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
    /// Interaction logic for BookOPWindow.xaml
    /// </summary>
    public partial class BookOPWindow : Window
    {
        private BookstoreDBEntities db = new BookstoreDBEntities();
        //public BookViewWindow bookView = new BookViewWindow();

        public BookOPWindow()
        {
            InitializeComponent();
        }

        private void fillcmbCategory_Author_Publisher()
        {
            foreach(Category category in db.Categories)
            {
                if(category != null)
                {
                    cmbCategory.Items.Add(category.Name);
                }
            }
            foreach(Author author in db.Authors)
            {
                if(author != null)
                {
                    cmbAuthor.Items.Add(author.Name);
                }
            }
            foreach(Publisher publisher in db.Publishers)
            {
                if(publisher != null)
                {
                    cmbPublisher.Items.Add(publisher.Name);
                }
            }
        }
        private void frmBookOP_Loaded(object sender, RoutedEventArgs e)
        {
            fillcmbCategory_Author_Publisher();
            txtId.Text = getLatestBookId().ToString();
            MessageBox.Show(popularAuthor().Name);
        }
        

        private void defualttxt()
        {
            txtName.Text = "Name";
            txtName.Opacity = 0.30;
        }


        private Author popularAuthor()
        {
            Sale_detail saleDetail = db.Sale_detail.OrderByDescending(sad => sad.Quantity).FirstOrDefault();
            if(saleDetail != null)
            {
                Author author = db.Authors.Where(aa => aa.Name == saleDetail.Book.Author.Name).FirstOrDefault();
                return author;
            }
            return null;
        }


        private void clear()
        {
            txtName.Clear();
            txtPages.Clear();
            txtDescription.Clear();
            txtQuantity.Clear();
            cmbAuthor.Text = "";
            cmbCategory.Text = "";
            cmbPublisher.Text = "";
            txtId.Text = getLatestBookId().ToString();
        }

        private int getLatestBookId()
        {
            Book b = db.Books.OrderByDescending(bb => bb.Id).FirstOrDefault();
            if (b != null)
                return b.Id + 1;
            return 1;
            
        }

        public void pullDataFromView(BookViewWindow.BookData b)
        {
            txtId.Text = b.Id.ToString();
            txtName.Text = b.Title;
            txtPages.Text = b.Pages.ToString();
            txtDescription.Text = b.Description;
            txtQuantity.Text = b.Quantity.ToString();
            cmbAuthor.Text = b.Author;
            cmbCategory.Text = b.Category;
            cmbPublisher.Text = b.Publisher;

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Book b = new Book();
            Stock s = new Stock();
            b.Id = getLatestBookId();
            b.Name = txtName.Text;
            b.Number_of_page = int.Parse(txtPages.Text);
            b.Description = txtDescription.Text;
            Author author = db.Authors.Where(a => a.Name == cmbAuthor.Text).FirstOrDefault();
            b.Author_id = author.Id;
            Category category = db.Categories.Where(cat => cat.Name == cmbCategory.Text).FirstOrDefault();
            b.Category_id = category.Id;
            Publisher publisher = db.Publishers.Where(pub => pub.Name == cmbPublisher.Text).FirstOrDefault();
            b.Publisher_id = publisher.Id;
            db.Books.Add(b);
            db.SaveChanges();

            s.Quantity = int.Parse(txtQuantity.Text);
            s.Book_id = b.Id;
            db.Stocks.Add(s);
            db.SaveChanges();

            clear();
            MessageBox.Show("Book added successfully");
            
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int bookId = int.Parse(txtId.Text);
            Book b = db.Books.Where(bb => bb.Id == bookId).FirstOrDefault();
            if (b != null)
            {
                b.Name = txtName.Text;
                b.Number_of_page = int.Parse(txtPages.Text);
                b.Description = txtDescription.Text;
                Author author = db.Authors.Where(a => a.Name == cmbAuthor.Text).FirstOrDefault();
                b.Author_id = author.Id;
                Category category = db.Categories.Where(cat => cat.Name == cmbCategory.Text).FirstOrDefault();
                b.Category_id = category.Id;
                Publisher publisher = db.Publishers.Where(pub => pub.Name == cmbPublisher.Text).FirstOrDefault();
                b.Publisher_id = publisher.Id;
                db.SaveChanges();

                Stock s = db.Stocks.Where(ss => ss.Id == bookId).FirstOrDefault();
                s.Quantity = int.Parse(txtQuantity.Text);
                db.SaveChanges();

                clear();
                MessageBox.Show("Book Updated successfully");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int bookId = int.Parse(txtId.Text);
            Book b = db.Books.Where(bb => bb.Id == bookId).FirstOrDefault();
            if (b != null)
            {
                Stock s = db.Stocks.Where(ss => ss.Id == bookId).FirstOrDefault();
                db.Stocks.Remove(s);
                db.SaveChanges();

                db.Books.Remove(b);
                db.SaveChanges();

                clear();
                MessageBox.Show("Book Deleted successfully");

            }
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            BookViewWindow bookViewWindow = new BookViewWindow();
            bookViewWindow.bookOP = this;
            bookViewWindow.ShowDialog();

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAddCatergory_Click(object sender, RoutedEventArgs e)
        {
            CategoryOPWindow categoryOPWindow = new CategoryOPWindow();
            categoryOPWindow.ShowDialog();
        }

        private void btnAddAuthor_Click(object sender, RoutedEventArgs e)
        {
            AuthorOPWindow authorOPWindow = new AuthorOPWindow();
            authorOPWindow.ShowDialog();
        }

        private void btnAddPublisher_Click(object sender, RoutedEventArgs e)
        {
            PublisherOPWindow publisherOPWindow = new PublisherOPWindow();
            publisherOPWindow.ShowDialog();
        }
    }
}
