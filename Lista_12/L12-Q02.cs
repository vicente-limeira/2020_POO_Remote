using System;
using System.Globalization;
using System.Threading;

class MainClass {
  public static void Main (string[] args) {

    CultureInfo ci = new CultureInfo("pt-BR");
    Thread.CurrentThread.CurrentCulture = ci;

    string nome, cpf, telefone;
    DateTime nascimento;

    Console.WriteLine("\nPaciente\n----------\n");
    try {
      Console.Write("Nome: ");
      nome = Console.ReadLine();
      Console.Write("CPF: ");
      cpf = Console.ReadLine();
      Console.Write("Telefone: ");
      telefone = Console.ReadLine();
      Console.Write("Nascimento: ");
      nascimento = DateTime.Parse(Console.ReadLine());
      Paciente p = new Paciente(nome, cpf, telefone, nascimento);
      Console.WriteLine(p);    
    }
    catch (ArgumentOutOfRangeException) {
      Console.WriteLine($"Data de nascimento deve ser anterior ao dia de hoje.");
      return;
    }
    catch (Exception erro) {
      Console.WriteLine(erro.Message);
      return;
    }   
    return;
  }
}

class Paciente {
  private string nome, cpf, telefone;
  private DateTime nascimento;

  public int Idade {
    get { return this.GetIdade(); }
  }

  public Paciente (string _nome, string _cpf, string _telefone, DateTime _nascimento) {

    if (_nascimento >= DateTime.Today) {
      throw new ArgumentOutOfRangeException();
    }

    this.nome = _nome;
    this.cpf = _cpf;
    this.telefone = _telefone;
    this.nascimento = _nascimento;
  }

  public override string ToString() {
    return $"\nNome: {this.nome}, Cpf: {this.cpf}, Telefone: {this.telefone}, Nascimento: {this.nascimento:dd/MM/yyyy}, Idade: {this.Idade} ano(s).";
  }

  public int GetIdade() {
    int idade = (DateTime.Today.Year - nascimento.Year);

    if (DateTime.Today.Month < nascimento.Month || (DateTime.Today.Month == nascimento.Month && DateTime.Today.Day < nascimento.Day))
    {
        idade--;
    }

    return idade;
  }

}