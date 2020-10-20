using System;

class MainClass {

  public static void Main (string[] args) {
    
    double n = double.Parse(Console.ReadLine());
    int i=0, f=0;
    Intervalo(n, out i, out f);
    Console.WriteLine($"Intervalo: [{i},{f}]");
  }

  public static void Intervalo (double x, out int inicio, out int fim) {
    inicio = (int)x;
    fim = inicio+1;
    return;
  }
}