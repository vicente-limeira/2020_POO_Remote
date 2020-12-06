using System;

class MainClass {
  public static void Main (string[] args) {
    Retangulo r = new Retangulo(10,20);
    Console.WriteLine(r);
    Retangulo q1 = new Quadrado(10);
    Console.WriteLine(q1);
    Quadrado q2 = new Quadrado(20);
    Console.WriteLine(q2);    
  }
}

class Retangulo {
  private double b, h;
  public Retangulo (double b, double h) {
    this.b = b;
    this.h = h;
  }
  public double GetBase() {
    return this.b;
  }
  public double GetAltura() {
    return this.h;
  }
  public double CalcArea() {
    return b*h;
  }
  public double CalcDiagonal() {
    return Math.Sqrt(b*b+h*h);
  }
  public override string ToString() {
    return $"\nRetangulo de base: {this.b:0.00}, altura: {this.h:0.00}, area: {CalcArea():0.00} e Diagonal: {CalcDiagonal():0.00}\n";
  }
}

class Quadrado : Retangulo {
  public Quadrado (double l) : base(l,l) {}
  public override string ToString() {
    return $"\nQuadrado de lado: {base.GetBase():0.00}, area: {base.CalcArea():0.00}, e diagonal: {base.CalcDiagonal():0.00}\n";
  }

}
