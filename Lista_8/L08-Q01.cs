using System;
using System.Collections;

class MainClass {

  public static void Main (string[] args) {

    Aluno[] turma = new Aluno[10];
    int indx=0;

    while (true) {
      Console.WriteLine("\nMenu\n-------------------------------------\nI = Inserir\nA = Listar em ordem alfabetica\nN = Listar em ordem decrescente de data de nascimento\nM = Listar em ordem de Matricula\n<enter> = Fim");
      string op = Console.ReadLine();
      if ((op == "I") || (op == "i")) {
            indx = Form.GetAluno(turma, indx);
            continue;
      }
      if ((op == "A") || (op == "a")) {
          Form.OrdemPorNome(turma, indx);
          continue;
      }

      if ((op == "M") || (op == "m")) {
          Form.OrdemPorMatricula(turma, indx);
          continue;
      }

      if ((op == "N") || (op == "n")) {
          Form.OrdemPorNascimento(turma, indx);
          continue;
      }

      if (op == "") {
          break;
      }
    }

    Console.WriteLine("\nFim.");
    return;
  }
}

class Form {

  public static int GetAluno(Aluno[] t, int i) {
    Aluno a = new Aluno();
    Console.Write("\nDados do Aluno\n-------------------------------\nNome: ");
    a.Nome = Console.ReadLine();
    Console.Write("Matricula: ");
    a.Matricula = Console.ReadLine();
    Console.Write("Data de Nascimento: ");
    a.Nascimento = DateTime.Parse(Console.ReadLine());
    t[i]=a;
    i++;
    return i;
  }

  public static void OrdemPorNome(Aluno[] t, int indx) {
    Console.Write("\nOrdem Ascendente por Nome\n-----------------------------\n");
    Aluno[] lista = new Aluno[indx];
    Array.Copy(t, lista, indx);
    Array.Sort(lista);
    foreach (Aluno a in lista) {
      Console.WriteLine(a);
    }
    return;
  }
  
  public static void OrdemPorNascimento(Aluno[] t, int indx) {
    Console.Write("\nOrdem Descendente por Nascimento\n-----------------------------\n");
    AlunoNascimentoComp anc = new AlunoNascimentoComp();
    Aluno[] lista = new Aluno[indx];
    Array.Copy(t, lista, indx);   
    Array.Sort(lista, anc);
    foreach (Aluno a in lista) {
      Console.WriteLine(a);
    } 
    return;
  }

  public static void OrdemPorMatricula(Aluno[] t, int indx) {
    Console.Write("\nOrdem Ascendente por Matricula\n-----------------------------\n");
    AlunoMatriculaComp amc = new AlunoMatriculaComp();
    Aluno[] lista = new Aluno[indx];
    Array.Copy(t, lista, indx);
    Array.Sort(lista, amc);
    foreach (Aluno a in lista) {
      Console.WriteLine(a);
    } 
    return;
  }

}

class Aluno : IComparable {
  private string nome, matricula;
  private DateTime nascimento;
  
  public string Nome {
    set {this.nome = value;}
    get {return this.nome;}
  }
  
  public string Matricula {
    set {this.matricula = value;}
    get {return this.matricula;}
  }

  public DateTime Nascimento {
    set {this.nascimento = value;}
    get {return this.nascimento;}
  }

  public override string ToString() {
    return $"Nome: {this.nome}, Matricula: {this.matricula}, Nascimento: {this.nascimento:dd/MM/yyyy}";
  }

  public int CompareTo(object i) {
    Aluno a = (Aluno) i;
    return this.nome.CompareTo(a.nome);
  }

}

class AlunoNascimentoComp : IComparer {
  public int Compare(object x, object y) {
    Aluno a = (Aluno)x;
    Aluno b = (Aluno)y;
    return -a.Nascimento.CompareTo(b.Nascimento);
  }
}

class AlunoMatriculaComp : IComparer {
  public int Compare(object x, object y) {
    Aluno a = (Aluno)x;
    Aluno b = (Aluno)y;
    return a.Matricula.CompareTo(b.Matricula);
  }
}