using System;
using System.Threading;

public class Dados{
  public int Dice = 0;
  public void RollDice(){
    Thread.Sleep(500);
    Console.WriteLine("Dados Jogados... Tomara que caia um número alto...");
    Thread.Sleep(1000);
    Dice = new Random().Next(1, 20);
    Console.WriteLine($"Caiu {Dice}.");
  }
}

//CLASSE DO MAIN CHARACTER:
public class MC{
  public string Name {get; set;}
  public int Hp = 10000;
  public int Attack = 25;
  public int DefFinal = 0;
  public int Defesa = 100;

  //ATAQUE DO MC:
  public void Atacar(Enemy GoblinKing, Dados Dices){
    int Dano = Attack * Dices.Dice;
    GoblinKing.HpEnemy -= Dano;

    //VIDA NEGATIVA:
    if (GoblinKing.HpEnemy < 0){
      GoblinKing.HpEnemy = 0;
    }

    Thread.Sleep(1000);
    Console.WriteLine($"Dano aplicado: {Dano};");
    Thread.Sleep(1000);
    Console.WriteLine($"Vida atual do Goblin King: {GoblinKing.HpEnemy};");
  }

  public void Defender(Dados Dices){
    Console.WriteLine("Você ergueu sua defesa.\nQuando ele atacar, o dano vai ser reduzido!");
    DefFinal = Defesa * Dices.Dice;
  }
}


//CLASSE DO ENEMY:
public class Enemy{
  public string NameEnemy = "Rei Goblin";
  public int HpEnemy = 10000;
  public int AttEnemy = 500;

  //MÉTODOS:
  public void GoblinAttack(MC mainChar, Dados Dices){
    int DanoFinal = (AttEnemy * Dices.Dice) - mainChar.DefFinal;

    if (DanoFinal < 0){
      DanoFinal == 0;
    }

    mainChar.Hp -= DanoFinal;

    //EVITANDO VIDA NEGATIVA:
    if (mainChar.Hp < 0){
      mainChar.Hp = 0;
    }

    Thread.Sleep(1000);
    Console.WriteLine($"Dano aplicado: {DanoFinal}");
    Thread.Sleep(1000);
    Console.WriteLine($"Sua defesa: {mainChar.Defesa};");
    Thread.Sleep(1000);
    Console.WriteLine($"Sua vida atual: {mainChar.Hp}");
    mainChar.DefFinal = 0;
  }
}
