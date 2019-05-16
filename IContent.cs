using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using Newtonsoft.Json;


namespace ContentManagement
{
    public interface IContect
    {
        int CountWords();
        string GetLengthiestWords();
        bool LoadText(string filename);
        bool SaveText(string filename);

    }




    public class Msql


    {

        public void M1sql()

        {

            using (SqlConnection conn = new SqlConnection())
            {
                string s3 = "Server =localhost; Database =GrosseryList; Integrated Security=SSPI;Persist Security Info=False;";
                //* s3: intergrate from windows
                //string s4 = "Server =localhost; Database =dvdstore; Persist Security Info=True;User ID=sa;Password=passw0rd;";
                //** s4: intergrate with password
                conn.ConnectionString = s3;
                conn.Open();
                // Create the command
                SqlCommand command = new SqlCommand("SELECT [Id] ,[Name], [Price], [GrosCategory] FROM[dbo].[Grossery]", conn);

                // Add the parameters.
                //command.Parameters.Add(new SqlParameter("0", 1));

                /* Get the rows and display on the screen!
                 * This section of the code has the basic code
                 * that will display the content from the Database Table
                 * on the screen using an SqlDataReader. */

                //using (SqlDataReader reader = command.ExecuteReader())
                //{
                //Console.WriteLine("FirstColumn\tSecond Column\t\tThird Column\t\tForth Column\t");
                //while (reader.Read())
                //{



                //    {
                //        Console.WriteLine(String.Format("{0} \t | {1} \t  ",
                //            reader[0], reader[1]));


                //    }

                //}
                var items = new List<Item>();

                using (SqlDataReader reader1 = command.ExecuteReader())
                {

                    Console.WriteLine("FirstColumn\tSecond Column\t\tThird Column\t\tForth Column\t");
                    while (reader1.Read())
                    {

                        Item item = new Item(int.Parse(reader1[0].ToString()), (reader1[1].ToString),
                            (reader1[2].ToString), (reader1[3].ToString));
                        items.Add(item);

                        //item.Add(String.Format("",, reader1[1], reader1[2], reader1[3]));



                    }
                }
                string jsonData = JsonConvert.SerializeObject(items);
                System.IO.File.WriteAllText("Jsondata.txt", jsonData);


                Console.WriteLine("Press any key to exit");
                Console.ReadLine();

            }
        }

    }
}