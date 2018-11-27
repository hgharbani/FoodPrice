using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FoodPrice.Food;

namespace FoodPrice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void خروجازبرنامهToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void مواداولیهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var material=new Material.MaterialIndex();
            material.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var Id =(int) dataGridView1.CurrentRow.Cells[0].Value;
            var foodEdit=new AddOrEditFood();
            foodEdit.Show();
        }

        private void خروجازبرنامهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var food = new AddOrEditFood();
            food.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
