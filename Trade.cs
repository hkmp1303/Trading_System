namespace App;

class Trade
{
    public Trade_State Status; // trade status of indiviudal trades
    public Item Item;

    public static Dictionary<string, List<Trade>> tradesByUser = new Dictionary<string, List<Trade>>();
    public Trade(string username, Item item, Trade_State status) // trade object constructor
    {
        Item = item;
        Status = status;
    }

    public static void tradeMenu(string loggedInUser)
    {
        while (true)
        {
            Trade_State trade_State = Trade_State.SHOW_Menu;
            switch (trade_State)
            {
                case Trade_State.SHOW_Menu:
                    System.Console.WriteLine(("Ready to trade?!\nType \"t\" to start a trade\nType \"p\" to see pending trades\nType \"h\" to view your trade history\n\"b\" to return to the previous menu"));
                    switch (Console.ReadLine() ?? "")
                    {
                        case "t":  // request trade
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

