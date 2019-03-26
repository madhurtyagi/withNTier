using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BEL;
using BAL;

namespace WithNTier
{
	public partial class userview : System.Web.UI.Page
	{
		int flag;
		BusinessAccess ba = new BusinessAccess();
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void btnInsert_Click(object sender, EventArgs e)
		{
			AddressBook ab = new AddressBook { firstname = txtFirstName.Text, lastname = txtLastName.Text, email = txtEmail.Text, mobno = txtMobNo.Text, address = txtAddress.Text };

			flag = ba.InsertIntoAddressBook(ab);
			if (flag == 1)
				lblShow.Text = "record inserted";
			else
				lblShow.Text = "Record not inserted";
		}

		protected void btnUpdate_Click(object sender, EventArgs e)
		{
			AddressBook ab = new AddressBook { addressid = Convert.ToInt32(txtAddressId.Text) , email = txtEmail.Text };
			flag= ba.UpdateAddressBookEmail(ab);
			if (flag == 1)
				lblShow.Text = "record updated";
			else
				lblShow.Text = "Record not updated";

		}

		protected void btnDelete_Click(object sender, EventArgs e)
		{
			AddressBook ab = new AddressBook { addressid = Convert.ToInt32(txtAddressId.Text) };
			flag = ba.UpdateAddressBookEmail(ab);
			if (flag == 1)
				lblShow.Text = "record delted";
			else
				lblShow.Text = "Record cannot be deleted or not exists";
		}

		protected void btnSearch_Click(object sender, EventArgs e)
		{
			AddressBook ab = new AddressBook { addressid = Convert.ToInt32(txtAddressId.Text) };
			DataTable dt = ba.SearchAddressBook(ab);

			txtFirstName.Text = (dt.Columns[1].va).ToString();
			txtLastName.Text = (dt.Columns[2]).ToString();
			txtEmail.Text = (dt.Columns[3]).ToString();
			txtMobNo.Text =(dt.Columns[4]).ToString();
			txtAddress.Text = (dt.Columns[5]).ToString();
		}
	}
}