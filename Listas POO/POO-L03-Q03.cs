using System;

class MainClass {
// incompleto.
  public static void Main (string[] args) {
    
    Console.WriteLine("\nCalculando Frete ...");
    Console.WriteLine("Informe a Distancia (Km)");
    double d = double.Parse(Console.ReadLine());    
    Console.WriteLine("Informe o Peso (Kg)");
    double p = double.Parse(Console.ReadLine());

    Frete f = new Frete(d, p);
    
    Console.WriteLine("---------------------------\n");
    Console.WriteLine($"Distancia: {f.GetDistancia():0.00}");
    Console.WriteLine($"Peso: {f.GetPeso():0.00}");
    Console.WriteLine($"Valor do Frete: R$ {f.CalcFrete():0.00}");

    Console.WriteLine("---------------------------\n");
    f.SetDistancia(d*10);
    f.SetPeso(p*3);
    Console.WriteLine($"Valores modificados para:\n{f}");

    Console.WriteLine($"Valor do Frete: {f.CalcFrete():0.00}");

    Console.WriteLine("---------------------------\n");    

    return;
  }

}

class Conversor {

  private int num;

  public Conversor(int num) {
    if (num>0) this.num = num;
    return;
  }

  public double GetNum() {
    return num;
  }

  public void SetNum(int num) {
    if (num>0) this.num = num;
    return;
  }

  public string Binario() {
    int resto, q;
    string result = "";
    for (i=0;i!=num) {
        q = resto / 2;
        resto = resto % 2;

    } while ();

    return "*";
  }

  public override string ToString() {
    return $"O numero {num:0.00} em codigo binario eh {Binario()}.";
  }

  void ConvertToBinary(int n)
{
    if (n / 2 != 0) {
        ConvertToBinary(n / 2);
    }
    printf("%d", n % 2);
}
}