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
    /// Interaction logic for PublisherOPWindow.xaml
    /// </summary>
    public partial class PublisherOPWindow : Window
    {
        BookstoreDBEntities db = new BookstoreDBEntities();
        public PublisherOPWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Publisher p = new Publisher();
            p.Id = getLatestPublisherId();
            p.Name = txtName.Text;
            DateTime date = Convert.ToDateTime(txtDate.Text);
            p.Date_of_publishing = date;
            db.Publishers.Add(p);
            db.SaveChanges();
            txtName.Clear();
            txtDate.Clear();
            MessageBox.Show("Added successfully");
        }

        private int getLatestPublisherId()
        {
            Publisher p = db.Publishers.OrderByDescending(pp => pp.Id).FirstOrDefault();
            if (p != null)
                return p.Id + 1;
            return 1;
        }
    }
}
