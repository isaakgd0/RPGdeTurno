using System;
using System.Threading;

//classe do Main Character
public class MC {
  public string name {get; set;}
  public int vd {get; set;}
  public int att {get; set;}
  public int def {get; set;}
  public int defFinal;

  //MÉTODO DE ATAQUE DO MAIN CHARACTER:
  public void atacar(Enemy GoblinKing, int Dice){
    int dano = (att * Dice);
    GoblinKing.vdEnemy -= dano;
    //evitando vd negativa:
    if (GoblinKing.vdEnemy < 0) GoblinKing.vdEnemy = 0;


    Console.WriteLine($"Você causou {dano} de dano no {GoblinKing.nmEnemy}!");
    Thread.Sleep(2000);
    Console.WriteLine($"Vida do {GoblinKing.nmEnemy}: {GoblinKing.vdEnemy}.");
  }

  //MÉTODO DE DEFESA DO MAIN CHARACTER:
  public void defend(Enemy GoblinKing, int Dice){
    int defFinal = (def * Dice);

    Console.WriteLine("Você ergueu sua defesa.");
    Thread.Sleep(1000);
    Console.WriteLine($"Sua defesa total é de {defFinal}. Se o {GoblinKing.nmEnemy} tirar um ataque menor que isso, você bloqueará o dano dele...");
  }
}

public class Enemy{
  public string nmEnemy {get; set;}
  public int vdEnemy {get; set;}
  public int atEnemy {get; set;}

  //MÉTODO DE ATAQUE DO ENEMY:
  public void ataque(MC mainChar, int Dice){
    
    int atFinal = (atEnemy * Dice) - mainChar.defFinal;

    mainChar.vd -= atFinal;
    //Evitando vd negativa:
    if (mainChar.vd < 0) mainChar.vd = 0;

    Console.WriteLine($"Sua defesa: {mainChar.def}");
    Thread.Sleep(1000);
    Console.WriteLine("Dano aplicado:" + atFinal);
    Thread.Sleep(1000);
    Console.WriteLine($"Sua Vida restante: {mainChar.vd}");
  }
}
