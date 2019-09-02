using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using Dapper;
using CriticalMass.TagNode.IRepository;
using CriticalMass.TagNode.Model;
using MySql.Data.MySqlClient;

namespace CriticalMass.TagNode.Repository
{
    public class BaseRepository{
        public IDbConnection GetConnection() {
            return new MySqlConnection(CriticalMass.TagNode.Utility.Config.GetConnectionString());
        }
    }
}
