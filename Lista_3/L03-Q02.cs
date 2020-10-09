using System;

class MainClass {
  public static void Main (string[] args) {
    string i = Console.ReadLine();
    string[] inteiro = i.Split();

    int a,b,maior;
    a = int.Parse(inteiro[0]);
    b = int.Parse(inteiro[1]);
    maior = (a+b+Math.Abs(a-b))/2;
    a = maior;
    b = int.Parse(inteiro[2]);
    maior = (a+b+Math.Abs(a-b))/2;    
    Console.WriteLine ($"{maior} eh o maior");
  }
}