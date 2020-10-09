using System;

class MainClass {
  public static void Main (string[] args) {
    double b, h, a, p, d;
    Console.WriteLine ("Digite a base e a altura do retângulo");
    b = double.Parse(Console.ReadLine());
    h = double.Parse(Console.ReadLine());
    a = b * h;
    p = 2 * (b + h);
    d = Math.Sqrt(b*b + h*h);
    Console.WriteLine ($"Área = {a:0.00} - Perímetro = {p:0.00} - Diagonal = {d:0.00}");    
  }
}
