using System;

class MainClass {
  public static void Main (string[] args) {
    Esfera e1 = new Esfera(10);
    Console.WriteLine($"Volume da esfera: {e1.GetVolume():0.00}");
    Figura3D e2 = new Esfera(10);
    Console.WriteLine($"Volume da esfera: {e2.GetVolume():0.00}");
    Cubo cb = new Cubo(10);
    Console.WriteLine($"Volume do cubo: {cb.GetVolume():0.00}");
  }
}

abstract class Figura3D {
  abstract public double GetVolume();
}

class Esfera : Figura3D {
  private double raio;
  public Esfera(double raio) {
    this.raio = raio;
  }
  public override double GetVolume() {
    return 4 * Math.PI * Math.Pow (this.raio,3) / 3;
  }
}

class Cubo : Figura3D {
  private double lado;
  public Cubo(double lado) {
    this.lado = lado;
  }
  public override double GetVolume() {
    return Math.Pow (this.lado,3);
  }
}
