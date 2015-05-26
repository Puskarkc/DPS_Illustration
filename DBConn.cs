using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;

namespace Manage_Data
{
	/// <summary>
	/// Summary description for Connection.
	/// </summary>
	public class DBConn
	{
        private static string strConns = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
		private static OleDbConnection objConn = null;
		public DBConn()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static OleDbConnection GetConn()
		{
            objConn = new OleDbConnection(strConns);
			return objConn;
		}
	}
}
