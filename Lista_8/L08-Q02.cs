using System;
using System.Collections;

class MainClass {

  public static void Main (string[] args) {

    QuadroMedalhas qm = new QuadroMedalhas();
    Pais a = new Pais("Brasil",20,30,10);
    qm.Inserir(a);
    Pais b = new Pais("Argentina",1,10,10);
    qm.Inserir(b);
    Pais c = new Pais("EUA",20,30,40);
    qm.Inserir(c);
    Pais d = new Pais("Russia",20,30,10);
    qm.Inserir(d);

    foreach (Pais item in qm.Listar()) {
      Console.WriteLine(item);
    }

    return;
  }
}

class Pais : IComparable {
  private string nome;
  private int ouro, prata, bronze;
  
  public Pais(string n, int o, int p, int b) {
    this.nome = n;
    this.ouro = o;
    this.prata = p;
    this.bronze = b;
  }

  public override string ToString() {
    return $"Nome: {this.nome}, Ouro: {this.ouro}, Prata: {this.prata}, Bronze: {this.bronze}";
  }

  public int CompareTo(object obj) {
    
    Pais p = (Pais) obj;

    int result = this.ouro.CompareTo(p.ouro);
    if (result==0) {
      result = this.prata.CompareTo(p.prata);
      if (result==0) {
        result = this.bronze.CompareTo(p.bronze);
        if (result==0) {
          result = -this.nome.CompareTo(p.nome);
        }
      }
    }

    return -result;
  }

}

class QuadroMedalhas {
  private Pais[] paises;
  private int indx;

  public QuadroMedalhas() {
    paises = new Pais[10];
  }

  public void Inserir(Pais p) {
    
    if (indx>=paises.Length)
      Array.Resize(ref this.paises,paises.Length*2);

    paises[this.indx++] = p;
    return;
  }

  public Pais[] Listar() {    
    Pais[] lista = new Pais[this.indx];
    Array.Copy(this.paises, lista, this.indx);
    Array.Sort(lista);
    return lista;
  }

}