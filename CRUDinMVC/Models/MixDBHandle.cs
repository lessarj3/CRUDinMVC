using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CRUDinMVC.Models
{
    public class MixDBHandle
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["FreshMixConn"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW MIX *********************
        public bool AddMix(MixModel smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddNewMix", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@MixName", smodel.MixName);
            cmd.Parameters.AddWithValue("@CFx", smodel.CFx);
            cmd.Parameters.AddWithValue("@SVO", smodel.SVO);
            cmd.Parameters.AddWithValue("@ConductiveCarbon", smodel.ConductiveCarbon);
            cmd.Parameters.AddWithValue("@Binder", smodel.Binder);
            cmd.Parameters.AddWithValue("@Ratio", smodel.Ratio);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********** VIEW MIX DETAILS ********************
        public List<MixModel> GetMix()
        {
            connection();
            List<MixModel> mixlist = new List<MixModel>();

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
                    new MixModel
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        MixName = Convert.ToString(dr["MixName"]),
                        CFx = Convert.ToInt32(dr["CFx"]),
                        SVO = Convert.ToInt32(dr["SVO"]),
                        ConductiveCarbon = Convert.ToInt32(dr["ConductiveCarbon"]),
                        Binder = Convert.ToInt32(dr["Binder"]),
                        Ratio = Convert.ToInt32(dr["Ratio"])
                    });
            }
            return mixlist;
        }

        // ***************** UPDATE MIX DETAILS *********************
        public bool UpdateDetails(MixModel smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateMixDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@MixId", smodel.Id);
            cmd.Parameters.AddWithValue("@MixName", smodel.MixName);
            cmd.Parameters.AddWithValue("@CFx", smodel.CFx);
            cmd.Parameters.AddWithValue("@SVO", smodel.SVO);
            cmd.Parameters.AddWithValue("@ConductiveCarbon", smodel.ConductiveCarbon);
            cmd.Parameters.AddWithValue("@Binder", smodel.Binder);
            cmd.Parameters.AddWithValue("@Ratio", smodel.Ratio);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********************** DELETE MIX DETAILS *******************
        public bool DeleteMix(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteMix", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@MixId", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

    }
}