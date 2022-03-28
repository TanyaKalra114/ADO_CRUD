using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace ADO_CRUD
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Program.Connection();
            Console.ReadLine();
        }
        static void Connection()
        {
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            SqlConnection con = null;
            try
            {
                using (con=new SqlConnection(cs))
                {
                    con.Open();
                    if(con.State == ConnectionState.Open)
                    {
                        Console.WriteLine("Connection has been Created Successfully");
                        Console.WriteLine("Welcome to Starbucks!");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("HEY! Tanya, Welcome Back!");
                        Console.ForegroundColor= ConsoleColor.Yellow;
                        Console.WriteLine("Press Enter to Show Pop-Up Window****");
                        Console.ReadLine();
                       MessageBox.Show("IT WOULD TAKE A MINUTE TO COMPLETE YOUR PROFILE!");
                        //insert the values in Customers table
                        Console.WriteLine("\n Enter your Customer_Id");
                        string Customer_Id=Console.ReadLine();
                        Console.WriteLine("\n Enter your First_name");
                        string First_name = Console.ReadLine();
                        Console.WriteLine("\n Enter your Last_name");
                        string Last_name= Console.ReadLine();
                        Console.WriteLine("\n Enter your Phone_number");
                        string Phone_number = Console.ReadLine();
                        Console.WriteLine("\n Enter your Email_Id");
                        string Email_Id = Console.ReadLine();
                        string query = "INSERT INTO Customers(Customer_Id,First_name,Last_name,Phone_number,Email_Id) values('" + Customer_Id + "','" + First_name + "','" + Last_name + "','" + Phone_number + "','" + Email_Id + "')";
                        SqlCommand ins = new SqlCommand(query,con);
                        ins.ExecuteNonQuery();
                        Console.ForegroundColor =ConsoleColor.DarkGreen;
                        Console.WriteLine("Data Stored(Inserted) successfully!");
                        Console.ForegroundColor=ConsoleColor.White;
                        Console.WriteLine("Enter OTP to verify your Phone_number and Email_Id");
                        string userName= Console.ReadLine();
                        Console.WriteLine("OTP IS:" + userName);
                        MessageBox.Show("Your Profile has been Created Successfully!");
                        //fetching products table
                       // Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("What Do You Like to Order??");
                        string qu = "spGetProducts";
                        SqlDataAdapter sda = new SqlDataAdapter(qu,con);
                        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        foreach(DataRow row in ds.Tables[0].Rows)
                        {
                            Console.WriteLine(row[0] + " " + row[1] + " "+row[2]); 
                        }
                        //product Display
                        Console.WriteLine("Choose the Product from the following list:");
                        Console.WriteLine("\ta - Caffe Latte");
                        Console.WriteLine("\tb - Caffe Mocha");
                        Console.WriteLine("\tc - White Chocolate Mocha");
                        Console.WriteLine("\td - Black Coffee");
                        Console.WriteLine("\te - Coffee Cold");
                        Console.Write("Your Option? ");
                        switch (Console.ReadLine())
                        {
                            case "a":
                                int quantity, total;
                                int CaffeLatte = 78;
                                Console.WriteLine("You Ordered Caffe Latte");
                                Console.WriteLine("Enter Quantity");
                                quantity = Convert.ToInt32(Console.ReadLine());
                                total = quantity * CaffeLatte;
                                Console.WriteLine(total);


                                break;
                                case "b":
                                int CaffeMocha = 89;
                                Console.WriteLine("You Ordered Caffe Mocha");
                                Console.WriteLine("Enter Quantity");
                                quantity = Convert.ToInt32(Console.ReadLine());
                                total = quantity * CaffeMocha;
                                Console.WriteLine(total);


                                break;
                            case "c":
                                int WhiteChocolateMocha = 45;
                                Console.WriteLine("You Ordered White Chocolate Mocha");
                                Console.WriteLine("Enter Quantity");
                                quantity = Convert.ToInt32(Console.ReadLine());
                                total = quantity * WhiteChocolateMocha;
                                Console.WriteLine(total);

                                break;
                            case "d":
                                int BlackCoffee = 150;
                                Console.WriteLine("You Ordered Black Coffee");
                                Console.WriteLine("Enter Quantity");
                                quantity = Convert.ToInt32(Console.ReadLine());
                                total = quantity * BlackCoffee;
                                Console.WriteLine(total);

                                break;
                            case "e":
                                int Coffee = 90;
                                Console.WriteLine("You Ordered Coffee");
                                Console.WriteLine("Enter Quantity");
                                quantity = Convert.ToInt32(Console.ReadLine());
                                total = quantity * Coffee;
                                Console.WriteLine(total);

                                break;


                                
                        }
                        MessageBox.Show("Please Provided the Address for delievery");
                        Console.WriteLine("\nEnter your Address_Id");
                        string Address_Id=Console.ReadLine();
                        Console.WriteLine("\nEnter your Customer_Id");
                        string CustomerId = Console.ReadLine();
                        Console.WriteLine("\nEnter your House Number");
                        string Line1_House_Number = Console.ReadLine();
                        Console.WriteLine("\nEnter your Building");
                        string Line2_Bulding = Console.ReadLine();
                        Console.WriteLine("\nEnter your locality");
                        string Line3_locality= Console.ReadLine();
                        Console.WriteLine("\nEnter your Landmark");
                        string landmark = Console.ReadLine();
                        Console.WriteLine("\nEnter your city");
                        string city= Console.ReadLine();
                        Console.WriteLine("\nEnter your postal code");
                        string Zip_Postal_Code = Console.ReadLine();
                        Console.WriteLine("\nEnter your state");
                        string State = Console.ReadLine();
                        Console.WriteLine("\nEnter your country");
                        string Country = Console.ReadLine();

                        string q = "INSERT INTO Address(Address_Id,Customer_Id,Line1_House_Number, Line2_Bulding,Line3_locality,landmark,city, Zip_Postal_Code, State, Country) values('" + Address_Id+"','" + Customer_Id + "','" + Line1_House_Number + "','" + Line2_Bulding+ "','" + Line3_locality + "','" + landmark + "','" + city + "','" + Zip_Postal_Code + "','" + State + "','" + Country + "')";
                        SqlCommand a= new SqlCommand(q,con);
                        a.ExecuteNonQuery();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Address inserted Successfully!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Please select your Payment Mode:");
                        Console.WriteLine("\ta - COD Payment");
                        Console.WriteLine("\tb - Online Payment");
                        Console.Write("Your option?");
                        switch (Console.ReadLine())
                        {
                            case "a":
                                Console.WriteLine("Please be ready  with cash at the time of delievery");
                                MessageBox.Show("Your Order has been placed successfully!");
                                Console.WriteLine("Thankyou for Choosing Starbucks");


                                break;
                                case "b":
                                int amount;
                                Console.ForegroundColor= ConsoleColor.White;
                                Console.WriteLine("Enter Total Amount");
                                amount= Convert.ToInt32(Console.ReadLine());
                                if(amount>1000)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Transaction Failed");
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.WriteLine("Please do not refresh or navigate your page");
                                    Console.WriteLine("For Transaction Enter OTP ");
                                    Console.WriteLine("Enter OTP");
                                    string OTP = Console.ReadLine();
                                    Console.WriteLine("OTP is:" + OTP);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Payment done Successfully!");

                                   
                                }
                                break;
                        }

                        Console.ForegroundColor=ConsoleColor.White;
                        Console.WriteLine("Do you want to continue or sign out??");
                        Console.WriteLine("\ta - Stay in");
                        Console.WriteLine("\tb - Please try Update Operation");
                        Console.WriteLine("\tc - Sign out");

                        Console.WriteLine("Your Option?");
                        switch(Console.ReadLine())
                            {
                            case "a":
                                SqlCommand cm = new SqlCommand("delete from Customers where Customer_Id='8'", con);
                                cm.ExecuteNonQuery();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("delete successfully");
                                Console.WriteLine("SIGN-IN");

                                break;
                                case "b":
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Enter Order_Id:");
                                int _Order_Id = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter Dates:");
                                string _Dates = Console.ReadLine();
                                Console.WriteLine("Enter Total_Price:");
                                string _Total_Price = Console.ReadLine();
                                Console.WriteLine("Enter Customer_Id:");
                                int _Customer_Id = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter Store_Id:");
                                string _Store_Id = Console.ReadLine();

                                SqlCommand cmd = new SqlCommand();
                                cmd.CommandType = CommandType.Text;
                                cmd.Connection = con;
                                cmd.CommandText = "Update Orders set Dates=@Dates, Total_Price=@Total_Price, Customer_Id=@Customer_Id,Store_Id=@Store_Id where Order_Id=@Order_Id";
                                cmd.Parameters.AddWithValue("@Order_Id", _Order_Id);
                                cmd.Parameters.AddWithValue("@Dates", _Dates);
                                cmd.Parameters.AddWithValue("@Total_Price", _Total_Price);
                                cmd.Parameters.AddWithValue("@Customer_Id", _Customer_Id);
                                cmd.Parameters.AddWithValue("@Store_Id", _Store_Id);
                                int _rows = cmd.ExecuteNonQuery();
                                if(_rows > 0)
                                {
                                    Console.ForegroundColor= ConsoleColor.Green;
                                    Console.WriteLine("Updated Successfully!");
                                    Console.WriteLine("Wait for our Services");

                                }
                                else
                                {
                                    Console.ForegroundColor= ConsoleColor.Red;
                                    Console.WriteLine("Fail to Update!");
                                }




                                break;
                            case "c":
                                Console.ForegroundColor= ConsoleColor.White;
                                Console.WriteLine("SIGN-OUT");
                                Console.Write("Press any key to close the console app....");
                                Console.ReadKey();
                                break;
                        }








                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
