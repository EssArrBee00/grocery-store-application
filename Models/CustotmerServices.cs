using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using Microsoft.Data.SqlClient;
namespace Assignment02.Models
{
    //implementing class that handles all data reading and writing operations from database
    class CustotmerServices
    {
        SqlConnection conn;  //for connection sttringn
        ObservableCollection<Customer> customerLit;
        public CustotmerServices()
        {
            try
            {
               
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Syed\Downloads\Assignment02_BCSF18M530\Data\CustomerDataBase.mdf;Integrated Security=True";
                conn = new SqlConnection(connectionString);
                conn.Open();

                customerLit = new ObservableCollection<Customer>();
            }
            catch
            {
                MessageBox.Show("DATABASE NOT FIND TRY AGAIN");
            }
        }

        public bool AddCustomerDB(Customer C)  // addidng customer in database
        {
            if (conn == null) return false;
            try
            {
               
                string query = $"insert into CustomerTable(CName, CPassword, CPhnum) values('{C.CustomerName}', '{C.Password}', '{C.Phonenum}')";
                SqlCommand cmd = new SqlCommand(query, conn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        public void ReadCustomerDB() //reading data from database
        {
            try
            {
                string query = "select CName,CPassword,CPhnum from CustomerTable";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader(); //reading data
                while (reader.Read())
                {
                    string name = reader.GetString(0);
                    string Cpassword = reader.GetString(1);
                    int num = reader.GetInt32(2);
                    Customer temp = new Customer
                    {
                        CustomerName = name.Trim(),
                        Password = Cpassword.Trim(),
                        Phonenum = num
                    };

                    customerLit.Add(temp);
                    
                }

            }
            catch
            {
               
            }

            

        }

        public bool CustomerExists(string usrname,string password) //checking acccount valididty
        {
            ReadCustomerDB();
            foreach(Customer x in customerLit)
            {
                if(x.CustomerName==usrname && x.Password == password)
                {
                    return true;
                }
            }

            return false;
        }



        public void closeConnection() //closing connection
        {
            conn.Close();
        }


    }
}
