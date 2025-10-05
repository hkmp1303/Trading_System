namespace Trading_System;

class Item
{
    public string Name;
    public string Description;

    public static Dictionary<string, List<Item>> itemsByUser = new Dictionary<string, List<Item>>();
    public Item(string name, string description)
    {
        Name = name;
        Description = description;
    }
    public static void itemMenu(string loggedInUser)
    {
        Item_State item_State = Item_State.REGISTERING_NewItem;
        while (true)
        {
            //string itemSelection = Console.ReadLine() ?? "";
            switch (item_State)
            {
                case Item_State.REGISTERING_NewItem:
                    System.Console.Write("New Item Registration\nItem name: ");
                    string itemName = System.Console.ReadLine() ?? ""; // null coalesce, returns empty string if user input error
                    System.Console.Write("The best item descriptions include the color, size and type!\nItem description: ");
                    string itemDescription = System.Console.ReadLine() ?? "";
                    List<Item> loggedInUserItems;
                    if (!itemsByUser.TryGetValue(loggedInUser, out loggedInUserItems))
                    {
                        loggedInUserItems = new List<Item>();
                        itemsByUser.Add(loggedInUser, loggedInUserItems);
                    }
                    loggedInUserItems.Add(new Item(itemName, itemDescription));
                    System.Console.WriteLine("Do you have more? Type \"y\" to add another item.");
                    if ((System.Console.ReadLine() ?? "") != "y")
                    {
                        item_State = Item_State.SHOW_ItemInventory;
                    }
                    break;
                case Item_State.SHOW_ItemInventory:
                    System.Console.WriteLine("Availible items listed below!");
                    foreach (var Items in itemsByUser)
                    {
                        foreach (Item i in Items.Value)
                        {
                            System.Console.WriteLine(Items.Key+"\t"+i.Name+"\t"+i.Description);
                        }
                    }
                    System.Console.ReadLine();  // temp stop
                    break;
            }

        }


    }

}

enum Item_State
{
    SHOW_ItemInventory,
    REGISTERING_NewItem,
}
