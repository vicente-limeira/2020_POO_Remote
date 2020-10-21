using System;

class MainClass {

  public static void Main (string[] args) {

    Console.WriteLine("Informe o nome do titular");
    string titular = Console.ReadLine();
    Console.WriteLine("Informe o o numero da conta");
    string conta = Console.ReadLine();

    ContaBancaria cb = new ContaBancaria(titular, conta);
    Console.WriteLine($"Conta aberta.\nSaldo = {cb.GetSaldo():0.00}");

    decimal vlr = 10.00m;
    if (!cb.Sacar(vlr))
      Console.WriteLine($"Sacando R$ {vlr:0.00}\nOps! Deu errado.\nSaldo = {cb.GetSaldo():0.00}");
    else
      Console.WriteLine($"Sacando R$ {vlr:0.00}\nSaldo = {cb.GetSaldo():0.00}");  
      
    vlr = 163.18m;
    cb.Depositar(vlr);
    Console.WriteLine($"Depositando R$ {vlr:0.00}\nSaldo = {cb.GetSaldo():0.00}");  

    vlr = 100.00m;
    cb.Depositar(vlr);
    Console.WriteLine($"Depositando R$ {vlr:0.00}\nSaldo = {cb.GetSaldo():0.00}");  

    vlr = -300.00m;
    if (!cb.Sacar(vlr))
      Console.WriteLine($"Sacando R$ {vlr:0.00}\nOps! Deu errado.\nSaldo = {cb.GetSaldo():0.00}");
    else
      Console.WriteLine($"Sacando R$ {vlr:0.00}\nSaldo = {cb.GetSaldo():0.00}"); 

    vlr = 150.00m;
    if (!cb.Sacar(vlr))
      Console.WriteLine($"Ops! Deu errado.\nSaldo = {cb.GetSaldo():0.00}");
    else
      Console.WriteLine($"Sacando R$ {vlr:0.00}\nSaldo = {cb.GetSaldo():0.00}");
  }

}

class ContaBancaria {

  private decimal saldo;
  private string titular, cc;

  public ContaBancaria (string nome, string conta) {
    titular = nome;
    cc = conta;
    saldo = 0.00m;
    return;
  }

  public decimal GetSaldo() {
    return saldo;
  }

  public bool Sacar(decimal vlr) {
    if (vlr>0) {
      decimal novosaldo = saldo - vlr;
      if (novosaldo > 0)
        saldo = novosaldo;
      else
        return false;
    }
    else
      return false;

    return true;
  }

  public void Depositar(decimal vlr) {
    if (vlr>0)
      saldo += vlr;
    return;
  }

}