using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace WaterReservoir
{
    public partial class SelectByAll : Form
    {
        public string yearStr;
        public string monthStr;
        public ArrayList topicStr = new ArrayList();

        public SelectByAll()
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = "SteelBlue.ssk";
            year.Text = "2016";
            month.Text = "10";
        }

        private void 查询_Click(object sender, EventArgs e)
        {
            yearStr = year.Text;
            monthStr = month.Text;

            for (int i = 0; i < this.checkedListBox3.CheckedItems.Count; i++)
            {
                topicStr.Add("" + checkedListBox3.CheckedItems[i].ToString());
            }
            DialogResult = DialogResult.OK;
        }
    }
}
