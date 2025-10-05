namespace App;

class Trade
{
    public Trade_State Status; // trade status of indiviudal trades
    public Item Item;
    public Item OwnItem;

    public static Dictionary<string, List<Trade>> tradesByUser = new Dictionary<string, List<Trade>>();
    private static Trade_State trade_State;
    public Trade(string username, Item item, Item ownItem, Trade_State status) // trade object constructor
    {
        Item = item;
        OwnItem = ownItem;
        Status = status;
    }

    public static void tradeMenu(string loggedInUser)
    {
        while (true)
        {
            trade_State = Trade_State.SHOW_Menu;
            switch (trade_State)
            {
                case Trade_State.SHOW_Menu:
                    System.Console.WriteLine(("Ready to trade?!\nType \"t\" to start a trade\nType \"p\" to see pending trades\nType \"h\" to view your trade history\n\"b\" to return to the previous menu"));
                    switch (Console.ReadLine() ?? "")
                    {
                        case "t":  // request trade
                            startTrade(loggedInUser);
                            break;
                        case "p":   // accept, deny requests
                            break;
                        case "h": // user history, completed trades
                            trade_State = Trade_State.SHOW_History;
                            break;
                        case "b":
                            return; // returns user to main menu in main loop
                    }
                    break;
            }
        }
    }

    public static void startTrade(string loggedInUser)
    {
        System.Console.WriteLine("");
        Dictionary<int, KeyValuePair<string, Item>> tradeItems = new Dictionary<int, KeyValuePair<string, Item>>();
        int i = 0;
        foreach (var userItems in Item.itemsByUser)
        {
            if (userItems.Key == loggedInUser) continue; // skip own items
            foreach (Item item in userItems.Value)
            {
                tradeItems.Add(i++, new KeyValuePair<string, Item>(userItems.Key, item));
                System.Console.WriteLine(i + ". " + userItems.Key + "\t" + item.Name + "\t" + item.Description);
            }
        }
        System.Console.WriteLine("Select a numbered item to trade or 0 to cancel");
        int itemSelection = 0;
        if (!int.TryParse(Console.ReadLine() ?? "0", out itemSelection))
        {
            itemSelection = 0;
        }
        if (itemSelection == 0)
        {
            trade_State = Trade_State.SHOW_Menu;
            System.Console.WriteLine("Trade canceled. ");
            return;
        }
        List<Trade> userTrades;
        string username = tradeItems[itemSelection - 1].Key; // username of selected item
        if (!tradesByUser.TryGetValue(loggedInUser, out userTrades)) // Verify list exists for logged in user
        {
            userTrades = new List<Trade>(); // create missing list if needed
            tradesByUser.Add(loggedInUser, userTrades); // add missing list to tradesByUser index
        }
        System.Console.WriteLine("What are you offering for this item? Select your item for this trade: ");
        i = 1;
        foreach (Item ownItem in Item.itemsByUser[loggedInUser])
        {
            System.Console.WriteLine(i + ". " + loggedInUser + "\t" + ownItem.Name + "\t" + ownItem.Description);
        }
        if (!int.TryParse(Console.ReadLine() ?? "0", out itemSelection))
        {
            itemSelection = 0;
        }
        if (itemSelection == 0)
        {
            trade_State = Trade_State.SHOW_Menu;
            System.Console.WriteLine("Trade canceled. ");
            return;
        }
        System.Console.WriteLine("Type your own item's number or 0 to cancel the trade.");
        userTrades.Add(new Trade(username, tradeItems[itemSelection - 1].Value, Item.itemsByUser[loggedInUser][itemSelection -1], Trade_State.PENDING_Trade)); // add trade to user trade list
        System.Console.WriteLine("Trade request created and pending");
    }

    public static void showHistory(string loggedInUser)
    {
        //TODO
    }
}

enum Trade_State
{
    SHOW_Menu,
    SHOW_History,
    PENDING_Trade,
    APPROVED,
    REJECTED,
    COUNTER,

}

