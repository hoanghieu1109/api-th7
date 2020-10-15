using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;

namespace FrontEndOfTH7
{
    public partial class QLSP : Form
    {
        private DataGridView dataGridView = new DataGridView();
        private string link = "https://localhost:44384/";
        public QLSP()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView1_OnLoad()
        {

        }
        private List<DanhMuc> getloai()
        {
            List<DanhMuc> dm = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(link);
                var respondtask = client.GetAsync("api/DanhMucs");
                respondtask.Wait();
                var rs = respondtask.Result;
                if (rs.IsSuccessStatusCode)
                {
                    var readtask = rs.Content.ReadAsAsync<List<DanhMuc>>();
                    readtask.Wait();
                    dm = readtask.Result;
                }
                else dm = null;
            }
            return dm;
        }
        private List<SanPham> timtheoten(string ten)
        {
            var client = new HttpClient();
            List<SanPham> product;
            client.BaseAddress = new Uri(link);
            var respondtask = client.GetAsync("SanPhams/by-name/" + ten);
            respondtask.Wait();
            var rs = respondtask.Result;
            if (rs.IsSuccessStatusCode)
            {
                var readtask = rs.Content.ReadAsAsync<List<SanPham>>();
                readtask.Wait();
                product = readtask.Result;

            }
            else product = null;
            return product;
        }
        private List<SanPham> getdata()
        {
            List<SanPham> product = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(link);
                var respondtask = client.GetAsync("SanPhams/all");
                respondtask.Wait();
                var rs = respondtask.Result;
                if (rs.IsSuccessStatusCode)
                {
                    var readtask = rs.Content.ReadAsAsync<List<SanPham>>();
                    readtask.Wait();
                    product = readtask.Result;
                }
                else product = null;
            }
            return product;
        }
        private SanPham timtheoma(string id)
        {
            SanPham product = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(link);
                var respondtask = client.GetAsync("api/SanPhams/)" + id);
                respondtask.Wait();
                var rs = respondtask.Result;
                if (rs.IsSuccessStatusCode)
                {
                    var readtask = rs.Content.ReadAsAsync<SanPham>();
                    readtask.Wait();
                    product = readtask.Result;
                }
                else product = null;
            }
            return product;
        }
        private List<SanPham> timtheomaloai(string id)
        {
            List<SanPham> product = null;
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(link);
                var respondtask = client.GetAsync("SanPhams/by-ma-danh-muc/" + id);
                respondtask.Wait();
                var rs = respondtask.Result;
                if (rs.IsSuccessStatusCode)
                {
                    var readtask = rs.Content.ReadAsAsync<List<SanPham>>();
                    readtask.Wait();
                    product = readtask.Result;

                }
                else product = null;
            }
            return product;
        }
        private List<SanPham> timtheogia(int gia)
        {
            List<SanPham> product = null;
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(link);
                var respondtask = client.GetAsync("SanPhams/by-price/" + gia);
                respondtask.Wait();
                var rs = respondtask.Result;
                if (rs.IsSuccessStatusCode)
                {
                    var readtask = rs.Content.ReadAsAsync<List<SanPham>>();
                    readtask.Wait();
                    product = readtask.Result;

                }
                else product = null;
            }
            return product;
        }
        private List<SanPham> timtheominmax(int min, int max)
        {
            List<SanPham> product = null;
          
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(link);
                var respondtask = client.GetAsync("SanPhams/by-prices/" + min+"/"+max);
                respondtask.Wait();
                var rs = respondtask.Result;
                if (rs.IsSuccessStatusCode)
                {
                    var readtask = rs.Content.ReadAsAsync<List<SanPham>>();
                    readtask.Wait();
                    product = readtask.Result;

                }
                else product = null;
            }
            return product;
        }
        private void QLSP_Load(object sender, EventArgs e)
        {
            var data = getdata().ToArray();
            var loai = getloai();
            
            foreach (var item in data)
            {
               
                dataGridView1.Rows.Add(item.Ma,item.Ten,item.DonGia,item.MaDanhMuc);
                    }
            
            foreach (var item in loai)
            {
                comboBox1.Items.Add(item.MaDanhMuc);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            textBox6.Text = dataGridView1.Rows[numrow].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[numrow].Cells[1].Value.ToString();
            textBox8.Text = dataGridView1.Rows[numrow].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[numrow].Cells[3].Value.ToString();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox9.Text == null) MessageBox.Show("hả?","không thấy");
            
            else {
                var kq = timtheoten(textBox9.Text);
                if (kq != null || kq.ToArray() !=null)
                {
                    dataGridView1.Rows.Clear();
                    foreach (var item in kq)
                    {
                        dataGridView1.Rows.Add(item.Ma, item.Ten, item.DonGia, item.MaDanhMuc);
                    }
                }
                else MessageBox.Show("hả?","không thấy");
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == null) MessageBox.Show("hả?", "không thấy");

            else
            {
                var kq = timtheoma(textBox5.Text);
                if (kq != null)
                {
                    dataGridView1.Rows.Clear();
                    
                        dataGridView1.Rows.Add(kq.Ma, kq.Ten, kq.DonGia, kq.MaDanhMuc);
                    
                }
                else MessageBox.Show("hả?", "không thấy");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == null) MessageBox.Show("hả?", "không thấy");

            else
            {
                var kq = timtheogia(Convert.ToInt32( textBox4.Text));
                if (kq != null)
                {
                    dataGridView1.Rows.Clear();

                    foreach (var item in kq)
                    {
                        dataGridView1.Rows.Add(item.Ma, item.Ten, item.DonGia, item.MaDanhMuc);
                    }

                }
                else MessageBox.Show("hả?", "không thấy");
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == null || textBox2.Text == null) MessageBox.Show("hả?", "không thấy");

            else
            {
                var kq = timtheominmax(Convert.ToInt32(textBox3.Text),Convert.ToInt32(textBox2.Text));
                if (kq != null)
                {
                    dataGridView1.Rows.Clear();

                    foreach (var item in kq)
                    {
                        dataGridView1.Rows.Add(item.Ma, item.Ten, item.DonGia, item.MaDanhMuc);
                    }

                }
                else MessageBox.Show("hả?", "không thấy");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            QLSP_Load(sender,e);
        }
    }
}