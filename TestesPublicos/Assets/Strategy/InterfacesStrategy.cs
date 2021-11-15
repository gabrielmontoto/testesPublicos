using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace interfaces
{
    public interface ICausarDano
    {
        void CausarDano(int valor, GameObject quemRecebe, bool ataqueDistante);
    }

    public interface ITomarDano
    {
        void ReceberDano(int valor, elementos tipo, bool ataqueDistante);
    }

    public enum elementos
    {
        FOGO,
        GRAMA,
        AGUA
    }
}
