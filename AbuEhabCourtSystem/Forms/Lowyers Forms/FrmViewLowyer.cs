using LowyerDatalayer;
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
    public partial class FrmViewLowyer : Form
    {
        public Lowyer TargetLowyer { get; set; }
        public FrmViewLowyer()
        {
            InitializeComponent();
        }
        void LoadLowyerData()
        {
            txtLowyerName.Text = TargetLowyer.LowyerName;
            txtAddress.Text = TargetLowyer.Address;
            txtPhone.Text = TargetLowyer.Phone;
            txtMobile.Text = TargetLowyer.Mobile;
            txtDescription.Text = TargetLowyer.Description;
        }

        private void FrmViewLowyer_Load(object sender, EventArgs e)
        {
            LoadLowyerData();
        }
    }
}
