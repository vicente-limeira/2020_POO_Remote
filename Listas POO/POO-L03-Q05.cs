using System;

class MainClass {

  public static void Main (string[] args) {
    Console.WriteLine("\nTrabalhando com data ...");
    Console.WriteLine("Informe uma data no formato dd/mm/aaaa");
    string i = Console.ReadLine();

    Data dt0 = new Data(i);

    Console.WriteLine("\nInstanciando dt0 com String ..."); 
    Console.WriteLine($"Dia: {dt0.GetDia()}");
    Console.WriteLine($"Mes: {dt0.GetMes()}");
    Console.WriteLine($"Ano: {dt0.GetAno()}");

    string[] input = i.Split('/');

    Data dt1 = new Data(int.Parse(input[0]),int.Parse(input[1]),int.Parse(input[2]) );

    Console.WriteLine("\nInstanciando dt1 com inteiros");
    Console.WriteLine($"Dia: {dt1.GetDia()}");
    Console.WriteLine($"Mes: {dt1.GetMes()}");
    Console.WriteLine($"Ano: {dt1.GetAno()}");

    dt1.SetData(31,12,2020);

    Console.WriteLine("\ndt1 modificada para '31/12/2020':");
    Console.WriteLine(dt1);

    dt1.SetData(31,04,2020);

    Console.WriteLine("\ndt1 modificada para: '31/04/2020'");
    Console.WriteLine($"Dia: {dt1.GetDia()}");
    Console.WriteLine($"Mes: {dt1.GetMes()}");
    Console.WriteLine($"Ano: {dt1.GetAno()}");

    return;
  }

}

class Data {

  private int dia,mes,ano;

  public Data(int dia, int mes, int ano) {
    SetData(dia,mes,ano);
    return;
  }

  public Data(string data) {
    string[] input = data.Split('/');
    SetData(
      int.Parse(input[0]),
      int.Parse(input[1]),
      int.Parse(input[2])
    );
    return;
  }

  public int GetDia() {
    return dia;
  }
  public int GetMes() {
    return mes;
  }
  public int GetAno() {
    return ano;
  }    

  public void SetData(int dia, int mes, int ano) {

    int[] ultimo = new int[12] {31,28,31,30,31,30,31,31,30,31,30,31};

    if (mes>=1 && mes<=12)
      if (
        (ano>=1900 && ano<=2020) && (dia>=1 && dia<=ultimo[mes-1])
      ) {
        this.dia = dia;
        this.mes = mes;
        this.ano = ano;
      }
    
    return;
  }

  public override string ToString() {
    return $"ToString: {dia}/{mes}/{ano}";
  }
}