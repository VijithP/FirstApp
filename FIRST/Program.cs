using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace FIRST
{
    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Users list");
            Program pr = new Program();

            DataTable dt = pr.GetUsers();

            foreach(DataRow item in dt.Rows)
            {
                Console.WriteLine(item[1]);
            }


            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
        

        public DataTable GetUsers()
        {
            try
            {

                
                SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = D:\R&D\GITHUB FIRST\FIRST\Database1.mdf; Integrated Security = True; ");
              
                SqlDataAdapter adapt;
                conn.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("select * from dbo.[User]", conn);
                adapt.Fill(dt);
                conn.Close();
                return dt;



            }
            catch (Exception e)
            {

                throw e;
            }
        }








    }
  public  class User{

        public int UserId { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public bool IsActive { set; get; }
    }



}
