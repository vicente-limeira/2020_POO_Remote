using System;

class MainClass {
  public static void Main (string[] args) {
    
    string i = Console.ReadLine (); 
    string[] input = i.Split();
    int[] original = new int[3];
    int[] classificado = new int[3];
    
    int j;

    for (j=0;j<3;j++) original[j] = int.Parse(input[j]);
    Array.Copy(original,classificado,3);
    Array.Sort(classificado);

    for (j=0;j<3;j++) Console.WriteLine($"{classificado[j]}\n");
    Console.WriteLine("\n");    
    for (j=0;j<3;j++) Console.WriteLine($"{original[j]}\n");    
    
  }
}