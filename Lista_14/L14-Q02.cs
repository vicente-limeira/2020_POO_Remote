using System;

class MainClass {
  public static void Main (string[] args) {
    Frete f = new Frete(100,10);
    Console.WriteLine(f);
    FreteExpresso fe1 = new FreteExpresso(100,10,1000);
    Console.WriteLine(fe1);
    Frete fe2 = new FreteExpresso(100,10,1000);
    Console.WriteLine(fe2);    
  }
}

class Frete {
  private double distancia, peso;
  public decimal ValorFrete {
    get { return (decimal) (0.01 * this.distancia * this.peso); }
  }
  public double Distancia {
    get { return this.distancia;}
  }
  public double Peso {
    get { return this.peso;}
  }

  public Frete (double d, double p) {
    this.distancia = d;
    this.peso = p;
  }
  public override string ToString() {
    return $"\nFrete com distancia: {this.distancia:0.00}, peso: {this.peso:0.00} e valor: R$ {this.ValorFrete:0.00}\n";
  }
}

class FreteExpresso : Frete {
  private decimal seguro;
  public decimal ValorFrete {
    get { return 0.01M * seguro + (decimal) (2 * base.ValorFrete);}
  }
  public FreteExpresso (double d, double p, decimal s) : base(d, p) {
    this.seguro = s;
  }
  public override string ToString() {
    return $"\nFrete Expresso com distancia: {base.Distancia:0.00}, area: {base.Peso:0.00}, e valor: R$ {this.ValorFrete:0.00}\n";
  }

}
