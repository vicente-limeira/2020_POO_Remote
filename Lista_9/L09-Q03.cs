using System;
using System.Collections;

class MainClass {


  public static void Main (string[] args) { 

    int i, bolas = 10;
    Console.WriteLine($"\nBingo de {bolas} bolas\n-----------------------------");
    Bingo b = new Bingo();
    b.Iniciar(bolas);
    for (i=0;i<bolas;i++)    
      Console.WriteLine($"Sorteando ... {b.Proximo()}");

    Console.WriteLine("\nBolas sorteadas\n--------------------");
    foreach(int bola in b.Sorteados()) {
      Console.WriteLine($"{bola}\t");
    }

    Console.WriteLine($"\nMega Sena\n-----------------------------");
    Mega ms = new Mega();
    for (i=0;i<6;i++)
      Console.WriteLine($"Sorteando ... {ms.Proximo()}");

    Console.WriteLine("\nBolas sorteadas\n--------------------");
    foreach(int bola in ms.Sorteados()) {
      Console.WriteLine($"{bola}\t");
    }

    return;
  }

}


interface ISorteio {
  int Proximo();
  int[] Sorteados();
}

class Bingo : ISorteio {

  private int numBolas;
  private Random sorteio;
  private int k;
  public int[] bolasSorteadas;

  public void Iniciar(int b) {
    sorteio = new Random();
    this.numBolas = b;
    this.bolasSorteadas = new int[this.numBolas];  
    return;
  }

  public int Proximo() {
    int result = -1, next;
    if (this.k < this.numBolas) {
      do {
        next = sorteio.Next(1,this.numBolas+1);
      } while (Sorteou(next));

      this.bolasSorteadas[this.k++] = next;
      result = next;
    }
    return result;
  }

  public int[] Sorteados() {
    int[] result = new int[this.k];
    Array.Copy(this.bolasSorteadas, result, this.k);
    return result;
  }

  private bool Sorteou (int bola) {
    foreach(int sorteada in this.Sorteados()) {
      if (bola==sorteada) return true;
    }
    return false;
  }

}

class Mega : ISorteio {

  private Random sorteio;
  private int k;
  public int[] bolasSorteadas;

  public Mega() {
    sorteio = new Random();
    this.bolasSorteadas = new int[6];
    return;
  }

  public int Proximo() {
    int result = -1, next;
    if (this.k < 6) {
      do {
        next = sorteio.Next(1,61);
      } while (NaoSorteou(next));

      this.bolasSorteadas[this.k++] = next;
      result = next;
    }
    return result;
  }

  public int[] Sorteados() {
    int[] result = new int[this.k];
    Array.Copy(this.bolasSorteadas, result, this.k);
    return result;
  }

  private bool NaoSorteou (int bola) {
    if (bola==0) return true;
    foreach(int sorteada in this.Sorteados()) {
      if (bola==sorteada) return true;
    }
    return false;
  }
  
}