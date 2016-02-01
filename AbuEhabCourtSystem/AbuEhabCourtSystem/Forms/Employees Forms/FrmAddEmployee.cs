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
            //    عايز اخليك تشوف اهمية الكومنت اللى انا عملتها قبل شويه الان  في الكود فاهم  
            // نعم 


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
            #region "            Save New Employee                         "
            // Complete code : كمل الحقول
            Employee employee = new Employee() 
            { 
            
             EmployeeName=txtEmployeeName.Text,IdCard=txtIdCard.Text,Phone=txtPhone.Text,Mobile=txtMobile.Text,
     Address=txtAddress.Text,Email=txtEmail.Text, 
     
     
     Salary= Convert.ToDouble( txtSalary.Text),Status=CmbStatus.Text
   
            };

            
            cmd.NewEmployee(employee);
            #endregion 
    
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
    }
}
