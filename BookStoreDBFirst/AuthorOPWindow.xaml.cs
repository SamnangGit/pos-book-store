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
    /// Interaction logic for AuthorOPWindow.xaml
    /// </summary>
    public partial class AuthorOPWindow : Window
    {
        BookstoreDBEntities db = new BookstoreDBEntities();
        public AuthorOPWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Author a = new Author();
            a.Id = getLatestAuthorId();
            a.Name = txtName.Text;
            db.Authors.Add(a);
            db.SaveChanges();
            txtName.Clear();
            MessageBox.Show("Added successfully");
        }

        private int getLatestAuthorId()
        {
            Author a = db.Authors.OrderByDescending(aa => aa.Id).FirstOrDefault();
            if(a != null)
                return a.Id+1;
            return 1;
        }

    }
}
