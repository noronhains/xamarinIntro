using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppGasolina
{
    public interface IConfig
    {
        string DiretorioSQLite { get; }
    }
}
