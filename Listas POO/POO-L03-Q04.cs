using System;

class MainClass {

  public static void Main (string[] args) {
    
    double x1, x2;
    double x, y, z;

    Console.WriteLine("\nCalculando Equacao do 2o. grau ...");
    Console.WriteLine("Informe 'a'");
    double a = double.Parse(Console.ReadLine());    
    Console.WriteLine("Informe 'b'");
    double b = double.Parse(Console.ReadLine());
    Console.WriteLine("Informe 'c'");
    double c = double.Parse(Console.ReadLine());
    
    Equacao e = new Equacao(a,b,c);
    e.GetABC(out x, out y, out z);
    
    Console.WriteLine("---------------------------");
    Console.WriteLine($"a: {x:0.00}");
    Console.WriteLine($"b: {y:0.00}");
    Console.WriteLine($"c: {z:0.00}");

    if (!e.RaizesReais(out x1, out x2))
      Console.WriteLine("Equacao nao possui raizes reais.");
    else
      Console.WriteLine($"Raizes: {x1:0.00} e {x2:0.00}");
    
    Console.WriteLine("---------------------------");
    e.SetABC(a*1.2, b*-1, c-2.3);
 
    Console.WriteLine($"Valores modificados para:\n{e}");

    if (!e.RaizesReais(out x1, out x2))
      Console.WriteLine("Equacao nao possui raizes reais.");
    else
      Console.WriteLine($"Raizes: {x1:0.00} e {x2:0.00}");

    Console.WriteLine("---------------------------\n");    

    return;
  }

}

class Equacao {

  private double a,b,c;

  public Equacao(double a, double b, double c) {
    this.a = a;
    this.b = b;
    this.c = c;
    return;
  }

  public void GetABC(out double a, out double b, out double c) {
    a = this.a;
    b = this.b;
    c = this.c;
    return;
  }

  public void SetABC(double a, double b, double c) {
    this.a = a;
    this.b = b;
    this.c = c;
    return;
  }  

  public bool RaizesReais (out double x1, out double x2) {
    x1=0;
    x2=0;
    double delta = Delta();
    if (delta >= 0) {
        x1 = (-b + Math.Sqrt(delta)) /(2*a);
        x2 = (-b + Math.Sqrt(delta)) /(2*a);
        return true;
    }
    return false;
  }

  public double Delta() {
    return b*b - 4*a*c;
  }

  public override string ToString() {
    return $"a = {a:0.00}, b = {b:0.00}, c = {c:0.00}";
  }
}