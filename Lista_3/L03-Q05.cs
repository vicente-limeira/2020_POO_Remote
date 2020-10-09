using System;

class MainClass {
  public static void Main (string[] args) {
    int n, d;
    
    n = int.Parse(Console.ReadLine());
    
    Console.WriteLine (n);

    d = n/100;
    n = n%100;
    Console.WriteLine ($"{d} nota(s) de R$ 100,00");

    d = n/50;
    n = n%50;
    Console.WriteLine ($"{d} nota(s) de R$ 50,00");

    d = n/20;
    n = n%20;
    Console.WriteLine ($"{d} nota(s) de R$ 20,00");

    d = n/10;
    n = n%10;
    Console.WriteLine ($"{d} nota(s) de R$ 10,00");

    d = n/5;
    n = n%5;
    Console.WriteLine ($"{d} nota(s) de R$ 5,00");

    d = n/2;
    n = n%2;
    Console.WriteLine ($"{d} nota(s) de R$ 2,00");
    Console.WriteLine ($"{n} nota(s) de R$ 1,00");        
  }
}