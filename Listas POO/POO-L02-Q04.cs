using System;

class MainClass {

  public static void Main (string[] args) {

    Console.WriteLine("Informe o nome do titular");
    string titular = Console.ReadLine();
    Console.WriteLine("Informe o o numero da conta");
    string conta = Console.ReadLine();

    ContaBancaria cb = new ContaBancaria();
    cb.SetTitular(titular);
    cb.SetConta(conta);
    Console.WriteLine($"Conta aberta.\nSaldo = {cb.GetSaldo():0.00}");

    double vlr = 10.00;
    cb.Sacar(vlr);
    Console.WriteLine($"Sacando R$ {vlr:0.00}\nSaldo = {cb.GetSaldo():0.00}");  
      
    vlr = 163.18;
    cb.Depositar(vlr);
    Console.WriteLine($"Depositando R$ {vlr:0.00}\nSaldo = {cb.GetSaldo():0.00}");  

    vlr = 100.00;
    cb.Depositar(vlr);
    Console.WriteLine($"Depositando R$ {vlr:0.00}\nSaldo = {cb.GetSaldo():0.00}");  

    vlr = 150.00;
    cb.Sacar(vlr);
    Console.WriteLine($"Sacando R$ {vlr:0.00}\nSaldo = {cb.GetSaldo():0.00}");
  }

}

class ContaBancaria {

  private double saldo;
  private string titular, conta;

  public void SetTitular (string n) {
    titular = n;
    return;
  }

  public void SetConta (string cc) {
    conta = cc;
    return;
  }

  public void Sacar(double vlr) {
    if (vlr>0) saldo -= vlr;
    return;
  }

  public void Depositar(double vlr) {
    if (vlr>0) saldo += vlr;
    return;
  }

  public string GetTitular() {
    return titular;
  }

  public string GetConta() {
    return conta;
  }

  public double GetSaldo() {
    return saldo;
  }

}