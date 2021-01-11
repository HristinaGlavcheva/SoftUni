using System;

namespace _03._World_Snooker_Championship
{
    class Program
    {
        static void Main(string[] args)
        {
            string stageOfChampionship = Console.ReadLine();
            string ticketType = Console.ReadLine();
            int countTickets = int.Parse(Console.ReadLine());
            char picture = char.Parse(Console.ReadLine());
            double totalPrice = 0;
            double finalPrice = 0;

            if(stageOfChampionship == "Quarter final")
            {
                if (ticketType == "Standard")
                {
                    totalPrice = countTickets * 55.50;

                    if(totalPrice > 4000)
                    {
                        finalPrice = totalPrice * 0.75;
                    }
                    else if (totalPrice > 2500)
                    {
                        if(picture == 'Y')
                        {
                            finalPrice = totalPrice * 0.9 + 40 * countTickets;
                        }
                        else
                        {
                            finalPrice = totalPrice * 0.9;
                        }
                    }
                    else
                    {
                        if (picture == 'Y')
                        {
                            finalPrice = totalPrice + 40 * countTickets;
                        }
                        else
                        {
                            finalPrice = totalPrice;
                        }
                    }
                }
                else if (ticketType == "Premium")
                {
                    totalPrice = countTickets * 105.20;

                    if (totalPrice > 4000)
                    {
                        finalPrice = totalPrice * 0.75;
                    }
                    else if (totalPrice > 2500)
                    {
                        if (picture == 'Y')
                        {
                            finalPrice = totalPrice * 0.9 + 40 * countTickets;
                        }
                        else
                        {
                            finalPrice = totalPrice * 0.9;
                        }
                    }
                    else
                    {
                        if (picture == 'Y')
                        {
                            finalPrice = totalPrice + 40 * countTickets;
                        }
                        else
                        {
                            finalPrice = totalPrice;
                        }
                    }
                }
                else if (ticketType == "VIP")
                {
                    totalPrice = countTickets * 118.90;

                    if (totalPrice > 4000)
                    {
                        finalPrice = totalPrice * 0.75;
                    }
                    else if (totalPrice > 2500)
                    {
                        if (picture == 'Y')
                        {
                            finalPrice = totalPrice * 0.9 + 40 * countTickets;
                        }
                        else
                        {
                            finalPrice = totalPrice * 0.9;
                        }
                    }
                    else
                    {
                        if (picture == 'Y')
                        {
                            finalPrice = totalPrice + 40 * countTickets;
                        }
                        else
                        {
                            finalPrice = totalPrice;
                        }
                    }
                }
            }

            if (stageOfChampionship == "Semi final")
            {
                if (ticketType == "Standard")
                {
                    totalPrice = countTickets * 75.88;

                    if (totalPrice > 4000)
                    {
                        finalPrice = totalPrice * 0.75;
                    }
                    else if (totalPrice > 2500)
                    {
                        if (picture == 'Y')
                        {
                            finalPrice = totalPrice * 0.9 + 40 * countTickets;
                        }
                        else
                        {
                            finalPrice = totalPrice * 0.9;
                        }
                    }
                    else
                    {
                        if (picture == 'Y')
                        {
                            finalPrice = totalPrice + 40 * countTickets;
                        }
                        else
                        {
                            finalPrice = totalPrice;
                        }
                    }
                }
                else if (ticketType == "Premium")
                {
                    totalPrice = countTickets * 125.22;

                    if (totalPrice > 4000)
                    {
                        finalPrice = totalPrice * 0.75;
                    }
                    else if (totalPrice > 2500)
                    {
                        if (picture == 'Y')
                        {
                            finalPrice = totalPrice * 0.9 + 40 * countTickets;
                        }
                        else
                        {
                            finalPrice = totalPrice * 0.9;
                        }
                    }
                    else
                    {
                        if (picture == 'Y')
                        {
                            finalPrice = totalPrice + 40 * countTickets;
                        }
                        else
                        {
                            finalPrice = totalPrice;
                        }
                    }
                }
                else if (ticketType == "VIP")
                {
                    totalPrice = countTickets * 300.40;

                    if (totalPrice > 4000)
                    {
                        finalPrice = totalPrice * 0.75;
                    }
                    else if (totalPrice > 2500)
                    {
                        if (picture == 'Y')
                        {
                            finalPrice = totalPrice * 0.9 + 40 * countTickets;
                        }
                        else
                        {
                            finalPrice = totalPrice * 0.9;
                        }
                    }
                    else
                    {
                        if (picture == 'Y')
                        {
                            finalPrice = totalPrice + 40 * countTickets;
                        }
                        else
                        {
                            finalPrice = totalPrice;
                        }
                    }
                }
            }

            if (stageOfChampionship == "Final")
            {
                if (ticketType == "Standard")
                {
                    totalPrice = countTickets * 110.10;

                    if (totalPrice > 4000)
                    {
                        finalPrice = totalPrice * 0.75;
                    }
                    else if (totalPrice > 2500)
                    {
                        if (picture == 'Y')
                        {
                            finalPrice = totalPrice * 0.9 + 40 * countTickets;
                        }
                        else
                        {
                            finalPrice = totalPrice * 0.9;
                        }
                    }
                    else
                    {
                        if (picture == 'Y')
                        {
                            finalPrice = totalPrice + 40 * countTickets;
                        }
                        else
                        {
                            finalPrice = totalPrice;
                        }
                    }
                }
                else if (ticketType == "Premium")
                {
                    totalPrice = countTickets * 160.66;

                    if (totalPrice > 4000)
                    {
                        finalPrice = totalPrice * 0.75;
                    }
                    else if (totalPrice > 2500)
                    {
                        if (picture == 'Y')
                        {
                            finalPrice = totalPrice * 0.9 + 40 * countTickets;
                        }
                        else
                        {
                            finalPrice = totalPrice * 0.9;
                        }
                    }
                    else
                    {
                        if (picture == 'Y')
                        {
                            finalPrice = totalPrice + 40 * countTickets;
                        }
                        else
                        {
                            finalPrice = totalPrice;
                        }
                    }
                }
                else if (ticketType == "VIP")
                {
                    totalPrice = countTickets * 400.00;

                    if (totalPrice > 4000)
                    {
                        finalPrice = totalPrice * 0.75;
                    }
                    else if (totalPrice > 2500)
                    {
                        if (picture == 'Y')
                        {
                            finalPrice = totalPrice * 0.9 + 40 * countTickets;
                        }
                        else
                        {
                            finalPrice = totalPrice * 0.9;
                        }
                    }
                    else
                    {
                        if (picture == 'Y')
                        {
                            finalPrice = totalPrice + 40 * countTickets;
                        }
                        else
                        {
                            finalPrice = totalPrice;
                        }
                    }
                }
            }

            Console.WriteLine($"{finalPrice:F2}");
        }
    }
}
