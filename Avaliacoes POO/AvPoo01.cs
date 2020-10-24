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
    p.nome = n;
    p.area = km2;
    p.populacao = pop;
    Console.WriteLine("---------------------------\n");
    Console.WriteLine($"Pais: {p.nome}");
    Console.WriteLine($"Area: {p.area:0.00} km2");
    Console.WriteLine($"Populacao: {p.populacao:0} habitantes");
    Console.WriteLine($"Densidade Demografica: {p.DensidadeDemografica():0.000} habitantes/km2");
    return;
  }

}

class Pais {

  public string nome;
  public double area;
  public double populacao;

  public double DensidadeDemografica() {
    return populacao/area;
  }

}