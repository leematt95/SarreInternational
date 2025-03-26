using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarreInternationalCinema
{
    class Program
    {
        static void Main(string[] args)
        {
            //variables for the cinema seats and the screen they are being shown in.
            var jawsScreen = 1;
            var exorcistScreen = 2;
            int cinemaSeatsJaws = 15;
            int cinemaSeatsTheExorcist = 33;

            //variables for the prices of the tickets. 
            decimal childFare = 1.50m;
            int childAmount;
            decimal adultFare = 2.35m;
            int adultAmount;
            decimal studentFare = 1.99m;
            int studentAmount;

            //varibales for totals and VAT.
            int totalAmount;
            decimal totalFare;
            decimal PreVAT = 0.80m; //this variabe is what will enable a display of what monies will be retained by Sarre after the VAT has been paid
            decimal VATdue = 0.20m; //this variable enables display of what VAT will be paid as a result of the current earnings.

            string filmchoice;
            string username;
            bool end = false; //condition that allows use of the application while these conditions are not met as to using a for loop with a predetermined number of loops enabled.
            string endChoice;

            //lists that allow storage of the variables in question. Allows for reproduction when called upon further down the program.
            var grandTotalSales = new List<int>();
            var dayTakings = new List<decimal>();
            var totalAdult = new List<int>();
            var totalChild = new List<int>();
            var totalStudent = new List<int>();


            for (int r = 0; end == false; r++)

            {

                Console.WriteLine("                    Welcome to the Sarre International Cinema");
                Console.WriteLine("");
                Console.WriteLine("Order Number: " + r);
                Console.WriteLine("");
                Console.WriteLine("Please enter your username: ");
                username = Console.ReadLine().ToLower();
                Console.WriteLine("");
                if (username != "leon odida")

                {
                    Console.Clear();
                    Console.WriteLine("                    Welcome to the Sarre International Cinema");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine(" ____________________________________________________________ ");
                    Console.WriteLine("|       {0}       |  {1}  |  {2} |   {3} |", "Film", "Certificate", "Seats", "Screen");
                    Console.WriteLine(" ____________________________________________________________ ");
                    Console.WriteLine("|       {0}       |      {1}      |   {2}   |     {3}    |", "Jaws", "12A", cinemaSeatsJaws, jawsScreen);
                    Console.WriteLine(" ____________________________________________________________ ");
                    Console.WriteLine("|   {0}   |      {1}       |   {2}   |     {3}    |", "The Exorcist", "18", cinemaSeatsTheExorcist, exorcistScreen);
                    Console.WriteLine(" ------------------------------------------------------------- ");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("Please select which film you wish to see");
                    Console.WriteLine("");
                    filmchoice = Console.ReadLine().ToLower();

                    //conditional statement which is enter the "Jaws" tree.
                    if (filmchoice == "jaws")

                    {
                        Console.WriteLine("");
                        Console.WriteLine("How many Child tickets would you like to purchase");
                        Console.WriteLine("");
                        childAmount = Convert.ToInt32(Console.ReadLine());
                        if (r == 0)
                        {
                            totalChild.Add(childAmount); //first itteration
                        }
                        else
                        {
                            totalChild.Add(childAmount + totalChild[r - 1]); //itterations thereafter
                        }
                        Console.WriteLine("");
                        Console.WriteLine("The number of child tickets you have chosen is: " + (childAmount));
                        Console.WriteLine("");
                        Console.WriteLine("How many Adult tickets would you like to purchase?");
                        Console.WriteLine("");
                        adultAmount = Convert.ToInt32(Console.ReadLine());
                        if (r == 0)
                        {
                            totalAdult.Add(adultAmount);
                        }
                        else
                        {
                            totalAdult.Add(adultAmount + totalAdult[r - 1]);
                        }
                        Console.WriteLine("");
                        Console.WriteLine("The number of adult tickets you have chosen is: " + (adultAmount));
                        Console.WriteLine("");
                        Console.WriteLine("How many Student Tickets would you like to purchase?");
                        Console.WriteLine("");
                        studentAmount = Convert.ToInt32(Console.ReadLine());
                        if (r == 0)
                        {
                            totalStudent.Add(studentAmount);
                        }
                        else
                        {
                            totalStudent.Add(studentAmount + totalStudent[r - 1]);
                        }
                        Console.WriteLine("");
                        Console.WriteLine("The number of student tickets you have chosen is: " + (studentAmount));
                        Console.WriteLine("");
                        totalAmount = childAmount + adultAmount + studentAmount;
                        if ((adultAmount == 0 && childAmount > 0) || (studentAmount == 0 && childAmount > 0)) // condition using boolean logic which enables use of multiple outcomes to set boundaries. Necessary for child tickets.
                        {
                            Console.Clear();
                            Console.WriteLine("As this film is rated 12A, all children must be accompanied by an adult.");
                            Console.ReadLine();
                            Console.Clear();
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("In total, you will be purchasing " + (totalAmount) + " tickets");
                            totalFare = (childAmount * childFare) + (adultAmount * adultFare) + (studentAmount * studentFare);
                            Console.WriteLine("The total cost of your bill today will be : £" + (totalFare));
                            cinemaSeatsJaws = --totalAmount; // decrements the total amount of seats after each itteration
                            if (r == 0)
                            {
                                dayTakings.Add(totalFare);
                            }
                            else
                            {
                                dayTakings.Add(totalFare + dayTakings[r - 1]);
                            }
                            if (r == 0)
                            {
                                grandTotalSales.Add(totalAmount);
                            }
                            else
                            {
                                grandTotalSales.Add(totalAmount + grandTotalSales[r - 1]);
                            }
                            Console.ReadLine();
                            Console.Clear();

                            Console.WriteLine("Press '0' to end and check days totals, press Enter for new order");
                            endChoice = Console.ReadLine();
                            if (endChoice == "0") // condition that determines whether the programm will run again or end based on user input.
                            {
                                end = true;
                            }
                            else
                            {
                                Console.Clear();
                            }
                        }



                    }
                    else if (filmchoice == "the exorcist")//the exorcist tree
                    {
                        Console.WriteLine("");
                        Console.WriteLine("How many Child tickets would you like to purchase");
                        Console.WriteLine("");
                        childAmount = Convert.ToInt32(Console.ReadLine());
                        if (childAmount > 0) //no children should be allowed into this film as it rated 18. This conditional statement deals with any potential child purchases.
                        {
                            Console.Clear();
                            Console.WriteLine("As this film is rated 18, unfortuntely no children are allowed to enter this screening");
                            Console.ReadLine();
                            Console.Clear();
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("The number of child tickets you have chosen is: " + (childAmount));
                            Console.WriteLine("");
                            Console.WriteLine("How many Adult tickets would you like to purchase?");
                            Console.WriteLine("");
                            adultAmount = Convert.ToInt32(Console.ReadLine());
                            if (r == 0)
                            {
                                totalAdult.Add(adultAmount);
                            }
                            else
                            {
                                totalAdult.Add(adultAmount + totalAdult[r - 1]);
                            }
                            Console.WriteLine("The number of adult tickets you have chosen is: " + (adultAmount));
                            Console.WriteLine("");
                            Console.WriteLine("How many Student Tickets would you like to purchase?");
                            Console.WriteLine("");
                            studentAmount = Convert.ToInt32(Console.ReadLine());
                            if (r == 0)
                            {
                                totalStudent.Add(studentAmount);
                            }
                            else
                            {
                                totalStudent.Add(studentAmount + totalStudent[r - 1]);
                            }
                            Console.WriteLine("");
                            Console.WriteLine("The number of student tickets you have chosen is: " + (studentAmount));
                            Console.WriteLine("");
                            totalAmount = childAmount + adultAmount + studentAmount;


                            if (r == 0)
                            {
                                grandTotalSales.Add(totalAmount);
                            }
                            else
                            {
                                grandTotalSales.Add(totalAmount + grandTotalSales[r - 1]);
                            }


                            Console.WriteLine("In total, you will be purchasing " + (totalAmount) + " tickets");
                            totalFare = (childAmount * childFare) + (adultAmount * adultFare) + (studentAmount * studentFare);
                            Console.WriteLine("The total cost of your bill today will be : £" + (totalFare));
                            if (r == 0)
                            {
                                dayTakings.Add(totalFare);
                            }
                            else
                            {
                                dayTakings.Add(totalFare + dayTakings[r - 1]);
                            }
                            Console.ReadLine();
                            cinemaSeatsTheExorcist = --totalAmount;

                            Console.Clear();
                            Console.WriteLine("Press '0' to end and view server report or press Enter for new order");
                            endChoice = Console.ReadLine();
                            if (endChoice == "0")
                            {
                                end = true;
                            }

                        }

                    }

                }

                else if (username == "leon odida")
                {
                    //this is the server report where all the end of day takings and other reports will be displayed to the user in question.
                    Console.Clear();
                    Console.WriteLine(("Hello Leon Odida. Welcome to the server report for the Sarre International Cinema"));
                    Console.WriteLine("");
                    Console.WriteLine("Number of Child Seats Sold: " + totalChild[r]);
                    Console.WriteLine("Number of Adult Seats Sold: " + totalAdult[r]);
                    Console.WriteLine("Number of Student Seats Sold: " + totalStudent[r]);
                    Console.WriteLine("Showing on Screen 1: Jaws - Certificate 12A ");
                    Console.WriteLine("Number of seats available in Screen 1: " + cinemaSeatsJaws);
                    Console.WriteLine("Showing on Screen 2: The Exorcist - Certificate 18");
                    Console.WriteLine("Number of seats available in Screen 2:  " + cinemaSeatsTheExorcist);
                    Console.WriteLine("Days takings: £" + dayTakings[r]);
                    Console.WriteLine("Takings for Sarre International Cinema: £" + (dayTakings[r] * (PreVAT)));
                    Console.WriteLine("VAT to pay: £" + (dayTakings[r] * (VATdue)));
                    Console.ReadLine();
                    Console.Clear();
                    end = false;
                }
                if (end == true)
                {

                    Console.Clear();
                    Console.WriteLine(("Hello Leon Odida. Welcome to the server report for the Sarre International Cinema"));
                    Console.WriteLine("");
                    Console.WriteLine("Number of Child Seats Sold: " + totalChild[r]);
                    Console.WriteLine("Number of Adult Seats Sold: " + totalAdult[r]);
                    Console.WriteLine("Number of Student Seats Sold: " + totalStudent[r]);
                    Console.WriteLine("Showing on Screen 1: Jaws - Certificate 12A ");
                    Console.WriteLine("Number of seats available in Screen 1: " + cinemaSeatsJaws);
                    Console.WriteLine("Showing on Screen 2: The Exorcist - Certificate 18");
                    Console.WriteLine("Number of seats available in Screen 2:  " + cinemaSeatsTheExorcist);
                    Console.WriteLine("Days takings: £" + dayTakings[r]);
                    Console.WriteLine("Takings for Sarre International Cinema: £" + (dayTakings[r] * (PreVAT)));
                    Console.WriteLine("VAT to pay: £" + (dayTakings[r] * (VATdue)));
                    Console.ReadLine();
                    Console.Clear();
                    end = false;
                }
            }

        }
    }
}
