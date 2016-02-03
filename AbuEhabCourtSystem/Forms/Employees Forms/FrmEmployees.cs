using LowyerDatalayer.Tables_Classes;
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
    public partial class FrmEmployees : Form
    {
        public FrmEmployees()
        {
            InitializeComponent();
        }

        EmployeeCmd cmd = new EmployeeCmd();
        void PopulateDgv()
        {
            Dgv.Rows.Clear();

            var lst = cmd.AllEmplyees();
            this.Invoke((MethodInvoker)delegate
            {

                lst.ForEach(i =>
                {
               
                    Dgv.Rows.Add(i.Id.ToString() , i.EmployeeName , i.Address ,
                        i.IdCard , i.Phone , i.Mobile , i.Email , i.Salary .ToString ()
    
                        );
                });
            });
        }


        private void FrmEmployees_Load(object sender, EventArgs e)
        {
            PopulateDgv();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddEmployee frm = new FrmAddEmployee();
            frm.ShowDialog();
        }

        private void btnUpdata_Click(object sender, EventArgs e)
        {
            PopulateDgv();
        }

        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Dgv.Rows.Count > 0)
            {

                int col = this.Dgv.CurrentCell.ColumnIndex;

                var rw = cmd.GetEmployeeById(int.Parse(Dgv.CurrentRow.Cells[0].Value.ToString()));

                if (col.ToString() == "8")
                {
                    FrmEditEmployee frm = new FrmEditEmployee();

                    frm.TargetEmployee = rw;
                    frm.ShowDialog();
                }


                #region  "       Delete Patient : UnUsed      "
                if (col.ToString() == "9")
                {

                    if (MessageBox.Show("هـــــل تريـــــد الحـــــذف بالفـــعل   ؟  ", "حــــــذف",
                       MessageBoxButtons.OKCancel,
                       MessageBoxIcon.Question,
                       MessageBoxDefaultButton.Button1,
                       MessageBoxOptions.RtlReading |
                       MessageBoxOptions.RightAlign) == System.Windows.Forms.DialogResult.OK)
                    {
                        //====================================
                        // Set Status  = Disactive
                        cmd.RemoveEmployee(rw, rw.Id);
                        MessageBox.Show ("حـــــذف", "تـــــم الحــــذف");
                        PopulateDgv();
                    }
                }

                #endregion
                if (col.ToString() == "10")
                {
                    FrmViewEmployee frm = new FrmViewEmployee();
                    frm.TargetEmployee = rw;
                    frm.ShowDialog();
                
                }

            }
        }

    }
}
