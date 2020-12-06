using System;

class MainClass {
  public static void Main (string[] args) {
    FreteTerrestre ft1 = new FreteTerrestre(100,10);
    Console.WriteLine(ft1);
    Frete f1 = new FreteTerrestre(100,10);
    Console.WriteLine(f1);
    FreteAereo fa1 = new FreteAereo(100,10,10000M);
    Console.WriteLine(fa1);    
  }
}

abstract class Frete {
  protected double distancia, peso;
  public Frete(double d, double p) {
    this.distancia = d;
    this.peso = p;
  }
  public abstract decimal GetFrete();
  public override string ToString() {
    return $"(Frete) Distância: {this.distancia:0.00}, Peso: {this.peso:0.00}, Valor: {GetFrete():0.00}";
  }
}

class FreteTerrestre : Frete {
  public FreteTerrestre(double d, double p) : base(d,p) {}
  public override decimal GetFrete() {
    return 0.01M * (decimal)(this.distancia * this.peso);
  }
}

class FreteAereo : Frete {
  private decimal seguro;
  public FreteAereo(double d, double p, decimal s) : base(d,p) {
    this.seguro = s;
  }
  public override decimal GetFrete() {
    return (0.01M * (decimal)(this.distancia * this.peso))*2 + (0.01M * seguro);
  }  
  public override string ToString() {
    return $"(Frete Aereo) Distância: {this.distancia:0.00}, Peso: {this.peso:0.00}, Seguro: {this.seguro:0.00}, Valor: {GetFrete():0.00}";
  }
}
