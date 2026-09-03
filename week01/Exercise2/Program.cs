using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage?");
        int percent = int.Parse(Console.ReadLine());

        string grade = "";
        string sign = "";

        if(percent>=90)
        {
             grade = "A";
        
        }
        else if(percent>=80)
        {
            grade = "B";
        }
        else if(percent>=70)
        {
            grade = "C";
        }
        else if(percent>=60)
        {
            grade = "D";
        }
        else
        {
            grade = "F";
        }

        int lastDigit = percent%10;

        if(lastDigit>=7)
        {
            sign = "+";
        }
        else if (lastDigit < 3)
        {
            sign = "-";
        }
        else
        {
            sign = "";
        }



         if (grade == "A")
        {
            sign = lastDigit < 3 ? "-" : "";
        }
         if (grade == "F")
        {
            sign = "";
        }

        Console.WriteLine($"Your grade is {grade}{sign}");

        if (percent >= 70)
        {
            Console.WriteLine("You passed!");
        }
        else
        {
            Console.WriteLine("Better luck next time!");
        }


    }
}