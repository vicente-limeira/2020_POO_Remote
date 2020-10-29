using System;
using System.Globalization;
using System.Threading;

class MainClass {
  public static void Main (string[] args) {

    CultureInfo ci = new CultureInfo("pt-BR");
    Thread.CurrentThread.CurrentCulture = ci;

    Estagio e = new Estagio ("Vicente","Theorika");
    e.Iniciar(DateTime.Parse("01/01/2020"));
    e.Finalizar(DateTime.Parse("31/01/2020"));

    Console.WriteLine(e);
    return;
  }

  enum SituacaoEstagio : byte {
    Cadastrado = 0, Iniciado = 1, Cancelado = 3, Finalizado = 4
  }

  class Estagio {
    private string estagiario, empresa;
    private DateTime dataInicio, dataCancelamento, dataFim;
    private int situacao;
    
    public Estagio(string est, string emp) {
      this.estagiario = est;
      this.empresa = emp;
      this.dataInicio = DateTime.Today;
      return;
    }

    public bool Iniciar(DateTime data) {
      bool result = false;
      if (this.situacao == (int)SituacaoEstagio.Cadastrado) {
        this.situacao = (int) SituacaoEstagio.Iniciado;
        this.dataInicio = data;
        result = true;
      }
      return result;
    }

    public bool Cancelar(DateTime data) {
      bool result = false;
      if (this.situacao == (int) SituacaoEstagio.Iniciado) {
        this.situacao = (int) SituacaoEstagio.Cancelado;
        this.dataCancelamento = data;
        result = true;
      }
      return result;
    }

    public bool Finalizar(DateTime data) {
      bool result = false;
      if (this.situacao == (int) SituacaoEstagio.Iniciado) {
        this.situacao = (int) SituacaoEstagio.Finalizado;
        this.dataFim = data;
        result = true;
      }
      return result;
    }

    public TimeSpan TempoEstagio() {
      switch (this.situacao) {
        case (int) SituacaoEstagio.Iniciado:
          return DateTime.Now - this.dataInicio;
        case (int) SituacaoEstagio.Cancelado:
          return this.dataCancelamento - this.dataInicio;
        case (int) SituacaoEstagio.Finalizado:
          return this.dataFim - this.dataInicio;
      }
      return TimeSpan.Zero;
    }

    public override string ToString() {
      string result = $"Estagiario: {this.estagiario}\nEmpresa: {this.empresa}\nSituacao: {(SituacaoEstagio) this.situacao}\nTempo de estagio: {TempoEstagio().Days} dias\nData de inicio: {this.dataInicio.ToString("dd/MM/yyyy")}\nData de Cancelamento: {this.dataCancelamento.ToString("dd/MM/yyyy")}\nData de Conclusão: {this.dataFim.ToString("dd/MM/yyyy")}";
      return result;
    }

  }

}