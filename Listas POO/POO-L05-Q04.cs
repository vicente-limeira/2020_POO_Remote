using System;

class MainClass {
  public static void Main (string[] args) {

    Estagiario e = new Estagiario ("Vicente", "111.111.111-11", "+55 84 9-9471-2565");

    Dias d = Dias.segunda | Dias.quarta | Dias.sexta;
    e.SetDias(d);

    Turno t = Turno.vespertino;
    e.SetTurno(t);

    Console.WriteLine(e);
    return;
  }

  [Flags]
  enum Dias : byte {
    segunda = 2, terça = 3, quarta = 4, quinta = 5, sexta = 6
  }

  enum Turno : byte {
    matutino = 0, vespertino = 1, noturno = 2
  }

  class Estagiario {
    private string nome, cpf, telefone;
    private Dias dias;
    private Turno turno;
    
    public Estagiario(string n, string c, string t) {
      this.nome = n;
      this.cpf = c;
      this.telefone = t;
      return;
    }

    public void SetDias(Dias d) {
      this.dias = d;        
      return;
    }

    public void SetTurno(Turno t) {
      this.turno = t;     
      return;
    }

    public Dias GetDias() {
      return this.dias;
    }

    public Turno GetTurno() {
      return this.turno;
    }

    public override string ToString() {
      string result = $"Nome: {this.nome}, Cpf: {this.cpf}, Telefone: {this.telefone}, Dias: {GetDias()}, Turno: {GetTurno()}";
      return result;
    }

  }

}