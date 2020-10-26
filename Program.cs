using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Рулетка
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] blacks = { 2, 4, 6, 7, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35 };
            int[] reds = { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };
            int[] firstdozen = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 12 };
            int[] seconddozen = { 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };
            int[] thirddozen = { 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36 };

            int balance = 1000;
            string choice;
            loop:
            {
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "help":
                        Console.WriteLine("\nbet \n<amount> \n<poition> \nif position is u, then bet will be cancelled\n");
                        Console.WriteLine("places - shows table");
                        Console.WriteLine("balance(bal)(b) - show your balance");
                        Console.WriteLine("cls - clear screen");
                        Console.WriteLine("");
                        goto loop;
                    case "places":
                        Console.WriteLine("\n    3r  6b  9r  12r  |  15b  18r  21r  24b  |  27r  30r  33b  36r  |  2 to 1(1c)");
                        Console.WriteLine("0   2b  5r  8b  11b  |  14r  17b  20b  23r  |  26b  29b  32r  35b  |  2 to 1(2c)");
                        Console.WriteLine("    1r  4b  7r  10b  |  13b  16r  19r  22b  |  25r  28b  31b  34r  |  2 to 1(3c)");
                        Console.WriteLine("        1st 12       |        2nd 12        |        3rd 12        |");
                        Console.WriteLine("    1to18  |   even  |    red   |   black   |    odd   |   19to36  |");
                        Console.WriteLine("number - 1:36 \ncolumn - 1:3 \n1,2 or 3 12 - 1:3 \n1to18, 19to36, red, black, odd or even - 1:2");
                        Console.WriteLine("bet: 4 \n1c \n312 \neven \nred \n19to36");
                        Console.WriteLine("");
                        goto loop;
                    case "balance":
                        Console.WriteLine(balance);
                        Console.WriteLine("");
                        goto loop;
                    case "bal":
                        Console.WriteLine(balance);
                        Console.WriteLine("");
                        goto loop;
                    case "b":
                        Console.WriteLine(balance);
                        Console.WriteLine("");
                        goto loop;
                    case "cls":
                        Console.Clear();
                        goto loop;
                    case "bet":
                        goto res;
                    default:
                        Console.WriteLine("error");
                        goto loop;
                }
            }

            res:
            {
                string amount = Console.ReadLine();
                
                if (Convert.ToInt32(amount) < 0)
                    goto loop;
                if (Convert.ToInt32(amount) > balance)
                    goto loop;

                try
                {
                    int i = Convert.ToInt32(amount);
                }
                catch (FormatException)
                {
                    goto loop;
                }

                string position = Console.ReadLine();

                Random rnd = new Random();
                int v = rnd.Next(0, 36);

                if (position == "u")
                    goto loop;

                if(v == 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine(0);
                    Console.WriteLine("");
                }
                for (int i = 0; i < reds.Length; i++)
                {
                    if (v == reds[i])
                    {
                        Console.WriteLine("");
                        Console.WriteLine(v + " - red");
                        Console.WriteLine("");
                    }
                    else if (v == blacks[i])
                    {
                        Console.WriteLine("");
                        Console.WriteLine(v + " - black");
                        Console.WriteLine("");
                    }
                }

                balance -= Convert.ToInt32(amount);

                int pos;
                try
                {
                    pos = Convert.ToInt32(position);
                }
                catch (FormatException)
                {
                    switch (position)
                    {
                        case "1c":
                            if (v == 3 || v == 6 || v == 9 || v == 12 || v == 15 || v == 18 || v == 21 || v == 24 || v == 27 || v == 30 || v == 33 || v == 36)
                                balance += Convert.ToInt32(amount) * 3;
                            goto loop;
                        case "2c":
                            if (v == 2 || v == 5 || v == 8 || v == 11 || v == 14 || v == 17 || v == 20 || v == 23 || v == 26 || v == 29 || v == 32 || v == 35)
                                balance += Convert.ToInt32(amount) * 3;
                            goto loop;
                        case "3c":
                            if (v == 1 || v == 4 || v == 7 || v == 10 || v == 13 || v == 16 || v == 19 || v == 22 || v == 25 || v == 28 || v == 31 || v == 34)
                                balance += Convert.ToInt32(amount) * 3;
                            goto loop;
                        case "1to18":
                            for (int i = 1; i <= 18; i++)
                            {
                                if (v == i)
                                    balance += Convert.ToInt32(amount) * 2;
                            }
                            goto loop;
                        case "19to36":
                            for (int i = 19; i <= 36; i++)
                            {
                                if (v == i)
                                    balance += Convert.ToInt32(amount) * 2;
                            }
                            goto loop;
                        case "odd":
                            for (int i = 1; i <= 35; i++)
                            {
                                if (i % 2 != 0 && v == i)
                                    balance += Convert.ToInt32(amount) * 2;
                            }
                            goto loop;
                        case "even":
                            for (int i = 1; i <= 36; i++)
                            {
                                if (i % 2 == 0 && v == i)
                                    balance += Convert.ToInt32(amount) * 2;
                            }
                            goto loop;
                        case "red":
                            foreach (int i in reds)
                            {
                                if (v == i)
                                {
                                    balance += Convert.ToInt32(amount) * 2;
                                }
                            }
                            goto loop;
                        case "black":
                            foreach (int i in blacks)
                            {
                                if (v == i)
                                {
                                    balance += Convert.ToInt32(amount) * 2;
                                }
                            }
                            goto loop;
                    }
                }
                pos = Convert.ToInt32(position);
                if (pos == v)
                {
                    balance += Convert.ToInt32(amount) * 36;
                    goto loop;
                }
                else if (pos == 112)
                {
                    foreach (int i in firstdozen)
                    {
                        if (v == i)
                        {
                            balance += Convert.ToInt32(amount) * 3;
                        }
                    }
                }
                else if (pos == 212)
                {
                    foreach (int i in seconddozen)
                    {
                        if (v == i)
                        {
                            balance += Convert.ToInt32(amount) * 3;
                        }
                    }
                }
                else if (pos == 312)
                {
                    foreach (int i in thirddozen)
                    {
                        if (v == i)
                        {
                            balance += Convert.ToInt32(amount) * 3;
                        }
                    }
                }
                else
                    goto loop;
            }
        }
    }
}
