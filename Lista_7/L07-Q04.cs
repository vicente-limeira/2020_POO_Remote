using System;

class MainClass {

  public static void Main (string[] args) {
    
    int a = int.Parse(Console.ReadLine());
    int b = int.Parse(Console.ReadLine());
    int result = MMC(a, b);
    Console.WriteLine($"MMC: {result}");
  }

  public static int MMC(int x, int y) {
    int i, j, result = 0;

    for (i = 2; i <= y; i++) {
        j = x * i;
        if ((j % y) == 0) {
            result = j;
            i = y + 1;
        }
    }
    return result;
  }

}