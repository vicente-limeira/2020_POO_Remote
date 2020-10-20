using System;

class MainClass {
  public static void Main (string[] args) {
    
    string evento_inicio_dd = Console.ReadLine (); 
    string evento_inicio_hr = Console.ReadLine (); 
    string evento_final_dd = Console.ReadLine (); 
    string evento_final_hr = Console.ReadLine (); 
    
    uint inicio_dd = uint.Parse(evento_inicio_dd.Substring(04));

    uint inicio_hh = uint.Parse (evento_inicio_hr.Substring(00,02));
    uint inicio_mm = uint.Parse (evento_inicio_hr.Substring(05,02));
    uint inicio_ss = uint.Parse (evento_inicio_hr.Substring(10,02));

    uint final_dd = uint.Parse(evento_final_dd.Substring(04));    

    uint final_hh = uint.Parse (evento_final_hr.Substring(00,02));
    uint final_mm = uint.Parse (evento_final_hr.Substring(05,02));
    uint final_ss = uint.Parse (evento_final_hr.Substring(10,02));

    uint t1 = inicio_ss + inicio_mm*60 + inicio_hh*3600 + inicio_dd*86400;
    uint t2 = final_ss + final_mm*60 + final_hh*3600 + final_dd*86400;
    uint t = t2-t1;

    //Console.WriteLine($"{t2} - {t1} = {t}\n");

    uint evento_dd = t/86400;
    t = t%86400;
    uint evento_hh = t/3600;
    t = t%3600;
    uint evento_mm = t/60;
    uint evento_ss = t%60;

    Console.WriteLine($"{evento_dd} dia(s)");
    Console.WriteLine($"{evento_hh} hora(s)");
    Console.WriteLine($"{evento_mm} minuto(s)");
    Console.WriteLine($"{evento_ss} segundo(s)");
  }
}