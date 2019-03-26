using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BEL;
namespace DAL
{
    public class DataAccess
    {
		SqlConnection con;
		SqlCommand com;
		public SqlConnection GetConnection()
		{
			con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
			con.Open();
			con.Close();
			return con;
		}
		public int InsertIntoAddressBook(AddressBook addressbook)
		{
			int flag = 0;
			using (con = GetConnection())
			{
				SqlDataAdapter ada = new SqlDataAdapter("Select * from addressBook", con);

				SqlCommandBuilder sb = new SqlCommandBuilder(ada);

				DataSet ds = new DataSet();
				ada.Fill(ds);
				DataRow dr = ds.Tables[0].NewRow();
				//dr[0] = batch.id;
				dr[1] = addressbook.firstname;
				dr[2] = addressbook.lastname;
				dr[3] = addressbook.email;
				dr[4] = addressbook.mobno;
				dr[5] = addressbook.address;

				ds.Tables[0].Rows.Add(dr);
				ada.Update(ds);
			}
			return flag;
		}

		public int UpdateAddressBookEmail(AddressBook addressbook)
		{
			int flag = 0;
			using (con = GetConnection())
			{
				SqlDataAdapter ada = new SqlDataAdapter("Select * from addressBook", con);
				SqlCommandBuilder sb = new SqlCommandBuilder(ada);

				DataSet ds = new DataSet();
				ada.Fill(ds);

				for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
				{
					if (Convert.ToInt32(ds.Tables[0].Rows[i][0]) == addressbook.addressid)
					{
						ds.Tables[0].Rows[i][3] = addressbook.email;
						flag = 1;
						break;
					}
					else
					{
						flag = 0;
					}
				}
				ada.Update(ds);

			}

			return flag;
		}

		public int DeleteFromAddressBook(AddressBook addressbook)
		{
			int flag = 0;

			using (con = GetConnection())
			{
				SqlDataAdapter ada = new SqlDataAdapter("select * from addressBook", con);
				SqlCommandBuilder cb = new SqlCommandBuilder(ada);

				DataSet ds = new DataSet();

				for (int i = 0; i <= ds.Tables[0].Rows.Count; i++)
				{
					if(Convert.ToInt32(ds.Tables[0].Rows[i][0])==addressbook.addressid)
					{
						ds.Tables[0].Rows[i].Delete();
						flag = 1;
						break;
						
					}
					
				}
			}
			return flag;
		}

		public DataTable SearchAddressBook(AddressBook addressbook)
		{
			//int flag = 0;

			using (con = GetConnection())
			{
				SqlDataAdapter ada = new SqlDataAdapter("select * from addressBook", con);
				SqlCommandBuilder cb = new SqlCommandBuilder(ada);
				DataSet ds = new DataSet("Returnsingle");
				DataTable dt = new DataTable();
				DataColumn dc;
				DataRow dr;
				dc = new DataColumn();
				dc.DataType = typeof(Int32);
				dt.Columns.Add(dc);
				dc = new DataColumn();
				dc.DataType = typeof(string);
				dt.Columns.Add(dc);
				dc = new DataColumn();
				dc.DataType = typeof(string);
				dt.Columns.Add(dc);
				dc = new DataColumn();
				dc.DataType = typeof(string);
				dt.Columns.Add(dc);
				dc = new DataColumn();
				dc.DataType = typeof(string);
				dt.Columns.Add(dc);
				dc = new DataColumn();
				dc.DataType = typeof(string);
				dt.Columns.Add(dc);

				ada.Fill(ds);
				//DataTable dt = new DataTable();

				for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
				{
					if (Convert.ToInt32(ds.Tables[0].Rows[i][0]) == addressbook.addressid)
					{
						DataRow dr1 = dt.NewRow();
						dr1[0] = addressbook.addressid;
						dr1[1] = addressbook.firstname;
						dr1[2] = addressbook.lastname;
						dr1[3] = addressbook.email;
						dr1[4] = addressbook.mobno;
						dr1[5] = addressbook.address;
						return dt;

					}
				}

				return dt;
			}

		}
	}
}
