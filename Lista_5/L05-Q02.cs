using System;

class MainClass {
  public static void Main (string[] args) {
    
    double n = double.Parse(Console.ReadLine());

    if (n>=0 && n<=25)
       Console.Write("Intervalo [0,25]\n");
    else if (n>25 && n<=50)
       Console.Write("Intervalo (25,50]\n");
    else if (n>50 && n<=75)
       Console.Write("Intervalo (50,75]\n");
    else if (n>70 && n<=100)
       Console.Write("Intervalo (75,100]\n");
    else
       Console.Write("Fora de intervalo\n");
  }
}