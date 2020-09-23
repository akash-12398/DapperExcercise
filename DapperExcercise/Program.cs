﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using DapperInClass;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace DapperExcercise
{
    class Program
    {
        public static IDbConnection conn;

        static void Main(string[] args)


        {
            var config = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();


            string connStri = config.GetConnectionString("DefaultConnection");

            conn = new MySqlConnection(connStri);
            ListProducts();

                DeleteProduct();

                ListProducts();
                


        }
            public static void DeleteProduct()

            {

                var prodRepo = new ProductRepository(conn);

                Console.WriteLine($"Please enter the productID of the product you would like to delete:");
                var productID = Convert.ToInt32(Console.ReadLine());

                prodRepo.DeleteProduct(productID);



            }

            public static void UpdateProductName()

            {

                var prodRepo = new ProductRepository(conn);

                Console.WriteLine($"What is the productID of the product you would like to update?");
                var productID = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"What is the new name you would like for the product with an id of {productID}?");
                var updatedName = Console.ReadLine();

                prodRepo.UpdateProductName(productID, updatedName);


            }

            public static void CreateAndListProducts()
            {

                var prodRepo = new ProductRepository(conn);

                Console.WriteLine($"What is the new product name?");
                var prodName = Console.ReadLine();

                Console.WriteLine($"What is the new product's price?");
                var price = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine($"What is the new product's category id?");
                var categoryID = Convert.ToInt32(Console.ReadLine());

                prodRepo.CreateProduct(prodName, price, categoryID);

               var products = prodRepo.GetAllProducts();

             
                 foreach (var product in products)
            {
                   Console.WriteLine($"{product.ProductID} {product.Name}");
            }



            }

                

            public static void ListProducts()
            {
               

                var prodRepo = new ProductRepository(conn);
                var products = prodRepo.GetAllProducts();

                //print each product from the products collection to the console
                foreach (var product in products)
                {
                    Console.WriteLine($"{product.ProductID} {product.Name}");
                }



            }


            public static void ListDepartments()
            {

                var repo = new DapperDepartmentRepository(conn);

                var departments = repo.GetAllDepartments();

               
                foreach (var item in departments)
                {
                    Console.WriteLine($"{item.DepartmentID} {item.name}");
                }



            }
            public static void DepartmentUpdate()
            {
                var repo = new DapperDepartmentRepository(conn);

                Console.WriteLine($"Would you like to update a department? yes or no");

                if (Console.ReadLine().ToUpper() == "YES")
                {
                    Console.WriteLine($"What is the ID of the Department you would like to update?");

                    var id = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine($"What would you like to change the name of the department to?");

                    var newName = Console.ReadLine();

                    repo.UpdateDepartment(id, newName);

                     var depts = repo.GetAllDepartments();

                    foreach (var item in depts)
                    {
                        Console.WriteLine($"{item.DepartmentID} {item.name}");
                    }




                }


            }







           
           
        
    }
}
