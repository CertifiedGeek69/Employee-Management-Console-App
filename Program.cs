using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Employee
    {
        public int ID { get; set; }
        public string EmployeeName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public int VacationDays { get; set; }
        public List<Payroll> payrolls { get; set; }=new List<Payroll>();
        //public List<Vacation> vacations { get; set; } =new List<Vacation>();    
    }
    public class Payroll
    {
        public int ID { get; set; }
        //public int EmployeeID { get; set; }
        public int HoursWorked { get; set; }
        public int HourlyRate { get; set; }
        public int amount { get; set; }
        

        public DateTime Date { get; set; }
        
    }
    /*public class Vacation
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public int Numofdays {  get; set; } 

    }*/
    internal class Program
    {
        public static int id = 1;
        public static List<Employee> employees = new List<Employee>();
        public static List<Payroll> payroll = new List<Payroll>();
       // public static List<Vacation> vacation = new List<Vacation>();

        static void Main(string[] args)
        {
            Mainmenu();
        }
        static void Mainmenu()
        {
            bool isNull = false;
            if (!isNull)
            {
                Console.Clear();
                Console.WriteLine("-----Welcome to Employee management System-------");
                Console.WriteLine("");
                Console.WriteLine("Made by - Joydeep Roy");
                Console.WriteLine("Registration No. - 12115687");
                Console.WriteLine();
                Console.WriteLine("1: Modify employees");
                Console.WriteLine("2: Add payroll");
                Console.WriteLine("3: View Vacation days");
                Console.WriteLine("4: Exit Program");
                Console.WriteLine();
                Console.WriteLine();

                String choice=Console.ReadLine();
                switch(choice)
                {
                    case "1":
                        submenu1();
                        break;
                    case "2": 
                        submenu2();
                        break;
                    case "3":
                        submenu3();
                        break;
                    case "4":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }


            }
        }

        static void submenu1()
        {
            Console.Clear();
            Console.WriteLine("-----Submenu 1: Employees----");
            Console.WriteLine("1 : List all employees");
            Console.WriteLine("2 : Add new employee");
            Console.WriteLine("3 : Update employee details");
            Console.WriteLine("4 : Delete employee");
            Console.WriteLine("5 : Return to main menu");
            Console.WriteLine();
            Console.WriteLine();

            String choice=Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ListEmployee();
                    break;
                case "2":
                    addEmployee();
                    break;
                case "3":
                    UpdEmployee();
                    break;
                case "4":
                    DelEmployee();
                    break;
                case "5":
                    Mainmenu();
                    break;
            }
        }
        static void submenu2()
        {
            Console.Clear();
            Console.WriteLine("-----Submenu 2: Payroll-----");
            Console.WriteLine("1 : Insert new payroll entry");
            Console.WriteLine("2 : View payroll history");
            Console.WriteLine("3 : Return to main menu");
            Console.WriteLine();
            Console.WriteLine();

            String choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    insertPayroll();
                    break;
                case "2":
                    ViewPayrollHistory();
                    break;
                case "3":
                    Mainmenu();
                    break;
                default: Console.WriteLine("Invalid input");
                    submenu2();
                    break;
            }
        }
        static void submenu3()
        {
            Console.Clear();
            Console.WriteLine("-----Submenu 3: Vacation Days-----");
            Console.WriteLine("Enter the name of the employee to check vacation days:");
            Console.WriteLine();
            Console.WriteLine();
            String payName = Console.ReadLine();

            Employee foundEmployee = employees.Find(Employee => Employee.EmployeeName.Equals(payName, StringComparison.OrdinalIgnoreCase));

            if(foundEmployee != null)
            {
                Console.WriteLine($"Number of days : '{foundEmployee.VacationDays}'");
            }
            else
            {
                Console.WriteLine("Employee name not found");
                submenu3();
            }
            waitForInput();
        }
        
       
        static void addEmployee()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Employee Name: ");
            String name=Console.ReadLine();
            Console.WriteLine("Enter address:");
            String address=Console.ReadLine();
            Console.WriteLine("Enter email:");
            String email=Console.ReadLine();
            Console.WriteLine("Enter Phone Number:");
            String phone=Console.ReadLine();
            Console.WriteLine("Enter Role:");
            String role=Console.ReadLine();
            


            Employee NewEmployee = new Employee { ID = id, EmployeeName = name, Address = address, Email = email, Phone = phone, Role = role ,VacationDays=14};
            employees.Add(NewEmployee);

            
            

            Console.WriteLine("Employee added successfully!");
            waitForInput();

        }
        static int GetIntInput()
        {
            int result;
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Invalid input. Please enter a valid decimal.");
            }
            return result;
        }
        static DateTime GetDateInput()
        {
            DateTime result;
            while (!DateTime.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Invalid input. Please enter a valid date (yyyy-MM-dd).");
            }
            return result;
        }
        static void ListEmployee()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            if (employees.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("No Employees found!");
            }
            else
            {
                Console.WriteLine("List of all employees :");
                foreach(var Employee in employees)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine($"ID : {Employee.ID}, Name : {Employee.EmployeeName}, Address : {Employee.Address}, Email : {Employee.Email}, Phone Number : {Employee.Phone}, Role: {Employee.Role}");
                }
            }
            waitForInput();
        }
        static void UpdEmployee()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Enter employee name to update its record : ");
            String UpdName=Console.ReadLine();

            Employee foundEmployee=employees.Find(Employee=> Employee.EmployeeName.Equals(UpdName,StringComparison.OrdinalIgnoreCase));

            if(foundEmployee != null)
            {
                String newName;
                String newAdd;
                String newEmail;
                String newPhone;
                String newRole;
                Console.WriteLine("1: Change Name");
                Console.WriteLine("2: Change Address");
                Console.WriteLine("3: Change Email");
                Console.WriteLine("4: Change Phone Number");
                Console.WriteLine("5: Change Role");

                String Updchoice=Console.ReadLine();

                switch(Updchoice)
                {
                    case "1":
                        Console.WriteLine("Enter new name:");
                        newName = Console.ReadLine();
                        foundEmployee.EmployeeName = newName;
                        break;
                    case "2":
                        Console.WriteLine("Enter new address:");
                        newAdd= Console.ReadLine();
                        foundEmployee.Address = newAdd;
                        break;
                    case "3":
                        Console.WriteLine("Enter new Email:");
                        newEmail= Console.ReadLine();
                        foundEmployee.Email = newEmail;
                        break;
                    case "4":
                        Console.WriteLine("Enter new phone number:");
                        newPhone= Console.ReadLine();
                        foundEmployee.Phone = newPhone;
                        break;
                    case "5":
                        Console.WriteLine("Enter new role");
                        newRole= Console.ReadLine();
                        foundEmployee.Role = newRole;
                        break;

                }

            }
            waitForInput();


        }
        static void DelEmployee()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Enter the name of the employee to delete");
            String delName=Console.ReadLine();

            Employee foundEmployee = employees.Find(Employee => Employee.EmployeeName.Equals(delName, StringComparison.OrdinalIgnoreCase));

            if (foundEmployee!= null)
            {
                employees.Remove(foundEmployee);
                Console.WriteLine("Employee removed successfully");
            }
            else
            {
                Console.WriteLine($"No Employee found with the name '{delName}'.");
            }
            waitForInput();
        }
        static void insertPayroll()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Enter the name of the employee to add payroll:");
            String payName = Console.ReadLine();

            Employee foundEmployee = employees.Find(Employee => Employee.EmployeeName.Equals(payName, StringComparison.OrdinalIgnoreCase));

            if (foundEmployee != null)
            {
                Console.WriteLine($"Inserting payroll entry for '{foundEmployee}'.");
                Console.WriteLine("Enter hours worked:");
                int hrsworked = GetIntInput();
                Console.WriteLine("Enter hourly rate:");
                int hrRate=GetIntInput();
                Console.WriteLine("Enter payroll Date (yyyy-MM-dd): ");
                DateTime date =GetDateInput();


                Payroll newpayroll = new Payroll { HourlyRate = hrRate, HoursWorked = hrsworked, amount = hrsworked * hrRate,Date=date };
                foundEmployee.payrolls.Add(newpayroll);
                foundEmployee.VacationDays += 1;

                Console.WriteLine("Payroll entry added successfully");
                

            }
            else
            {
                Console.WriteLine($"No Employee found with the name '{payName}'.");
            }
            waitForInput();
        }
        static void ViewPayrollHistory()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Enter the name of the employee to view his/her payroll history:");
            String payName = Console.ReadLine();

            Employee foundEmployee = employees.Find(Employee => Employee.EmployeeName.Equals(payName, StringComparison.OrdinalIgnoreCase));

            if (foundEmployee != null)
            {
                Console.WriteLine($"Payroll history for employee {foundEmployee.EmployeeName}:");
                foreach (var payroll in foundEmployee.payrolls)
                {
                    Console.WriteLine($"  Date: {payroll.Date}, Amount: {payroll.amount}");
                }
            }
            else
            {
                Console.WriteLine($"Employee with ID {payName} not found.");
            }
            waitForInput();
        }
        static void waitForInput()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press Enter to main menu");
            Console.ReadLine();
            Mainmenu();
        }
        
    }
}
