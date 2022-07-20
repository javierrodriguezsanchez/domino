using DominoGame;
using DominoPlayer;
using DominoRules;
static public class Bridge2
{
    static public Torney<char> torneo=null!;
    static public Game<char> juegoActual=null!;
    static public IEnumerator<Game<char>> juegos=null!;
    static public IEnumerator<Escena<char>> escenas=null!;
    static public Escena<char> escenaActual=null!;
    static public Player<char>[] jugadores=null!; 
    static public Rules<char> reglas=null!;
    public static void CrearTorneo(int NumOfPlayers, int top, int max, string[] names, int[] teams, 
    int[] tipes, int Turn, int judge, int end, int torney, int winner, int deliver, int generator, int evaluator)
    {
        jugadores= new Player<char>[NumOfPlayers];
        for(int i=0;i<NumOfPlayers;i++)
        {
            switch(tipes[i])
            {
                case 0:
                {
                    jugadores[i]=new Player<char>(names[i], new estrategiaBorracho<char>(), teams[i]);
                    break;
                }
                case 1:
                {
                    jugadores[i]=new Player<char>(names[i], new estrategiaBotaGorda<char>(), teams[i]);
                    break;
                }
                case 2:
                {
                    jugadores[i]=new Player<char>(names[i], new BotaMasRepetida<char>(), teams[i]);
                    break;
                }
                case 3:
                {
                    jugadores[i]=new Player<char>(names[i], new Pro<char>(),teams[i]);
                    break;
                }
                case 4:
                {
                    jugadores[i]=new Player<char>(names[i], new EstrategiaCambiante<char>(),teams[i]);
                    break;
                }
                default:
                {
                    jugadores[i]=new Player<char>(names[i], new estrategiaBotaGorda<char>(), teams[i]);
                    break;
                }
            }
        }

        IEndCondition<char> final;

        switch(end)
        {
            case 0:
            {
                final=new FinPorTranque<char>();
                break;
            }
            case 1:
            {
                final=new DosPases<char>();
                break;
            }
            case 2:
            {
                final=new Mesa150puntos<char>();
                break;
            }
            default:
            {
                final=new FinPorTranque<char>();
                break;
            }
        }
        
        IPieceEvaluator<char> evaluador;

        switch(evaluator)
        {
            case 4:
            {
                evaluador=new EquitativeEvaluator<char>();
                break;
            }
            default:
            {
                evaluador=new CharEvaluator();
                break;
            }
        }
        
        ITurn<char> turno;
        
        switch(Turn)
        {
            case 0:
            {
                turno= new NormalTur<char>();
                break;
            }
            case 1:
            {
                turno= new Robadito<char>();
                break;
            }
            case 4:
            {
                turno= new Ciclomino<char>();
                break;
            }
            default:
            {
                turno= new NormalTur<char>();
                break;
            }
        }

        ILegalPlay<char> validador;

        switch(judge)
        {
            case 0:
            {
                validador= new RegularLegalPlay<char>();
                break;
            }
            case 3:
            {
                validador= new AlwaysCanUseDobles<char>();
                break;
            }
            default:
            {
                validador= new RegularLegalPlay<char>();
                break;
            }
        }

        IWinner<char> ganador;
        
        switch(winner)
        {
            case 0:
            {
                ganador=new finalPorPuntos<char>();
                break;
            }
            case 1:
            {
                ganador=new TeamPoints<char>();
                break;
            }
            default:
            {
                ganador=new finalPorPuntos<char>();
                break;
            }
        }

        ITorn<char> tipoTorn;
        switch(torney)
        {
            case 0:
            {
                tipoTorn=new TornPorPuntos<char>();
                break;
            }
            default:
            {
                tipoTorn=new TornPorVictorias<char>();
                break;
            }
        }

        IPieceDistributer<char> distributer;
        
        switch(deliver)
        {
            case 1:
            {
                distributer=new distribucionRandom<char>();
                break;
            }
            default:
            {
                distributer=new distribucionEquitativa<char>();
                break;
            }
        }

        IGenerator<char> generador;

        switch(generator)
        {
            default:
            {
                generador=new CharGenerator();
                break;
            }
        }

        reglas=new Rules<char>(final,evaluador,turno,validador,ganador,tipoTorn,distributer,generador,top,max);
        torneo=new Torney<char>(jugadores,reglas);
        juegos=torneo.GetEnumerator();
        if(juegos.MoveNext())
        {
            escenas=juegos.Current.GetEnumerator();
            if(escenas.MoveNext())
                escenaActual=escenas.Current;
        }
    }
}