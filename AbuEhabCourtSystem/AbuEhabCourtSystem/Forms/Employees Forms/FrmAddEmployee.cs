using AbuEhabCourtSystem.Tables_Classes;
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
    public partial class FrmAddEmployee : Form
    {
        //
        public FrmAddEmployee()
        {
            InitializeComponent();
        }
        EmployeeCmd cmd = new EmployeeCmd();
        private void btnSave_Click(object sender, EventArgs e)
        {
     
            #region " Check  All Values First "
            // Your Code Here 
            if (txtEmployeeName.Text == string.Empty)
            { MessageBox.Show("أدخل الاسم الان  وبعدها يمكن لك التعديل او اكمال البيانات لاحقا"); return; }
            #endregion 

            
            #region " Check Current Employee if exiseted or not "

            // Your Code Here 
            Employee emp = cmd.GetEmployeeByName(txtEmployeeName.Text);
            if (emp != null) { MessageBox.Show(" موجود بالفعل "); ClearValues(); txtEmployeeName.Focus(); return; }
            #endregion

            if (txtSalary.Text == string.Empty) { txtSalary.Text = "0"; }


            #region "            Save New Employee                         "
        
            Employee employee = new Employee() 
            { 
             EmployeeName = txtEmployeeName.Text,
             IdCard = txtIdCard.Text,
             Phone = txtPhone.Text,
             Mobile = txtMobile.Text,
             Address = txtAddress.Text,
             Email = txtEmail.Text,
             Salary = Convert.ToDouble(txtSalary.Text),
             Status = "Active"

            };
            cmd = new EmployeeCmd();
            cmd.NewEmployee(employee);


            #endregion 
            MessageBox.Show("تم الحفظ");

        }

        void ClearValues()
        {
            //  الدالة موجودة في الدل  اللى انا رفعته اللى بيفرغ مربعات 
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearValues();
            txtEmployeeName.Focus();
        }

        private void txtSalary_TextChanged(object sender, EventArgs e)
        {
            if (txtSalary.Text == string.Empty) { txtSalary.Text = "0"; }
        }
    }
}
