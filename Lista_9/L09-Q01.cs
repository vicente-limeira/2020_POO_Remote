using System;
using System.Collections;

class MainClass {

  public static void Main (string[] args) {
    DisciplinaSemestral ds1 = new DisciplinaSemestral("POO",100,100,0);
    Console.WriteLine($"{ds1.GetNome()}\t{ds1.CalcMediaParcial()}\t{ds1.CalcMediaFinal()}");
    DisciplinaSemestral ds2 = new DisciplinaSemestral("Algoritmos",80,40,60);
    Console.WriteLine($"{ds2.GetNome()}\t{ds2.CalcMediaParcial()}\t{ds2.CalcMediaFinal()}");
    DisciplinaAnual da1 = new DisciplinaAnual("Programação",70,70,40,40,0);
    Console.WriteLine($"{da1.GetNome()}\t{da1.CalcMediaParcial()}\t{da1.CalcMediaFinal()}");       
    return;
  }
}

interface IDisciplica {
  string GetNome();
  int CalcMediaParcial();
  int CalcMediaFinal();
}

class DisciplinaSemestral : IDisciplica {
  private string nome;
  private int nota1, nota2, notafinal;

  public DisciplinaSemestral(string nome, int n1, int n2, int nf) {
    this.nome = nome;
    this.nota1 = n1;
    this.nota2 = n2;
    this.notafinal = nf;
  }

  public string GetNome() {
    return this.nome;
  }
  public int CalcMediaParcial() {
    return (this.nota1*2)+(this.nota2*3)/5;
  }
  public int CalcMediaFinal() {
    return (CalcMediaParcial()+this.notafinal)/2;
  }

}

class DisciplinaAnual : IDisciplica {
  private string nome;
  private int nota1, nota2, nota3, nota4, notafinal;

  public DisciplinaAnual(string nome, int n1, int n2, int n3, int n4, int nf) {
    this.nome = nome;
    this.nota1 = n1;
    this.nota2 = n2;
    this.nota3 = n3;
    this.nota4 = n4;
    this.notafinal = nf;
  }

  public string GetNome() {
    return this.nome;
  }
  public int CalcMediaParcial() {
    return ((this.nota1+this.nota2)*2+(this.nota3+this.nota4)*3)/10;
  }
  public int CalcMediaFinal() {
    return (CalcMediaParcial()+this.notafinal)/2;
  }

}