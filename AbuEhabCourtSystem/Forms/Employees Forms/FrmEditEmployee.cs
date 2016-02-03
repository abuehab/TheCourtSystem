using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LowyerDatalayer.Tables_Classes;
using LowyerDatalayer;
namespace AbuEhabCourtSystem.Forms.Employees_Forms
{
    public partial class FrmEditEmployee : Form
    {
        public FrmEditEmployee()
        {
            InitializeComponent();
        }
        public Employee  TargetEmployee { get; set; }
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

        private void FrmEditEmployee_Load(object sender, EventArgs e)
        {
            LoadEmployeeData();

        }
        EmployeeCmd cmd = new EmployeeCmd();
        private void btnUpdtate_Click(object sender, EventArgs e)
        {
            if (txtEmployeeName.Text != string.Empty)
            {

                #region "            Save New Employee                         "
                // Complete code : كمل الحقول
            

                   TargetEmployee. EmployeeName = txtEmployeeName.Text;
                   TargetEmployee.IdCard = txtIdCard.Text;
                   TargetEmployee.Phone = txtPhone.Text;
                   TargetEmployee.Mobile = txtMobile.Text;
                   TargetEmployee.Address = txtAddress.Text;
                   TargetEmployee.Email = txtEmail.Text;
                   TargetEmployee.Salary = Convert.ToDouble(txtSalary.Text);



                   cmd.EditEmployee(TargetEmployee, TargetEmployee.Id);
                   this.Close();
                #endregion
            }
        }




    }
}
