using DatabasefirstApproach.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DatabasefirstApproach
{
    class Program
    {
        pubsContext pubs;
        public string Au_id;
        public Program()
        {
            pubs = new pubsContext();
        }
        void GetAuthor()
        {
            while (true)
            {
                Console.WriteLine("Enter 'P' to get data \n'E' to Exit");
                string cha = Console.ReadLine();
                if (cha == "P")
                {
                    Console.WriteLine("Enter the first name of Author");
                    string fname = Console.ReadLine();
                    Console.WriteLine("Enter the last name of Author");
                    string lname = Console.ReadLine();
                    var au_id = (from a in pubs.Authors join au in pubs.Titleauthors on a.AuId equals au.AuId join Tt in pubs.Titles on au.TitleId equals Tt.TitleId where a.AuFname == fname && a.AuLname == lname select Tt.Title1).ToList();
                    if (au_id.Count == 0)
                        Console.WriteLine("Authors Not Yet Published");
                    else
                    {
                        foreach (var item in au_id)
                        {
                            Console.WriteLine(item);
                        }
                    }
                }
                else if (cha == "E")
                    break;
                else
                    Console.WriteLine("Enter Valid Value");
            }
            
        }
        void GetSales()
        {
            while (true)
            {
                Console.WriteLine("Enter 'P' to get data \n'E' to Exit");
                string cha = Console.ReadLine();
                if (cha == "P")
                {
                    Console.WriteLine("Enter the Title Id");
                    string Id = Console.ReadLine();
                    var books = (from t in pubs.Titles
                                 join s in pubs.Sales on t.TitleId equals s.TitleId
                                 where t.TitleId == Id
                                 select new
                                 {
                                     stor_id = s.StorId,
                                     ord_num = s.OrdNum,
                                     ord_date = s.OrdDate,
                                     quantity = s.Qty,
                                     payterms = s.Payterms

                                 });
                    if (books.Any())
                    {
                        foreach (var item in books)
                        {
                            Console.WriteLine("stor_id "+item.stor_id);
                            Console.WriteLine("Order number" + item.ord_num);
                            Console.WriteLine("Order Date" + item.ord_date);
                            Console.WriteLine("Quantity" + item.quantity);
                        }
                         
                    }
                    else
                    {
                        Console.WriteLine("No such Title present");
                    }
                }
                else if (cha == "E")
                {
                    break;
                }
                else
                    Console.WriteLine("Enter Valid Value");
            }
            }
        static void Main(string[] args)
        {
           new Program().GetAuthor();
            new Program().GetSales();
           
        }
    }
}
