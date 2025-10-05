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
                    if (!itemsByUser.TryGetValue(loggedInUser, out loggedInUserItems)) // check if user has registered items
                    {
                        loggedInUserItems = new List<Item>(); // creates new list if user does not have register items
                        itemsByUser.Add(loggedInUser, loggedInUserItems); // adding list to item by user index (ItemsbyUser dictionary)
                    }
                    loggedInUserItems.Add(new Item(itemName, itemDescription)); // adding new item to current (logged in) user
                    System.Console.WriteLine("Do you have more? Type \"y\" to add another item. Otherwise press any key to see the trade inventory.");
                    if ((System.Console.ReadLine() ?? "") != "y")
                    {
                        item_State = Item_State.SHOW_ItemInventory;
                    }
                    break;
                case Item_State.SHOW_ItemInventory:
                    System.Console.WriteLine("All availible items listed below!");
                    foreach (var Items in itemsByUser) // loops through all users with items
                    {
                        foreach (Item i in Items.Value) // loops through current users items, all items
                        {
                            System.Console.WriteLine(Items.Key+"\t"+i.Name+"\t"+i.Description); // printing all items inventory across users
                        }
                    }
                    System.Console.WriteLine("Type \"a\" to add more items or \"b\" to go back to the previous menu");
                    switch (System.Console.ReadLine() ?? "")
                    {
                        case "a":
                            item_State = Item_State.REGISTERING_NewItem;
                            break;
                        case "b":
                            return; // returns user to main menu in main loop
                    }
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
