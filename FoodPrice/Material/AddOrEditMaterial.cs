using DataLayer;
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
            if (textBox1.Text == "")
            {
                MessageBox.Show("نام کالا را وارد نمایید");
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("قیمت کالا را وارد نمایید");
            }

            if (db.Material.Any(a => a.MaterialName == textBox1.Text))
            {
                MessageBox.Show("کالا تکراری می باشد");
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

        public void EditMaterial()
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("نام کالا را وارد نمایید");
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("قیمت کالا را وارد نمایید");
            }

            var id = int.Parse(Id.Text);
            if (db.Material.Any(a => a.Id != id && a.MaterialName == textBox1.Text))
            {
                MessageBox.Show("کالا تکراری می باشد");
            }

            var SearchMaterial = db.Material.Find(id);

            SearchMaterial.MaterialName = textBox1.Text;
            SearchMaterial.UnitPrice = int.Parse(textBox2.Text);

            if (db.SaveChanges() > 0)
            {
                MessageBox.Show("ثبت شد");
            }
            else
            {
                MessageBox.Show("کالا ثبت نگردید");
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
            this.Close();
        }
    }
}