using System;

class MainClass {
  public static void Main (string[] args) {
    
    string input;
    string letra;
    string[] palavra = new string[50];
    char yn;
 
    while (true) {

      input = Console.ReadLine();
      if (input == "*") break;

      letra = input.Substring(0,1) ;
      palavra = input.Split();
      yn = 'Y';

 //     for (int i=0;i<palavra.Length;i++) Console.Write($"{palavra[i]}\n");

      foreach (string p in palavra) {
 //       Console.Write($"{p}\n");
          if (p.Substring(0,1) != letra) {
              yn = 'N';
              break;
          }
      }
     Console.WriteLine($"{yn}");
    }
  }
}