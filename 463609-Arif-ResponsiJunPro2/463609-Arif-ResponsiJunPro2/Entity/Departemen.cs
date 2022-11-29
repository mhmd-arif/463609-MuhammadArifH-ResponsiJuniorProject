using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _463609_Arif_ResponsiJunPro2.Entity;
using Npgsql;

namespace _463609_Arif_ResponsiJunPro2.Entity
{
    internal class Departemen
    {
        // field
        private int _id_dep;
        private string _nama_dep;

        public int id_dep
        {
            get { return _id_dep; }
        }

        public string nama_dep
        {
            get { return _nama_dep; }
            set { _nama_dep = value; }
        }

        // constructor
        public Departemen (int _id, string _nama)
        {
            _id_dep = _id;
            _nama_dep = _nama;
        }

        // method
        
        Connection newConn;
        NpgsqlConnection conn;
        NpgsqlCommand cmd;
        NpgsqlDataReader rd;
        DataTable dt;
        
        
        public void GetDepartemen()
        {
            conn = newConn.GetConn();

            conn.Open();
            
            string sql = "select * from tb_departemen";
            cmd = new NpgsqlCommand(sql, conn);
            rd = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(rd);

            conn.Close();
        }
    }
}
