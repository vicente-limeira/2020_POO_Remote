using System;
using System.Globalization;
using System.Threading;

class MainClass {
  public static void Main (string[] args) {

    CultureInfo ci = new CultureInfo("pt-BR");
    Thread.CurrentThread.CurrentCulture = ci;

    Boleto b = new Boleto ("1234 4321 1234 4321", DateTime.Today, DateTime.Today.AddDays(7), 900.00M);

    b.Pagar(900.00M);

    Console.WriteLine(b);

    return;
  }

  enum Pagamento : byte {
    EmAberto = 0, PagoParcial = 1, Pago = 2
  }

  class Boleto {
    private string codBarras;
    private DateTime dataEmissao, dataVencimento, dataPagamento;
    private decimal valorBoleto, valorPago;
    private Pagamento situacaoPagamento;
    
    public Boleto(string cod, DateTime emissao, DateTime venc, Decimal valor) {
      this.codBarras = cod;
      this.dataEmissao = emissao;
      this.dataVencimento = venc;
      this.valorBoleto = valor;
      return;
    }

    public void Pagar(Decimal valorPago) {
      
      if (this.valorPago <= 0) return;

      this.valorPago = valorPago;
      this.dataPagamento = DateTime.Now;

      if (this.valorPago < this.valorBoleto)
        this.situacaoPagamento = Pagamento.PagoParcial;
      else
        this.situacaoPagamento = Pagamento.Pago;
        
      return;
    }

    public Pagamento Situacao() {
      return this.situacaoPagamento;
    }

    public override string ToString() {
      string result = $"Barras = {this.codBarras}, Emissão = {this.dataEmissao.ToString("dd/MM/yyyy")}, Vencimento = {this.dataVencimento.ToString("dd/MM/yyyy")}, Valor = {this.valorBoleto}, Situacao = {Situacao()}";

      if (!(this.situacaoPagamento == Pagamento.EmAberto)) {
        result += $", Pago {this.valorBoleto} em {this.dataPagamento}";
      }
      
      return result;
    }

  }

}