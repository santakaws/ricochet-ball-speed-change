/*
Brennon Hahs
The string: “Midterm #2”
Today’s date: November 8, 2021
course number: CPSC 223N-1


*/

using System;
using System.Windows.Forms;

public class speedChangerMain {
    static void Main(string[] args) {
        System.Console.WriteLine("Welcome to the Main method of the Speed Changer program.");
        speedChangerUI speedChng = new speedChangerUI();
        Application.Run(speedChng);
        System.Console.WriteLine("Main method will now shutdown.");
    }
}