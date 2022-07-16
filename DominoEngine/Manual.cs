public static class Manual{
    public static string text="MANUAL DE USUARIO\n------------------\n\nBienvenido al simulador de partidas de domino 1.3\nEsta aplicación tiene como objetivo representar una partida de dominó con diferentes variaciones de reglas, las cuales son elegidas en la pantalla principal.\nEntre las variaciones a elegir están:\n-El último doble disponible: Mínimo el doble 4, es personalizable\n-El número de jugadores: entre 2 y 4\n-La máxima cantidad inicial de fichas al inicio del juego: puede variar entre 3 y el máximo posible\n-Los nombres de los jugadores y sus respectivas estrategias\n-La distribución de los jugadores en equipos\n-La condición para poder poner o no una ficha\n-El estilo de juego que se llevara a cabo\n-Que equipo gana la partida\n-Cuánto vale cada ficha\n-Cuándo es que se acaba el juego\n-Si las fichas pueden estar repetidas o no\n-Si todos comienzan con la misma cantidad de fichas\n-La condición de victoria del torneo\n\nEntre las diferentes estrategias esta:\n-El Borracho: Este no sabe lo que hace, pone la primera que pueda poner\n-El BotaGorda: El enemigo #1 del doble 9, suelta siempre la que mas valga\n-El Agachao: Siempre evita jugar una que no lleve mucho\n-El Pro: Este esta escapao, sabe jugar bien\n-El Impredecible: Cambia de estrategia repentinamente\n\nLos equipos pueden ser:\n-1 contra todos: un reto personal\n-equilibrados: el clasico\n-todos contra todos: la guerra\n\nEntre las reglas están:\n-Todas las reglas estándares del dominó(por default)\n-El EscaleroDominó: solo puedes poner el blanco o una mayor\n-El Piramidominó: solo puedes poner o la superior o la inferior(ejemplo: el 5 solo puedes matarlo con el 4 o el 6)\n-El SiempreDobles: puedes poner un doble siempre\n-El Robadito: Si no llevas coges una ficha\n-El CicloDominó: Puedes salir con dos fichas, si juegas un doble puedes jugar de nuevo, si no llevas robas 1 y cambias el sentido del juego\n-Que el juego acabe cuando ocurran dos pases seguidos\n-Que el juego acabe cuando la suma de las fichas en la mesa superen una cantidad\n\nEl resto de las posibles variaciones son más o menos obvias\n\nUna vez que se eligen las reglas, puede presionar el botón play para comenzar a ver la simulación\n\nPara cambiar entre una escena y otra se presiona el boton ▶ en la esquina superior izquierda\n\nPara salir de la simulación en medio de una ronda presione el botón ↩ en la esquina superior izquierda\n\nAl final de cada ronda vera el resumen del juego hasta el momento y podra seleccionar si continuar o salir\n\nAl final del juego saldrá el equipo ganador, sus puntos y podra ver un nuevo juego o volver al menu principal\n\nEsperamos de disfruten de este simulador\nCreadores:\nDaniel Abad Fundora\nJavier Rodriguez Sanchez";

    public static IEnumerable<string> Lineas(string s)
    {
        string retorno="";
        for(int i=0;i<s.Length;i++)
        {
            if(s[i]=='\n')
            {
                yield return retorno;
                retorno="";
                continue;
            }
            retorno+=s[i];
        }
    }
}