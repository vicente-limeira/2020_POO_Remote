using System;

class MainClass {
// incompleto.
  public static void Main (string[] args) {
    
    Conversor conversor;

    Console.WriteLine("\nConvertendo numero em codigo decimal para binario ...");
    while (true) {
      Console.WriteLine("\nInforme um numero");
      int n = int.Parse(Console.ReadLine());    
      if (n == 0) break;

      conversor = new Conversor(n);
      Console.WriteLine($"{conversor}\n");
      Console.WriteLine("---------------------------");    
    }

   

    return;
  }

}

class Conversor {

  private int num;

  public Conversor(int num) {
    if (num>0) this.num = num;
    return;
  }

  public int GetNum() {
    return num;
  }

  public void SetNum(int num) {
    if (num>0) this.num = num;
    return;
  }

  public string Binario() {
    int resto = 1, quociente = num, n = num;
    char[] r = new char[16];;

    for (int i=0; i<16; i++) {
        quociente = n / 2;
        resto = n % 2;
        r[i]=char.Parse(resto.ToString());
        n = quociente;
    }

    Array.Reverse(r);
    string result = new String(r);
    return result;
  }


  public override string ToString() {
    return $"O numero {num} em codigo binario eh {Binario()}";
  }

}