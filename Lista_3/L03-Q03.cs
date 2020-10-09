using System;

class MainClass {
  public static void Main (string[] args) {
    int x = int.Parse(Console.ReadLine());
    decimal y = decimal.Parse(Console.ReadLine());
    decimal consumo = x/y;  
    Console.WriteLine ($"{consumo:0.000} km/l");
  }
}