using System;

class MainClass {
  public static void Main (string[] args) {
    string nome, nome1;
    int indx;
    Console.WriteLine ("Digite seu nome completo");
    nome = Console.ReadLine();
    indx = nome.IndexOf(" ");
    indx = indx == -1 ? nome.Length : indx;
    nome1 = nome.Substring(0,indx);
    Console.WriteLine ($"Bem-vindo ao C#, {nome1}.");
  }
}
