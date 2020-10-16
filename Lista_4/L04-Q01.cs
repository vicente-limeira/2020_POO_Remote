using System;

class MainClass {
  public static void Main (string[] args) {
    
    string i = Console.ReadLine ();
    
    string[] input = i.Split();
    
    double a = double.Parse(input[0]);
    double b = double.Parse(input[1]);
    double c = double.Parse(input[2]);

    double pi = 3.14159;
    double triangulo = a*c/2;
    double circulo = pi*c*c;
    double trapezio = ((a+b)/2)*c;
    double quadrado = b*b;
    double retangulo = a*b;

    Console.Write($"TRIANGULO: {triangulo:0.000}\n");
    Console.Write($"CIRCULO: {circulo:0.000}\n");
    Console.Write($"TRAPEZIO: {trapezio:0.000}\n");
    Console.Write($"QUADRADO: {quadrado:0.000}\n");
    Console.Write($"RETANGULO: {retangulo:0.000}\n");
  }
}