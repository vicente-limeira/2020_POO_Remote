using System;

class MainClass {
  public static void Main (string[] args) {
    
    int i = 0;
    double[] nota = new double[2];

    while (i<2) {
      nota[i] = double.Parse(Console.ReadLine());
      if (nota[i]<0 || nota[i]>10) {
        Console.Write("nota invalida\n");
        continue;
      }
      i++;
    }

    double media = (nota[0]+nota[1])/2;
    Console.Write($"media = {media:0.00}\n");
  }
}