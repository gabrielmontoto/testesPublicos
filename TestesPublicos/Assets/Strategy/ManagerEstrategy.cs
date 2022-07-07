using interfaces;
using outrosStrategy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerEstrategy : MonoBehaviour
{
    [SerializeField] GameObject[] slots;
    ICausarDano[] tipoDano;
    [SerializeField] ArmaBaseStrategy[] tipoDeArmas;
    [SerializeField] List<elementos> proximoAtaqueInimigo;

    [Space][Header("algo escrito")][Tooltip("vou escreveer algo aqui")]
    [SerializeField] Cores cores;
    [SerializeField] Turnos turnos;
    public Turnos TurnoJogo { get { return turnos; }  }

    [SerializeField] InimigoStrategy inimigo;
    [SerializeField] Image inimigoImagem;
    [SerializeField] Text InimigoProximosAtaques;
    [SerializeField] PlayerStrategy player;
    [SerializeField] Text textoElementoJogador, textoVidaJogador;
    // Start is called before the first frame update
    void Start()
    {
        ArmazenamentoDeElementos();
        proximoAtaqueInimigo = new List<elementos>();

        
        for (int i = 0; i < 3; i++)
        {
            // proximoAtaqueInimigo.TipoInimigo = (elementos)Random.Range(0, 3);
            proximoAtaqueInimigo.Add((elementos)Random.Range(0, 3));

            
        }
        InimigoProximosAtaques.text = "";
        for (int i = 0; i < 3; i++)
        {
            InimigoProximosAtaques.text += proximoAtaqueInimigo[i] + "\n";
        }
        
        EscolherAlguemPraIniciar();
        inimigoImagem.color = cores.coresElementos(inimigo.TipoInimigo);
        inimigo.ReceberArma(tipoDeArmas[Random.Range(0, tipoDeArmas.Length)]);
        textoElementoJogador.text = player.ElementoAtualPlayer.ToString();
        textoVidaJogador.text = player.Vida + "/10";
        AplicarElementosNosBotoes();
    }

    private void AplicarElementosNosBotoes()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            ElementoEArmaStrategy temp = slots[i].GetComponent<ElementoEArmaStrategy>();
            temp.Elementos = (elementos)Random.Range(0, 3);
            slots[i].GetComponent<Image>().color = cores.coresElementos(temp.Elementos);
            temp.ArmaArmazenada = tipoDeArmas[Random.Range(0, tipoDeArmas.Length)];
            temp.GetComponentInChildren<Text>().text = temp.ArmaArmazenada.Nome + "\n" + temp.ArmaArmazenada.ValorDano + " de dano";
            //fazer o mesmo com as armas
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(turnos==Turnos.Player)
        {
            //aguardar jogada player
           // AtaquePlayer();
        }
        else if(turnos==Turnos.Inimigo)
        {
            AtaqueInimigo();
        }
        //estrutura da batalha por turno x
        //escolher arma e elemento ao jogador e aplicar aos slots
        //quando vencer x
        //quando perder x
       
    }


    private void EscolherAlguemPraIniciar()
    {
        int alguem = Random.Range(0, 2);
        if(alguem==0)
        {
            //vez player
            turnos = Turnos.Player;
        }
        else
        {
            //vez inimigo
            turnos = Turnos.Inimigo;
        }
    }

    private void ArmazenamentoDeElementos()
    {
        tipoDano = new ICausarDano[3];
        ICausarDano elemento = new GramaEstrategy();
        tipoDano[0] = elemento;
        elemento = new FogoEstrategy();
        tipoDano[1] = elemento;
        elemento = new AguaEstrategy();
        tipoDano[2] = elemento;
    }

    public void AtaquePlayer()
    {

        //checar se inimigo morreu
        //mudar turno
        textoElementoJogador.text = player.ElementoAtualPlayer.ToString();
        if (inimigo.Vida > 0)
        {
            turnos = Turnos.Inimigo;
        }
        else
        {
            turnos = Turnos.Vitoria;
            print("o Player venceu!");
        }
        AplicarElementosNosBotoes();


    }
    public void AtaqueInimigo()
    {
        inimigo.ReceberArma(tipoDeArmas[Random.Range(0, tipoDeArmas.Length)]);
        inimigo.TipoInimigo = proximoAtaqueInimigo[0];
        proximoAtaqueInimigo.RemoveAt(0);
        inimigoImagem.color = cores.coresElementos(inimigo.TipoInimigo);
        proximoAtaqueInimigo.Add((elementos)Random.Range(0, 3));

        inimigo.AtaqueInimigo();
        //checar se player morreu
        //mudar turno
        if (player.Vida > 0)
        {
            turnos = Turnos.Player;
            textoVidaJogador.text = player.Vida + "/10";
        }
        else
        {
            turnos = Turnos.Derrota;
            textoVidaJogador.text =  "0/10";
            print("O player perdeu");
        }

        InimigoProximosAtaques.text = "";
        for (int i = 0; i < 3; i++)
        {
            InimigoProximosAtaques.text += proximoAtaqueInimigo[i] + "\n";
        }
    }
}
