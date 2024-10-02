# RPGdeTurno
Um RPG de turno de fantasia onde se cria um player, define-se seu armamento, defesas, e se enfrenta um oponente.
O usuário define seu nome e pode jogar dados para definir os níveis de seu armamento e defesas. 

# DEFININDO ARMAMENTO:
O primeiro passo será jogar os dados para definir o armamento do jogador, isto é, seu nível de ataque. O nível base é 25, e, quando os dados forem jogados, este número será multiplicado pelo número sorteado, que pode ser de 1 a 20.
# DEFININDO AS DEFESAS:
Depois do ataque, o jogador irá jogar os dados para definir seus níveis de defesa, da mesma forma que fez com o ataque. O nível base da defesa é 100, que será multiplicado pelo número que cair no dado.

Tendo tudo isso definido, o player poderá enfrentar um inimigo com um sistema de turnos, onde ele poderá escolher se ataca ou bloqueia. Em qualquer dos casos, joga-se os dados novamente para definir a força das suas defesas ou ataques.
Foi usado C# para criar as classes e todo o sistema do jogo.

O jogo é baseado em turnos, o que quer dizer que o usuário terá de escolher se ataca o oponente ou se bloqueia.

# CASO ATAQUE:
Caso escolha atacar, o jogador será orientado a jogar os dados. O número que cair será multiplicado pelo dado do ataque, e será aplicado sobre a vida do inimigo que ele irá enfrentar. 
# CASO DEFENDA:
Caso escolha erguer as defesas, o jogador também irá jogar os dados, e o número que cair irá multiplicar a defesa total dele. A defesa, então, está erguida, e o próximo turno é o do inimigo.

# TURNO DO INIMIGO:
Chegando o turno do inimigo, ele ataca. O inimigo também joga os dados e multiplica o próprio ataque, que irá se abater sobre a defesa do jogador. 

Caso, ao final dos dois turnos, ambos ainda estejam vivos, partimos para a próxima rodada até que o jogador vença ou perca.
