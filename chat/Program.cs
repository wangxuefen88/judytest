using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using System.Configuration;
using System.Data;


namespace chat
{
  public  class Program
    { 
      public  static void Main(string[] args)
        {
            string a = null;
            a = DateTime.Now.ToString("T");
            //while (a != "20:07:10")
            //{
            //    a = DateTime.Now.ToString("T");
            //}
            //a = DateTime.Now.ToString("T");

            accesstoken.quertion();
         
        }
    }

}