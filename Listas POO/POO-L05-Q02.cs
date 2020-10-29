using System;
using System.Globalization;
using System.Threading;

class MainClass {
  public static void Main (string[] args) {

    CultureInfo ci = new CultureInfo("pt-BR");
    Thread.CurrentThread.CurrentCulture = ci;

    ValeCompras valecompras = new ValeCompras(DateTime.Now, 400.00M);
    Produto produto = new Produto("Cafeteira", 380.00M);

    Premio premio = new Premio("Vicente",DateTime.Parse("01/10/2020"));

    premio.SetPremio(produto);
    Console.WriteLine (premio);

    premio.SetPremio(valecompras);
    Console.WriteLine (premio);    

    return;
  }

  class Premio {
    private string cliente;
    private DateTime data;
    private object premio;

    public Premio(string c, DateTime d) {
      this.cliente = c;
      this.data = d;
      return;
    }

    public void SetPremio(object p) {
      this.premio = p;
      return;
    }

    public object GetPremio() {
      return this.premio;
    }

    public override string ToString() {

      string result = $"(Premio) Cliente: {this.cliente}, Data: {this.data.ToString("dd/MM/yyyy")}, {premio}";
      return result;
    }

  }

  class ValeCompras {
    private DateTime dataValidade;
    private Decimal valor;

    public ValeCompras(DateTime d, Decimal v) {
      this.dataValidade = d;
      this.valor = v;
      return;
    }

    public override string ToString() {     
      return $"(Vale Compras) Validade: {this.dataValidade.ToString("dd/MM/yyyy")}, Valor: {this.valor}";
    }
  }

  class Produto {
    private string descricao;
    private Decimal valor;

    public Produto(string d, Decimal v) {
      this.descricao = d;
      this.valor = v;
      return;
    }

    public override string ToString() {
      return $"(Produto) Descrição: {this.descricao}, Valor: {this.valor}";
    }
  }

}