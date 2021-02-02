using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using Microsoft.Data.SqlClient;

namespace Assignment02.Models
{
    class ProductServices
    {
        SqlConnection conn; //defining object for database connection
        List<Product> productList;
        public ProductServices() //constructor
        {
            try
            {
                
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Syed\Downloads\Assignment02_BCSF18M530\Data\CustomerDataBase.mdf;Integrated Security=True";
                conn = new SqlConnection(connectionString);
                conn.Open();
                productList = new List<Product>();

            }
            catch(Exception ex)
            {
                
                MessageBox.Show($"Database cannot be connected due to error {ex.Message} \n please try again");
            }
        }

        public bool AddProductDB(Product p) //adding product to database
        {
            if (conn == null) return false;
            try {
                string query = $"insert into ProductTable(pid,pname,pprice,pquantity) values('{p.ProductID}','{p.ProductName}','{p.ProductPrice}','{p.ProductQuantity}')";
                
                SqlCommand cmd = new SqlCommand(query, conn);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch {
                return false;
            }
            closeConnestion();
            return false;

        } 

        public void ReadProductsDB() //reading product froM Database
        {
            if (conn == null) return;
            try
            {
                string query = $"select pid,pname,pprice,pquantity from ProductTable";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1).Trim();
                    decimal price = reader.GetDecimal(2);
                    int quantity = reader.GetInt32(3);

                    Product obj = new Product
                    {
                        ProductID = id,
                        ProductName = name,
                        ProductPrice = (int)price,
                        ProductQuantity = quantity
                    };

                    productList.Add(obj);
                }


            }
            catch
            {
                MessageBox.Show("data cannot be read try agaian connecting database");

            }
            closeConnestion();
          
        }

        public List<Product> GetProdList()
        {
            List<Product> temp = new List<Product>();
            ReadProductsDB();
            temp = productList;
            return temp;
        }




        public bool DelProduct(int ProductId) //deleting product from database
        {
            if (conn == null) return false;
            try
            {
                string query = $"DELETE FROM ProductTable WHERE pid='{ProductId}' ";
                SqlCommand cmd = new SqlCommand(query, conn);
                if (cmd.ExecuteNonQuery() >= 0)
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

        public bool UpdateProduct(int product,int quantity) //updating products in database
        {
            if (conn == null) return false;
            try
            {
                ReadProductsDB();
                conn.Open();
                foreach(Product x in productList)
                {
                    if (x.ProductQuantity <= 0)
                    {
                        DelProduct(x.ProductID);
                        return true;
                    }
                    if(x.ProductID==product && x.ProductQuantity >= quantity)
                    {
                        string query = $"update ProductTable set pquantity=pquantity-{quantity} where pid={product}";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        if (cmd.ExecuteNonQuery() > 0)
                        {

                            return true;

                        }

                    }
                }

              
            }
            

            catch
            {
                return false;
            }

            closeConnestion();
            return false;
        }

       
        public Product findProductById(int id)
        {
            Product temp = new Product();
            for (int i = 0; i < productList.Count; i++)
            {
                if (productList[i].ProductID == id)
                {
                    temp = productList[i];
                }
            }

            return temp;
        }

        public void closeConnestion() //closing connection
        {
            conn.Close();
        }



    }
}
