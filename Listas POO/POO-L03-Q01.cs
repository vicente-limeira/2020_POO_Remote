using System;

class MainClass {

  public static void Main (string[] args) {
    
    Console.WriteLine("\nCalculando Area e Diagonal de um retangulo ...");
    Console.WriteLine("Informe a Base");
    double b = double.Parse(Console.ReadLine());    
    Console.WriteLine("Informe a Altura");
    double h = double.Parse(Console.ReadLine());

    Retangulo r = new Retangulo(b, h);
    
    Console.WriteLine("---------------------------\n");
    Console.WriteLine($"Base: {r.GetBase():0.00}");
    Console.WriteLine($"Altura: {r.GetAltura():0.00}");
    Console.WriteLine($"Area: {r.CalcArea():0.00}");
    Console.WriteLine($"Diagonal: {r.CalcDiagonal():0.00}");    

    Console.WriteLine("---------------------------\n");
    r.SetBase(b*2);
    r.SetAltura(h*3);
    Console.WriteLine($"Valores modificados para:\n{r}");
    Console.WriteLine($"Area: {r.CalcArea():0.00}");
    Console.WriteLine($"Diagonal: {r.CalcDiagonal():0.00}");

    Console.WriteLine("---------------------------\n");    

    return;
  }

}

class Retangulo {

  private double b;
  private double h;

  public Retangulo(double b, double h) {
    if (b>0) this.b = b;
    if (h>0) this.h = h;
    return;
  }

  public double GetBase() {
    return b;
  }

  public double GetAltura() {
    return h;
  }

  public void SetBase(double b) {
    if (b>0) this.b = b;
    return;
  }

  public void SetAltura(double h) {
    if (h>0) this.h = h;
    return;
  }

  public double CalcArea() {
    return b*h;
  }

  public double CalcDiagonal() {
    return Math.Sqrt (b*b+h*h);
  }

  public override string ToString() {
    return $"Base = {b:.00} e Altura = {h:0.00}";
  }
}