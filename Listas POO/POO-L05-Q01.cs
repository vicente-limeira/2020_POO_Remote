using System;
using System.Globalization;
using System.Threading;

class MainClass {
  public static void Main (string[] args) {
    
    CultureInfo ci = new CultureInfo("pt-BR");
    Thread.CurrentThread.CurrentCulture = ci;
    
    Paciente p = new Paciente ("Vicente", "999.999.999-99","+55 84 9-9471-2565", DateTime.Parse("14/03/1968"));
    
    Console.Write(p.Idade());
    Console.Write(p);

    return;
  }

  class Paciente {
    private string nome, cpf, telefone;
    private DateTime nascimento;

    public Paciente(string n, string c, string t, DateTime nasc) {
      this.nome = n;
      this.cpf = c;
      this.telefone = t;
      this.nascimento = nasc;
      return;
    }

    public string Idade() {

      TimeSpan ts = DateTime.Today - this.nascimento;
      DateTime idade = (new DateTime() + ts).AddYears(-1).AddDays(-1);

      int anos = idade.Year;
      int meses = idade.Month;

      if (meses >0) {
        return $"{this.nome} tem {anos} anos e {meses} meses.\n";
      }
        return $"{this.nome} tem {anos} anos.\n";
    }

    public override string ToString() {

      CultureInfo ci = new CultureInfo("pt-BR");
      Thread.CurrentThread.CurrentCulture = ci;

      return $"{this.nome}, Cpf {this.cpf}, telefone {this.telefone}, nasceu em {this.nascimento.ToString("dd/MM/yyyy")}, {ci.DateTimeFormat.GetDayName(this.nascimento.DayOfWeek)}.\n";
    }

  }
}