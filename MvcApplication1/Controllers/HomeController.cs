﻿using MvcApplication1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        //Change



        List<ClientsList> ClientsList = new List<ClientsList>
            {
                 new ClientsList ( "Adam",  "Bielecki",  DateTime.Parse("22/05/1986"),       "adamb@example.com" ), 
                 new ClientsList (  "George", "Smith",  DateTime.Parse("10/10/1990"),  "george@example.com" )
            };

        public ActionResult Index()
        {
            return View(ClientsList);
        }



        public void ExportClientsListToCSV()
        {

            StringWriter sw = new StringWriter();

            sw.WriteLine("\"First Name\",\"Last Name\",\"DOB\",\"Email\"");

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=Exported_Users.csv");
            Response.ContentType = "text/csv";

            foreach (var line in ClientsList)
            {
                sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\"",
                                           line.FirstName,
                                           line.LastName,
                                           line.Dob,
                                           line.Email));
            }

            Response.Write(sw.ToString());

            Response.End();

        }


        public void ExportClientsListToExcel()
        {
            var grid = new System.Web.UI.WebControls.GridView();

            grid.DataSource = /*from d in dbContext.diners
                              where d.user_diners.All(m => m.user_id == userID) && d.active == true */
                              from d in ClientsList
                              select new
                              {
                                  FirstName = d.FirstName,
                                  LastName = d.LastName,
                                  DOB = d.Dob,
                                  Email = d.Email

                              };

            grid.DataBind();

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=Exported_Diners.xls");
            Response.ContentType = "application/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            grid.RenderControl(htw);

            Response.Write(sw.ToString());

            Response.End();

        }

    }
}
