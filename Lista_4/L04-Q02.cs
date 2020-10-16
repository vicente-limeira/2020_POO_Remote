using System;

class MainClass {
  public static void Main (string[] args) {
    
    int t = int.Parse(Console.ReadLine());
    int v = int.Parse(Console.ReadLine ());
    double kml = 12;

    double l = v*t/kml;

    Console.Write($"{l:0.000}");
  }
}