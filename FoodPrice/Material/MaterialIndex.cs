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
    public partial class MaterialIndex : Form
    {
        JelvehabKhoramshahrEntities db=new JelvehabKhoramshahrEntities();
        public MaterialIndex()
        {
            InitializeComponent();
        }

        private void MaterialIndex_Load(object sender, EventArgs e)
        {
            using (JelvehabKhoramshahrEntities db=new JelvehabKhoramshahrEntities())
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
            AddOrEditMaterial materil=new AddOrEditMaterial();
            materil.Show();
        }
    }
}
