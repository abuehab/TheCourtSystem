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
    public partial class FrmLowyer : Form
    {
        public FrmLowyer()
        {
            InitializeComponent();
        }
        LawyerCmd cmd = new LawyerCmd();
        void PopulateDgv()
        {
            Dgv.Rows.Clear();

            var lst = cmd.AllLowyers();
            this.Invoke((MethodInvoker)delegate
            {

                lst.ForEach(i =>
                {

                    Dgv.Rows.Add(i.Id.ToString(), i.LowyerName,i.Phone,i.Mobile,i.Address,i.Description  );
                });
            });
        }


        private void FrmEmployees_Load(object sender, EventArgs e)
        {
            PopulateDgv();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddLowyer frm = new FrmAddLowyer();
            frm.ShowDialog();
            PopulateDgv();
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

                var rw = cmd.GetLowyerById(int.Parse(Dgv.CurrentRow.Cells[0].Value.ToString()));

                if (col.ToString() == "6")
                {
                    FrmEditLowyer frm = new FrmEditLowyer();

                    frm.TargetLowyer = rw;
                    frm.ShowDialog();
                    PopulateDgv();
                }


                #region  "       Delete Patient : UnUsed      "
                if (col.ToString() == "7")
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
                        cmd.DeleteLowyer(rw, rw.Id);
                        MessageBox.Show("حـــــذف", "تـــــم الحــــذف");
                        PopulateDgv();
                    }
                }

                #endregion
                if (col.ToString() == "8")
                {
                    FrmViewLowyer frm = new FrmViewLowyer();
                    frm.TargetLowyer = rw;
                    frm.ShowDialog();
                }
            }
        }

    }
}
