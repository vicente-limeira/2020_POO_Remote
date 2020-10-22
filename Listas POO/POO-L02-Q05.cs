using System;

class MainClass {

  public static void Main (string[] args) {
    
    string dia, horario;
    Cinema cinema;
    
    while (true) {
      Console.WriteLine("Informe o dia da semana");
      dia = Console.ReadLine();
      if (dia == "*") break;

      Console.WriteLine("Informe a hora HH:MM");
      horario = Console.ReadLine();
      int hh = int.Parse(horario.Substring(0,2));
      int mm = int.Parse(horario.Substring(3,2));

      cinema = new Cinema();

      cinema.SetDia(dia);
      cinema.SetHorario(hh*60+mm);

      Console.WriteLine($"Dia             = {cinema.GetDia()}");
      Console.WriteLine($"Horário         = {cinema.GetHorario()} min");
      Console.WriteLine($"Meia Entrada    = {cinema.MeiaEntrada():0.00}");
      Console.WriteLine($"Entrada Inteira = {cinema.EntradaInteira():0.00}\n");
    }   
  }   
}

class Cinema {

  const int inicioacrescimo = 17*60;
  const int finalacrescimo = 24*60;

  private string dia;
  private int horario;
  
  public void SetDia (string d) {
    dia = d;
    return;
  }

  public void SetHorario (int h) {
    horario = h;
    return;
  }

  public string GetDia () {
    return dia;
  }

  public int GetHorario () {
    return horario;
  }

  public double EntradaInteira() {
    
    double preco = 0.00;

    if (dia == "Domingo") {
        preco = 20.00;
    } else if (dia == "Segunda") {
        preco = 16.00;
    } else if (dia == "Terca") {
        preco = 16.00;
    } else if (dia == "Quarta") {
        preco = 08.00;
    } else if (dia == "Quinta") {
        preco = 16.00;
    } else if (dia == "Sexta") {
        preco = 20.00;
    } else if (dia == "Sabado") {
        preco = 20.00;
    }

    if ((horario>=inicioacrescimo) && (horario<=finalacrescimo) && (dia!="Quarta"))
      preco *= 1.50;    

    return preco;
  }

  public double MeiaEntrada() {
    
    double preco = 0.00;

    if (dia == "Domingo") {
        preco = 20.00;
    } else if (dia == "Segunda") {
        preco = 16.00;
    } else if (dia == "Terca") {
        preco = 16.00;
    } else if (dia == "Quarta") {
        preco = 08.00;
    } else if (dia == "Quinta") {
        preco = 16.00;
    } else if (dia == "Sexta") {
        preco = 20.00;
    } else if (dia == "Sabado") {
        preco = 20.00;
    }

    if ((horario>=inicioacrescimo) && (horario<=finalacrescimo) && (dia!="Quarta"))
      preco *= 1.50;

    if (dia!="Quarta")
      preco /=2;

    return preco;
  }

}