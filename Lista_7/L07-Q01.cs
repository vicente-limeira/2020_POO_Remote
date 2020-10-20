using System;

class MainClass {

  public static void Main (string[] args) {
    
    double[] n = new double[2];
    n[0] = double.Parse(Console.ReadLine());
    n[1] = double.Parse(Console.ReadLine());
    double maior = Maior(n[0],n[1]);
    Console.WriteLine($"O maior numero entre {n[0]} e {n[1]} eh {maior}");
  }

  public static double Maior (double a, double b) {
    double m = b>a ? b : a; 
    return m;
  }
}