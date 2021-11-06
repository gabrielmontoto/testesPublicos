using interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogoEstrategy : ICausarDano
{
    public void CausarDano(int valor, GameObject quemRecebe)
    {
        quemRecebe.GetComponent<ITomarDano>().ReceberDano(valor, elementos.FOGO);
    }
}
