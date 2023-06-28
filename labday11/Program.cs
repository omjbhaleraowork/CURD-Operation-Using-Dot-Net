using Microsoft.Data.SqlClient;
using System;

using System.Data;


namespace labday11
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Connect();
           //Insert();
           Customer customer = new Customer();
            // Insert(customer);
           // Update();

            Delete();         
            DataReader();
        }
        static void Connect()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=LabAssign;Integrated Security=true";
            cn.Open();

            Console.WriteLine("open");

            cn.Close();
        }

        static void Insert()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=LabAssign;Integrated Security=true";
            cn.Open();

            try
            {
                
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Insert into Customer values('mayur','mk@gmail.com',102,1165648)";

                cmd.ExecuteNonQuery();

                Console.WriteLine("okay");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        static void Update()
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = @"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=LabAssign;Integrated Security=true";
                cn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE Customer SET Name = @Name, Email =  @Email WHERE CustID = @CustID";
                    cmd.Parameters.AddWithValue("@Name", "Rohan ");
                    cmd.Parameters.AddWithValue("@Email", "rohan@gmail.com");
                    cmd.Parameters.AddWithValue("@CustID", 102);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine("Rows updated: " + rowsAffected);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    cn.Close();
                }
            }
           
        }

        static void DataReader()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=LabAssign;Integrated Security=true";
            cn.Open();

            try
            {
               
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Customer";

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Console.WriteLine(dr["Name"]);
                    Console.WriteLine(dr["Email"]);
                    Console.WriteLine(dr["CustID"]);
                }

                Console.WriteLine();
                Console.WriteLine();

               /* dr.NextResult();
                while (dr.Read())
                {
                    Console.WriteLine(dr["CustID"]);
                }*/



                dr.Close();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        static void Delete()
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = @"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=LabAssign;Integrated Security=true";
                cn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM Customer WHERE CustID = @CustID";
                // Assuming CustomerId is the primary key column
cmd.Parameters.AddWithValue("@CustID", 102);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine("Rows deleted: " + rowsAffected);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
       


    }
}

class Customer
{
    public int CustID { get; set; }
    public string Name { get; set; }
    public int MobileNo{ get; set; }

    public string Email { get; set; }
}