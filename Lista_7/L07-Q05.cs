using System;

class MainClass {

  public static void Main (string[] args) {
    
    string msg = Console.ReadLine();
    Console.WriteLine($"Novo texto: {FormatarTexto(msg)}");
  }

  public static string FormatarTexto (string texto) {
    string[] palavras = texto.Split();
    string result = "";
    foreach (string p in palavras) {
      p.Trim();
      if (p!="") result+=" " + p;
    }
    return result.Trim();
  }

}