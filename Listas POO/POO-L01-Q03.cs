using System;

class MainClass {

  public static void Main (string[] args) {
    
    Console.WriteLine("Informe a distancia (km) percorrida");
    double d = double.Parse(Console.ReadLine());
    Console.WriteLine("Informe o tempo de viagem (hh:mm)");
    string hhmm = Console.ReadLine();
    int hh = int.Parse(hhmm.Substring(0,2));
    int mm = int.Parse(hhmm.Substring(3,2));

    Viagem v = new Viagem();
    v.SetViagem(d, hh, mm);
    Console.WriteLine($"Velociade media: {v.GetSpeed():0.00} km/h");
  }

}

class Viagem {

  private double km, speed;
  private int hh, mm;

  public void SetViagem(double d, int horas, int minutos ) {
    if ((d>0) && (horas >= 0) && (minutos >= 0)) {
      km = d;
      hh = horas;
      mm = minutos;
      speed = km / (double) (hh + (double) mm/60);
    }
    return;
  }

  public double GetSpeed() {
    return speed;
  }

}