using System;

class MainClass {
  public static void Main (string[] args) {

        ulong numero, i;
        double raiz;
        bool primo;
        
        int n = int.Parse(Console.ReadLine());
    
        for (int j=1; j<=n; j++) {
          
          numero = ulong.Parse(Console.ReadLine());
          primo = true;
          raiz = Math.Sqrt(numero);
          for (i=2; i<=raiz; i++) {
            if (numero % i == 0) {
                primo = false;
                break;
            }
          }    
          if (primo)
            Console.WriteLine("Prime");
          else
            Console.WriteLine("Not Prime");
        }
    }
}
