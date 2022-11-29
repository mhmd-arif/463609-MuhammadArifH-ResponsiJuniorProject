using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace _463609_Arif_ResponsiJunPro2.Entity
{
    internal class Connection
    {
        NpgsqlConnection _conn;

        public string connstring = "Host=localhost ; port=2022 ; username=postgres ; password=informatika; database=463609_responsi2";

        public NpgsqlConnection GetConn()
        {
            this._conn = new NpgsqlConnection(connstring);
            return this._conn;
        }
    }
}
