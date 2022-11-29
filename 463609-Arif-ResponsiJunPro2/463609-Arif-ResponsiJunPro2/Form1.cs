using _463609_Arif_ResponsiJunPro2.Entity;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _463609_Arif_ResponsiJunPro2
{
    public partial class Form1 : Form
    {
        Connection newConn;
        NpgsqlConnection conn;
        NpgsqlCommand cmd;
        NpgsqlDataReader rd;
        DataTable dt;
        Karyawan newKaryawan;
        
        public string connstring = "Host=localhost ; port=2022 ; username=postgres ; password=informatika; database=463609_responsi2";


        public Form1()
        {
            InitializeComponent();
        }


        private void LoadCb()
        {
            /*cbDepartemen.DataSource = null;
            
            conn = new NpgsqlConnection(connstring);
            conn.Open();
            string sql = "select nama_dep from tb_departemen";
            cmd = new NpgsqlCommand(sql, conn);
            rd = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(rd);

            cbDepartemen.DataSource = dt;

            conn.Close();*/
        }

        private void LoadDgv()
        {
            try
            {
                dgvKaryawan.DataSource = null;

                conn = new NpgsqlConnection(connstring);

                conn.Open();
                string sql = "select * from tb_karyawan";
                cmd = new NpgsqlCommand(sql, conn);
                rd = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(rd);

                dgvKaryawan.DataSource = dt;

                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCb();
            LoadDgv();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {

            try
            {
                conn = new NpgsqlConnection(connstring);
                string nama = tbNamaKaryawan.Text;
                string idDep = cbDepartemen.Text;

                newKaryawan.nama = nama;
                newKaryawan.id_dep = idDep;


                conn.Open();
                string sql = "insert into tb_karyawan(nama, id_dep) values(@nama, @id_dep)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.Add("@nama", NpgsqlTypes.NpgsqlDbType.Varchar).Value = nama;
                cmd.Parameters.Add("@id_dep", NpgsqlTypes.NpgsqlDbType.Varchar).Value = idDep;

                cmd.ExecuteNonQuery();                

                conn.Close();

                LoadDgv();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new NpgsqlConnection(connstring);
                string nama = tbNamaKaryawan.Text;
                string idDep = cbDepartemen.Text;
                string namaOld = "";

                /* newKaryawan.nama = nama;
                 newKaryawan.id_dep = idDep;*/


                conn.Open();
                string sql = "update tb_karyawan set (nama, id_dep) values(@nama, @id_dep) where nama = '@namaOld'";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.Add("@nama", NpgsqlTypes.NpgsqlDbType.Varchar).Value = nama;
                cmd.Parameters.Add("@namaOld", NpgsqlTypes.NpgsqlDbType.Varchar).Value = namaOld;
                cmd.Parameters.Add("@id_dep", NpgsqlTypes.NpgsqlDbType.Varchar).Value = idDep;

                cmd.ExecuteNonQuery();

                conn.Close();

                LoadDgv();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
