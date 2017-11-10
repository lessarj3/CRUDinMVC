using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CathRepoCommon.Models
{
    public class MixRepositorySQL : IMixRepository
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["FreshMixConn"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW MIX *********************
        public void AddMix(IEnumerable<Mix> mixes)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddNewMix", con);


            foreach (var mix in mixes)
            {
 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MixName", mix.MixName);
                cmd.Parameters.AddWithValue("@CFx", mix.CFx);
                cmd.Parameters.AddWithValue("@SVO", mix.SVO);
                cmd.Parameters.AddWithValue("@ConductiveCarbon", mix.Carbon);
                cmd.Parameters.AddWithValue("@Binder", mix.Binder);
                cmd.Parameters.AddWithValue("@Ratio", mix.Ratio);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    con.Close();
                    throw new Exception("Error Adding Mix", ex);
                }
            }
            //if(con.IsOpen)
            con.Close();
        }

        // **************** ADD NEW MIX *********************
        public void AddMix(Mix mix)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddNewMix", con);


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MixName", mix.MixName);
            cmd.Parameters.AddWithValue("@CFx", mix.CFx);
            cmd.Parameters.AddWithValue("@SVO", mix.SVO);
            cmd.Parameters.AddWithValue("@ConductiveCarbon", mix.Carbon);
            cmd.Parameters.AddWithValue("@Binder", mix.Binder);
            cmd.Parameters.AddWithValue("@Ratio", mix.Ratio);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Adding Mix", ex);
            }
            finally
            {
                con.Close();
            }

        }


        // ********** VIEW MIX DETAILS ********************
        public IEnumerable<Mix> GetMixes()
        {
            connection();
            List<Mix> mixlist = new List<Mix>();

            SqlCommand cmd = new SqlCommand("GetMixDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                mixlist.Add(
                    new Mix
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        MixName = Convert.ToString(dr["MixName"]),
                        CFx = Convert.ToInt32(dr["CFx"]),
                        SVO = Convert.ToInt32(dr["SVO"]),
                        Carbon = Convert.ToInt32(dr["ConductiveCarbon"]),
                        Binder = Convert.ToInt32(dr["Binder"]),
                        Ratio = Convert.ToInt32(dr["Ratio"])
                    });
            }
            return mixlist;
        }

        // ***************** UPDATE MIX DETAILS *********************
        public void UpdateDetails(Mix mix)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateMixDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@MixId", mix.Id);
            cmd.Parameters.AddWithValue("@MixName", mix.MixName);
            cmd.Parameters.AddWithValue("@CFx", mix.CFx);
            cmd.Parameters.AddWithValue("@SVO", mix.SVO);
            cmd.Parameters.AddWithValue("@ConductiveCarbon", mix.Carbon);
            cmd.Parameters.AddWithValue("@Binder", mix.Binder);
            cmd.Parameters.AddWithValue("@Ratio", mix.Ratio);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception ("Error updating mix", ex);
            }
            finally
            {
                con.Close();
            }                   
        }

        // ********************** DELETE MIX DETAILS *******************
        public void DeleteMix(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteMix", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MixId", id);
            
            con.Close();

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Deleting mix", ex); ;
            }
            finally
            {
                con.Close();
            }
        }

    }

    public class MyConnectionException : Exception
    {

    }
}