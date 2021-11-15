using interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaBaseStrategy : MonoBehaviour
{
    public ICausarDano TipoDeDano;
    [SerializeField] protected int valorDano;
    [SerializeField] protected bool distante;
    [SerializeField] protected string nome;
    public string Nome { get { return nome; } }
    public int ValorDano { get { return valorDano; }  }
    public bool Distante { get { return distante; } }
    // [SerializeField] GameObject QuemRecebeDano;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AtribuirElemento(ICausarDano elemento)
    {

        TipoDeDano = elemento;
    }

    public void Ataque(GameObject QuemRecebeDano, bool AtqueDistancia)
    {
        TipoDeDano.CausarDano(valorDano, QuemRecebeDano, AtqueDistancia);
    }
}
