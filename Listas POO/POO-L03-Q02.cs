using System;

class MainClass {

  public static void Main (string[] args) {
    
    Console.WriteLine("\nCalculando Frete ...");
    Console.WriteLine("Informe a Distancia (Km)");
    double d = double.Parse(Console.ReadLine());    
    Console.WriteLine("Informe o Peso (Kg)");
    double p = double.Parse(Console.ReadLine());

    Frete f = new Frete(d, p);
    
    Console.WriteLine("---------------------------\n");
    Console.WriteLine($"Distancia: {f.GetDistancia():0.00}");
    Console.WriteLine($"Peso: {f.GetPeso():0.00}");
    Console.WriteLine($"Valor do Frete: R$ {f.CalcFrete():0.00}");

    Console.WriteLine("---------------------------\n");
    f.SetDistancia(d*10);
    f.SetPeso(p*3);
    Console.WriteLine($"Valores modificados para:\n{f}");

    Console.WriteLine($"Valor do Frete: {f.CalcFrete():0.00}");

    Console.WriteLine("---------------------------\n");    

    return;
  }

}

class Frete {

  private double distancia;
  private double peso;

  public Frete(double d, double p) {
    if (d>0) this.distancia = d;
    if (p>0) this.peso = p;
    return;
  }

  public double GetDistancia() {
    return distancia;
  }

  public double GetPeso() {
    return peso;
  }

  public void SetDistancia(double d) {
    if (d>0) this.distancia = d;
    return;
  }

  public void SetPeso(double p) {
    if (p>0) this.peso = p;
    return;
  }

  public double CalcFrete() {
    return 0.01*distancia*peso;
  }

  public override string ToString() {
    return $"Distancia = {distancia:0.00} km e Peso = {peso:0.00} kg";
  }
}