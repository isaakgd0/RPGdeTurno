using System;
using System.Threading;

class Program {
  public static void Main (string[] args) {

    //DEFININDO O INIMIGO
    Enemy GoblinKing = new Enemy();
    GoblinKing.nmEnemy = "Rei Goblin";
    GoblinKing.vdEnemy = 10000;
    GoblinKing.atEnemy = 150;
    
    //Definindo os dados.
    int Dice = 0;
    
    //Criação do Player
    Console.WriteLine("Saudações, bravo cavaleiro! Como devo chamar-lhe?");
    MC mainChar = new MC();
    mainChar.vd = 10000;
    
    mainChar.name = Console.ReadLine();
    Console.WriteLine(mainChar.name + "... É um belo nome!...");

    Console.WriteLine("Vamos definir o seu armamento.");
    Console.WriteLine("Pressione qualquer tecla para jogar os dados...");
    Console.ReadKey(); //Leitura da tecla pressionada.
    Thread.Sleep(500);
    
    Console.WriteLine("Jogando os dados...");
    Thread.Sleep(2000);
    Dice = new Random().Next(15, 400);

    //Definição do armamento
    Console.WriteLine("Caiu " + Dice + ".");
    if (Dice <= 50){
      Console.WriteLine("Baixo. Você conta apenas com seus punhos...");
    }
    else if (Dice <= 120){
      Console.WriteLine("Você tem uma adaga. Bem boa contra inimigos menores, e ágil!");
    }
    else if (Dice <= 220){
      Console.WriteLine("Uma espada. Muito bom!");
    }
    else{
      Console.WriteLine("Um machado! É pesado, mas é Muito Forte!");
    }
  
    mainChar.att = Dice;
    //Armamento definido

    //Definindo a defesa do Player
    Console.WriteLine("Agora vamos jogar os dados para definir os seus níveis de defesa.");
    Console.WriteLine("Pressione qualquer tecla para jogar os dados...");
    Console.ReadKey(); //Leitura da tecla pressionada.
    Thread.Sleep(500);
    Console.WriteLine("Jogando os dados...");
    Thread.Sleep(2000);

    Dice = new Random().Next(200, 3000);

    Console.WriteLine("Caiu " + Dice + ".");
    if (Dice <= 400){
      Console.WriteLine("Vai só no braço mesmo...");
    }
    else if (Dice <= 1000){
      Console.WriteLine("Um escudo bem feito. Vai servir!");
    }
    else if (Dice <= 2000){
      Console.WriteLine("O famoso Escudo de Carvalho... Ótimo!");
    }
    else{
      Console.WriteLine("Uma boa armadura e um escudo! Você está pronto para a batalha!");
    }
    mainChar.def = Dice;

    Thread.Sleep(2000);
    Console.WriteLine($"\nSua armadura e seu armamento estão definidos, {mainChar.name}. Sua vida é {mainChar.vd} por padrão.");


    Thread.Sleep(2000);
    Console.WriteLine($"Veja, {mainChar.name}, há um inimigo se aproximando! É o Rei Goblin! Você deve enfrentá-lo!");
    Thread.Sleep(1000);
    Console.WriteLine("Rei Goblin te desafia para um combate.\nAceitar?\nSim? Não?");
    if (Console.ReadLine().ToLower() == "sim"){
      Thread.Sleep(1000);
      Console.WriteLine("A batalha vai começar! O Rei Goblin te dá a vantagem, o primeiro turno.");
    }
    else{
      Thread.Sleep(2000);
      Console.WriteLine("Você tentou fugir saindo de fininho, mas o Rei Goblin te encontrou. Você deve enfrentá-lo...!");
    }
    
    
    for (int i = 1; i >= 0; i++){
      Console.WriteLine($"\n####### ROUND {i} #######");
      Thread.Sleep(3000);
      
      //Vez do mainChar
      Console.WriteLine("É o seu turno.");
      Thread.Sleep(1000);
      Console.WriteLine("Quer atacar ou bloquear?");

      if (Console.ReadLine().ToLower() == "atacar"){
        Thread.Sleep(2000);

        Console.WriteLine("Vamos jogar os dados, então. Tomara que caia um bom número...");
        Console.WriteLine("Pressione qualquer tecla para jogar os dados...");
        Console.ReadKey();

        Thread.Sleep(2000);
        Dice = new Random().Next(0, 20);
        Console.WriteLine(Dice);
        if (Dice == 0){
          Console.WriteLine($"{GoblinKing.nmEnemy} se esquivou...");
        }
        else{
          mainChar.atacar(GoblinKing, Dice);
        }
      }
      else{
        Thread.Sleep(1000);
        Console.WriteLine($"Vamos jogar os dados para ver se você consegue bloquear o ataque do {GoblinKing.nmEnemy}.");
        Thread.Sleep(2000);
        Console.WriteLine("Pressione qualquer tecla para jogar os dados...");
        Console.ReadKey();

        Dice = new Random().Next(1, 20);
        Console.WriteLine($"Caiu {Dice}...");
        Thread.Sleep(2000);
        mainChar.defend(GoblinKing, Dice);
      }

      Thread.Sleep(5000);
      
      //O Goblin King ainda está vivo?
      if (GoblinKing.vdEnemy <= 0){
        Console.WriteLine("Você venceu! O Rei Goblin está morto!");
        break;
      }

      //Vez do Goblin King
      Console.WriteLine("É a vez do Rei Goblin atacar...!");
      Thread.Sleep(1000);
      Console.WriteLine("Ele vai jogar os dados...");
      Thread.Sleep(2000);

      Dice = new Random().Next(0, 20);
      Console.WriteLine($"Ele tirou um {Dice}.");
      Thread.Sleep(2000);

      int attFinal = (GoblinKing.atEnemy * Dice) - mainChar.def;

      if (Dice == 0 || attFinal < 0){
        attFinal = 0;
        Console.WriteLine("Você bloqueou!");
        Thread.Sleep(2000);
      }
      else{
        GoblinKing.ataque(mainChar, Dice);
      }
      
      //O mainChar ainda está vivo?
      if (mainChar.vd <= 0){
        Console.WriteLine("Você perdeu...");
        break;
      }
    }
  }
}
