using LowyerDatalayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AbuEhabCourtSystem.Forms.Employees_Forms
{
    public partial class FrmViewEmployee : Form
    {
        public FrmViewEmployee()
        {
            InitializeComponent();
        }
        public Employee TargetEmployee { get; set; }
        void LoadEmployeeData()
        {
            txtEmployeeName.Text = TargetEmployee.EmployeeName;
            txtAddress.Text = TargetEmployee.Address;
            txtEmail.Text = TargetEmployee.Email;
            txtIdCard.Text = TargetEmployee.IdCard;
            txtPhone.Text = TargetEmployee.Phone;
            txtMobile.Text = TargetEmployee.Mobile;
            txtSalary.Text = TargetEmployee.Salary.ToString();


        }
        private void FrmViewEmployee_Load(object sender, EventArgs e)
        {
            LoadEmployeeData();
        }
    }
}
