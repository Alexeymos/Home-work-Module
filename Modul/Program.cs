using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul
{
    class Program
    {
        // Error Metod
        static void InputError()
        {
            Console.WriteLine("Input Error. press any key!!!");
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            int admintry = 0;//Verification variable for administrator login
            string adminpass = "qqq";//Admin password
            string[] arrusername = new string[2] { "Alex", "Serg" };//Array of usernames
            int[] arrusernum = new int[2] { 1, 2 };//Array of user numbers
            int[] arrusermoney = new int[2] { 0, 0 };//An array of user money
            int[] arruserblock = new int[2] { 0, 0 };//Blocking Array
            while (true)
            {
                Console.Clear();
                admintry = 0;//Verification variable for administrator login
                Console.WriteLine("Wellcome to A-LEVEL BANK SYSTEM");
                Console.Write("Enter PASSWORD: ");
                string menuchek = Console.ReadLine(); //Password variable
                //Checking the login of the user and admin
                if (menuchek == "qqq")
                {
                    adminmenu(ref admintry, ref adminpass, ref arrusername, ref arrusernum, ref arrusermoney, ref arruserblock);
                }
                else if (menuchek != "qqq")
                {
                    usermenu(ref arrusername, ref arrusernum, ref arrusermoney, ref arruserblock, menuchek);
                }
                else
                {
                    continue;
                }
            }
        }//ADMIN MENU METOD
        static void adminmenu(ref int admintry, ref string adminpass, ref string[] arrusername, ref int[] arrusernum, ref int[] arrusermoney, ref int[] arruserblock)
        {
            while (true)
            {
                Console.Clear();
                admintry = 1;
                Console.WriteLine("===== Admin menu =====");
                Console.WriteLine(" 1- add new user      ");
                Console.WriteLine(" 2- list users acounts");
                Console.WriteLine(" 3- block account     ");
                Console.WriteLine(" 4- delete account    ");
                Console.WriteLine(" 5- back to main menu ");
                Console.WriteLine("======================");
                string menuchoice = Console.ReadLine();
                if (menuchoice == "1")
                {
                    adduser(ref arrusername, ref arrusernum, ref arrusermoney, ref arruserblock);// to Menu add a user metod
                }
                else if (menuchoice == "2")
                {
                    listusers(ref arrusername, ref arrusernum, ref arrusermoney, ref arruserblock);
                }
                else if (menuchoice == "3")
                {
                    blockusers(ref arrusername, ref arrusernum, ref arrusermoney, ref arruserblock);
                }
                else if (menuchoice == "4")
                {
                    deleteusers(ref arrusername, ref arrusernum, ref arrusermoney, ref arruserblock);
                }
                else if (menuchoice == "5")
                {
                    break;
                }
                else
                {
                    continue;
                }
            }
        }//USER MENU METOD
        static void usermenu(ref string[] arrusername, ref int[] arrusernum, ref int[] arrusermoney, ref int[] arruserblock, string menuchek)
        {
            while (true)
            {

                int usermoney = 0;
                string userlog = "";
                Console.Clear();
                for (int i = 0; i < arrusername.Length; i++)
                {
                    if (menuchek == arrusername[i])
                    {
                        if (arruserblock[i] == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("YOU ACCOUNT IS BLOCKED");
                            Console.WriteLine("PRESS ANY KEY TO EXIT!");
                            Console.ReadLine();
                            goto meinmenu;
                        }
                        login://INSIDE  user login
                        Console.Clear();
                        inusermenu(arrusername, arrusernum, arrusermoney, i);
                        Console.WriteLine("==============================");
                        Console.WriteLine("= Press -1 key to add money  =");
                        Console.WriteLine("= Press -2 key to money back =");
                        Console.WriteLine("= Press -3 key to Maine Menu =");
                        Console.WriteLine("==============================");
                        userlog = Console.ReadLine();
                        if (userlog == "1")
                        {
                            Console.Clear();
                            inusermenu(arrusername, arrusernum, arrusermoney, i);
                            Console.WriteLine("Enter how much money to add.");
                            string Usermoney = (Console.ReadLine());
                            if (int.TryParse(Usermoney, out usermoney))
                            {
                                arrusermoney[i] += usermoney;
                                goto login;//At the beginning of the method
                            }
                            else
                            {
                                InputError();
                                goto login;//At the beginning of the method
                            }
                        }
                        if (userlog == "2")
                        {
                            Console.Clear();
                            inusermenu(arrusername, arrusernum, arrusermoney, i);
                            Console.WriteLine("Enter how much money to back.");
                            string Usermoney = (Console.ReadLine());
                            if (int.TryParse(Usermoney, out usermoney))
                            {
                                if (arrusermoney[i] - usermoney < 0)
                                {
                                    Console.WriteLine("You do not have enough money");
                                    Console.WriteLine("Press any key to exit");
                                    Console.ReadLine();
                                    goto login;//At the beginning of the method
                                }
                                else
                                {
                                    arrusermoney[i] -= usermoney;
                                    goto login;//At the beginning of the method
                                }
                            }
                            else
                            {
                                InputError();
                                goto login;//At the beginning of the method
                            }

                        }
                        if (userlog == "3")
                        {
                            goto meinmenu;
                        }
                    }
                }
                Console.Clear();
                Console.WriteLine("User not Found");
                Console.WriteLine("Press any key to Maine Menu");
                Console.ReadLine();
                meinmenu://BAck to MAINE MENU!!
                break;
            }

        }//ADD User MENU METOD
        static void adduser(ref string[] arrusername, ref int[] arrusernum, ref int[] arrusermoney, ref int[] arruserblock)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("======== ADD USER MENU ========");
                Console.WriteLine("=     Enter Name new User     =");
                Console.WriteLine("===============================");
                string newname = Console.ReadLine();

                string[] arrusername1 = new string[arrusername.Length + 1];
                int[] arrusernum1 = new int[arrusernum.Length + 1];
                int[] arrusermoney1 = new int[arrusermoney.Length + 1];
                int[] arruserblock1 = new int[arruserblock.Length + 1];
                for (int i = 0; i < arrusernum.Length; i++)
                {
                    arrusername1[i] = arrusername[i];
                    arrusernum1[i] = arrusernum[i];
                    arrusermoney1[i] = arrusermoney[i];
                    arruserblock1[i] = arruserblock[i];
                }
                arrusername = arrusername1;
                arrusernum = arrusernum1;
                arrusermoney = arrusermoney1;
                arruserblock = arruserblock1;
                arrusername[arrusername.Length - 1] = newname;
                arrusernum[arrusernum.Length - 1] = arrusernum.Length;
                arrusermoney[arrusermoney.Length - 1] = 0;
                arruserblock[arruserblock.Length - 1] = 0;
                Console.Clear();
                Console.WriteLine("N A M E     accont     money     blocked");
                for (int i = 0; i < arrusernum.Length; i++)
                {
                    Console.WriteLine("{0}", arrusername[i] + "        " + arrusernum[i] + "           " + arrusermoney[i] + "           " + arruserblock[i]);
                }

                Console.WriteLine("= = = =  Press any key to Menu  = = = = ");
                Console.ReadLine();
                break;
            }
        }//LIST USERS METOD
        static void listusers(ref string[] arrusername, ref int[] arrusernum, ref int[] arrusermoney, ref int[] arruserblock)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("============== LIST USERS ==============");
                Console.WriteLine("N A M E     accont     money     blocked");
                for (int i = 0; i < arrusernum.Length; i++)
                {
                    Console.WriteLine("{0}", arrusername[i] + "        " + arrusernum[i] + "           " + arrusermoney[i] + "           " + arruserblock[i]);
                }
                Console.WriteLine("= = = =  Press any key to Menu  = = = = ");
                Console.ReadLine();
                break;
            }
        }//BLOCK USERS METOD
        static void blockusers(ref string[] arrusername, ref int[] arrusernum, ref int[] arrusermoney, ref int[] arruserblock)
        {
            while (true)
            {
                string blok = " ";
                Console.Clear();
                Console.WriteLine("======= BLOCK USERS MENU =======");
                Console.WriteLine("N A M E     accont     money   ");
                for (int i = 0; i < arrusernum.Length; i++)
                {
                    if (arruserblock[i] == 1)
                    {
                        blok = "blocked";
                    }
                    else
                    {
                        blok = "unblocked";
                    }
                    Console.WriteLine("{0}", arrusername[i] + "        " + arrusernum[i] + "           " + arrusermoney[i] + "           " + blok);
                }
                Console.WriteLine();
                Console.WriteLine("To Block or Unblok User enter account number");
                Console.WriteLine("         Type <0> to MAIN MENU           ");
                int usernum = int.Parse(Console.ReadLine());
                if (usernum == 0)
                {
                    break;
                }
                else if (arruserblock[usernum - 1] == 0)
                {
                    arruserblock[usernum - 1] = 1;
                    continue;
                }
                else
                {
                    arruserblock[usernum - 1] = 0;
                    continue;
                }
            }
        }//Metod for menu User
        static void inusermenu(string[] arrusername, int[] arrusernum, int[] arrusermoney, int i)
        {
            Console.WriteLine("Name      " + arrusername[i]);
            Console.WriteLine();
            Console.WriteLine("Account   " + arrusernum[i]);
            Console.WriteLine();
            Console.WriteLine("Money     " + arrusermoney[i]);
            Console.WriteLine();
        }
        //DELETE MENU METOD
        static void deleteusers(ref string[] arrusername, ref int[] arrusernum, ref int[] arrusermoney, ref int[] arruserblock)
        {
            while (true)
            {
                int deleteuser = 0;
                Console.Clear();
                Console.WriteLine("=========  DELETE USERS MENU  ==========");
                Console.WriteLine("N A M E     accont     money     blocked");
                for (int i = 0; i < arrusernum.Length; i++)
                {
                    Console.WriteLine("{0}", arrusername[i] + "        " + arrusernum[i] + "           " + arrusermoney[i] + "           " + arruserblock[i]);
                }
                Console.WriteLine("=      Enter user NAMBER to delete      ");
                Console.WriteLine("=                 OR                    ");
                Console.WriteLine("         Type <0> to MAIN MENU          ");
                Console.WriteLine("========================================");
                string Deleteuser = (Console.ReadLine());
                if (int.TryParse(Deleteuser, out deleteuser))
                {


                    if (deleteuser < 0 || deleteuser > arrusernum.Length)
                    {
                        continue;
                    }

                    if (deleteuser == 0)
                    {
                        break;
                    }

                    string[] arrusername1 = new string[arrusername.Length - 1];
                    int[] arrusernum1 = new int[arrusernum.Length - 1];
                    int[] arrusermoney1 = new int[arrusermoney.Length - 1];
                    int[] arruserblock1 = new int[arruserblock.Length - 1];
                    for (int i = 0, k = 0; i < arrusername.Length; i++, k++)
                    {
                        if (deleteuser - 1 == i)
                        {
                            k--;
                            continue;
                        }
                        else
                        {
                            arrusername1[k] = arrusername[i];
                            arrusernum1[k] = arrusernum[i];
                            arrusermoney1[k] = arrusermoney[i];
                            arruserblock1[k] = arruserblock[i];
                        }
                    }
                    arrusername = arrusername1;
                    arrusernum = arrusernum1;
                    arrusermoney = arrusermoney1;
                    arruserblock = arruserblock1;
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
