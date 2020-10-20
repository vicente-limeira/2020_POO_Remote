using System;

class MainClass {

  public static void Main (string[] args) {
    
    int[] n = new int[3];
    n[0] = int.Parse(Console.ReadLine());
    n[1] = int.Parse(Console.ReadLine());
    n[2] = int.Parse(Console.ReadLine());
    Ordenar(ref n[0],ref n[1], ref n[2]);
    Console.WriteLine($"Ordenados: {n[0]}, {n[1]} e {n[2]}.");
  }

  public static void Ordenar (ref int x, ref int y, ref int z) {
    int[] n = new int[3];
    n[0]=x;
    n[1]=y;
    n[2]=z;
    Array.Sort(n);
    x = n[0];
    y = n[1];
    z = n[2];
    return;
  }
}