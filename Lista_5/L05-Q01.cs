using System;

class MainClass {
  public static void Main (string[] args) {
    
    string i = Console.ReadLine ();
    
    string[] input = i.Split();
    
    int a = int.Parse(input[0]);
    int b = int.Parse(input[1]);
    int c = int.Parse(input[2]);
    int d = int.Parse(input[3]);

    if (
        (b>c) &&
        (d>a) &&
        ((c+d)>(a+b)) &&
        (c>0) &&
        (d>0) &&
        (a%2==0)
      )
        Console.Write("Valores aceitos\n");
    else
      Console.Write("Valores nao aceitos\n");
  }
}