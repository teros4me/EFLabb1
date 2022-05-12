using EFlabb1.Models;
using System;

namespace EFlabb1
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();

            //PopulateEmployees();

            Console.WriteLine("Welcome! Who are you?");
            Console.WriteLine("1: Worker\n2: Admin");

            string who = Console.ReadLine();

            if (who == "1")
            {
                Console.WriteLine("[Worker] what do you want to create?\n1: Vacation\n2: CareOfChildren\n3: Parental leave");
                string chooseLeave = Console.ReadLine();
                if (chooseLeave == "1")
                {
                    Console.WriteLine("Write your id");
                    int empId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Vacation:\nChoose start date (yyyy-mm-dd)");
                    DateTime startDate = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Choose end date (yyyy-mm-dd)");
                    DateTime endDate = Convert.ToDateTime(Console.ReadLine());

                        LeaveApplication newApplication = new LeaveApplication()
                        {
                            EmployeeId = empId,
                            Type = "Vacation",
                            StartDate = startDate,
                            EndDate = endDate,
                            CreationDate = DateTime.Now
                        };
                        context.Add(newApplication);
                        context.SaveChanges();
                }
                else if (chooseLeave == "2")
                {
                    Console.WriteLine("Write your id");
                    int empId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("CareOfChildren:\nChoose start date (yyyy-mm-dd)");
                    DateTime startDate = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Choose end date (yyyy-mm-dd)");
                    DateTime endDate = Convert.ToDateTime(Console.ReadLine());

                        LeaveApplication newApplication = new LeaveApplication()
                        {
                            EmployeeId = empId,
                            Type = "CareOfChildren",
                            StartDate = startDate,
                            EndDate = endDate,
                            CreationDate = DateTime.Now
                        };
                        context.Add(newApplication);
                        context.SaveChanges();
                }
                else if (chooseLeave == "3")
                {
                    Console.WriteLine("Write your id");
                    int empId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Parental leave:\nChoose start date (yyyy-mm-dd)");
                    DateTime startDate = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Choose end date (yyyy-mm-dd)");
                    DateTime endDate = Convert.ToDateTime(Console.ReadLine());

                        LeaveApplication newApplication = new LeaveApplication()
                        {
                            EmployeeId = empId,
                            Type = "Parental leave",
                            StartDate = startDate,
                            EndDate = endDate,
                            CreationDate = DateTime.Now
                        };
                        context.Add(newApplication);
                        context.SaveChanges();
                }
                
                else
                {
                    Console.WriteLine("Choose 1, 2, or 3");
                }
            }

            else if (who == "2")
            {
                string employId = "";
                string month = "";

                Console.WriteLine("[Admin] What do you want to do?\n1: Get worker and it´s leave applications\n2: Choose month and see all leave applications");
                string getInfo = Console.ReadLine();
                
                if (getInfo == "1")
                {
                    Console.WriteLine("Choose worker by id: ");
                    
                        foreach (var item in context.Employee)
                        {
                            Console.WriteLine("Id: " + item.EmployeeId + " - " + item.FirstName + " " + item.LastName);
                        }

                    employId = Console.ReadLine();

                        foreach (var item in context.LeaveApplications)
                        {
                            if (item.EmployeeId == Convert.ToInt32(employId))
                            {
                                Console.WriteLine("Id: " + item.EmployeeId + " - Type: " + item.Type + " , Date: " + item.StartDate.Date.ToString("yyyy-MM-dd") + " - " + item.EndDate.Date.ToString("yyyy-MM-dd") + " , Created: " + item.CreationDate.Date.ToString("yyyy-MM-dd"));
                            }
                        }
                }
                else if (getInfo == "2")
                {
                    Console.WriteLine("Choose month 1-12 (1 = January, 2 = February, 3 = March ......): ");
                    month = Console.ReadLine();

                    foreach (var item in context.LeaveApplications)
                    {
                        if (item.CreationDate.Month == Convert.ToInt32(month))
                        {
                            Console.WriteLine("Id: " + item.EmployeeId + " - Type: " + item.Type + " , Date: " + item.StartDate.Date.ToString("yyyy-MM-dd") + " - " + item.EndDate.Date.ToString("yyyy-MM-dd") + " , Created: " + item.CreationDate.Date.ToString("yyyy-MM-dd"));
                        }
                    }
                }
            }

            else
            {
                Console.WriteLine("Choose 1 or 2");
            }

            Console.WriteLine("Press Enter to register yourleave application and close the program");



            Console.ReadLine();
        }

        static void PopulateEmployees() 
        {
            using (var context = new Context())
            {
                Employees employee1 = new Employees()
                {
                    FirstName = "Sara",
                    LastName = "Svensson"
                };
                context.Add(employee1);

                Employees employee2 = new Employees()
                {
                    FirstName = "Edit",
                    LastName = "Karlsson"
                };
                context.Add(employee2);

                Employees employee3 = new Employees()
                {
                    FirstName = "Bengt",
                    LastName = "Berg"
                };
                context.Add(employee3);

                context.SaveChanges();
            };
        }
    }
}
