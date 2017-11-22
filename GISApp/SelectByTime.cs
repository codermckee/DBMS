using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WaterReservoir
{
    public partial class FormByTime : Form
    {
        List<string> YearList = new List<string>();
        public FormByTime()
        {
            InitializeComponent();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {/*
            var CheckedItem = this.ckxYear.CheckedItems;
            foreach (var item in CheckedItem)
            {
                YearList.Add(item.ToString());
            }*/
        }

        private void FormByTime_Load(object sender, EventArgs e)
        {

        }




    }
}
