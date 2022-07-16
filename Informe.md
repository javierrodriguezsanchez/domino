 El dominó es un popular juego de mesa en el cual, un conjunto de jugadores se turnan para concatenar un conjunto de fichas. 

 Existen disimiles variantes de este juego, por ejemplo, en la zona oriental de nuestro país, el juego se compone de 28 fichas y 4 jugadores, tomando cada jugador 7 fichas al iniciar el juego. Por otro lado, en la capital, el juego se compone de 55 fichas, de las cuales se le asignan 10 a cada jugador y 15 permanecen boca abajo en la mesa.

  Con este proyecto pretendemos simular distintos juegos de domino, permitiendo variar las reglas y las diferentes posibles estrategias de los jugadores.

 
 Estructura: 

 Game<T>:

Este proyecto posee como clase principal la clase “Game<T>”, la cual representa una partida de domino, esta clase implementa la interface IEnumerable<Escena<T>>, que permite recorrer un objeto de tipo “Game” con un ciclo foreach y ver las escenas del juego. 
 “Game<T>” recibe como parámetros una clase de tipo “Rules<T>” y un array de “DominoPlayer<T>” (posteriormente se explicará brevemente la estructura de estas clases)
  La mesa del juego viene representada mediante la clase “Table<T>”, la cual memoriza el historial del juego y revela las posibles jugadas. 
 Con el objetivo de simular todo un torneo de Domino, se ha creado la clase “Torney<T>”, la cual implementa la interface “IEnumerable<Game<T>>”, que permite recorrer a través de los diferentes juegos de dominó para poder observar así todo el desarrollo del torneo.
A continuación explicaré el funcionamiento de las clases “DominoPlayer<T>”, “Table<T>”, “Torney<T>”, “Rules<T>” y “Escena<T>”:

-	DominoPlayer<T> representa a un jugador de dominó, este recibe como parámetro un string con el nombre del jugador, un int que representa el equipo del jugador y una interface "IEstrategia" que representa el algoritmo que seguira el jugador a la hora de jugar. Esta clase posee el metodo Play que recibe un conjunto de datos del juego y devuelve la jugada ideal según la estategia. 

Entre las diferentes estrategias que implementa el jugador podemos mecionar: 
Estrategia Borracho: El cual juega la primera ficha que ve.
Estrategia BotaGordas: Evalua cada ficha ficha y juega la de mayor valor posible
Estrategia Agachado: Analiza que tan reemplazable es cada ficha de su mano y juega la mas prescindible posible
Estrategia Pro: Analiza el historial del juego, tiene en cuenta las fichas que sabe que no 
lleva tanto sus aliados como sus oponentes, ademas analiza que fichas ha jugado cada uno de ellos con el objetivo de seleccionar la ficha ideal a jugar
Estrategia Cambiante: Juega a partir de alguna de las estrategias anteriores aleatoriamente

-   Table<T>: Representa la mesa del juego, esta lleva la cuenta de las casillas que estan disponibles para jugar, almacena el historial del juego y lleva la cuenta de los pases de cada jugador. Ademas posee un metodo "VerMesaActual" el cual devuelve la forma de mostrarle a la intefaz grafica la estructura de las fichas. La clase Piece<T> representa a una ficha del juego. Esta posee un array de valores que representa cada cara de la ficha. La clase GamePieces<T> almacena las fichas que no han sido repartidas.

-   Torney<T>: Representa el torneo que se esta llevando a cabo. Es un recorrible de juegos, el cual, genera juegos y asigna puntos a los gandores hasta que se cumpla cierta condición de victoria.

-   Escena<T>: Constituye el nexo entre Game<T> y la interfaz gráfica. Se trata de una "foto" del juego que devuelve toda la información que se necesita para representarlo en pantalla.

-   Rules<T> representa las reglas del juego. Recibe un conjunto de interfaces que especifican cada regla del juego, entre las que podemos mencionar:

IPieceEvaluator: Posee el método Evaluar, el cual recibe una ficha y devuelve un entero (su valor asignado) Entre las diferentes formas de evaluar una ficha, podemos mencionar: la suma de sus caras, el producto de las mismas, su máximo, asi como la norma euclideana asociada a la misma si la consideramos un vector de Rn, un evaluador que devuelve el mismo valor para toda ficha y un evaluador que duplica el valor de los dobles. Tambien se ha implementado un evaluador de char, el cual le asigna a cada letra su posición en el alfabeto latino y devuelve la suma de estos valores.

IWinCondition<T>: Determina cuando se da por concluido un juego, estre las diferentas formas de tomar tal decisión tenemos: Al trancarse el juego, cuando la suma de los valores de las fichas en la mesa es mayor a 150 y al ocurrir dos pases seguidos

IWinner<T>: Al finalizar un juego, determina quien es el ganador del mismo. Como criterios para determinar esto tenemos: El equipo que posea al jugador cuya suma de los valores de las fichas en la mano sea menor y el jugador que posea la menor cantidad de fichas en la mano

IGenerator: Al iniciar el juego, genera las fichas con las cuales se jugara, el metodo Generate recibe un int que indica cuantos valores diferentes puede tener cada cara. Entre las diferentes formas de generar las fichas, podemos mencionar: todas las combinaciones de numeros posibles desde 0 a n, asi como un generador que crea fichas al azar de valores validos y uno encargado de crear las combinaciones de las n+1 primeras letras del alfabeto latino

ILegalPLay<T>: Proporciona un criterio de si una jugada es o no legal. Entre estos criterios tenemos: Si la cara de la ficha a jugar es igual a la cara de la ficha por donde se jugará, asi como una modadlidad del criterio anterior donde siempre se pueden usar dobles. Tenemos una modalidad donde siempre se puede jugar un blanco o el inmediato superior al valor por donde se jugará. Otra modalidad permite a los jugadores jugar por una cara que sea igual al antecesor o al sucesor de la ficha en mesa.

IPieceDistributer<T>: Se encarga de repartir las fichas a cada jugador al iniciar el juego. Recibe como parametro la cantidad de fichas que puede tener un jugador como máximo. Se ha creado una modalidad que le da la cada jugador el máximo de fichas al iniciar y uno que le da una cantidad aleatoria entre 1 y el máximo.

ITurn<T>: Establece las acciones a realizar durante un turno, rigiendo el proceso del juego. Se ha creado una modalidad en la cual cada jugador simplemente juega una ficha por turno, otra en la que, cada vez que un jugador se pasa, roba una ficha y una en la que si un jugador se pasa, además este de robar una ficha, se invierte la mesa, el jugador que comienza el juego puede jugar una ficha además de la salida, y si juegas un doble, puedes volver a jugar.

ITorn<T>: Establece el funcionamiento de un torneo, la forma de asiganar puntuaciones a los equipos y las condiciones de finalizacion del mismo. Se ha implementado una modalidad de torneo en la cual gana el primer jugador en alcanzar 3 victorias gana y uno en el cual, al acabar un juego, se le asigna al equipo ganador una puntiacion igual a la suma de los valores de las manos de los jugadores del equipo perdedor, ganado el primer equipo en obtener 100 puntos.




 