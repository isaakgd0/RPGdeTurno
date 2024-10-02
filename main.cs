using System;
using System.Threading;

class Program{
    public static void Main(string[] args){
        //DECLARANDO O DADO:
        int Dano = 0;
        Dados Dices = new();

        //DEFININDO O ENEMY:
        Enemy GoblinKing = new();

        // INÍCIO E CRIANÇÃO DO PLAYER:
        MC mainChar = new();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Saudações, Bravo Cavalheiro!");
        Console.ResetColor();
        Console.WriteLine("Como devo chamá-lo?");

        mainChar.Name = Console.ReadLine();
        Console.WriteLine($"{mainChar.Name}... É um belo nome, forte!");

        //DEFININDO O ARMAMENTO DO PLAYER:
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Vamos definir o seu armamento agora.");
        Console.ResetColor();

        Console.WriteLine("Pressione qualquer tecla para jogar os dados.");
        Console.ReadKey();
        Dices.RollDice();

        Console.ForegroundColor = ConsoleColor.Cyan;
        if (Dices.Dice <= 5){
            Console.WriteLine("Baixo... Você conta apenas com os seus punhos...");
        }
        else if (Dices.Dice <= 12){
            Console.WriteLine("Uma adaga... Deve servir...");
        }
        else if (Dices.Dice <= 15){
            Console.WriteLine("Boa! Uma espada!");
        }
        else {
            Console.WriteLine("Um machado duplo! É um pouco pesado, mas é MUITO forte!");
        }
        mainChar.Attack = mainChar.Attack * Dices.Dice;

        //DEFININDO A DEFESA DO PLAYER:
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Vamos definir sua defesa, agora.");
        Console.ResetColor();

        Console.WriteLine("Pressione qualquer tecla para jogar os dados.");
        Console.ReadKey();
        Dices.RollDice();

        Console.ForegroundColor = ConsoleColor.Cyan;
        if (Dices.Dice <= 5){
            Console.WriteLine("Quem precisa de defesa, né?");
        }
        else if(Dices.Dice <= 12){
            Console.WriteLine("Um pedacinho de madeira deve servir...");
        }
        else if(Dices.Dice <= 15){
            Console.WriteLine("Um escudo bem feito é bom!");
        }
        else{
            Console.WriteLine("Muito bom! Famoso escudo de carvalho!");
        }
        mainChar.Defesa = mainChar.Defesa * Dices.Dice;
        Console.ResetColor();

        //TUDO PRONTO PRA BATALHA:
        Thread.Sleep(2000);
        Console.WriteLine($"Tudo pronto. Sua vida é {mainChar.Hp} por padrão.");
        Thread.Sleep(2000);

        Console.WriteLine($"Olhe, {mainChar.Name}! Um inimigo!\n É o {GoblinKing.NameEnemy}!");
        Console.WriteLine("O que você faz agora?!\nQuer fugir ou atacar?");
        string comando = Console.ReadLine().ToLower();

        if (comando == "atacar"){
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Você desafiou o {GoblinKing.NameEnemy} para uma batalha.");
            Thread.Sleep(1000);
            Console.WriteLine("Ele aceitou.");
        }
        else{
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Você tentou fugir saindo de fininho, mas o {GoblinKing.NameEnemy} viu você.");
            Thread.Sleep(1000);
            Console.WriteLine("O jeito vai ser lutar...");
        }
        Console.ResetColor();
        Console.WriteLine($"A batalha vai começar.\nO {GoblinKing.NameEnemy} te dá a vantagem do primeiro turno.");
        Thread.Sleep(2000);

        //HORA DA BATALHA:
        for (int i = 1; i > 0; i++){
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"##### ROUND {i} #####");
            Console.ResetColor();
            Thread.Sleep(2000);

            //VEZ DO PLAYER:
            Console.WriteLine("É o seu turno. O que você quer fazer?");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Atacar?");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Defender?");
            Console.ResetColor();

            comando = Console.ReadLine().ToLower();

            if (comando == "atacar"){
                Console.WriteLine("Vamos jogar os dados. Pressione qualquer tecla para jogar os dados.");
                Console.ReadKey();
                
                Dices.RollDice();
                mainChar.Atacar(GoblinKing, Dices);

                //O GOBLIN KING AINDA ESTÁ VIVO?
                if (GoblinKing.HpEnemy == 0){
                    Thread.Sleep(3000);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"Você venceu! O {GoblinKing.NameEnemy} está morto!");
                    break;
                }
            }
            else if (comando == "defender"){
                Console.WriteLine("Vamos jogar os dados para ter uma boa defesa.");
                Console.WriteLine("Pressione qualquer tecla para jogar os dados.");
                Console.ReadKey();

                Dices.RollDice();
                mainChar.Defender(Dices);
            }

            //VEZ DO GOBLIN KING:
            Thread.Sleep(1500);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"É a vez do {GoblinKing.NameEnemy} agora...");
            Thread.Sleep(500);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ele vai atacar! Cuidado!");

            GoblinKing.GoblinAttack(mainChar, Dices);
            Console.ResetColor();

            //O MAIN CHARACTER AINDA ESTÁ VIVO?
            if (mainChar.Hp == 0){
                Thread.Sleep(3000);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Você morreu... Que chato.");
                break;
            }
        }
    }
}
