using System;

class MainClass {

  public static void Main (string[] args) {
    
    string nome = Console.ReadLine();
    string i = Console.ReadLine();
    string[] input = i.Split();
    
    double n1 = double.Parse(input[0]);
    double n2 = double.Parse(input[1]);
    double n3 = double.Parse(input[2]);
    double n4 = double.Parse(input[3]);

    Disciplina d = new Disciplina();
    d.SetNotas(nome,n1,n2,n3,n4);

    if (d.GetMediaParcial(out double mp)) {
      Console.WriteLine($"Media Parcial: {mp}");

      if (mp<60) {
        Console.WriteLine("Informe a nota da Prova Final");
        double pfinal = double.Parse(Console.ReadLine());

        if (!d.SetProvaFinal(pfinal))
          Console.WriteLine("Prova Final não pode ser informada.");
        else
        if (d.GetMediaFinal(out double mf))
          Console.WriteLine($"Media Final: {mf}");
        else
          Console.WriteLine($"Media Final não pode ser calculada.");
      }
    }  
  }
}

class Disciplina {

  private string nome;
  private bool fimdosemestre = false, provafinal = false;
  private double nota1, nota2, nota3, nota4, pfinal, mparcial, mfinal;

  public void SetNotas(string n, double n1, double n2, double n3, double n4) {
    if  ((n1>=000.0 && n1<=100.0)
    &&   (n2>=000.0 && n1<=100.0)
    &&   (n3>=000.0 && n1<=100.0)
    &&   (n1>=000.0 && n1<=100.0)) {
       nome  = n;
       nota1 = n1;
       nota2 = n2;
       nota3 = n3;
       nota4 = n4;
       mparcial = ((n1*2)+(n2*2)+(n3*3)+(n4*3))/10;
       fimdosemestre = true;
       provafinal = false;       
       mfinal = 0;
    }
  }

  public bool GetMediaParcial(out double mp) {
    mp = 0;
    if (!fimdosemestre) return false;
    mp = mparcial;
    return true;
  }

  public bool GetMediaFinal(out double mf) {
    mf = 0;
    if (!provafinal) return false;
    mf = mfinal;    
    return true;
  }

  public bool SetProvaFinal(double pf) {
    if ((!fimdosemestre) || (mfinal>=60)) return false;
    pfinal = pf;
    bool result = GetMediaParcial(out double mp);
    mfinal = (mp + pf)/2;
    provafinal = true; 
    return result;
  }
}