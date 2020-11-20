using System;
using System.Collections;

class MainClass {

  public static void Main (string[] args) { 
    Fibonacci f = new Fibonacci();
    Console.WriteLine("\nFibonacci\n---------");
    Console.WriteLine($"{f.Iniciar()}\t{f.Proximo()}\t{f.Proximo()}\t{f.Proximo()}\t{f.Proximo()}\t{f.Proximo()}\t{f.Proximo()}\t{f.Proximo()}\t{f.Proximo()}\t{f.Proximo()}\t{f.Proximo()}\t{f.Proximo()}\t{f.Proximo()}\t{f.Proximo()}");

    PA pa = new PA(10,2);
    Console.WriteLine("\nFibonacci\n---------");
    Console.WriteLine($"{pa.Iniciar()}\t{pa.Proximo()}\t{pa.Proximo()}\t{pa.Proximo()}\t{pa.Proximo()}\t{pa.Proximo()}\t{pa.Proximo()}\t{pa.Proximo()}\t{pa.Proximo()}\t{pa.Proximo()}\t{pa.Proximo()}\t{pa.Proximo()}\t{pa.Proximo()}\t{pa.Proximo()}");

    return;
  }

}

interface ISequencia {
  int Iniciar();
  int Proximo();
}

class Fibonacci : ISequencia {

  private int nmenos2, nmenos1, n;

  public int Iniciar() {
    return 0;
  }
  public int Proximo() {
    if (n==0) {
      nmenos2 = 0;
      nmenos1 = 0;
      return n = 1;
    }
    nmenos2 = nmenos1;
    nmenos1 = n;
    return n = nmenos1 + nmenos2;
  }
}

class PA: ISequencia {

  private int primeiroElemento, razao;

  public PA(int p, int r) {
    this.primeiroElemento = p;
    this.razao = r;
  }

  public int Iniciar() {
    return this.primeiroElemento;
  }
  public int Proximo() {
    return this.primeiroElemento = primeiroElemento + this.razao;
  }

}