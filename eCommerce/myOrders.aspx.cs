﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class myOrders : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (ecommerceEntities context = new ecommerceEntities())
        {
            var lq = (from o in context.Orders
                      join p in context.Products
                      on o.ProductID equals p.ProductID
                      select new { 
                          o.OrderID,
                          o.DateOrdered,
                          p.ProductName,
                          p.ProductPrice,
                          p.Discount,
                      }).ToList();

            GridView1.DataSource = lq;
            GridView1.DataBind();
        }
    }
}