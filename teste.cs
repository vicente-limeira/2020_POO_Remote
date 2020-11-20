using System;
using System.Collections;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {
    Aluno a1 = new Aluno {Nome = "Vicente Limeira", Matricula = "175.234-9", Idade = 52};
    Aluno a2 = new Aluno {Nome = "Maria Conceição", Matricula = "999.666-9", Idade = 24};
    Aluno a3 = new Aluno {Nome = "Jair  Bolsonaro", Matricula = "666.666-6", Idade = 62};
    Aluno a4 = new Aluno {Nome = "Gilber T. Silva", Matricula = "123.123-9", Idade = 48};
    Colecao<Aluno> c = new Colecao<Aluno>();
    c.Add(a1);
    c.Add(a2);
    c.Add(a3);

    Console.WriteLine();    
    foreach (Aluno a in c) Console.WriteLine(a);
    Console.WriteLine();
    c.Sort();
    foreach (Aluno a in c) Console.WriteLine(a);

    c.Remove(a1);
    c.Remove(a2);
    c.Add(a4);

    Console.WriteLine();    
    foreach (Aluno a in c) Console.WriteLine(a);
    Console.WriteLine();
    c.Sort();
    foreach (Aluno a in c) Console.WriteLine(a);
  }
}

//-----------------------------------------
class Aluno : IComparable<Aluno> {
  public  string Nome {get; set;}
  public  string Matricula {get; set;}
  public  int Idade {get; set;}

  public override string ToString() {
    return $"{this.Nome} {this.Matricula} {this.Idade}";
  }

  public int CompareTo(Aluno obj) {
    return this.Nome.CompareTo(obj.Nome);
  }

}

//-----------------------------------------
class Colecao<T> : IEnumerable<T> where T : IComparable<T> {
  
  private List<T> objs = new List<T>();
  
  public void Sort() {
    this.objs.Sort();
  }
  
  public IEnumerator<T> GetEnumerator() {
    return this.objs.GetEnumerator();
  }
  
  IEnumerator IEnumerable.GetEnumerator()
  {
    return this.GetEnumerator();
  }
  
  public void Add(T obj) {
    this.objs.Add(obj);
  }
  
  public void Remove(T o) {
    this.objs.Remove(o);
  }

}