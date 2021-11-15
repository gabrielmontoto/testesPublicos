using interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStrategy : MonoBehaviour, ITomarDano
{
    [SerializeField] float vida;
    [SerializeField] elementos elementoAtualPlayer;

    //algo pra representar a arma
    [SerializeField] ArmaBaseStrategy armaBaseStrategy;
    [SerializeField] GameObject inimigo;

    [SerializeField] ManagerEstrategy manager;
    public float Vida { get { return vida; } }
    public void ReceberDano(int valor, elementos tipo, bool ataqueDistante)
    {
        if (ataqueDistante || armaBaseStrategy.Distante == false)
            switch (tipo)
        {
            case elementos.FOGO:
                if (elementoAtualPlayer == elementos.FOGO)
                {

                    print("nenhum dano recebido");
                }
                else if (elementoAtualPlayer == elementos.GRAMA)
                {
                    vida -= valor ;
                }
                else if (elementoAtualPlayer == elementos.AGUA)
                {
                    vida -= valor / 2;
                }
                break;
            case elementos.GRAMA:
                if (elementoAtualPlayer == elementos.FOGO)
                {
                    vida -= valor / 2;

                }
                else if (elementoAtualPlayer == elementos.GRAMA)
                {
                    print("nenhum dano recebido");
                }
                else if (elementoAtualPlayer == elementos.AGUA)
                {
                    vida -= valor ;
                }
                break;
            case elementos.AGUA:
                if (elementoAtualPlayer == elementos.FOGO)
                {
                    vida -= valor ;

                }
                else if (elementoAtualPlayer == elementos.GRAMA)
                {
                    vida -= valor / 2;
                }
                else if (elementoAtualPlayer == elementos.AGUA)
                {
                    print("nenhum dano recebido");
                }
                break;
            default:
                break;
        }
    }
    public elementos ElementoAtualPlayer { get { return elementoAtualPlayer; }  }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            print("pew!");
            ICausarDano elemento = new GramaEstrategy();
            armaBaseStrategy.AtribuirElemento(elemento);
            armaBaseStrategy.Ataque(inimigo, armaBaseStrategy.Distante);
        }
    }
    public void botaoAtaqueEscolhido(ElementoEArmaStrategy elementoEArmaStrategy)
    {
        if (manager.TurnoJogo == outrosStrategy.Turnos.Player)
        {
            elementoAtualPlayer = elementoEArmaStrategy.Elementos;
            armaBaseStrategy = elementoEArmaStrategy.ArmaArmazenada;

            ICausarDano elemento = RetornarElemento();
            armaBaseStrategy.AtribuirElemento(elemento);
            armaBaseStrategy.Ataque(inimigo, armaBaseStrategy.Distante);

            //gamemanager e turno terminado
            manager.AtaquePlayer();
        }
    }
    private ICausarDano RetornarElemento()
    {
        if (elementoAtualPlayer == elementos.AGUA)
        {
            return new AguaEstrategy();
        }
        else if (elementoAtualPlayer == elementos.FOGO)
        {
            return new AguaEstrategy();
        }
        else
        {
            return new GramaEstrategy();
        }
    }
}
