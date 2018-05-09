using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using static TryLinq.ListGenerators;
using System.IO;

namespace TryLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path = @"C:\\Users\\Mohamed Abdullah\\Documents\\Visual Studio 2017\\Projects\\LINQ\\LINQ_Day3Assignments\\Assignment Files\\";
            string MyDictionary = File.ReadAllText($"{ListGenerators.Path}\\dictionary_english.txt ", Encoding.UTF8);

            string[] MyDictionaryWords = MyDictionary.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);//370_099 words
            string shortString = MyDictionaryWords[0];
            string LongestString = MyDictionaryWords[0];


            #region Restriction Operators
            /* LINQ - Restriction Operators
                Use ListGenerators.cs & Customers.xml
               1.Find all products that are out of stock.
               */

             var Result_Restriction = ProductList.Where(r => r.UnitsInStock == 0);
            int Count = Result_Restriction.Count();

 
              foreach (var item in Result_Restriction)
            {


               // Console.WriteLine($"{item}");
            }
           for (int i = 0; i < Count; i++)
            {

               // Console.WriteLine($"{Result_Restriction.ElementAt(i)}");

            }


            /*
           2. Find all products that are in stock and cost more than 3.00 per unit.
           */
             var Result2_Restriction = ProductList.Where(x => x.UnitsInStock > 0 && x.UnitPrice < 3.00m);

            foreach (var item in Result2_Restriction)
            {


                // Console.WriteLine($"{item}");
            }
            /*
            3. Returns digits whose name is shorter than their value.
           string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            */
            int[] numbers_Restriction = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            string[] Arr_Restriction = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };



            var Result3_Restriction = //from d in Arr_Restriction
                                      from n in numbers_Restriction
                                      where Arr_Restriction[n].Length < n
                                      select Arr_Restriction[n];
            foreach (var item in Result3_Restriction)
            {
             // Console.WriteLine($"{item}{Environment.NewLine}");
            }

            #endregion

            #region  Element Operators
            /*
           LINQ - Element Operators

           Use ListGenerators.cs & Customers.xml
           1. Get first Product out of Stock 
           */

            var Result2_Element = (from p in ProductList
                            where p.UnitsInStock == 0
                           select p).First();
             //Console.WriteLine($"{Result2_Element.ProductName}::{Result2_Element.UnitsInStock}");
             
           
            /*
           2. Return the first product whose Price > 1000, unless there is no match, in which case null is returned.

            */

           var Result3_Element = ProductList.FirstOrDefault(m=>m.UnitPrice>1000);

            /*if (Result3_Element != null)
                Console.WriteLine($"{Result3_Element.ProductName}::{Result3_Element?.UnitsInStock}");
            else
                Console.WriteLine($"There is no Item it's Price>1000");
             


            /*
           3. Retrieve the second number greater than 5 
           int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };.
           */
             int[] Arr2_Element = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

             var Result4_Element = (from a in Arr2_Element
                                    where a>5
                           select a).ElementAtOrDefault(1);

             /*if (Result4_Element != 0)
                 Console.WriteLine($"the second number greater than 5 in 5,4, 1, 3, 9, 8, 6, 7, 2, 0  : {Result4_Element}");
             else
                 Console.WriteLine($"There is no Second Item > 5");*/
            #endregion

            #region Set Operators
            /*
           LINQ - Set Operators

           Use ListGenerators.cs & Customers.xml
           1. Find the unique Category names from Product List
           */
           
             var Result_Set = (from p in ProductList
                           select p.Category).Distinct();

             foreach (var item in Result_Set)
             {

                 //Console.WriteLine($"{item}");
             }
             /*
            2. Produce a Sequence containing the unique first letter from both product and customer names.
            */
            
              List<string> Result2Products = (from p in ProductList
                                              select p.ProductName.Substring(0, 1)).ToList();

              List<string> Result2Customers = (from c in CustomerList
                                              select c.CompanyName.Substring(0, 1)).ToList();

              var Try = (from p in ProductList
                        let TwoNames = p.ProductName.Substring(0, 1)
                        from c in CustomerList
                        let TwoNames2= c.CompanyName.Substring(0, 1)
                        select TwoNames+""+ TwoNames2).Distinct().ToList();


              var Try2 = (from p in ProductList
                         let TwoNames = p.ProductName
                         from c in CustomerList
                         let TwoNames2 = c.CompanyName
                         select "Product: "+TwoNames + "::: Company: " + TwoNames2).Distinct().ToList();

              var Result2_Set = Result2Products.Union(Result2Customers);//2


              //Console.WriteLine($"All First letters in one Sequence ");
              foreach (var item in Result2_Set)
              {

                  //Console.WriteLine($"{item}");
              }
             // Console.WriteLine($"All First letters in one Sequence (Try)");

              foreach (var item in Try)
              {

                  //Console.WriteLine($"{item}");
              }

             // Console.WriteLine($"All Names  in one Sequence (Try)");

              foreach (var item in Try2)
              {

                //  Console.WriteLine($"{item}");

              }
              /*
             3. Create one sequence that contains the common first letter from both product and customer names.
             */
          
            List<string> Result3Products = (from p in ProductList
                                            select p.ProductName.Substring(0, 1)).ToList();

            List<string> Result3Customers = (from c in CustomerList
                                             select c.CompanyName.Substring(0, 1)).ToList();
            var Result3_Set = Result3Products.Intersect(Result3Customers);//3


            foreach (var item in Result3_Set)
            {

               // Console.WriteLine($"{item}");

            }
            /*

             4. Create one sequence that contains the first letters of product names that are not also first letters of customer names.

              */

         
            List<string> Result4Products = (from p in ProductList
                                            select p.ProductName.Substring(0, 1)).ToList();

            List<string> Result4Customers = (from c in CustomerList
                                             select c.CompanyName.Substring(0, 1)).ToList();
            var Result4_Set = Result4Products.Except(Result4Customers);//4


            foreach (var item in Result4_Set)
            {

                //Console.WriteLine($"{item}");

            }
            /*
             5. Create one sequence that contains the last Three Characters in each names of all customers and products, including any duplicates
             */
            
           //List<string> Result5Products = (from p in ProductList
           //                                from pn in Array.Reverse(p.ProductName.ToCharArray())
           //                                let Name = pn.Substring(0, 3)
           //                                select Name
           //                       // let Name2=select Name.Substring(0, 3)
           //                       //select (string)Name
           //                       ).ToList();

           ////(System.Linq.Enumerable.<ReverseIterator>d__75<char>)ProductList[0].ProductName.Reverse()	{System.Linq.Enumerable.<ReverseIterator>d__75<char>}System.Collections.Generic.IEnumerable<char> 

           //List<string> Result5Customers = (from c in CustomerList
           //                                 let Name = (string)c.CompanyName
           //                                 select Name.Substring(0, 1)).ToList();

           var Result5Products = ProductList.Select(p => p.ProductName.Substring(p.ProductName.Length - 3, 3)).ToList();

           var Result5Customers = CustomerList.Select(c => c.CompanyName.Substring(c.CompanyName.Length - 3, 3)).ToList();


           var Result5_Set = Result5Products.Concat(Result5Customers);//5


           foreach (var item in Result5_Set)
           {

             //  Console.WriteLine($"{item}");

           }

           


            #endregion

            #region Aggregate Operators


            /*
            LINQ - Aggregate Operators
           1. Uses Count to get the number of odd numbers in the array
           */
            int[] Arr_Aggregate = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

              int Result_Aggregate = Arr_Aggregate.Count(x => x % 2 != 0);
              // Console.WriteLine($"{Result}");


              /*
             Use ListGenerators.cs & Customers.xml
             2. Return a list of customers and how many orders each has.
             */

             var Result2_Aggregate = from c in CustomerList
                            select new {ID= c.CustomerID,Name=c.CompanyName,CountOrders=c.Orders.Count()};

              foreach (var item in Result2_Aggregate)
              {

                 // Console.WriteLine($"{item}");

              }
              /*
             3. Return a list of categories and how many products each has
             */



            
            var Result3_Aggregate = from p in ProductList
                    group p by p.Category
                    into Groups
                    select new { Category = Groups.Key, NumOfProducts = Groups.Count() };


            foreach (var item in Result3_Aggregate)
            {

               Console.WriteLine($"{item}");

            }

            /*

           4. Get the total of the numbers in an array.
           int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
           */
            int[] Arr2_Aggregate = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
             int Result4_Aggregate = Arr2_Aggregate.Sum();
            // Console.WriteLine($"Sum of 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 {Result4}");//45

             /*
            5. Get the total number of characters of all words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            Use ListGenerators.cs & Customers.xml
            //https://code.msdn.microsoft.com/LINQ-Aggregate-Operators-c51b3869#SumSimple
            */



            //List<char> MyDictionaryChars = new List<char>();
            //for(int i = 0; i < MyDictionary.Length; i++)
            //{
            //    if(MyDictionary[i]!='\r' && MyDictionary[i]!='\n')
            //    MyDictionaryChars.Add(MyDictionary[i]);

            //}

            var Result5_Aggregate = MyDictionaryWords.Sum(c => c.Length);//Number of chars in all words


             //Console.WriteLine($"Number of chars in all words {Result5}");//3_494_678 chars

             var Result5_2_Aggregate = (from s in MyDictionaryWords
                             select new { s,Count=s.Count() }).ToList();
             /*
                     [0]	{ s = "a", Count = 1 }	<Anonymous Type>
                     [1]	{ s = "aa", Count = 2 }	<Anonymous Type>
                     [2]	{ s = "aaa", Count = 3 }	<Anonymous Type>
                     [3]	{ s = "aah", Count = 3 }	<Anonymous Type>

              */
           foreach (var item in Result5_2_Aggregate)
            {

                //Console.WriteLine($"{item}");

            }




            /*
            6. Get the total units in stock for each product category.
            */

           var Result6_Aggregate = from p in ProductList
                         group p by p.Category into Groups
                         select new {Category=Groups.Key, UnitOfStock = Groups.Sum(u=>u.UnitsInStock) };
             foreach (var item in Result6_Aggregate)
             {

                 //Console.WriteLine($"{item}");

             }

             /*
             7. Get the length of the shortest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
             */
            
            for (int i = 0; i < MyDictionaryWords.Length; i++) {

                if (shortString.Length > MyDictionaryWords[i].Length)
                    shortString = MyDictionaryWords[i];
                if (LongestString.Length < MyDictionaryWords[i].Length)
                    LongestString = MyDictionaryWords[i];

            }
            //Console.WriteLine($"shortString {shortString},,,Length=:{shortString.Length}");

            var Result7_Aggregate = MyDictionaryWords.Min(s => s.Length);
            //Console.WriteLine($"shortString {shortString},,,Length=:{Result7_Aggregate}");

            /*
            Use ListGenerators.cs & Customers.xml
            8. Get the cheapest price among each category's products
            */

        
                        var Result8_Aggregate = (from p in ProductList
                                      group p by p.Category into Groups
                                      select new { Category = Groups.Key, cheapeastPrice = Groups.Min(u => u.UnitPrice) }).ToList();

                        var Result8_1_Aggregate = (from p in ProductList
                                        group p by p.Category into Groups
                                        select new { Category = Groups.Key, Products = Groups.Select(p=>p.ProductName)}).ToList();

                        var Result8_2_Aggregate = (from p in ProductList
                                         group p by p.Category into Groups
                                         select new { Category = Groups.Key, CheapeastPrice = Groups.Min(u => u.UnitPrice), Product_That_Has_Cheapest_Price = Groups.SingleOrDefault(s => s.UnitPrice == Groups.Min(m=>m.UnitPrice)).ToString() }).ToList();

                        foreach (var item in Result8_2_Aggregate)
                        {

                          //  Console.WriteLine($"{item}{Environment.NewLine}");

                        }

          /*
           9. Get the products with the cheapest price in each category (Use Let)
           */
         
             var Result9_Aggregate = (from p in ProductList
                              group p by p.Category into Groups
                              let CheapeastPriceVar= Groups.Min(u => u.UnitPrice)
                            select new { Category = Groups.Key, CheapeastPriceVar, Product_That_Has_Cheapest_Price = Groups.SingleOrDefault(s => s.UnitPrice == CheapeastPriceVar) }).ToList();

             foreach (var item in Result9_Aggregate)
             {

               //  Console.WriteLine($"{item}{Environment.NewLine}");

             }
            /*
            10. Get the length of the longest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            */
           
            var Result10_Aggregate = MyDictionaryWords.Max(s => s.Length);
            //Console.WriteLine($"LongestString: {LongestString},,,Length=:{Result10_Aggregate}");

            /*
            Use ListGenerators.cs & Customers.xml
            11. Get the most expensive price among each category's products.
            12. Get the products with the most expensive price in each category.

            */

            var Result11_12_Aggregate = (from p in ProductList
                              group p by p.Category into Groups
                              select new { Category = Groups.Key, TheMostExpensivePrice = Groups.Max(u => u.UnitPrice), Product_That_Has_TheMostExpensive_Price = Groups.SingleOrDefault(s => s.UnitPrice == Groups.Max(m => m.UnitPrice)).ToString() }).ToList();

             foreach (var item in Result11_12_Aggregate)
             {

                //Console.WriteLine($"{item}{Environment.NewLine}");

             }
             /*
             13. Get the average length of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
             */
           
            var Result13_Aggregate = MyDictionaryWords.Average(s => s.Length);
           // Console.WriteLine($"AverageLength:{Result13_Aggregate}");

            /*
            14. Get the average price of each category's products.
            */

            var Result14_Aggregate = (from p in ProductList
                                   group p by p.Category into Groups
                                   select new { Category = Groups.Key, AveragePrice = Groups.Average(u => u.UnitPrice) }).ToList();//, Product_That_Has_Average_Price = Groups.Where(s => s.UnitPrice == Groups.Average(m => m.UnitPrice)).ToString() }).ToList();

                   foreach (var item in Result14_Aggregate)
                   {

                      // Console.WriteLine($"{item}{Environment.NewLine}");

                   }
                   /*
                    */
            #endregion

            #region Ordering Operators

            /*
            LINQ - Ordering Operators

            Use ListGenerators.cs & Customers.xml
           1.Sort a list of products by name
           */

               var Result_Ordering = ProductList.OrderBy(p => p.ProductName).Select(p=>new { p.ProductName });
                foreach (var item in Result_Ordering)
            {

                   // Console.WriteLine($"{item}{Environment.NewLine}");

                }
                /*
               2.Uses a custom comparer to do a case-insensitive sort of the words in an array.
               string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
               */
            string[] Arr_Ordering = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

              var Result2_Ordering = Arr_Ordering.OrderBy(s => s, new StringComparer());//Compare using StringComparer
              foreach (var item in Result2_Ordering)
            {

                  //Console.WriteLine($"{item}{Environment.NewLine}");

              }
              /*
              Use ListGenerators.cs & Customers.xml
             3.Sort a list of products by units in stock from highest to lowest.
             */
            var Result3_Ordering = from p in ProductList
                           orderby p.UnitsInStock descending
                           select new { p.ProductName, p.UnitsInStock };
             foreach (var item in Result3_Ordering)
            {

               // Console.WriteLine($"{item}{Environment.NewLine}");

             }

             /*
            4.Sort a list of digits, first by length of their name, and then alphabetically by the name itself.
            */
            string[] Arr2_Ordering = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

              var Result4_Ordering = Arr2_Ordering.OrderBy(s => s.Length).ThenBy(s => s);
              foreach (var item in Result4_Ordering)
            {

               //  Console.WriteLine($"{item}{Environment.NewLine}");

              }
              /*
              5.Sort first by word length and then by a case-insensitive sort of the words in an array.
             string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
             */
           
             var Result5_Ordering = Arr_Ordering.OrderByDescending(s => s.Length).ThenBy(s=>s, new StringComparer());//Compare using StringComparer
             foreach (var item in Result5_Ordering)
            {

               //  Console.WriteLine($"{item}{Environment.NewLine}");

             }
             /*
             Use ListGenerators.cs & Customers.xml
            6.Sort a list of products, first by category, and then by unit price, from highest to lowest.
            */
            var Result6_Ordering = from p in ProductList
                           orderby p.Category ,p.UnitPrice descending
                           select new { p.ProductName, p.UnitPrice };
             foreach (var item in Result6_Ordering)
            {

              //Console.WriteLine($"{item}{Environment.NewLine}");

             }

             /*
            7.Sort first by word length and then by a case-insensitive descending sort of the words in an array.
            string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            */
            var Result7_Ordering = from s in Arr_Ordering
                                   orderby s.Length, new StringComparer() descending
                           select new { s };

             var Result7_1_Ordering = Arr_Ordering.OrderBy(s => s.Length).ThenByDescending(s => s, new StringComparer());
             foreach (var item in Result7_1_Ordering)
            {

                // Console.WriteLine($"{item}{Environment.NewLine}");

             }

             /*
             8.Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.
            string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

             */
           string[] Arr3_Ordering = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

             var Result8_Ordering = from s in Arr3_Ordering
                                    orderby s.Length
                           select s;

             var Result8_1_Ordering = (from s in Arr3_Ordering
                                       where s[1] == 'i'
                              orderby s
                              select s).Reverse(); //.Reverse() here ==OrderByDescending()
             foreach (var item in Result8_1_Ordering)
            {

               // Console.WriteLine($"{item}{Environment.NewLine}");

             }


             /*
            */
            #endregion

            #region  Partitioning Operators

            /*LINQ - Partitioning Operators

           Use ListGenerators.cs & Customers.xml
           1.Get the first 3 orders from customers in Washington
           */

            // var Result = CustomerList.Where(c => c.Region == "Washington").Take(3).Select(c => new { c.CustomerID, c.Region });

            var Result_Partitioning = (from c in CustomerList
                          from order in c.Orders
                          where c.Region == "WA"
                          select new { c.CustomerID, c.CompanyName, order.OrderID, order.OrderDate }).Take(3);

            foreach (var item in Result_Partitioning)
            {
              //Console.WriteLine($"{item}{Environment.NewLine}");

            }
            /*
           2.Get all but the first 2 orders from customers in Washington.

            */

            //var Result2 = CustomerList.Where(c => c.City == "México D.F.").Skip(2).Select(c => new { c.CustomerID, c.CompanyName, c.City });
            var Result2_Partitioning = (from c in CustomerList
                           from o in c.Orders
                           where c.Region == "WA"
                           select new { c.CompanyName, o.OrderID, o.OrderDate }).Skip(2);
            foreach (var item in Result2_Partitioning)
            {
              //Console.WriteLine($"{item}{Environment.NewLine}");

            }
            /*
           3.Return elements starting from the beginning of the array until a number is hit that is less than its position in the array.
             int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            */
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var Result3_Partitioning = numbers.TakeWhile((n,indexer) => n >=indexer);//take all the elements that make this condition (n >=indexer) =>True then stop if the condition become false and return pervious elements

            foreach (var item in Result3_Partitioning)
            {
              // Console.WriteLine($"{item}{Environment.NewLine}");

            }
            /*
            4.Get the elements of the array starting from the first element divisible by 3.
           int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
           */
            int[] numbers2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var Result4_Partitioning = numbers2.SkipWhile(n => n % 3!= 0);//Skip all elements that make this Condition (n % 3!= 0) =>True then Stop if the condition become false and get next elements
            foreach (var item in Result4_Partitioning)
            {
             //   Console.WriteLine($"{item}{Environment.NewLine}");

            }
            /*
            5.Get the elements of the array starting from the first element less than its position.
           int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
           
             */
            int[] numbers3 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var Result5_Partitioning = numbers3.SkipWhile((n,index) => n >= index );
            foreach (var item in Result5_Partitioning)
            {
               //    Console.WriteLine($"{item}{Environment.NewLine}");

            }
            /**/

            #endregion

            #region Projection Operators

            /*

         LINQ - Projection Operators

         Use ListGenerators.cs & Customers.xml
         1. Return a sequence of just the names of a list of products.
         */

            var Result_Projection = from p in ProductList
                                    select new { p.ProductName };
            foreach (var item in Result_Projection)
            {
              //Console.WriteLine($"{item}{Environment.NewLine}");

            }

            /*
            2. Produce a sequence of the uppercase and lowercase versions of each word in the original array (Anonymous Types).
              string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };

            */
            string[] words_Projection = { "aPPLE", "BlUeBeRrY", "cHeRry" };

            var Result2_Projection = from w in words_Projection
                                     select new { Upper = w.ToUpper(), Lower = w.ToLower() };
            foreach (var item in Result2_Projection)
            {
                //Console.WriteLine($"Word={item}{Environment.NewLine}");

            }
            /* 

            Use ListGenerators.cs & Customers.xml
            3. Produce a sequence containing some properties of Products, including UnitPrice which is renamed to Price in the resulting type.
            */
            var Result3_Projection = from p in ProductList
                                    orderby p.UnitPrice 
                                    select new { p.ProductName ,Price=p.UnitPrice,Stock=p.UnitsInStock};
            foreach (var item in Result3_Projection)
            {
              // Console.WriteLine($"{item}{Environment.NewLine}");

            }
            /*
            4. Determine if the value of ints in an array match their position in the array.
                int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
                */
            int[] Arr_Projection = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var Result4_Projection = Arr_Projection.Select((i, indexer) => new { Num = i, Result = i == indexer });
            foreach (var item in Result4_Projection)
            {
              // Console.WriteLine($"{item}{Environment.NewLine}");

            }
            /*
            Result
            Number: In-place?
            5: False
            4: False
            1: False
            3: True
            9: False
            8: False
            6: True
            7: True
            2: False
            0: False
            
            
            
            5. Returns all pairs of numbers from both arrays such that the number from numbersA is less than the number from numbersB.
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };
            */

            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };
            var Result5_Projection = from a in numbersA
                                     from b in numbersB
                                     where a < b
                                     select  new { Num=a + " is less than "+ b }; 
            foreach (var item in Result5_Projection)
            {
              //  Console.WriteLine($"{item}{Environment.NewLine}");

            }
            /*
            Result
            Pairs where a < b:
            0 is less than 1
            0 is less than 3
            0 is less than 5
            0 is less than 7
            0 is less than 8
            2 is less than 3
            2 is less than 5
            2 is less than 7
            2 is less than 8
            4 is less than 5
            4 is less than 7
            4 is less than 8
            5 is less than 7
            5 is less than 8
            6 is less than 7
            6 is less than 8

            Use ListGenerators.cs & Customers.xml
            6. Select all orders where the order total is less than 500.00.
            */

            var Result6_Projection = (from c in CustomerList
                                       from order in c.Orders
                                       where order.Total < 500.00m
                                       orderby order.Total
                                       select new {  order.OrderID, order.OrderDate,order.Total });

            foreach (var item in Result6_Projection)
            {
            //   Console.WriteLine($"{item}{Environment.NewLine}");

            }
            /*
            7. Select all orders where the order was made in 1998 or later.
            */
            var Result7_Projection = (from c in CustomerList
                                      from order in c.Orders
                                      where order.OrderDate.Year <= 1998
                                      orderby order.OrderDate
                                      select new {  order.OrderID, order.OrderDate,order.Total });

            foreach (var item in Result7_Projection)
            {
                //Console.WriteLine($"{item}{Environment.NewLine}");

            }
            /*
            */
            #endregion

            #region Quantifiers

            /* LINQ - Quantifiers

             1. Determine if any of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First) contain the substring 'ei'.

           */
            bool Result_Quantifiers = MyDictionaryWords.Any(s => s.Contains("ei"));
            string Result_Quantifiers_2="";

            if (Result_Quantifiers)
                Result_Quantifiers_2 = MyDictionaryWords.First(s => s.Contains("ei"));

            // Console.WriteLine($"Result_Quantifiers:{Result_Quantifiers},,,Word is :{Result_Quantifiers_2}{Environment.NewLine}");

            //foreach (var item in Result_Partitioning)
            //{
            //   Console.WriteLine($"{item}{Environment.NewLine}");

            //}

            /*
              Use ListGenerators.cs & Customers.xml
              2. Return a grouped a list of products only for categories that have at least one product that is out of stock.
              */


            var Result2_Quantifiers =( from p in ProductList
                                      group p by p.Category into Categories
                                      where Categories.Any(pr => pr.UnitsInStock == 0) == true
                                       select new { Categories.Key, Products = Categories }).ToList();//new{Categories.Key,,Products = Categories}

            foreach (var item in Result2_Quantifiers)
            {
               /* Console.WriteLine($"Category:{item.Key}{Environment.NewLine}Products:{Environment.NewLine}");
                foreach (var pr in item.Products)
                {
                    Console.WriteLine($"ProductName:{pr.ProductName},,UnitsInStock:{pr.UnitsInStock}{Environment.NewLine}");

                }*/

            }

            /*
              3. Return a grouped a list of products only for categories that have all of their products in stock.

             */
            var Result3_Quantifiers = (from p in ProductList
                                       group p by p.Category into Categories
                                       where Categories.All(pr => pr.UnitsInStock >= 0) == true
                                       select new { Categories.Key, Products = Categories}).ToList();//new{Categories.Key,,Products = Categories}

            foreach (var item in Result3_Quantifiers)
            {
               /*Console.WriteLine($"Category:{item.Key}{Environment.NewLine}Products:{Environment.NewLine}");
                foreach (var pr in item.Products)
                {
                    Console.WriteLine($"ProductName:{pr.ProductName},,UnitsInStock:{pr.UnitsInStock}{Environment.NewLine}");

                }*/

            }
            #endregion

            #region Grouping Operators

            /*
             LINQ - Grouping Operators
             https://code.msdn.microsoft.com/LINQ-to-DataSets-Grouping-c62703ea
             1. Use group by to partition a list of numbers by their remainder when divided by 5
             */
            List<int> Arr_Grouping = new List<int>();
            for (int i = 0; i < 20; i++) {

                Arr_Grouping.Add(i);

            }
            var Result_Grouping=from n in Arr_Grouping
                                group n by n%5 into NArr
                                select new { Remainder=NArr.Key,Numbers=NArr };

            foreach (var item in Result_Grouping)
            {
               // Console.WriteLine($"Numbers with a remainder of {item.Remainder} when divided by 5:{Environment.NewLine}");
                foreach (var number in item.Numbers)
                {
                 // Console.WriteLine($"{number}{Environment.NewLine}");

                }

            }

            /*
             Output: 
             Numbers with a remainder of 0 when divided by 5:
             0
             5
             10
             Numbers with a remainder of 1 when divided by 5:
             1
             6
             11
             Numbers with a remainder of 2 when divided by 5:
             7
             2
             12
             Numbers with a remainder of 3 when divided by 5:
             3
             8
             13
             Numbers with a remainder of 4 when divided by 5:
             4
             9
             14

             2. Uses group by to partition a list of words by their first letter.
             Use dictionary_english.txt for Input

            */

            string[] words = { "blueberry", "chimpanzee", "abacus", "banana", "apple", "cheese" };

            var Result2_Grouping = from s in words //MyDictionaryWords
                                   group s by s[0] into SArr
                                   select new {FirstLetter= SArr.Key,Words= SArr };//,Words= MyDictionaryWords.Where(s=>s.StartsWith(s)};


            foreach (var item in Result2_Grouping)
            {
               // Console.WriteLine($"Words That Start with:{item.FirstLetter} are:");
                foreach (var Word in item.Words)
                {
                  //  Console.WriteLine($"{Word}");

                }
               // Console.WriteLine($"{Environment.NewLine}");
            }
            /*
             Result

                        Words that start with the letter 'b':
                        blueberry
                        banana
                        Words that start with the letter 'c':
                        chimpanzee
                        cheese
                        Words that start with the letter 'a':
                        abacus
                        apple
             */

            /*
             3. Consider this Array as an Input 
             string[] Arr = { "from   ", " salt", " earn ", "  last   ", " near ", " form  " };

             Use Group By with a custom comparer that matches words that are consists of the same Characters Together

            */
            string[] Arr2_Grouping = { "from   ", " salt", " earn ", "  last   ", " near ", " form  " };
           

            var Result3_Grouping = Arr2_Grouping.GroupBy(s => s.Trim(), new GroupStringEquality());
            /*
            1.Trim
            2.Add to the Array and Calculate GetHashCode
            3.Compare it with pervious elements of the array(not all of them)?
            4.If two Elements equal to each other add them two one group(it's key is first element)
            */
            foreach (var item in Result3_Grouping)
            {
               // Console.WriteLine($"Key:{item.Key}:");
                foreach (var w in item)

                {
                  //  Console.WriteLine($"{w}:");

                }
            }
            /*
             Result
             ...
             from 
             form 
             ...
             salt
             last 
             ...
             earn 
             near



              */


            #endregion








        }


    }

    //For Ordering Operators
    public class StringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return string.Compare(x, y, StringComparison.OrdinalIgnoreCase);// true=>Ignore Case
        }
 
    }
    public class StringComparable : IComparable<string>
    {
        

        public int CompareTo(string other)
        {
            return this.CompareTo(other);
        }
    }


    //For Grouping
    public class GroupStringEquality : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            char[] xArr = x.ToCharArray();
            char[] yArr = y.ToCharArray();
            Array.Sort<char>(xArr);
            Array.Sort<char>(yArr);
            string Cx = new string(xArr);
            string Cy = new string(yArr);
            return Cx.Equals(Cy);
        }

        public int GetHashCode(string obj)
        {
            return obj.Length * 157 * 257 % int.MaxValue;
        }
    }



}
