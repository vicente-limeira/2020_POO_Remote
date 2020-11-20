using System;
using System.Collections;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {
    Colecao<int> c = new Colecao<int>();
    c.Add(5);
    c.Add(3);
    c.Add(1);
    c.Sort();
    Console.WriteLine();
    foreach(int i in c) Console.WriteLine(i);
    c.Remove(5);
    Console.WriteLine();
    foreach(int i in c) Console.WriteLine(i);
    c.Add(55);
    c.Add(33);
    c.Add(11);
    Console.WriteLine();
    foreach(int i in c) Console.WriteLine(i);    
    c.Sort();
    Console.WriteLine();
    foreach(int i in c) Console.WriteLine(i);
  }
}

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