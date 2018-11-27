using DataLayer;
using FoodPrice.Material;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FoodPrice
{
    public partial class FormIndex : Form
    {
        public FormIndex()
        {
            InitializeComponent();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
        }

        private void FormIndex_Load(object sender, EventArgs e)
        {
            using (JelvehabKhoramshahrEntities db = new JelvehabKhoramshahrEntities())
            {
                var materailquery = db.Material.ToList();
                CountMAterial.Text = materailquery.Count().ToString();
                SumPriceMAterial.Text = materailquery.Sum(a => a.UnitPrice).ToString() + "تومان";
                var foodQuery = db.PreparingFood.AsNoTracking();
                CountFood.Text = foodQuery.GroupBy(a => a.FoodName).Count().ToString();
                SumPriceFood.Text = db.SurplasCosts.Any() ? db.SurplasCosts.Sum(a => a.unitPrice).ToString() + "تومان" : "0";
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Material.MaterialIndex material = new MaterialIndex();
            material.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            label2.ForeColor = Color.DarkRed;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.White;
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            label3.ForeColor = Color.DarkRed;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.White;
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            label4.ForeColor = Color.DarkRed;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.White;
        }
    }
}