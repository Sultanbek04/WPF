using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Runtime.InteropServices;

namespace ConnectionToC1
{
  class Program
  {
    static void Main(string[] args)
    {
      /*  SqlConnection con = new SqlConnection("server=192.168.0.100,1400;user=Users;password=password;database=Example1;integrated security = true;");

        const string server = "(local)";
        const string connString = @"Data Source=Server;Initial Catalog=Base;Integrated Security=false;MultipleActiveResultSets=true;";

      public static readonly string userDB = connString.Replace("Server", server).Replace("Base", "userdb");

      SqlDataAdapter sda = new SqlDataAdapter();
        DataTable dbdataset = new DataTable();

        BindingSource bsource = new BindingSource();
        SqlCommand cmd = new SqlCommand();


        try
        {
          SqlCommand cmdatabbase = new SqlCommand(" select * from Example1.dbo.Users ;", con);

          sda.SelectCommand = cmdatabbase;

          sda.Fill(dbdataset);

          bsource.DataSource = dbdataset;
          dataGridView1.DataSource = bsource;
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.ToString());*/
       string user = "Бухгалтер";

      string pas = "";

      string file = "C:\\Users\\user\\Documents\\InfoBase";

      dynamic result;

      dynamic refer;
      var xz=Type.GetTypeFromProgID("double");
      var d=Activator.CreateInstance(xz);
      Console.WriteLine(d.GetType());
      Console.ReadLine();
      var comConnector = Type.GetTypeFromProgID("V82.COMConnector");
      dynamic com1s = Activator.CreateInstance(comConnector);


      com1s.PoolCapacity = 10;

      com1s.PoolTimeout = 60;

      com1s.MaxConnections = 2;

      result = com1s.Connect("File='" + file + "';Usr='" + user + "';pwd='" + pas + "';");

      refer = result.Справочники.Номенклатура.СоздатьЭлемент();

      refer.Наименование = "Создано из C#";


      refer.Записать();
    }
    

  }
}
