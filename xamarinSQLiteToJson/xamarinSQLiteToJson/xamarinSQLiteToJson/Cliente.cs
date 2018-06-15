using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace xamarinSQLiteToJson
{
    class Cliente
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Nome { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        public override string ToString()
        {
            return string.Format("{0} {1}", Nome, Email);
        }
    }
}
