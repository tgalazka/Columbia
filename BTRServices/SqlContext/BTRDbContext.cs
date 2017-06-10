using BTRServices.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BTRServices.Models;
using System.Configuration;

namespace BTRServices.SqlContext
{
    public class BTRDbContext
    {
        public static readonly string sqlConnString = ConfigurationManager.ConnectionStrings["BTRDbContext"].ToString();
        SqlConnection sqlConnect = null;

        internal Btr BtrById(int id)
        {
            throw new NotImplementedException();
        }

        public BTRDbContext()
        {
            sqlConnect = new SqlConnection(sqlConnString);
        }

        internal Btr BtrCreate(Btr btrRecord)
        {
            return null;
        }

        internal Btr BtrGetById(int key)
        {
            return null;
        }

        private SqlConnection GetSqlConnection()
        {
            if (sqlConnect == null)
            {
                sqlConnect = new SqlConnection(sqlConnString);
            }
            return sqlConnect;
        }

        internal void BtrByRequestor(string requestor)
        {
            throw new NotImplementedException();
        }

        private DataTable ExecuteStatement(SqlCommand sqlCmd)
        {
            DataTable dataTable = new DataTable();
            sqlCmd.Connection = GetSqlConnection();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCmd);
            sqlDataAdapter.SelectCommand.CommandTimeout = 500;
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }

        private SqlCommand CreateSqlCmd_SP(string cmdText, SqlParameter[] sqlParams)
        {
            SqlCommand sqlCmd = new SqlCommand(cmdText);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            if (sqlParams != null)
            {
                sqlCmd.Parameters.AddRange(sqlParams);
            }
            return sqlCmd;
        }

        internal IEnumerable<Account> GetAccountBalances(int[] iKeys)
        {
            string ikValues = string.Join(",", iKeys);
            SqlParameter sqlParm = new SqlParameter("@indexKeys",ikValues);
            SqlCommand sqlCmd = CreateSqlCmd_SP("dbo.accountbalances_byindexkeys", new SqlParameter[] { sqlParm });

            DataTable dt = ExecuteStatement(sqlCmd);
            List<Account> accounts = new List<Account>();

            accounts = (from DataRow row in dt.Rows
                        select new Account
                        {
                            account_key = (Int32)row["account_key"],
                            index_key = (Int32)row["index_key"],
                            account_balance = (Decimal)row["account_balance"],
                            account_description = row["account_description"].ToString(),
                            account_number = row["account_number"].ToString(),
                            account_number_description = row["account_number_description"].ToString()
                        }
                        ).ToList();
            return accounts;
        }

        internal Account GetAccountBalance(int account_key)
        {
        SqlParameter sqlParm = new SqlParameter("@account_key", account_key);
        SqlCommand sqlCmd = CreateSqlCmd_SP("dbo.accountbalance_byaccountkey", new SqlParameter[] { sqlParm });
        DataTable dt = ExecuteStatement(sqlCmd);
        Account account = new Account();

            account = (from DataRow row in dt.Rows
                        select new Account
                        {
                            account_key = (Int32)row["account_key"],
                            index_key = (Int32)row["index_key"],
                            account_balance = (Decimal)row["account_balance"],
                            account_description = row["account_description"].ToString(),
                            account_number = row["account_number"].ToString(),
                            account_number_description = row["account_number_description"].ToString()
                        }
                        ).FirstOrDefault();
            return account;
        }
        internal List<Account> GetAccounts()
        {
            SqlCommand sqlCmd = CreateSqlCmd_SP("dbo.accounts_all", null);

            DataTable dt = ExecuteStatement(sqlCmd);
            List<Account> accounts = new List<Account>();

            accounts = (from DataRow row in dt.Rows
                        select new Account
                        {
                            account_key = (Int32)row["account_key"],
                            index_key = (Int32)row["index_key"],
                            account_balance = (Decimal)row["account_balance"],
                            account_description = row["account_description"].ToString(),
                            account_number = row["account_number"].ToString(),
                            account_number_description = row["account_number_description"].ToString()
                        }
                        ).ToList();
            return accounts;
        }
        internal List<Account> GetAccountByIndex(int index_key)
        {
            SqlCommand sqlCmd = CreateSqlCmd_SP("dbo.account_byIndex", new SqlParameter[] { new SqlParameter("@index_key", index_key) });
            DataTable dt = ExecuteStatement(sqlCmd);
            List<Account> accounts = new List<Account>();

            accounts = (from DataRow row in dt.Rows
                        select new Account
                        {
                            account_key = (Int32)row["account_key"],
                            index_key = (Int32)row["index_key"],
                            account_balance = (Decimal)row["account_balance"],
                            account_description = row["account_description"].ToString(),
                            account_number = row["account_number"].ToString(),
                            account_number_description = row["account_number_description"].ToString()
                        }
                        ).ToList();
            return accounts;
        }

        internal IEnumerable<Index> indices()
        {
            SqlCommand sqlCmd = CreateSqlCmd_SP("dbo.indices_all", null);

            DataTable dt = ExecuteStatement(sqlCmd);
            List<Index> indices = new List<Index>();

            indices = (from DataRow row in dt.Rows
                       select new Index
                       {
                           index_key = (Int32)row["index_key"],
                           index_orgn_code = row["index_orgn_code"].ToString(),
                           index_prog_code = row["index_prog_code"].ToString(),
                           index_description = row["index_description"].ToString(),
                           index_number_description = row["index_number_description"].ToString()
                       }).ToList();
            return indices;
        }

        internal IEnumerable<Index> indices_bydept(int dept_key)
        {
            SqlCommand sqlCmd = CreateSqlCmd_SP("dbo.indices_bydept",new SqlParameter[] { new SqlParameter("@dept", dept_key) });
            

            DataTable dt = ExecuteStatement(sqlCmd);
            List<Index> indices = new List<Index>();

            indices = (from DataRow row in dt.Rows
                        select new Index
                        {
                            index_key = (Int32)row["index_key"],
                            index_orgn_code = row["index_orgn_code"].ToString(),
                            index_prog_code = row["index_prog_code"].ToString(),
                            index_description = row["index_description"].ToString(),
                            index_number_description = row["index_number_description"].ToString()
                        }).ToList();
            return indices;
        }

        internal IEnumerable<Index> indices_owned_bydept(int dept_key, string uni)
        {

            SqlCommand sqlCmd = CreateSqlCmd_SP("dbo.indices_owned_bydept",null);
            sqlCmd.Parameters.Add(new SqlParameter("@dept", dept_key));
            sqlCmd.Parameters.Add(new SqlParameter("@uni", uni));

            DataTable dt = ExecuteStatement(sqlCmd);
            List<Index> indices = new List<Index>();

            indices = (from DataRow row in dt.Rows
                       select new Index
                       {
                           index_key = (Int32)row["index_key"],
                           index_orgn_code = row["index_orgn_code"].ToString(),
                           index_prog_code = row["index_prog_code"].ToString(),
                           index_description = row["index_description"].ToString(),
                           index_number_description = row["index_number_description"].ToString()
                       }).ToList();
            return indices;
        }

        internal object Set<T>()
        {
            throw new NotImplementedException();
        }

        internal List<Index> indices_byowner(string uni)
        {
            SqlCommand sqlCmd = CreateSqlCmd_SP("dbo.indices_byowner", new SqlParameter[] { new SqlParameter("@uni", uni)});

            DataTable dt = ExecuteStatement(sqlCmd);
            List<Index> indices = new List<Index>();

            indices = (from DataRow row in dt.Rows
                        select new Index
                        {
                            index_key = (Int32)row["index_key"],
                            index_orgn_code = row["index_orgn_code"].ToString(),
                            index_prog_code = row["index_prog_code"].ToString(),
                            index_description = row["index_description"].ToString(),
                            index_number_description = row["index_number_description"].ToString()
                        }
                        ).ToList();
            return indices;
        }

        internal Index GetIndexById()
        {
            throw new NotImplementedException();
        }

        internal void Dispose()
        {
            if (sqlConnect != null)
            {
                sqlConnect.Dispose();

            }
            sqlConnect = null;
        }
    }
}