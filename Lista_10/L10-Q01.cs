using System;
using System.Collections;
using System.Collections.Generic;

class MainClass {

  public static void Main (string[] args) {   
    Pilha<string> p = new Pilha<string>();
    p.Push("Vicente");
    p.Push("de");
    p.Push("Paiva");
    p.Push("Limeira");

    Form<string>.ListaOrdemChegada(p);
    Form<string>.ListaOrdemInversa(p);

    Console.WriteLine($"\nExcluindo o ultimo a chegar ...");
    p.Pop();
    Form<string>.ListaOrdemChegada(p);

    Console.WriteLine($"\nExcluindo o ultimo a chegar ...");
    p.Pop();
    Form<string>.ListaOrdemChegada(p);

    Console.WriteLine($"\nAgora com inteiros ...");

    Pilha<int> n = new Pilha<int>();
    n.Push(100);
    n.Push(7);
    n.Push(21);
    n.Push(19);

    Form<int>.ListaOrdemChegada(n);
    Form<int>.ListaOrdemInversa(n);

    Console.WriteLine($"\nExcluindo o ultimo a chegar ...");
    n.Pop();
    Form<int>.ListaOrdemChegada(n);

    Console.WriteLine($"\nExcluindo o ultimo a chegar ...");
    n.Pop();
    Form<int>.ListaOrdemChegada(n);

    return;
  }
}

public class Form<T> {
  public static void ListaOrdemChegada(Pilha<T> lista) {
    Console.WriteLine($"\nLista por ordem de Chegada: {lista.Count} itens");
    Console.WriteLine("--------------------------------------");
    foreach(T s in lista.List()) {
      Console.WriteLine(s.ToString());
    }
  }

  public static void ListaOrdemInversa(Pilha<T> lista) {
    Console.WriteLine($"\nLista Invertida {lista.Count} itens");
    Console.WriteLine("---------------------------------");
    foreach(T s in lista.Invert()) {
      Console.WriteLine(s.ToString());
    }  
  }  
}

public class Pilha<T> {
  private T[] objs = new T[10];
  private int k;
  public int Count { get {return this.k;} }
  
  public void Clear() {
    T[] vazio = new T[this.k];
    Array.Copy(vazio, this.objs, this.k);
    this.k=0;
    return;
  }

  public void Push(T obj) {
    if (this.k >= this.objs.Length)
      Array.Resize(ref this.objs, this.k*2);
    objs[this.k++] = obj;
    return;
  }

  public T Peek() {
    return this.objs[this.k];
  }

  public T Pop() {
    T result = this.objs[this.k];

    if (this.k>0) {
      result = this.objs[--this.k];
      T[] novoArray = new T[this.k];
      Array.Copy(this.objs, novoArray, this.k);
    }

    return result;
  }

  public T[] List() {
    T[] result = new T[this.k];
    Array.Copy(this.objs, result, this.k);
    return result;
  }

  public T[] Descending() {
    T[] result = new T[this.k];
    Array.Copy(this.objs, result, this.k);
    Array.Sort(result, new Teste());
    return result;
  }

  public T[] Invert() {
    T[] result = new T[this.k];
    Array.Copy(this.objs, result, this.k);
    Array.Reverse(result);
    return result;
  }

}

public class Teste : IComparer {
  public int Compare (object obj1, object obj2) {
    return -obj1.ToString().CompareTo(obj2.ToString());
  }
}
