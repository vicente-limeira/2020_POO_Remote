using System;
using System.Globalization;
using System.Threading;
using System.Collections.Generic;

[Flags]
public enum Menu {
  Sair      = 0,
  Incluir   = 1,
  Excluir   = 2,
  Listar    = 3,
  Pesquisar = 4
}

class MainClass {
  public static void Main (string[] args) {

    CultureInfo ci = new CultureInfo("pt-BR");
    Thread.CurrentThread.CurrentCulture = ci;

    Agenda agenda = new Agenda();
    Menu op;

    while (true) {
      Console.WriteLine("\nDigite a opção\n------------\n");
      Console.WriteLine(">0 Sair");
      Console.WriteLine(">1 Incluir");
      Console.WriteLine(">2 Excluir");
      Console.WriteLine(">3 Listar");
      Console.WriteLine(">4 Pesquisar por mês/ano");
      Console.Write(">");
      op = (Menu) int.Parse(Console.ReadLine());
      switch (op) 
      {
         case Menu.Sair:
            return;
         case Menu.Incluir:
            Form.Inserir(agenda);
            continue;
         case Menu.Excluir:
            Form.Excluir(agenda);
            continue;
         case Menu.Listar:
            Form.Listar(agenda);
            continue;
         case Menu.Pesquisar:
            Form.Pesquisar(agenda);
            continue;            
         default:
            Console.WriteLine("Opção inválida.");
            continue;
      }
    }
  }
}

class Form {
  public static void Inserir(Agenda a) {

    Console.WriteLine("\nNovo Compromisso");
    Console.Write("Assunto: ");
    string assunto = Console.ReadLine();
    Console.Write("Local: ");
    string local = Console.ReadLine();
    Console.Write("Data: ");
    DateTime data = DateTime.Parse(Console.ReadLine());

    Compromisso c = new Compromisso();
    c.Assunto = assunto;
    c.Local = local;
    c.Data = data;

    try {
      a.Inserir(c);
    } catch (InvalidOperationException) {
      Console.WriteLine("\n* Compromisso já está agendado.");
    }
  
    return;
  }

  public static void Listar(Agenda a) {
    Console.WriteLine($"\n{a.Qtd} Compromisso(s)\n--------------------");
    foreach (Compromisso c in a.Listar())
      Console.WriteLine(c);
    Console.WriteLine();
  }

  public static void Pesquisar(Agenda a) {
    Console.WriteLine("\nDados da Pesquisa");
    Console.Write("Mês: ");
    int mm = int.Parse(Console.ReadLine());
    Console.Write("Ano: ");
    int yy = int.Parse(Console.ReadLine());

    Console.WriteLine();
    foreach (Compromisso c in a.Pesquisar(mm, yy))
      Console.WriteLine(c);
    Console.WriteLine();
  }  

  public static void Excluir(Agenda a) {
    Console.WriteLine("\nInforme o Compromisso para excluir:");
    Console.Write("Assunto: ");
    string assunto = Console.ReadLine();
    Compromisso c = a.Listar().Find(x => x.Assunto == assunto);
    if (c == null)
      Console.WriteLine("\n* Compromisso não existe.");
    else
      a.Excluir(c);
    return;
  }

}

class Compromisso {
  public string Assunto { get; set; }
  public string Local { get; set; }
  public DateTime Data { get; set; }

  public override string ToString() {
    return $"{this.Assunto}, Local: {this.Local}, Data: {this.Data}.";
  }
}

class Agenda {
  private List<Compromisso> comps = new List<Compromisso>();
  private int k;
  public int Qtd { get {return k;} }

  public void Inserir(Compromisso c) {
    if (this.Listar().Exists(x => x.Assunto == c.Assunto))
      throw new InvalidOperationException();

    this.comps.Add(c);
    this.k = this.comps.Count;
    return;
  }
  public void Excluir(Compromisso c) {
    if (!this.comps.Remove(c))
      throw new InvalidOperationException();
    this.k = this.comps.Count;
    return;
  }
  public List<Compromisso> Listar() {
    return comps;
  }
  public List<Compromisso> Pesquisar(int mes, int ano) {
    List<Compromisso> lista = this.Listar().FindAll(c => c.Data.Month == mes && c.Data.Year == ano);
    if (lista.Count == 0)
      Console.WriteLine("\n* Não existem compromissos para mês/ano informados.");
    return lista;
  }  
}