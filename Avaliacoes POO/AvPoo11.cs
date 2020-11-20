using System;
using System.Collections;
using System.Collections.Generic;

class MainClass {

  public static void Main (string[] args) {

    Aplicativo app1 = new Aplicativo();
    app1.Nome = "Windows 10";
    app1.Categoria = "Sistema Operacional";
    app1.Preco = 5.50M;
    app1.Curtir();
    
    Aplicativo app2 = new Aplicativo();
    app2.Nome = "AutoCad";
    app2.Categoria = "Desenho Técnico";
    app2.Preco = 12000.00M;

    Aplicativo app3 = new Aplicativo();
    app3.Nome = "Sketshup";
    app3.Categoria = "Desenho Técnico";
    app3.Preco = 6500.00M;

    Aplicativo app4 = new Aplicativo();
    app4.Nome = "Word";
    app4.Categoria = "Automação de Escritório";
    app4.Preco = 158.65M;

    app1.Curtir();
    app1.Curtir();
    app2.Curtir();
    app2.Curtir();
    app3.Curtir();

    Loja lj = new Loja();
    
    lj.Nome = "Miranda Computação";
    
    Console.WriteLine("Incluindo ...");
    lj.Inserir(app1);
    Console.WriteLine("Incluindo ...");
    lj.Inserir(app2);
    Console.WriteLine("Incluindo ...");
    lj.Inserir(app3);
    Console.WriteLine("Incluindo ...");
    lj.Inserir(app4);
    
    Console.WriteLine("\nLista em ordem alfabética\n------------------------------");
    foreach (Aplicativo a in lj.Listar())
      Console.WriteLine(a);
    
    Console.WriteLine($"\nExcluindo {app2.Nome} ...");
    lj.Excluir(app2);

    Console.WriteLine("\nLista em ordem alfabética\n------------------------------");
    foreach (Aplicativo a in lj.Listar())
      Console.WriteLine(a);

    Console.WriteLine($"\nPesquisando categoria {app1.Categoria}\n------------------------------");
    foreach (Aplicativo a in lj.Pesquisar(app1.Categoria))
      Console.WriteLine(a);

    Console.WriteLine("\nLista em ordem de preços\n------------------------------");
    foreach (Aplicativo a in lj.ListarPreco())
      Console.WriteLine(a);

    Console.WriteLine("\nTop 10\n------------------------------");
    List<Aplicativo> apps = lj.Top10MaisCurtidos();
    for (int i=0; (i<10) && (i<apps.Count); i++)
      Console.WriteLine(apps[i]);

    return;
  }
}

class Aplicativo : IComparable {

  private int curtidas;
  public string Nome { get; set; }
  public string Categoria { get; set; }
  public decimal Preco { get; set; }
  public int Curtidas { get {return curtidas;} }
  
  public void Curtir() {
    this.curtidas++;
    return;
  }

  public override string ToString() {
    return $"Nome: {this.Nome}, Categoria: {this.Categoria}, Preço: {this.Preco}, Curtidas: {this.Curtidas}";
  }

  public int CompareTo(object obj) {
    Aplicativo a = (Aplicativo) obj;
    return this.Nome.CompareTo(a.Nome);
  }

}

class Loja {
  private List<Aplicativo> apps = new List<Aplicativo>();

  public string Nome { get; set; }
  public int Qtd { get {return apps.Count;} }

  public void Inserir(Aplicativo app) {
    Console.WriteLine(app);
    this.apps.Add(app);
    return;
  }

  public void Excluir(Aplicativo app) {
    this.apps.Remove(app);
    return;
  }

  public List<Aplicativo> Listar() {
    this.apps.Sort();
    return this.apps;
  }

 
  public List<Aplicativo> Pesquisar(string cat) {    
    List<Aplicativo> lista = new List<Aplicativo>();
    int i=0;
    foreach (Aplicativo app in this.Listar()) {
      if (app.Categoria == cat) {
        lista.Add(app);
      }
    }
    return lista;
  }

  public List<Aplicativo> ListarPreco() {    
    this.apps.Sort(new PrecoComp());
    return this.apps;
  }

  public List<Aplicativo> Top10MaisCurtidos() {
    IComparer<Aplicativo> cc = new CurtidasComp();
    this.apps.Sort(cc);
    return this.apps;
  }
}
/*
class PrecoComp : IComparer {
  public int Compare(object x, object y) {
    Aplicativo a = (Aplicativo)x;
    Aplicativo b = (Aplicativo)y;
    return a.Preco.CompareTo(b.Preco);
  }
}
*/
class PrecoComp : IComparer<Aplicativo> {
  public int Compare(Aplicativo x, Aplicativo y) {
    return x.Preco.CompareTo(y.Preco);
  }
}

class CurtidasComp : IComparer<Aplicativo> {
  public int Compare(Aplicativo x, Aplicativo y) {
    return -x.Curtidas.CompareTo(y.Curtidas);
  }
}