# Trading_System
A console based program written in C# (.NET 9) where users can trade items. Users self register and login to browse availble items, add their own items to the collective inventory and then start trading. The system was build for learning purposes.

system requirements:
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
- [ ] muliple user trades? "three way"
- [ ] custom column pad function to replace tabs in tables
- [ ] logout from anywhere in the program


## How to Run
git clone [git@github.com:hkmp1303/Trading_System.git](https://github.com/hkmp1303/Trading_System.git)

cd Trading_System

dotnet run

## Design Structure

A goal of this project was to practice using OOP

The project implements a state design pattern meaning internal program state changes alter object behavior.

The project benefits from this design patterns naturally dynamic qualities including having multiple states which each have unique behaviors. For example, being logged vs registering or logged out states. The design easily accomodates additional states.

## Data

The project uses CSV files for persistent data storage between sessions. The CSV file updates when data changes occur.

## Project Structure

UML State Machine Diagram to be added upon project completion.
