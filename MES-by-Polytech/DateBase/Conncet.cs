using MES_by_Polytech.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MES_by_Polytech.DateBase
{
    internal class Conncet
    {
        private static string connectionString = "Host=localhost;Port=5432;Database=test;Username=postgres;Password=admin";
        
        private NpgsqlConnection ConncetToDateBaseOpen()
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            conn.Open();
            return conn;
        }
        public void ConncetToDateBaseClose(NpgsqlConnection conn)
        {
            conn.Close();
        }
        public bool CheckInDateBaseAuthorization(string query)
        {
            string sqlQuery = "SELECT * " + query;
            var conn = ConncetToDateBaseOpen();
            NpgsqlCommand command = new NpgsqlCommand(sqlQuery, conn);
            NpgsqlDataReader reader = command.ExecuteReader();
            bool check = ReadCheckFromDateBase(reader);
            ConncetToDateBaseClose(conn);
            return check;
        }
        public NpgsqlDataReader CheckInDateBase(string query)
        {
            string sqlQuery = "SELECT * " + query;
            var conn = ConncetToDateBaseOpen();
            NpgsqlCommand command = new NpgsqlCommand(sqlQuery, conn);
            NpgsqlDataReader reader = command.ExecuteReader();
            
           
            return reader;
        }

        public NpgsqlDataReader LoadCycleFromDateBase(int firstIndexFromList, int secondIndexFromList, int thirdIndexFromList)
        {
            List<CycleModel> cycle = new List<CycleModel>();
            string sqlQuery = "SELECT * FROM cycle WHERE id IN " +
                $"({firstIndexFromList}, {secondIndexFromList}, {thirdIndexFromList})";
           
            
            var conn = ConncetToDateBaseOpen();
            NpgsqlCommand commnad = new NpgsqlCommand(sqlQuery, conn);
            NpgsqlDataReader reader = commnad.ExecuteReader();
            
            
            return reader;
        }

        public void DeletedData(string query)
        {
            string sqlQuery = "DELETE FROM " + query;
            var conn = ConncetToDateBaseOpen();
            NpgsqlCommand command = new NpgsqlCommand (sqlQuery, conn);
            command.ExecuteNonQuery();



            ConncetToDateBaseClose(conn);
        }
        public void ConncetToDateBaseClosePublic()
        {
            var conn = ConncetToDateBaseOpen();
            ConncetToDateBaseClose(conn);
        }
        //INSERT INTO
       

        public void AddToDateBase(string query)
        {
            string sqlQuery = "INSERT INTO " + query;
            var conn = ConncetToDateBaseOpen();
            
            NpgsqlCommand command = new NpgsqlCommand(sqlQuery,conn);
            command.ExecuteNonQuery();

            ConncetToDateBaseClose(conn);
        }


        // Код для реализации добавления, с проверкой(но мне лень сейчас делатЬ)
        /* private void CheckForAdding(NpgsqlDataReader reader)
         {
             try
             {
                 reader.Read();
             }
             catch (Exception ex)
             {
                 throw new Exception("Error in reading data from database", ex);
             }
         }*/
        private bool ReadCheckFromDateBase(NpgsqlDataReader reader)
        {
            try
            {
                if (reader.Read())
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in reading data from database", ex);
            }
        }

    }
}
