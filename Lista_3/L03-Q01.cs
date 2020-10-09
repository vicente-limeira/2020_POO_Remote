using System;

class MainClass {
  public static void Main (string[] args) {
    string nome = Console.ReadLine ();
    double salario = double.Parse(Console.ReadLine ());
    double vendas = double.Parse(Console.ReadLine ());
    double comissao = salario + (vendas * 0.15);
    Console.WriteLine ($"TOTAL = R$ {Math.Round(comissao,2):0.00}");
  }
}