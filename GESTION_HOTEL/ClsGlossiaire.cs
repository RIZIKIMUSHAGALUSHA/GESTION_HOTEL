using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_HOTEL.Classes
{
    internal class ClsGlossiaire
    {
        public static ClsGlossiaire instance = null;
        public static ClsGlossiaire GetInstance()
        {
            if (instance == null)
                instance = new ClsGlossiaire();
            return instance;
        }
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataAdapter dt = null;
        SqlDataReader dr = null;

        public void InitialiseConnexion()
        {
            try
            {
                con = new SqlConnection(connexion.chemin);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de connexion " + ex.Message);
            }
        }
        public void UpdateCategorisation(Categorie categ)
        {
            try
            {
                InitialiseConnexion();
                con.Open();
                cmd = new SqlCommand(" SaveCategorie @id, @categorie ", con);
                cmd.Parameters.AddWithValue("@id", categ.Id);
                cmd.Parameters.AddWithValue("@categorie", categ.Designation);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateClasse(Classe clas)
        {
            try
            {
                InitialiseConnexion();
                con.Open();
                cmd = new SqlCommand("exec SaveClasse @id, @designation, @prix ", con);
                cmd.Parameters.AddWithValue("@id", clas.Id);
                cmd.Parameters.AddWithValue("@designation", clas.Designation);
                cmd.Parameters.AddWithValue("@prix", clas.Prix);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public DataTable loadData(string nomTable)
        {

            InitialiseConnexion();
            if (!con.State.ToString().ToLower().Equals("open")) con.Open();
            DataTable table = new DataTable();
            dt = new SqlDataAdapter("select * from " + nomTable + "", con);
            dt.Fill(table);
            con.Close();

            return table;
        }

        public void DeleteData(string nomTable, string champId, int id)
        {
            try
            {
                InitialiseConnexion();
                con.Open();
                cmd = new SqlCommand("delete from  " + nomTable + " where " + champId + " = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void loadCombo(string nomTable, string nomchamp, System.Windows.Forms.ComboBox comb1)
        {
            InitialiseConnexion();
            if (!con.State.ToString().ToLower().Equals("open")) con.Open();
            DataTable table = new DataTable();
            dt = new SqlDataAdapter("SELECT " + nomchamp + " FROM " + nomTable + "", con);
            try
            {
                DataTable dt1 = new DataTable();
                dt.Fill(dt1);

                foreach (DataRow dr in dt1.Rows)
                {
                    comb1.Items.Add(dr[nomchamp]);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur" + ex);
            }

            con.Close();
        }

        public string getcode_Combo(string nomTable, string nomChampId, string nomChamp, string valeur)
        {
            string IdData = "";
            try
            {
                InitialiseConnexion();
                if (!con.State.ToString().ToLower().Equals("open")) con.Open();
                cmd = new SqlCommand("select " + nomChampId + " from " + nomTable + " where " + nomChamp + "=@a", con);
                cmd.Parameters.AddWithValue("@a", valeur);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    IdData = (dr[nomChampId].ToString());
                }
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return IdData;
        }
    }


}
