using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApiMemberValue.Models
{
	public class MemberProductsValue
	{
		public string CoverageLevel { get; set; }
		public string FullMemberNumber { get; set; }
		public string Business { get; set; }
		public string ProductDescription { get; set; }
		public decimal MemberValue { get; set; }
		public string ActivityDate { get; set; }

		public static List<MemberProductsValue> GetList(string FullMemberNumber)
		{
			string connString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
			List<MemberProductsValue> lstmpv = new List<MemberProductsValue>();
			DataSet ds = new DataSet();
			using (SqlConnection conn = new SqlConnection(connString))
			{
				using (SqlCommand cmd = new SqlCommand("spMemberProductsValueGet", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					if (null != FullMemberNumber)
					{
						cmd.Parameters.Add(new SqlParameter("MemberNumber", FullMemberNumber));
					}
					SqlDataAdapter da = new SqlDataAdapter(cmd);
					da.Fill(ds);
				}
			}

			if (ds.Tables.Count > 0)
			{
				foreach (DataRow row in ds.Tables[0].Rows)
				{
					MemberProductsValue mpv = new MemberProductsValue();
					mpv.Business = String.Format("{0}", row["Business"]);
					mpv.FullMemberNumber = String.Format("{0}", row["FullMemberNumber"]);
					mpv.CoverageLevel = String.Format("{0}", row["CoverageLevel"]);
					mpv.ProductDescription = String.Format("{0}", row["ProductDescription"]);
					mpv.ActivityDate = String.Format("{0:MM/dd/yyyy}", row["ActivityDate"]);

					if (row["MemberValue"] != DBNull.Value)
					{
						mpv.MemberValue = Convert.ToDecimal(row["MemberValue"]);
					}

					lstmpv.Add(mpv);
				}
			}

			return lstmpv;
		}


	}
}