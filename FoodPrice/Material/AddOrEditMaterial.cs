using DataLayer;
using DataLayer.Context;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FoodPrice.Material
{
    public partial class AddOrEditMaterial : Form
    {
        private JelvehabKhoramshahrEntities db = new JelvehabKhoramshahrEntities();

        public AddOrEditMaterial()
        {
            InitializeComponent();
        }

        public bool IsAnyMaterial(int id, string name)
        {
            return db.Material.Any(a => a.MaterialName == name && a.Id != id);
        }

        public void AddMaterial()
        {

            using (UnitOfWork db = new UnitOfWork())
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
                var result = db.MaterialRepositories.InsertMaterial(model);
                if (result == true)
                {
                    db.Save();
                    MessageBox.Show("ثبت شد");
                }
                else
                {
                    MessageBox.Show("کالا ثبت نگردید");
                }
            }


        }

        public void EditMaterial()
        {
            using (UnitOfWork db = new UnitOfWork())
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
                    Id = int.Parse(Id.Text),
                    MaterialName = textBox1.Text,
                    UnitPrice = int.Parse(textBox2.Text)

                };
                var result = db.MaterialRepositories.UpdateMaterial(model);
                if (result == true)
                {
                    db.Save();
                    MessageBox.Show("ثبت شد");
                }
                else
                {
                    MessageBox.Show("کالا ثبت نگردید");
                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Id.Text))
            {
                AddMaterial();

            }
            else
            {
                EditMaterial();
            }
        }
    }
}