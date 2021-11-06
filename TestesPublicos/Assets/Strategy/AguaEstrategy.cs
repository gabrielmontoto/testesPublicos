using interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AguaEstrategy : ICausarDano
{
    public void CausarDano(int valor, GameObject quemRecebe)
    {
        quemRecebe.GetComponent<ITomarDano>().ReceberDano(valor, elementos.AGUA);
    }
}
    


