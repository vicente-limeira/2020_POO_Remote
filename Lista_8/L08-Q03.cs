using System;
using System.Collections;

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
    lj.Inserir(app1);
    lj.Inserir(app2);
    lj.Inserir(app3);
    lj.Inserir(app4);
    
    Console.WriteLine("\nLista em ordem alfabética\n------------------------------");
    foreach (Aplicativo a in lj.Listar())
      Console.WriteLine(a);
    
    Console.WriteLine($"\nExcluindo {app2.Nome} ...");
    lj.Excluir(app2);

    Console.WriteLine("\nLista em ordem alfabética\n------------------------------");
    foreach (Aplicativo a in lj.Listar())
      Console.WriteLine(a);

    Console.WriteLine($"\nPesquisando {app1.Categoria}\n------------------------------");
    foreach (Aplicativo a in lj.Pesquisar(app1.Categoria))
      Console.WriteLine(a);

    Console.WriteLine("\nLista em ordem de preços\n------------------------------");
    foreach (Aplicativo a in lj.ListarPreco())
      Console.WriteLine(a);

    Console.WriteLine("\nTop 10\n------------------------------");
    Aplicativo[] apps = lj.Top10MaisCurtidos();
    for (int i=0; (i<10) && (i<apps.Length); i++)
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
  private Aplicativo[] apps;
  private int k;

  public string Nome { get; set; }
  public int Qtd { get {return k;} }

  public void Inserir(Aplicativo app) {
    
    if (this.k==0)
      this.apps = new Aplicativo[10];

    if (this.k>=this.apps.Length)
      Array.Resize(ref this.apps,this.apps.Length*2);

    apps[this.k++] = app;
    return;
  }

  public void Excluir(Aplicativo app) {
    Aplicativo[] novo = new Aplicativo[this.apps.Length];
    int i=0;
    foreach (Aplicativo a in Listar()) {
      if (a.CompareTo(app)!=0)
        novo[i++]=a;
    }

    this.k=i;
    if (i>0)
      Array.Copy(novo, this.apps, i);

    return;
  }

  public Aplicativo[] Listar() {    
    Aplicativo[] lista = new Aplicativo[this.k];
    Array.Copy(this.apps, lista, this.k);
    Array.Sort(lista);
    return lista;
  }

  public Aplicativo[] Pesquisar(string cat) {    
    Aplicativo[] lista = new Aplicativo[this.k];
    int i=0;
    foreach (Aplicativo a in Listar()) {
      if (a.Categoria == cat) {
        lista[i]=a;
        i++;
      }
    }
    Array.Resize(ref lista,i);
    Array.Sort(lista);
    return lista;
  }

  public Aplicativo[] ListarPreco() {    
    Aplicativo[] lista = new Aplicativo[this.k];
    PrecoComp pc = new PrecoComp();
    Array.Copy(this.apps, lista, this.k);
    Array.Sort(lista, pc);
    return lista;
  }

  public Aplicativo[] Top10MaisCurtidos() {    
    Aplicativo[] lista = new Aplicativo[this.k];
    CurtidasComp cc = new CurtidasComp();
    Array.Copy(this.apps, lista, this.k);
    Array.Sort(lista, cc);
    return lista;
  }
}

class PrecoComp : IComparer {
  public int Compare(object x, object y) {
    Aplicativo a = (Aplicativo)x;
    Aplicativo b = (Aplicativo)y;
    return a.Preco.CompareTo(b.Preco);
  }
}

class CurtidasComp : IComparer {
  public int Compare(object x, object y) {
    Aplicativo a = (Aplicativo)x;
    Aplicativo b = (Aplicativo)y;
    return -a.Curtidas.CompareTo(b.Curtidas);
  }
}