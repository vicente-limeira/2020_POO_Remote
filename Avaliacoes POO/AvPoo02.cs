using System;

class MainClass {

  public static void Main (string[] args) {
    
    Console.WriteLine("Informe o nome de um pais");
    string n = Console.ReadLine();
    Console.WriteLine("Sua area em km2?");
    double km2 = double.Parse(Console.ReadLine());
    Console.WriteLine("Sua populacao?");
    double pop = double.Parse(Console.ReadLine());

    Pais p = new Pais();
    p.SetNome(n);
    p.SetArea(km2);
    p.SetPopulacao(pop);

    Console.WriteLine("---------------------------\n");
    Console.WriteLine($"Pais: {p.GetNome()}");
    Console.WriteLine($"Area: {p.GetArea():0.00} km2");
    Console.WriteLine($"Populacao: {p.GetPopulacao():0} habitantes");
    Console.WriteLine($"Densidade Demografica: {p.DensidadeDemografica():0.000} habitantes/km2");
    return;
  }

}

class Pais {

  private string nome;
  private double area;
  private double populacao;

  public string GetNome() {
    return nome;
  }

  public double GetArea() {
    return area;
  }

  public double Getpopulacao() {
    return populacao;
  }

  public void SetNome(string n) {
    if (n!="") nome = n;
    return;
  }

  public void SetArea(double a) {
    if (a>0) area = a;
    return;
  }

  public void SetPopulacao(double p) {
     if (p>0) populacao = p;
    return;
  }

  public double DensidadeDemografica() {
    return populacao/area;
  }

}