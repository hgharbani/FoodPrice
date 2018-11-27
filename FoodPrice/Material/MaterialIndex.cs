using DataLayer;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FoodPrice.Material
{
    public partial class MaterialIndex : Form
    {
        private JelvehabKhoramshahrEntities db = new JelvehabKhoramshahrEntities();

        public MaterialIndex()
        {
            InitializeComponent();
        }

        private void MaterialIndex_Load(object sender, EventArgs e)
        {
            using (JelvehabKhoramshahrEntities db = new JelvehabKhoramshahrEntities())
            {
                var model = db.Material.Select(a => new
                {
                    a.Id,
                    a.MaterialName,
                    a.UnitPrice,
                }).ToList();
                dataGridView1.DataSource = model;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddOrEditMaterial materil = new AddOrEditMaterial();
            materil.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var id = dataGridView1.CurrentRow.Cells[0].Value;
            var model = db.Material.Find(id);
            if (model == null)
            {
                MessageBox.Show("کالا حذف شده است");
            }

            if (model.PreparingFood.Any())
            {
                MessageBox.Show("قادر به حذف این کالا نمی باشد زیرا در چندین غذا در حال استفاده است");
            }
            else
            {
                db.Material.Remove(model);
                MessageBox.Show("کالا با موفقیت حذف شد");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var id = dataGridView1.CurrentRow.Cells[0].Value;
                var model = db.Material.Find(id);
                AddOrEditMaterial formEdit = new AddOrEditMaterial();
                formEdit.Id.Text = id.ToString();
                formEdit.textBox1.Text = model.MaterialName;
                formEdit.textBox2.Text = model.UnitPrice.ToString();
                formEdit.Show();
            }
            else
            {
                MessageBox.Show("آیتمی انتخاب نشده است");
            }
        }
    }
}