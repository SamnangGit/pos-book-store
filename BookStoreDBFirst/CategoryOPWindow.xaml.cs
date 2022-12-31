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
    /// Interaction logic for CategoryOPWindow.xaml
    /// </summary>
    public partial class CategoryOPWindow : Window
    {
        BookstoreDBEntities db = new BookstoreDBEntities();

        public CategoryOPWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Category c = new Category();
            c.Id = getLatestCategoryId();
            c.Name = txtName.Text;
            db.Categories.Add(c);
            db.SaveChanges();
            txtName.Clear();
            MessageBox.Show("Added successfully");
        }

        private int getLatestCategoryId()
        {
            Category c = db.Categories.OrderByDescending(cc => cc.Id).FirstOrDefault();
            if (c != null)
                return c.Id+1;
            return 1;
        }
        
    }
}
