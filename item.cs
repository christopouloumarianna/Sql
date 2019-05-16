using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagement
{
    class FormattedTest
    {
        public string text;
    }
}
public class Item
{

    public int Id { get; set; }

    public string Name { get; set; }
    public decimal Price { get; set; }
    public string GrosCategory { get; set; }

    List<string> items = new List<string>();
    private int v;
    private Func<string> toString1;
    private Func<string> toString2;
    private Func<string> toString3;

    public Item(int id, string name, decimal price, string grosCategory, List<string> items)
    {
        Id = id;
        Name = name;
        Price = price;
        GrosCategory = grosCategory;
        this.items = items;
    }

    public Item(int v, Func<string> toString1, Func<string> toString2, Func<string> toString3)
    {
        this.v = v;
        this.toString1 = toString1;
        this.toString2 = toString2;
        this.toString3 = toString3;
    }
    public void InsertDB()
    {
        var items = new List<Item>();

        string data = File.ReadAllText("Jsondata.txt");
        var tempItem = JsonConvert.
            DeserializeObject<List<Item>>(data); // Load from json file
        foreach (Item t in tempItem)
        {
            items.Add(t);

        }
        using (SqlConnection conn = new SqlConnection())
        {
            string s3 = "Server =localhost; Database =GrosseryList; Integrated Security=SSPI;Persist Security Info=False;";

            conn.ConnectionString = s3;
            conn.Open();

            foreach (var t in items)
            {
                SqlCommand insertCommand = new SqlCommand("INSERT INTO Grossery (Name, Price, GrosCategory)" +
                    "" +
                    " VALUES (@0,@1,@2)", conn);


                insertCommand.Parameters.Add(new SqlParameter("0", t.Name));
                insertCommand.Parameters.Add(new SqlParameter("1", (t.Price)));
                insertCommand.Parameters.Add(new SqlParameter("2", int.Parse(t.GrosCategory)));
                int c = insertCommand.ExecuteNonQuery();
            }



        }



    }
}
