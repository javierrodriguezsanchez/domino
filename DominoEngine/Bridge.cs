using DominoGame;
using DominoPlayer;
using DominoRules;
static public class Bridge
{
    static public Torney torneo=null!;
    static public Game juegoActual=null!;
    static public IEnumerator<Game> juegos=null!;
    static public IEnumerator<Escena> escenas=null!;
    static public Escena escenaActual=null!;
    static public Player[] jugadores=null!; 
    static public Rules reglas=null!;
    public static void CrearTorneo(int NumOfPlayers, int top, int max, string[] names, int[] teams, 
    int[] tipes, int Turn, int judge, int end, int torney, int winner, int deliver, int generator, int evaluator)
    {
        System.Console.WriteLine(123478);
        jugadores= new Player[NumOfPlayers];
        for(int i=0;i<NumOfPlayers;i++)
        {
            switch(tipes[i])
            {
                case 0:
                {
                    jugadores[i]=new Player(names[i], new estrategiaBorracho(), teams[i]);
                    break;
                }
                case 1:
                {
                    jugadores[i]=new Player(names[i], new estrategiaBotaGorda(), teams[i]);
                    break;
                }
                case 2:
                {
                    jugadores[i]=new Player(names[i], new BotaMasRepetida(), teams[i]);
                    break;
                }
                default:
                {
                    jugadores[i]=new Player(names[i], new estrategiaBotaGorda(), teams[i]);
                    break;
                }
            }
        }

        IEndCondition final;

        switch(end)
        {
            case 0:
            {
                final=new FinPorTranque();
                break;
            }
            case 1:
            {
                final=new DosPases();
                break;
            }
            case 2:
            {
                final=new Mesa150puntos();
                break;
            }
            default:
            {
                final=new FinPorTranque();
                break;
            }
        }
        
        IPieceEvaluator evaluador;

        switch(evaluator)
        {
            case 0:
            {
                evaluador=new SumEvaluator();
                break;
            }
            case 1:
            {
                evaluador=new DoubleDoublesEvaluator();
                break;
            }
            case 2:
            {
                evaluador=new MultiplicatoryEvaluator();
                break;
            }
            case 3:
            {
                evaluador=new VectorialEvaluator();
                break;
            }
            case 4:
            {
                evaluador=new EquitativeEvaluator();
                break;
            }
            case 5:
            {
                evaluador=new MaxEvaluator();
                break;
            }
            default:
            {
                evaluador=new SumEvaluator();
                break;
            }
        }
        
        ITurn turno;
        
        switch(Turn)
        {
            case 0:
            {
                turno= new NormalTur();
                break;
            }
            case 1:
            {
                turno= new Robadito();
                break;
            }
            case 4:
            {
                turno= new Ciclomino();
                break;
            }
            default:
            {
                turno= new NormalTur();
                break;
            }
        }

        ILegalPlay validador;

        switch(judge)
        {
            case 0:
            {
                validador= new RegularLegalPlay();
                break;
            }
            case 1:
            {
                validador= new Escareromino();
                break;
            }
            case 2:
            {
                validador= new Piramiomino();
                break;
            }
            case 3:
            {
                validador= new AlwaysCanUseDobles();
                break;
            }
            default:
            {
                validador= new RegularLegalPlay();
                break;
            }
        }

        IWinner ganador;
        
        switch(winner)
        {
            case 0:
            {
                ganador=new finalPorPuntos();
                break;
            }
            case 1:
            {
                ganador=new TeamPoints();
                break;
            }
            default:
            {
                ganador=new finalPorPuntos();
                break;
            }
        }

        ITorn tipoTorn;
        switch(torney)
        {
            case 0:
            {
                tipoTorn=new TornPorPuntos();
                break;
            }
            default:
            {
                tipoTorn=new TornPorVictorias();
                break;
            }
        }

        IPieceDistributer distributer;
        
        switch(deliver)
        {
            case 1:
            {
                distributer=new distribucionRandom();
                break;
            }
            default:
            {
                distributer=new distribucionEquitativa();
                break;
            }
        }

        IGenerator generador;

        switch(generator)
        {
            case 1:
            {
                generador=new CrazyGenerator();
                break;
            }
            default:
            {
                generador=new ClassicGenerator();
                break;
            }
        }

        reglas=new Rules(final,evaluador,turno,validador,ganador,tipoTorn,distributer,generador,top,max);
        torneo=new Torney(jugadores,reglas);
        juegos=torneo.GetEnumerator();
        if(juegos.MoveNext())
        {
            escenas=juegos.Current.GetEnumerator();
            if(escenas.MoveNext())
                escenaActual=escenas.Current;
        }
    }
}