using System.Data;
using System.Data.SqlClient;
using System;
using System.Configuration;

using System.Web.UI.WebControls;

public class Database
{
    public static SqlConnection getConnection()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ToString();

        SqlConnection con = new SqlConnection(connectionString);
        con.Open();

        return con;
    }

    public static DataTable executeselect(string query)
    {
        SqlConnection con = getConnection();

        SqlCommand command = new SqlCommand(query, con);

        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.SelectCommand = command;
        DataSet ds = new DataSet();
        adapter.Fill(ds);

        con.Close();

        return ds.Tables[0];
    }

    public static int executeQuery(string query)
    {

        SqlConnection con = getConnection();
        SqlCommand cmd = new SqlCommand(query, con);

        int rowaffected = cmd.ExecuteNonQuery();

        con.Close();

        return rowaffected;


    }

    public static DataSet getdataset(string query)
    {
        SqlConnection conn = getConnection();

        SqlCommand command = new SqlCommand(query, conn);

        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.SelectCommand = command;
        DataSet ds = new DataSet();
        adapter.Fill(ds);

        conn.Close();

        return ds;
    }

    public static SqlDataReader getDataReader(string query)
    {
        SqlConnection conn = getConnection();

        SqlCommand command = new SqlCommand(query, conn);

        SqlDataReader dr = command.ExecuteReader();

        return dr;
    }
}