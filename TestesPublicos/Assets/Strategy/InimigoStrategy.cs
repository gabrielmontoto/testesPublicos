using interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InimigoStrategy : MonoBehaviour, ITomarDano
{
    [SerializeField] float vida;
    [SerializeField] elementos tipoInimigo;
    [SerializeField] ArmaBaseStrategy armaEquipada;
    [SerializeField] PlayerStrategy player;
    public float Vida { get { return vida; } }
    public elementos TipoInimigo { get { return tipoInimigo; } set { tipoInimigo = value; } }
    public void ReceberDano(int valor, elementos tipo)
    {
        switch (tipo)
        {
            case elementos.FOGO:
                if(tipoInimigo==elementos.FOGO)
                {

                    print("nenhum dano recebido");
                }
                else if(tipoInimigo == elementos.GRAMA)
                {
                    vida -= valor;
                }
                else if (tipoInimigo == elementos.AGUA)
                {
                    vida -= valor / 2;
                }
                break;
            case elementos.GRAMA://ataque que esta vindo
                if (tipoInimigo == elementos.FOGO)
                {
                    vida -= valor / 2;
                  
                }
                else if (tipoInimigo == elementos.GRAMA)
                {
                    print("nenhum dano recebido");
                }
                else if (tipoInimigo == elementos.AGUA)
                {
                    vida -= valor ;
                }
                break;
            case elementos.AGUA:
                if (tipoInimigo == elementos.FOGO)
                {
                    vida -= valor ;
                    
                }
                else if (tipoInimigo == elementos.GRAMA)
                {
                    vida -= valor / 2;
                }
                else if (tipoInimigo == elementos.AGUA)
                {
                    print("nenhum dano recebido");
                }
                break;
            default:
                break;
        }

        sliderVida.value = vida;
    }

    [SerializeField] Slider sliderVida;
    // Start is called before the first frame update
    void Start()
    {
        sliderVida.maxValue = vida;
        sliderVida.value = vida;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReceberArma(ArmaBaseStrategy arma)
    {
        armaEquipada = arma;
    }
    public void AtaqueInimigo()
    {
        armaEquipada.AtribuirElemento(RetornarElemento());
        armaEquipada.Ataque(player.gameObject);
    }
    private ICausarDano RetornarElemento()
    {
        if (TipoInimigo == elementos.AGUA)
        {
            return new AguaEstrategy();
        }
        else if (TipoInimigo == elementos.FOGO)
        {
            return new AguaEstrategy();
        }
        else
        {
            return new GramaEstrategy();
        }
    }
}
