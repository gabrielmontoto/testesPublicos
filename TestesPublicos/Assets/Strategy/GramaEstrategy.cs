using interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GramaEstrategy : ICausarDano
{
    public void CausarDano(int valor, GameObject quemRecebe,bool AtaqueDistante)
    {
        quemRecebe.GetComponent<ITomarDano>().ReceberDano(valor,elementos.GRAMA,AtaqueDistante);
    }
}
