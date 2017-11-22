using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace GISApp
{
    public partial class UserTableForm : Form
    {
        private ArrayList data;
        public UserTableForm(ArrayList data)
        {
            InitializeComponent();
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox2.ReadOnly = true;

            this.data = data;
            listView1.View = View.Details;
            listView1.CheckBoxes = true;
            listView1.BeginUpdate();
            listView1.Columns.Add("用户");
            listView1.Columns.Add("类型");
            int width = listView1.Width / 2;
            listView1.Columns[0].Width = width-2;
            listView1.Columns[1].Width = width-2;
            string[] user = new string[2];
            user[0] = "木子lee";
            user[1] = "李万志";
            if (data!=null)
            {
                for (int i = 0; i < user.Length;i++ )
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = user[i];
                    string type = ((NameAndType)data[i]).type.Equals("1") ? "管理员" : "作业员";
                    lvi.SubItems.Add(type);
                    this.listView1.Items.Add(lvi);
                }
            }
        }
        //删除按钮
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.listView1.CheckedItems.Count <= 0)
            {
                MessageBox.Show("请选择用户");
                return;
            }

            MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("确定要删除用户吗?", "删除", messButton);
            if (dr == DialogResult.OK)
            {
                foreach (ListViewItem ck in this.listView1.CheckedItems)
                {
                    if (ck.SubItems[1].Text.Equals("管理员"))
                    {
                        continue;
                    }
                    //从数据库删除该用户
                    if (DBHelper.delUser(ck.Text))
                    {
                        LogHelper.writeLog("delete user : " + ck.Text);
                        ck.Remove();
                    }
                }
            }
        }
        //新增
        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text.Equals("新增"))
            {
                button2.Text = "完成";
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox1.Text = "新用户";
                textBox2.Text = "作业员";
            }
            else
            {
                foreach (ListViewItem item in this.listView1.Items)
                {
                    if (item.Text.Equals(textBox1.Text))
                    {
                        MessageBox.Show("用户名重复！");
                        return;
                    }
                }

                ListViewItem lvi = new ListViewItem();
                lvi.Text = textBox1.Text;
                lvi.SubItems.Add(textBox2.Text);
                this.listView1.Items.Add(lvi);
                //从数据库新增该用户
                if (DBHelper.addUser(textBox1.Text))
                {
                    button2.Text = "新增";
                    textBox1.Visible = false;
                    textBox2.Visible = false;
                    textBox1.Text = "";
                    textBox2.Text = "";
                }

            }
        }
    }
}
