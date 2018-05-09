using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static TryLinq.ListGenerators;

namespace TryLinq
{
    class Lec_Code
    {
        static void Main2(string[] args)
        {
            String[] NameList = { "Ahmed", "Samier", "Ali", "Peter", "Salma", "Zaynab" };
            List<Product> PromotedProducts = new List<Product>();


            #region Anonymous Type
            //var X = 15.3;

            //Console.WriteLine(X.GetType());

            //Point3D P1 = new Point3D { X = 10, Y = 20, Z = 30 };

            //var P2 = new Point3D { X = 40, Y = 50, Z = 60 };

            //var Emp01 = new { ID = 101, Name = "Ahmed", Salary = 5000 };
            //var Emp02 = new { ID = 201, Name = "Samier", Salary = 2500 };
            //var Emp03 = new {  Name = "Samier", Salary = 2500 , ID = 201 };
            //var Emp04 = new { ID = 101, Name = "Ahmed", Salary = 5000 };


            ////Emp01.ID = 50;//Read Only
            //Console.WriteLine(Emp01.Name);

            //Console.WriteLine(Emp01.GetType().Name);

            //if ( Emp01.GetType() == Emp02.GetType())
            //    Console.WriteLine("Same Type");
            //else
            //    Console.WriteLine("Diff Types");

            //if (Emp01.GetType() == Emp03.GetType())
            //    Console.WriteLine("Same Type");
            //else
            //    Console.WriteLine("Diff Types");


            //if (Emp01.Equals (Emp04))
            //    Console.WriteLine("Value Equality");
            //else
            //    Console.WriteLine("Identity Equality");


            //Console.WriteLine(Emp01); 
            #endregion

            #region Extention Method

            //int X = 12345;

            //Console.WriteLine(
            //    //Int32AdditionalFunctions.Mirror(X)
            //    X.Mirror()
            //    );

            //List<int> lst = new List<int>();

            #endregion

            #region Query Expression VS Fluent Syntax
            // ///Fluent Syntax
            // var Result = Enumerable.Where(ProductList, p => p.UnitsInStock == 0);

            // Result = ProductList.Where(P => P.UnitsInStock == 0);
            // if (true)
            //     Result = Result.OrderBy(p => p.UnitPrice);

            // var Result2 = ProductList.Where(P => P.UnitsInStock == 0).OrderBy(P => P.UnitPrice);


            // List<Product> prdList = ProductList.Where(P => P.UnitsInStock == 0).ToList<Product>();
            ////.ToList() LINQ Casting Operator


            // Console.WriteLine(Result2.GetType().Name);//OrderedEnumerable`2

            ///Query Expression
            ///12 Query Operator Only

            //var Result = from P in ProductList //P Range Variable : Represinting Each and Every Element in Sequence
            //             where P.UnitsInStock == 0
            //             orderby P.UnitPrice
            //             select P;

            ///Mixed
            //List<Product> Result = (from P in ProductList //P Range Variable : Represinting Each and Every Element in Sequence
            //                        where P.UnitsInStock == 0
            //                        orderby P.UnitPrice
            //                        select P).ToList();

            #endregion

            #region Deffered Excution
            // List<int> lst = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // // Defered Excution
            // IEnumerable<int> Result = lst.Where(i => i % 2 == 0);//Result Now =>Count=0

            // // imidate Excution
            //  var Result2 = lst.Where(i => i % 2 == 0).ToList();//Result2 Now=>Count=4


            // lst.Remove(1);
            // lst.Remove(2);
            // lst.Remove(3);
            // lst.Remove(4);

            //Result= Result.ToList();//Now Compiler will run Where Operator //Count=2
            // lst.AddRange(new int[] { 10, 11, 12, 13, 14, 15, 16 });
            #endregion


            #region Transformation 

            //var Result = from P in ProductList
            //             where P.UnitsInStock == 0
            //             select new { Name = P.ProductName, P.UnitPrice };
            ////select P;

            //var Result2 = NameList.Select(N => N.Substring(0, 3).ToUpper());


            //// Select Many
            //// Multiple From
            //// Transform Each Element in Input Seq To Sub Sequence
            var Result3 = (from Name in NameList
                           from Ch in Name.ToCharArray()
                           select Ch).Distinct();//.ToList();

            //Result3 = NameList.SelectMany(Name => Name.ToCharArray()).Distinct();


            //// Indexed Select
            //// Must be Fluent Syntax
            //var Result4 = ProductList.Select((P, I) => new { Index = I, Name = P.ProductName });
            //Result4 = Result4.ToList();


            #endregion

            #region Filteration

            //var Result = from c in CustomerList
            //             where c.Orders.Count() > 5
            //             select new { c.CompanyName, Count = c.Orders.Count() };

            ///Indexed Where Only Fluent Syntax

            var Result5 = CustomerList.Where((C, i) => i % 2 == 1);
            //Result5 = Result5.ToList();
            #endregion

            #region Ordering Operators

            //var Result = from P in ProductList
            //             orderby P.UnitPrice
            //             select P;

            //var Result = from P in ProductList
            //             orderby P.UnitPrice , P.UnitsInStock descending
            //             select P;


            //var Result = ProductList.OrderBy(P => P.UnitPrice)
            //    .ThenByDescending(P => P.UnitsInStock);


            #endregion

            #region Natural Ordering Operators
            //var Result = ProductList.Take(10);
            /////First 10 Elements in Input Sequence

            //Result = ProductList.Skip(10);
            ////Skip First 10 Elements in Input Sequence , Rest of Elements Go To Output Sequence

            //Result = ProductList.TakeWhile(P => P.UnitsInStock > 0);
            /////Redirect Elements to Output Sequence as long as Condition = True , Abort First Element return False
            /////

            //Result = ProductList.SkipWhile(P => P.UnitsInStock > 0).Reverse();
            /////Skip elements Till First Element return false;



            #endregion

            #region Element Operators


            //var Result2 = ProductList.First();

            ////Result2 = ProductList.Last();

            ////Result2 = ProductList.First(P => P.UnitsInStock == 0);

            ////Result2 = ProductList.Last(P => P.UnitsInStock == 0);

            ////Result2 = ProductList.First(P => P.UnitPrice > 5000);

            ////Result2 = ProductList.Last(P => P.UnitPrice > 5000);

            ////Result2 = PromotedProducts.First();

            ////Result2 = PromotedProducts.Last();

            //Result2 = ProductList.FirstOrDefault(P => P.UnitPrice > 5000);
            /////if no Element Match Predicate , return null , will not Throw Exception
            //Result2 = ProductList.LastOrDefault(P => P.UnitPrice > 5000);

            //Result2 = PromotedProducts.FirstOrDefault();

            //Result2 = PromotedProducts.LastOrDefault();

            //Result2 = ProductList.ElementAt(5);

            //Result2 = ProductList.ElementAtOrDefault(100);

            ////Result2 = ProductList.Single();
            /////return the one and only one element in this Sequence 
            /////Or Throw Exception if Many Elements exists in this Sequnce


            ////Result2 = ProductList.Single(P => P.UnitsInStock >= 125);

            ////Result2 = ProductList.SingleOrDefault();
            ////Result2 = ProductList.SingleOrDefault(P=> P.UnitPrice >100);

            ////Result2 = PromotedProducts.Single(); //Throw Exception

            //Result2 = PromotedProducts.SingleOrDefault(); //Throw Exception

            //Result2 = ProductList.SingleOrDefault(P => P.UnitsInStock > 200);
            /////return One Element 
            /////Throw exception if Input sequence have more than one Element
            /////return null if Input Sequnce is Empty



            //Console.WriteLine(Result2?.ToString()??"Not Found");
            #endregion

            #region Aggregation Operators

            //var Result3 = ProductList.Count();

            //Result3 = ProductList.Count(P => P.UnitsInStock > 0);


            ////Console.WriteLine(ProductList.Sum(P=>P.UnitsInStock));

            ////Console.WriteLine(ProductList.Average(P=>P.UnitsInStock));


            ////Console.WriteLine(ProductList.Min());
            ////Console.WriteLine(ProductList.Max());

            //Console.WriteLine(ProductList.Max(P=>P.UnitsInStock));
            //Console.WriteLine(ProductList.Min(P => P.UnitsInStock));


            //Console.WriteLine(Result3);


            #endregion

            #region Generation Operators

            //IEnumerable<int> Lst = Enumerable.Range(0, 100);

            //IEnumerable<Order> Result = Enumerable.Empty<Order>();

            //var Result2 = Enumerable.Repeat(ProductList.First(), 10);

            //ProductList.First().UnitPrice = 100;

            #endregion

            #region Set Operators
            //var PrdLst01 = ProductList.Take(50);
            //var PrdLst02 = ProductList.Skip(27);

            //          List<int> Lst01 = Enumerable.Range(0, 100).ToList();
            //            List<int> Lst02 = Enumerable.Range(50, 100).ToList();
            //Console.WriteLine(
            //    Lst01.SequenceEqual(Lst02)

            //    );

            //var Result = Lst01.Intersect(Lst02);

            //var Result = PrdLst01.Intersect(PrdLst02);


            //var Result = Lst01.Union(Lst02);
            ////Remove Duplicates

            //Result = Lst01.Concat(Lst02);
            /////Allow Duplicates 

            //Result = Lst01.Concat(Lst02).Distinct();

            //Result = Lst01.Except(Lst02);


            //List<int> NumLst = new List<int>() { 1, 2, 3, 4, 5, 6,7,8 };

            //var Result = NumLst.Zip(NameList, (i, S) => new { Index = i, Name = S });

            //Sequence Equal operator?
            #endregion


            #region Into , Let (Introducing New Range Variable

            //var Result = from name in NameList
            //             select Regex.Replace(name.ToLower(), "[aoieu]", "");

            //Result = Result.Where(X => X.Length >= 3);

            //var Result = from name in NameList
            //             select Regex.Replace(name.ToLower(), "[aoieu]", "")
            //             into NoVolName     //Introduce New Range Variable, Restarting for Query
            //             ///After Into Old Range Variable is Not Accesable
            //             where NoVolName.Length >=3 
            //             orderby NoVolName.Length descending
            //             select NoVolName;


            //var Result = from name in NameList
            //             let NoVolName = Regex.Replace(name.ToLower(), "[aoieu]", "")
            //             ///Introduce New Range Variable , Both new and Old Range Variable
            //             ///Are Accessable after let
            //             where NoVolName.Length >= 3
            //             orderby NoVolName.Length, name.Length descending
            //             select new { Original = name, NoVolName };



            #endregion


            #region Quantifiers Operators

            Console.WriteLine(
             //   //ProductList.Any(P=> P.UnitsInStock==0)
             //   //ProductList.Any() //return True if this Sequence contains al least one element
             //   //PromotedProducts.Any() 
              //ProductList.All(P => P.UnitsInStock > 0)
             //   ///return true if All elements in Input Sequence Match Predicate
             //   ProductList.Contains(new Product() { ProductID = 1 }, new ProductComparer())
             );



            #endregion


            #region GroupBy

            foreach (var item in ProductList.Select(P => P.Category).Distinct())
            {
                Console.WriteLine(item);//item=Category
            }


            var Result = from P in ProductList
                         group P by P.Category
                         into PrdGroups
                         select new { PrdGroups.Key, Count = PrdGroups.Count() };


            #endregion


            foreach (var item in Result)
            {
                Console.WriteLine(item);
                //Console.Write($"{item} , ");
            }

            foreach (var item in Result)
            {
                // Console.WriteLine(item);
            }


            //foreach (var item in ProductList.OrderByDescending(P=> P.UnitsInStock))
            //{
            //    Console.WriteLine(item);
            //}
        }
    }
}
