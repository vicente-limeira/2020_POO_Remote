using System;

class MainClass {
  public static void Main (string[] args) {
    string nome;
    Console.WriteLine ("Digite seu primeiro nome");
    nome = Console.ReadLine ();
    Console.WriteLine ($"Bem-vindo ao C#, {nome}.");
  }
}
