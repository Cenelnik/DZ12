using System;
using System.Collections.ObjectModel;

namespace DZ12
{
    /// <summary>
    /// В классе Shop должна храниться информация о списке товаров
    /// </summary>
    internal class Shop
    {
        public ObservableCollection<Item> ListOfGoods = new ObservableCollection<Item>();

        /// <summary>
        /// добавление товара
        /// </summary>
        public void Add(Item newItem)
        {
            Console.WriteLine($"\nList of goods was changed!");
            ListOfGoods?.Add(newItem);
            PublishNewListOfGoods();
        }

        /// <summary>
        /// удаление товара
        /// </summary>
        public void Remove(string name)
        {
            Console.WriteLine($"{ListOfGoods?.Where(x => x.Name == name).FirstOrDefault<Item>(new Item()).Name}");
            Item? itemForRemove = ListOfGoods?.Where(x => x.Name == name).FirstOrDefault<Item>(new Item()).Name == "" ? null : ListOfGoods?.Where(x => x.Name == name).FirstOrDefault<Item>(new Item());
            if (itemForRemove != null) 
            {
                Console.WriteLine($"\nList of goods was changed!");
                ListOfGoods.Remove(itemForRemove);
                PublishNewListOfGoods();
            } else
            {
                Console.WriteLine($"Uncorrect name of good.");
            }
        }
         
        private void PublishNewListOfGoods()
        {
            Console.WriteLine($"\n # # # # NEW LIST OF GOODS # # # # ");
            Console.WriteLine($"ID:LABLE");
            foreach (Item curItem in ListOfGoods)
            {
                Console.WriteLine($"{curItem.Id} : {curItem.Name}");
            }
        }
    }
}
