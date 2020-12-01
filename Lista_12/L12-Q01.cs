using System;
using System.Collections;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {
    Retangulo r = new Retangulo();

    while (true) {
      Console.WriteLine("\nRetângulo\n----------\n");
      try {
        Console.Write("Informe a Base: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Informe a Altura: ");
        double h = double.Parse(Console.ReadLine());
        r.SetBase(b);
        r.SetAltura(h);
      }
      catch (ArgumentOutOfRangeException) {
        Console.WriteLine($"Valor negativo inválido. Informe os dados novamente.");
        continue;
      }
      catch (Exception erro) {
        Console.WriteLine(erro.Message);
        return;
      }   
      Console.WriteLine(r);    
    }
  }
}

class Retangulo {
  private double b;
  private double h;
  public double Area { get {return this.b * this.h;} }
  public double Diagonal { get {return Math.Sqrt(b*b+h*h);} }

  public void SetBase (double _base) {
    if (_base < 0) {
      throw new ArgumentOutOfRangeException();
    } 
    this.b = _base;
    return;
  }
  public double GetBase () {
    return this.b;
  }
  public void SetAltura (double _altura) {
    if (_altura < 0) {
      throw new ArgumentOutOfRangeException();
    }
    this.h = _altura;
    return;
  }
  public double GetAltura () {
    return this.h;
  }
  public override string ToString() {
    return $"\nBase: {this.b}, Altura: {this.h}, Area: {this.Area:0.00}, Diagonal: {Diagonal:0.00}";
  }

}