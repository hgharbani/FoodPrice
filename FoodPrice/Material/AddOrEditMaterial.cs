using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer;

namespace FoodPrice.Material
{
    public partial class AddOrEditMaterial : Form
    {
        JelvehabKhoramshahrEntities db=new JelvehabKhoramshahrEntities();
        public AddOrEditMaterial()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("نام کالا را وارد نمایید");
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("قیمت کالا را وارد نمایید");
            }

            var model = new DataLayer.Material()
            {
                MaterialName = textBox1.Text,
                UnitPrice = int.Parse(textBox2.Text)
            };
            db.Material.Add(model);
            if (db.SaveChanges() > 0)
            {
                MessageBox.Show("ثبت شد");
            }
            else
            {
                MessageBox.Show("کالا ثبت نگردید");
            }
        }
    }
}
