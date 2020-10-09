using System;

class MainClass {
  public static void Main (string[] args) {
    int n1, n2, media;
    Console.WriteLine ("Informe a nota (0 a 100) do 1o. Bimestre");
    n1 = int.Parse(Console.ReadLine());
    Console.WriteLine ("Informe a nota (0 a 100) do 2o. Bimestre");
    n2 = int.Parse(Console.ReadLine());
    media = (n1 + n2) / 2;
    Console.WriteLine ($"Nota 1 = {n1}, Nota 2 = {n2}, Media = {media}");

  }
}
