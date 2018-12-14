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
                CountFood.Text = foodQuery.GroupBy(a => a.Food.FoodName).Count().ToString();
                SumPriceFood.Text = db.SurplasCosts.Any() ? db.SurplasCosts.Sum(a => a.unitPrice).ToString() + "تومان" : "0";
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }
                   

        private void button1_Click(object sender, EventArgs e)
        {
            Material.MaterialIndex material = new MaterialIndex();
            material.Show();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}