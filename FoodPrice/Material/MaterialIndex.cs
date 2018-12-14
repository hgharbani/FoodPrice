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

        public void ShowMaterialGrid()
        {
            using (JelvehabKhoramshahrEntities db = new JelvehabKhoramshahrEntities())
            {
                dataGridView1.AutoGenerateColumns = false;
                var model = db.Material.Select(a => new
                {
                    a.Id,
                    a.MaterialName,
                    a.UnitPrice,
                }).ToList();
                dataGridView1.DataSource = model;
            }
        }
        private void MaterialIndex_Load(object sender, EventArgs e)
        {
           ShowMaterialGrid();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddOrEditMaterial materil = new AddOrEditMaterial();
            materil.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
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
                    db.SaveChanges();

                    MessageBox.Show("کالا با موفقیت حذف شد");
                }
                ShowMaterialGrid();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                ShowMaterialGrid();
            }
            else
            {
                dataGridView1.DataSource = db.Material.Where(c => c.MaterialName.Contains(textBox1.Text) || c.UnitPrice.ToString().Contains(textBox1.Text)).ToList();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            ShowMaterialGrid();
        }
    }
}