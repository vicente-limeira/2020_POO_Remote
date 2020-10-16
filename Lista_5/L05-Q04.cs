using System;

class MainClass {
  public static void Main (string[] args) {
    
    int j;

    string i = Console.ReadLine (); 
    string[] input = i.Split();
    int[] carta = new int[5];
    int[] espelho = new int[5];

    for (j=0;j<5;j++) carta[j] = int.Parse(input[j]);

    Array.Copy(carta,espelho,5);

    bool classified = true;
    Array.Sort(espelho);

    for (j=0;j<5;j++) 
      if (carta[j] != espelho[j]) {
          classified = false;
          break;
      }
    
    if (classified) {
        Console.WriteLine("C\n");
        return;
    }
   
    classified = true;
    Array.Reverse(espelho);

    for (j=0;j<5;j++) 
      if (carta[j] != espelho[j]) {
          classified = false;
          break;
      }
    
    if (classified)
        Console.WriteLine("D\n");
    else
        Console.WriteLine("N\n");
  }
}