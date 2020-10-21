using System;

class MainClass {

  public static void Main (string[] args) {
    int i, f;
    long s = 0;

    i = int.Parse(Console.ReadLine());
    f = int.Parse(Console.ReadLine());
    string validade = Util.Intervalo (i, f, out s) ? $"Valido = {s}" : "Invalido";
    Console.WriteLine($"Resultado {validade}");
  }
  
}

class Util {

    public static bool Intervalo(int inicio, int fim, out long soma) {
    soma = 0;
      if (fim<inicio) return false;
      for (int i=inicio;i<=fim;i++) soma+=i;
      return true;
  }

}