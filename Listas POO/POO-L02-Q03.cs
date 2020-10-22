using System;

class MainClass {

  public static void Main (string[] args) {
    
    Console.WriteLine("Informe a distancia (km) percorrida");
    double d = double.Parse(Console.ReadLine());
    Console.WriteLine("Informe o tempo de viagem (hh:mm)");
    string hhmm = Console.ReadLine();
    double hh = double.Parse(hhmm.Substring(0,2));
    double mm = double.Parse(hhmm.Substring(3,2));

    Viagem v = new Viagem();
    v.SetDistancia(d);
    v.SetTempo(hh + mm/60.0);

    Console.WriteLine($"Distância: {v.GetDistancia():0.00} km");
    Console.WriteLine($"Tempo    : {v.GetTempo():0.00} h");
    Console.WriteLine($"Velociade media: {v.VelocidadeMedia():0.00} km/h");        
  }

}

class Viagem {

  private double distancia, tempo;

  public void SetDistancia(double d) {
    if (d>0.00) distancia = d;
    return;
  }

  public void SetTempo(double t) {
    if (t>0.00) tempo = t;
    return;
  }
/*
    if ((d>0) && (horas >= 0) && (minutos >= 0)) {

*/

  public double GetDistancia() {
    return distancia;
  }
  public double GetTempo() {
    return distancia;
  }
  public double VelocidadeMedia() {
    return distancia/tempo;
  }

}