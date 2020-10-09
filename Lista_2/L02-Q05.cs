using System;

class MainClass {
  public static void Main (string[] args) {
    const ulong vluz = 300000; 
    string horario;
    Console.WriteLine ("Digite o intervalo de tempo no formato \"HH:MM:SS\"");
    horario = Console.ReadLine ();
    ulong hh, mm, ss;
    hh = ulong.Parse(horario.Substring(0,2));
    mm = ulong.Parse(horario.Substring(3,2));
    ss = ulong.Parse(horario.Substring(6,2));
    //Console.WriteLine ($"{hh}:{mm}:{ss}");
    ulong t = ss + (mm*60) + (hh*3600);
    //Console.WriteLine ($"Total = {t} segundo(s)");
    ulong d = t * vluz;
    Console.WriteLine ($"A luz percorreu {d} km nesse intervalo");
  }
}
