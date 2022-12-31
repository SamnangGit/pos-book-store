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
    /// Interaction logic for EmployeeViewWindow.xaml
    /// </summary>
    public partial class EmployeeViewWindow : Window
    {
        private BookstoreDBEntities db = new BookstoreDBEntities();
        private List<Employee> EmployeeList = new List<Employee>();
        public EmployeeOPWindow employeeOP;

        public class EmployeeData
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Role { get; set; }
            public DateTime DOB { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
        }
        
        public EmployeeViewWindow()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void frmEmployee_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (Employee ee in db.Employees)
            {
                if(ee != null)
                {
                    EmployeeData employeeData = new EmployeeData { Id = ee.Id,
                                                                    Name = ee.Name,
                                                                    Role = ee.Role,
                                                                    DOB = ee.DOB,
                                                                    Email = ee.Email,
                                                                    Phone = ee.Phone_number,
                                                                    Address = ee.Address
                                                                    };
                    dgEmployee.Items.Add(employeeData);
                    EmployeeList.Add(ee);
                }
            }
        }

        private void dgEmployee_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (employeeOP != null)
                employeeOP.pullDataFromView(EmployeeList[dgEmployee.SelectedCells.IndexOf(dgEmployee.SelectedCells[dgEmployee.SelectedIndex])]);
            else
            {
                EmployeeOPWindow employeeOP = new EmployeeOPWindow();
                employeeOP.pullDataFromView(EmployeeList[dgEmployee.SelectedCells.IndexOf(dgEmployee.SelectedCells[dgEmployee.SelectedIndex])]);
                employeeOP.ShowDialog();
            }
            this.Close();
        }
    }
}
