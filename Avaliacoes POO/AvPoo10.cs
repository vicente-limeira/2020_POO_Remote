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
    c.Add(a1); c.Add(a2); c.Add(a3);
    
    Console.WriteLine($"\n{c.Count} alunos.\n---------------------");
    foreach(Aluno aluno in c.Listar()) Console.WriteLine(aluno);

    c.Sort();
    Console.WriteLine($"\n{c.Count} alunos.\n---------------------");    
    foreach(Aluno aluno in c.Listar()) Console.WriteLine(aluno);

    Console.WriteLine($"\nRemovendo {a1.Nome} ...");
    c.Remove(a1);
    Console.WriteLine($"\n{c.Count} alunos.\n---------------------");    
    foreach(Aluno aluno in c.Listar()) Console.WriteLine(aluno);

    c.Add(a4);
    Console.WriteLine($"\n{c.Count} alunos.\n---------------------");    
    foreach(Aluno aluno in c.Listar()) Console.WriteLine(aluno);    
  }
}

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
class Colecao<T> : IEnumerable where T : IComparable<T>{
  
  public T[] objs = new T[10];
  private int k = 0;

  public int Count {
    get {return this.k;}
  }

  public IEnumerator GetEnumerator() {
    T[] v = new T[this.k];
    Array.Copy(this.objs,v,this.k);
    return v.GetEnumerator();
  }

  public void Add(T obj) {
    if (this.objs.Length <= this.k)
      Array.Resize(ref this.objs, this.objs.Length*2);
    this.objs[this.k++] = obj;
  }

  public T[] Listar() {
    T[] _objs = new T[this.k];
    Array.Copy(this.objs, _objs, this.k);
    return _objs;
  }

  public void Remove(T obj) {

    if (this.k > 0) {
      int j=0;
      T[] _objs = new T[this.k];
      for (int i=0; i<this.k; i++) {
        //if (this.objs[i] != obj) Não funciona para T.
        if (!this.objs[i].Equals(obj))
          _objs[j++] = this.objs[i];
      }
      this.k=j;
      Array.Copy(_objs,this.objs,this.k);
    }
    return;
  }

  public void Sort() {

    T[] result = new T[this.k];
    result = Listar();
    Array.Sort(result);
    Array.Copy(result, this.objs, this.k);
 
    return;
  }

}
