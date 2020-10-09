using System;

class MainClass {
  public static void Main (string[] args) {
    string[] p;

    p = Console.ReadLine().Split(); 
    float x1 = float.Parse(p[0]);
    float y1 = float.Parse(p[1]);

    p = Console.ReadLine().Split();
    float x2 = float.Parse(p[0]);
    float y2 = float.Parse(p[1]);

    double d = Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2-y1,2));

    Console.WriteLine ($"{d:0.0000}");
  }
}