using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _463609_Arif_ResponsiJunPro2.Entity
{
    internal class Karyawan
    {

        // fields
        private string _id_karyawan;
        private string _nama;
        private string _id_dep;

        public string id_karyawan 
        {
            get { return _id_karyawan; }
        }

        public string nama
        {
            get { return _nama; }
            set { _nama = value; }
        }

        public string id_dep 
        {
            get { return _id_dep; }
            set { _id_dep = value; }
        }

        // constructor
        public Karyawan(string _idkar, string _namakar, string _iddep)
        {
            _id_karyawan = _idkar;
            _nama = _namakar;
            _id_dep = _iddep;
        }

        

    }
}
