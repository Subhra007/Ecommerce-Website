﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Admin_AdminMaserPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (ecommerceEntities context = new ecommerceEntities())
        {
            if (Session["CustomerID"] != null)
            {
                //Getting user info based on session variable
                int id = (int)Session["CustomerID"];
                Customer cust = context.Customers.Where(i => i.CustomerID == id).FirstOrDefault();

                if (cust.UserType != "admin")
                {
                    Response.Redirect("~/home.aspx");
                }
            }
            else
            {
                Response.Redirect("~/home.aspx");
            }

        }
    }
}
