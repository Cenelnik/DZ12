using System.Collections.Concurrent;
using System.Collections.Generic;

namespace DZ12
{
    /// <summary>
    /// 12я домашка по OUTUS. Observable, Immutable и Concurrent коллекции
    /// </summary>
    class DZ12
    {
        /// <summary>
        /// Тестирование словаря.
        /// </summary>
        /// <param name="args"></param>
        public static async Task Main(string[] args)
        {
            
            Console.WriteLine("\n  * * * PART ONE. THE SHOP. * * * ");
            int id = 0;
            var Shop = new Shop();
            Customer Anna = new Customer();
            Shop.ListOfGoods.CollectionChanged += Anna.OnItemChanged;
            while (true)
            {
                Console.WriteLine("\nPress A for Adding new goods and press D for delete one. Press E for EXIT.");
                ConsoleKeyInfo key = Console.ReadKey();
                if(key.KeyChar == 'A')
                {
                    Shop.Add(new Item() { Id = id, Name = $"Goods_{DateTime.Now.ToString("o")}" });
                    id++;
                }
                else if(key.KeyChar == 'D')
                {
                    Console.WriteLine("\nWhat kind of goods do you want to delete? Write the lable please.");
                    string ?lable = Console.ReadLine();
                    if(lable.Length > 0)
                    {
                        Console.WriteLine($"\nTry to remove the {lable}... ");
                        Shop.Remove(lable);
                    }
                }
                else if (key.KeyChar == 'E')
                {
                    Console.Clear();
                    break;
                }
            }
            


            Console.WriteLine("\n  * * * PART TWO. THE LIBRARY. * * * ");
            ConcurrentDictionary<string, int> MyDictionary = new ConcurrentDictionary<string, int>();
            MyDictionary.TryAdd("book1", 0);
            MyDictionary.TryAdd("book2", 0);
           
            async Task t1(string name)
            {
                await Task.Run(async () =>
                {
                    Console.WriteLine($"Start to read the book {name}.");
                    while (true)
                    {
                        MyDictionary.TryUpdate(name, MyDictionary[name] + 1, MyDictionary[name]);
                        await Task.Delay(1000 + new Random().Next(1000));

                        if (MyDictionary[name] >= 100)
                        {
                            break;
                        }
                    }
                });
            }

            //await Task.Run(async () => t1());

            while(true)
            {
                Console.WriteLine($"\n\t * * * MENU * * * \n  - Press 1 to add new book.\n  - Press 2 to check book list.\n  - Press 3 to exit.");

                ConsoleKeyInfo key_part2 = Console.ReadKey();
                if (key_part2.KeyChar == '1')
                {
                    Console.WriteLine($"\n Write lable the book.");
                    string ?lable_part2 = Console.ReadLine();
                    if(lable_part2.Length > 0)
                    {
                        MyDictionary.TryAdd(lable_part2, 0);
                        //await Task.Run(async () => await t1(lable_part2));
                        t1(lable_part2);
                    }
                }
                else if(key_part2.KeyChar == '2')
                {
                    foreach (var book in MyDictionary.Where(i => i.Value >= 100).ToList()) MyDictionary.TryRemove(book);
                    Console.WriteLine($"\n\n--------------------- \n LABLE - STATUS");
                    foreach (var item in MyDictionary)
                    {
                        Console.WriteLine($"Book: {item.Key} - Stat: {item.Value}");
                    }
                }
                else if (key_part2.KeyChar == '3')
                {
                    break;
                }
                Console.WriteLine($" Press <Enter> for return to MENU. ");
                Console.ReadKey();
            }


        }
    }
}
