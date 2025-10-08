# Trading_System
A console based program written in C# (.NET 9) where users can trade items. The system was built for learning purposes.

### System requirements:
- [x] self registration, by user
- [x] log in
- [x] log out
- [x] upload info/description of items
- [x] browse other users items
- [ ] request trade
- [ ] accept trade requests
- [ ] deny trade requests
- [ ] browse completed requests

### Future feature creepers
- [ ] counter offers?
- [ ] value metrics?
- [ ] multiple items per trade? Collections or sets?
- [ ] multiple user trades? "three way"
- [ ] custom column pad function to replace tabs in tables
- [ ] logout from anywhere in the program


## 🚀 How to Run
```
git clone [git@github.com:hkmp1303/Trading_System.git](https://github.com/hkmp1303/Trading_System.git)

cd Trading_System

dotnet run
```
## 🦮 Quick guide

Users self register and login to browse available items, add their own items to the collective inventory and then start trading.

Follow console prompts to enter a username followed by a password for registered users. New users will receive a prompt which begins registration. 

Menus will display key letters for user selection to navigate the program.


## 🖌️ Design Structure

A goal of this project was to practice using OOP.

The project implements a state design pattern meaning internal program state changes alter object behavior.

The project benefits from this design pattern's naturally dynamic qualities including having multiple states which each have unique behaviors. For example, being logged vs registering or logged out states. The design easily accommodates additional states.

### Data

The project uses CSV files for persistent data storage between sessions. The CSV file updates when data changes occur.

### Project Structure

🚧 UML State Machine Diagram to be added upon project completion.
