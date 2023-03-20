# Banken_2023

Simple console app to to mimic the functions of a bank created with C#, Spectre.Console, MSSQL and Entity Framework.
In the app its possible to see bank balance, withdraw, deposit and transfer money between accounts.

## General Info

### Styling

This project utilizes Spectre.Console.

It is an open-source .NET library that makes it easier to create beautiful console applications.

### Class Structure

Classes are arranged in four separate folders:

* "Models" folder contains classes mapping DB tables.

* "UI" folder contains the menu class and respective functions.

### Repository

The "Repo" folder contains a DataAccess class that connects to the MSSQL database with the help of Entity. All functions related to accounts can be found in the AccountRepo class, the functions related to users in the userrepo class. These then communicate with the DataAcess class, which further establishes separations och conern.
