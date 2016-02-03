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
namespace AbuEhabCourtSystem.Forms.Lowyers_Forms
{
    public partial class FrmEditLowyer : Form
    {
        public FrmEditLowyer()
        {
            InitializeComponent();
        }
        public Lowyer TargetLowyer { get; set; }
        void LoadLowyerData()
        {
            txtLowyerName.Text = TargetLowyer.LowyerName;
            txtAddress.Text = TargetLowyer.Address;
            txtPhone.Text = TargetLowyer.Phone;
            txtMobile.Text = TargetLowyer.Mobile;
            txtDescription.Text = TargetLowyer.Description;
        }
        LawyerCmd cmd = new LawyerCmd();
        private void FrmEditLowyer_Load(object sender, EventArgs e)
        {
            LoadLowyerData();
        }

        private void btnUpdtate_Click(object sender, EventArgs e)
        {
            if (txtLowyerName.Text != string.Empty)
            {

                #region "           Edit  Lowyer                      "

                TargetLowyer.LowyerName = txtLowyerName.Text;
                TargetLowyer.Address = txtAddress.Text;
                TargetLowyer.Phone = txtPhone.Text;
                TargetLowyer.Mobile = txtMobile.Text;
                TargetLowyer.Description = txtDescription.Text;

                cmd.EditLawyer(TargetLowyer, TargetLowyer.Id);
                MessageBox.Show(" تــم الـتعديل ");
                this.Close();
            
            }
                #endregion

        }
    }
}