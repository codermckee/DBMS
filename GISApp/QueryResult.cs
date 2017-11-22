using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GISApp
{
    public partial class QueryResult : Form
    {
        public QueryResult(DataTable dt)
        {
            InitializeComponent();
            this.dataGridView1.DataSource = dt.DefaultView;
        }
    }
}
