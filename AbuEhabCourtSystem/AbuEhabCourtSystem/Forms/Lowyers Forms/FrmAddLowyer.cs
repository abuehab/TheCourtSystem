using AbuEhabCourtSystem.Tables_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AbuEhabCourtSystem.Forms.Lowyers_Forms
{
    public partial class FrmAddLowyer : Form
    {
        public FrmAddLowyer()
        {
            InitializeComponent();
        }
       
        LawyerCmd cmd = new LawyerCmd();
        private void FrmAddLowyer_Load(object sender, EventArgs e)
        {
            

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
              #region " Check  All Values First "
            // Your Code Here 
            if (txtLowyerName.Text == string.Empty)
            { MessageBox.Show("أدخل الاسم الان  وبعدها يمكن لك التعديل او اكمال البيانات لاحقا"); return; }
            #endregion 
            
            
            #region " Check Current Lowyer if exiseted or not "

            // Your Code Here 
            Lowyer low = cmd.GetLowyerByName(txtLowyerName.Text);
            if (low != null) { MessageBox.Show(" موجود بالفعل "); ClearValues(); txtLowyerName.Focus(); return; }
            #endregion
            #region "            Save New Lowyer                         "
      
            Lowyer lowyer = new Lowyer() 
            {
                LowyerName = txtLowyerName.Text,
                Address = txtAddress.Text, 
                Mobile=txtMobile.Text,
                Phone=txtPhone.Text,
                Status = "Active",
                Description = txtDescription.Text
            };

            cmd.NewLawyer(lowyer);
            MessageBox.Show("تــم الـحـفظ");

            #endregion    
        }

        void ClearValues()
        {
            //  الدالة موجودة في الدل  اللى انا رفعته اللى بيفرغ مربعات 
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearValues();
        }
        }
    }

