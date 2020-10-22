using System;

class MainClass {

  public static void Main (string[] args) {
    
    string nome = Console.ReadLine();
    string i = Console.ReadLine();
    string[] input = i.Split();
    
    int n1 = int.Parse(input[0]);
    int n2 = int.Parse(input[1]);
    int n3 = int.Parse(input[2]);
    int n4 = int.Parse(input[3]);

    Disciplina d = new Disciplina();
    d.SetNome(nome);
    d.SetNota1(n1);
    d.SetNota2(n2);
    d.SetNota3(n3);
    d.SetNota4(n4);

    Console.WriteLine($"\nAluno : {d.GetNome()}");
    Console.WriteLine($"Nota 1: {d.GetNota1()}");
    Console.WriteLine($"Nota 2: {d.GetNota2()}");
    Console.WriteLine($"Nota 3: {d.GetNota3()}");
    Console.WriteLine($"Nota 4: {d.GetNota4()}\n");

    int mparcial = d.CalcMediaParcial();
    Console.WriteLine($"Media Parcial: {mparcial}\n");

    if (mparcial<60) {
      Console.WriteLine("Informe a Nota Final");
      int nf = int.Parse(Console.ReadLine());
      d.SetNotaFinal(nf);      
      Console.WriteLine($"Nota Final : {d.GetNotaFinal()}");
      int mfinal = d.CalcMediaFinal();
      Console.WriteLine($"Media Final: {mfinal}\n");
      if (mfinal<60) {
        Console.WriteLine("Reprovado");
        return;
      }        
    }

    Console.WriteLine("Aprovado");
    return;
  }
}

class Disciplina {

  private string nome;
  private int nota1, nota2, nota3, nota4, notaFinal;

  public void SetNome(string s) {
    nome = s=="" ? nome : s;
    return;
  }
  public void SetNota1(int n) {
    if (n>=0 && n<=100) nota1 = n;
    return;    
  }
  public void SetNota2(int n) {
    if (n>=0 && n<=100) nota2 = n;
    return;    
  }
  public void SetNota3(int n) {
    if (n>=0 && n<=100) nota3 = n;
    return;    
  }
  public void SetNota4(int n) {
    if (n>=0 && n<=100) nota4 = n;
    return;    
  }
  public void SetNotaFinal(int n) {
    if (n>=0 && n<=100) notaFinal = n;
    return;    
  }

  public string GetNome() {
    return nome;
  }
  
  public int GetNota1() {
    return nota1;
  }

  public int GetNota2() {
    return nota2;
  }

  public int GetNota3() {
    return nota3;
  }

  public int GetNota4() {
    return nota4;
  }

  public int GetNotaFinal() {
    return notaFinal;
  }

  public int CalcMediaParcial() {
    return ((nota1*2)+(nota2*2)+(nota3*3)+(nota4*3))/10;
  }


  public int CalcMediaFinal() {
    return (CalcMediaParcial() + notaFinal)/2;
  }

}