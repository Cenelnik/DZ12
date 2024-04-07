using System;
using System.Collections.Specialized;

namespace DZ12
{
    /// <summary>
    /// Пользователь, который будет получать рассылку на обновление списка товаров
    /// Реализованно чреез ObservableCollection 
    /// </summary>
    internal class Customer
    {
        /// <summary>
        /// Для обновления списка товаров: добавился новый товар или удалился старый. 
        /// </summary>
        public void OnItemChanged(object? sender, NotifyCollectionChangedEventArgs e)
        { 
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if(e.NewItems[0] is Item NewItem)
                    {
                        Console.WriteLine($"INFO FROM EVENT: Add new item - {NewItem.Name}");
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    
                    if (e.OldItems?[0] is Item OldItem)
                    {
                        Console.WriteLine($"INFO FROM EVENT: Old item was deleted: {OldItem.Name}");
                    }
                    break;
            }
        }
    }
}
