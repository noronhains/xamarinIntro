using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace xamarinSQLiteToJson
{
    public interface IConfig
    {
        string DiretorioSQLite { get; }
        
    }
}
