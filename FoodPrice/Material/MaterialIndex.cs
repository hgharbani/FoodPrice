using DataLayer;
using DataLayer.Context;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FoodPrice.Material
{
    public partial class MaterialIndex : Form
    {
       
        public MaterialIndex()
        {
            InitializeComponent();
        }


        public void ShowMaterialGrid()
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                dataGridView1.AutoGenerateColumns = false;
               
                dataGridView1.DataSource = db.MaterialRepositories.GetAllMaterials();
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
                using(UnitOfWork db=new UnitOfWork())
                {
                    
                    var id =int.Parse( dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    var name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    if (MessageBox.Show($"ایا از حذف {name} مطمئن هستید","توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        var model = db.MaterialRepositories.GetMaterialById(id);
                        if (model.PreparingFood.Any())
                        {
                            MessageBox.Show("قادر به حذف این کالا نمی باشد زیرا در چندین غذا در حال استفاده است");
                        }
                        else
                        {
                            var result = db.MaterialRepositories.DeleteMaterial(id);
                            db.Save();

                            MessageBox.Show("کالا با موفقیت حذف شد");
                        }
                    }
                   
                }
                ShowMaterialGrid();
            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var id =int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                using(UnitOfWork db =new UnitOfWork())
                {
                    var model = db.MaterialRepositories.GetMaterialById(id);
                    AddOrEditMaterial formEdit = new AddOrEditMaterial();
                    formEdit.Id.Text = id.ToString();
                    formEdit.textBox1.Text = model.MaterialName;
                    formEdit.textBox2.Text = model.UnitPrice.ToString();
                    formEdit.Show();
                }
                
            }
            else
            {
                MessageBox.Show("آیتمی انتخاب نشده است");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            using (UnitOfWork db=new UnitOfWork())
            {
                if (textBox1.Text == "")
                {
                    ShowMaterialGrid();
                }
                else
                {
                    dataGridView1.DataSource = db.MaterialRepositories.GetMaterials(textBox1.Text);

                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            ShowMaterialGrid();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}