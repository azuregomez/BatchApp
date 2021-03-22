using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace BatchApp
{
    public class BatchDac: ISaveResult
    {
        private string _connectionString;
        public BatchDac(IConfiguration iconfiguration)
        {
            _connectionString = iconfiguration.GetConnectionString("Default");
        }

        public void SaveResult(BatchRun br)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("insert into batchrun (fname, result, timesaved, nodename) values (@fname,@result, GETDATE(),@nodename)", con);                    
                    cmd.Parameters.AddWithValue("fname", br.FName);
                    cmd.Parameters.AddWithValue("result", br.Result);                    
                    cmd.Parameters.AddWithValue("nodename", br.NodeName);                                        
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BatchRun> Get()
        {
            var batchRunList = new List<BatchRun>();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("Select * from batchrun", con);
                    cmd.CommandType = System.Data.CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        batchRunList.Add(new BatchRun
                        {
                            Id = Convert.ToInt32(rdr[0]),
                            FName = rdr[1].ToString(),
                            Result = rdr[2].ToString(),
                            TimeSaved = DateTime.Parse(rdr[3].ToString()),
                            NodeName = rdr[4].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return batchRunList;
        }
    }
}  
    