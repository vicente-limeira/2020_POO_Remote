using System;

class MainClass {

  public static void Main (string[] args) {
    
    double r = double.Parse(Console.ReadLine());
    Circulo c = new Circulo();
    c.SetRaio(r);
    Console.WriteLine($"Raio: {c.GetRaio()}");
    Console.WriteLine($"Area: {c.CalcArea()}");
    Console.WriteLine($"Perimetro: {c.CalcCircunferencia()}\n");
  }

}

class Circulo {

  const double pi = 3.14159;
  private double raio;

  public void SetRaio(double v) {
    if (v>0) raio = v;
    return;
  }

  public double GetRaio() {
    return raio;
  }

  public double CalcArea() {
    double area = pi*raio*raio;
    return area;
  }

  public double CalcCircunferencia() {
    double perimetro = 2*pi*raio;;
    return perimetro;
  }
  }