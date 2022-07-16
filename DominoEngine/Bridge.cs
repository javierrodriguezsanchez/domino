using DominoGame;
using DominoPlayer;
using DominoRules;
static public class Bridge
{
    static public Torney<int> torneo=null!;
    static public Game<int> juegoActual=null!;
    static public IEnumerator<Game<int>> juegos=null!;
    static public IEnumerator<Escena<int>> escenas=null!;
    static public Escena<int> escenaActual=null!;
    static public Player<int>[] jugadores=null!; 
    static public Rules<int> reglas=null!;
    public static void CrearTorneo(int NumOfPlayers, int top, int max, string[] names, int[] teams, 
    int[] tipes, int Turn, int judge, int end, int torney, int winner, int deliver, int generator, int evaluator)
    {
        jugadores= new Player<int>[NumOfPlayers];
        for(int i=0;i<NumOfPlayers;i++)
        {
            switch(tipes[i])
            {
                case 0:
                {
                    jugadores[i]=new Player<int>(names[i], new estrategiaBorracho<int>(), teams[i]);
                    break;
                }
                case 1:
                {
                    jugadores[i]=new Player<int>(names[i], new estrategiaBotaGorda<int>(), teams[i]);
                    break;
                }
                case 2:
                {
                    jugadores[i]=new Player<int>(names[i], new BotaMasRepetida<int>(), teams[i]);
                    break;
                }
                case 3:
                {
                    jugadores[i]=new Player<int>(names[i], new Pro<int>(),teams[i]);
                    break;
                }
                case 4:
                {
                    jugadores[i]=new Player<int>(names[i], new EstrategiaCambiante<int>(),teams[i]);
                    break;
                }
                default:
                {
                    jugadores[i]=new Player<int>(names[i], new estrategiaBotaGorda<int>(), teams[i]);
                    break;
                }
            }
        }

        IEndCondition<int> final;

        switch(end)
        {
            case 0:
            {
                final=new FinPorTranque<int>();
                break;
            }
            case 1:
            {
                final=new DosPases<int>();
                break;
            }
            case 2:
            {
                final=new Mesa150puntos<int>();
                break;
            }
            default:
            {
                final=new FinPorTranque<int>();
                break;
            }
        }
        
        IPieceEvaluator<int> evaluador;

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
                evaluador=new EquitativeEvaluator<int>();
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
        
        ITurn<int> turno;
        
        switch(Turn)
        {
            case 0:
            {
                turno= new NormalTur<int>();
                break;
            }
            case 1:
            {
                turno= new Robadito<int>();
                break;
            }
            case 4:
            {
                turno= new Ciclomino<int>();
                break;
            }
            default:
            {
                turno= new NormalTur<int>();
                break;
            }
        }

        ILegalPlay<int> validador;

        switch(judge)
        {
            case 0:
            {
                validador= new RegularLegalPlay<int>();
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
                validador= new AlwaysCanUseDobles<int>();
                break;
            }
            default:
            {
                validador= new RegularLegalPlay<int>();
                break;
            }
        }

        IWinner<int> ganador;
        
        switch(winner)
        {
            case 0:
            {
                ganador=new finalPorPuntos<int>();
                break;
            }
            case 1:
            {
                ganador=new TeamPoints<int>();
                break;
            }
            default:
            {
                ganador=new finalPorPuntos<int>();
                break;
            }
        }

        ITorn<int> tipoTorn;
        switch(torney)
        {
            case 0:
            {
                tipoTorn=new TornPorPuntos<int>();
                break;
            }
            default:
            {
                tipoTorn=new TornPorVictorias<int>();
                break;
            }
        }

        IPieceDistributer<int> distributer;
        
        switch(deliver)
        {
            case 1:
            {
                distributer=new distribucionRandom<int>();
                break;
            }
            default:
            {
                distributer=new distribucionEquitativa<int>();
                break;
            }
        }

        IGenerator<int> generador;

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

        reglas=new Rules<int>(final,evaluador,turno,validador,ganador,tipoTorn,distributer,generador,top,max);
        torneo=new Torney<int>(jugadores,reglas);
        juegos=torneo.GetEnumerator();
        if(juegos.MoveNext())
        {
            escenas=juegos.Current.GetEnumerator();
            if(escenas.MoveNext())
                escenaActual=escenas.Current;
        }
    }
}