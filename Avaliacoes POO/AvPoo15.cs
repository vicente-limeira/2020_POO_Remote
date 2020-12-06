using System;

class MainClass {
  public static void Main (string[] args) {
    //int[] n1 = new int[3] {100, 26, 39};
    //DisciplinaAnual da1 = new DisciplinaAnual("POO",n1,0);
    int[] n2 = new int[4] {10, 26, 39, 97};
    DisciplinaAnual da2 = new DisciplinaAnual("POO",n2,0);
    Console.WriteLine(da2);
    Console.WriteLine($"Média Parcial: {da2.CalcMediaParcial()}, Final: {da2.CalcMediaFinal()}");
    //
    int[] n3 = new int[4] {10, 26, 39, 97};
    DisciplinaAnual da3 = new DisciplinaAnual("Algoritmos",n3,100);
    Console.WriteLine(da3);
    Console.WriteLine($"Média Parcial: {da3.CalcMediaParcial()}, Final: {da3.CalcMediaFinal()}");
    //
    int[] n4 = new int[2] {20, 26};
    DisciplinaSemestral ds1 = new DisciplinaSemestral("Matemática",n4,100);
    Console.WriteLine(ds1);
    Console.WriteLine($"Média Parcial: {ds1.CalcMediaParcial()}, Final: {ds1.CalcMediaFinal()}");    
  }
}

abstract class Disciplina {
  private string nome;
  private int notafinal;
  private int[] notas;

  public Disciplina(string nome, int[] notas, int nf) {
    for (int i=0;i<notas.Length;i++)
      if (notas[i] <0 || notas[i]>100) throw new ArgumentOutOfRangeException();
    
    this.nome = nome;
    this.notas = notas;
    this.notafinal = nf;
  }

  public string GetNome() {
    return this.nome;
  }
  public int[] GetNotas() {
    return this.notas;
  }
  public int GetNotaFinal() {
    return this.notafinal;
  }
  abstract public int CalcMediaParcial();
  abstract public int CalcMediaFinal();
  public override string ToString() {
    return $"Disciplina: {this.nome}";
  }

}

class DisciplinaAnual : Disciplina {
  public DisciplinaAnual(string nome, int[] notas, int nf) : base(nome, notas, nf) {
    if (notas.Length != 4) throw new ArgumentOutOfRangeException();
  }

  public override int CalcMediaParcial() {
    return ((GetNotas()[0] + GetNotas()[1])*2 + (GetNotas()[2] + GetNotas()[3])*3)/10;
  }
  public override int CalcMediaFinal() {
    int result = CalcMediaParcial();
    if (result < 60)
      result = (CalcMediaParcial() + GetNotaFinal()) / 2;
    return result;
    
  }
  public override string ToString() {
    string result = $"\nDisciplina Anual: {GetNome()}\nNotas:\n";
    for (int i=0; i<GetNotas().Length; i++)
      result+=$"[{i+1}] {GetNotas()[i]}\n";
    return result + $"[NF] {GetNotaFinal()}";
  }
}

class DisciplinaSemestral : Disciplina {
  public DisciplinaSemestral(string nome, int[] notas, int nf) : base(nome, notas, nf) {
    if (notas.Length != 2) throw new ArgumentOutOfRangeException();
  }
  public override int CalcMediaParcial() {
    return (GetNotas()[0]*2 + GetNotas()[1]*3)/5;
  }
  public override int CalcMediaFinal() {
    int result = CalcMediaParcial();
    if (result < 60)
      result = (CalcMediaParcial() + GetNotaFinal()) / 2;
    return result;
  }
  public override string ToString() {
    string result = $"\nDisciplina Semestral: {GetNome()}\nNotas:\n";
    for (int i=0; i<GetNotas().Length; i++)
      result+=$"[{i+1}] {GetNotas()[i]}\n";
    return result + $"[NF] {GetNotaFinal()}";
  }
}
