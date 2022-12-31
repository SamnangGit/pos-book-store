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
    public partial class EmployeeOPWindow : Window
    {
        private BookstoreDBEntities db = new BookstoreDBEntities();
        //EmployeeViewWindow employeeViewWindow;
        public EmployeeOPWindow()
        {
            InitializeComponent();
        }

        private void frmEmployeeOP_Loaded(object sender, RoutedEventArgs e)
        {
            txtId.Text = getLatestEmployeeId().ToString();
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void clear()
        {
            txtId.Clear();
            txtName.Clear();
            txtRole.Clear();
            txtDOB.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtAddress.Clear();

            txtId.Text = getLatestEmployeeId().ToString();
        }

        private int getLatestEmployeeId()
        {
            
            Employee employee = db.Employees.OrderByDescending(ee => ee.Id).FirstOrDefault();
            if(employee != null)
                return employee.Id + 1;
            return 1;
        }
        public void pullDataFromView(Employee employee)
        {
            txtId.Text = employee.Id.ToString();
            txtName.Text = employee.Name;
            txtRole.Text = employee.Role;
            txtDOB.Text = employee.DOB.ToString();
            txtPhone.Text = employee.Phone_number;
            txtEmail.Text = employee.Email;
            txtAddress.Text = employee.Address;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = new Employee();
            employee.Id = getLatestEmployeeId();
            employee.Name = txtName.Text;
            employee.Role = txtRole.Text;
            DateTime date = Convert.ToDateTime(txtDOB.Text);
            employee.DOB = date;
            employee.Phone_number = txtPhone.Text;
            employee.Email = txtEmail.Text;
            employee.Address = txtAddress.Text;
            db.Employees.Add(employee);
            db.SaveChanges();
            MessageBox.Show("*Employee has been added successgully*");
            clear();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int EmployeeId = int.Parse(txtId.Text);
            Employee employee = db.Employees.Where(ee => ee.Id == EmployeeId).FirstOrDefault();
            if(employee != null)
            {
                employee.Name = txtName.Text;
                employee.Role = txtRole.Text;
                DateTime date = Convert.ToDateTime(txtDOB.Text);
                employee.DOB = date;
                employee.Phone_number = txtPhone.Text;
                employee.Email = txtEmail.Text;
                employee.Address = txtAddress.Text;
                db.SaveChanges();
                MessageBox.Show("*Employee has been updated successgully*");
                clear();
            }
        }
        
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int EmployeeId = int.Parse(txtId.Text);
            Employee employee = db.Employees.Where(ee => ee.Id == EmployeeId).FirstOrDefault();
            if( employee != null )
            {
                db.Employees.Remove(employee);
                db.SaveChanges();
                MessageBox.Show("*Employee has been deleted successgully*");
                clear();
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            clear();
            txtId.Text = getLatestEmployeeId().ToString(); 
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            EmployeeViewWindow employeeViewWindow = new EmployeeViewWindow();
            employeeViewWindow.employeeOP = this;
            employeeViewWindow.ShowDialog();
        }
    }
}
