using System;

class MainClass {

  public static void Main (string[] args) {
    
    double r = double.Parse(Console.ReadLine());
    Circulo c = new Circulo();
    c.SetRaio(r);
    Console.WriteLine($"Raio: {c.GetRaio()}");
    Console.WriteLine($"Area: {c.GetArea()}");
    Console.WriteLine($"Perimetro: {c.GetPerimetro()}\n");
  }

}

class Circulo {

  const double pi = 3.14159;
  private double raio;

  public void SetRaio(double r) {
    if (r>0) raio = r;
  }

  public double GetRaio() {
    return raio;
  }

  public double GetArea() {
    return pi*raio*raio;
  }

  public double GetPerimetro() {
    return 2*pi*raio;
  }
}