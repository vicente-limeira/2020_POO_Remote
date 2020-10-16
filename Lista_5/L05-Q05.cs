using System;

class MainClass {
  public static void Main (string[] args) {
    
    int j,k;
    string i;
    string[] input;
    int[] aposta = new int[6];
    int[] resultado = new int[6];
    string[] premio = {"azar","azar","azar","terno","quadra","quina","sena"};
 
//  Input da Aposta
    i = Console.ReadLine (); 
    input = i.Split();

    for (j=0;j<6;j++) aposta[j] = int.Parse(input[j]);

//  Input do Resultado
    i = Console.ReadLine (); 
    input = i.Split();

    for (j=0;j<6;j++) resultado[j] = int.Parse(input[j]);    

//  Verifica Acertos
    int acertos = 0;
    for (j=0;j<6;j++) 
      for (k=0;k<6;k++)
        if (aposta[k] == resultado[j]) {
          acertos++;
      }
    
//  Console.WriteLine($"{acertos}\n");
    Console.WriteLine($"{premio[acertos]}");
  }
}