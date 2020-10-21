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
      if (cinema.SetCinema(dia, hh, mm))
        Console.WriteLine($"Preco = {cinema.GetPreco():0.00}");
      else
        Console.WriteLine("Ops! Aldo deu errado.");
    }   
  }   
}

class Cinema {

  const int inicioacrescimo = 17*60;
  const int finalacrescimo = 24*60;
  private decimal preco;

  public bool SetCinema (string diasemana, int hh, int mm) {
    
    if (hh<0 || hh>23 || mm<0 || mm>59) return false;
    
    if (diasemana == "Domingo") {
        preco = 20.00m;
    } else if (diasemana == "Segunda") {
        preco = 16.00m;
    } else if (diasemana == "Terca") {
        preco = 16.00m;
    } else if (diasemana == "Quarta") {
        preco = 08.00m;
    } else if (diasemana == "Quinta") {
        preco = 16.00m;
    } else if (diasemana == "Sexta") {
        preco = 20.00m;
    } else if (diasemana == "Sabado") {
        preco = 20.00m;
    } else return false;

    int horario = (hh*60)+mm;
    if ((horario>=inicioacrescimo) && (horario<=finalacrescimo) && (diasemana!="Quarta"))
      preco *= 1.50m;

    return true;
  }

  public decimal GetPreco() {
    return preco;
  }

}