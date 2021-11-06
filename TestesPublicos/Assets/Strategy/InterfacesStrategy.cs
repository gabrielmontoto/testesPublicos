using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace interfaces
{
    public interface ICausarDano
    {
        void CausarDano(int valor, GameObject quemRecebe);
    }

    public interface ITomarDano
    {
        void ReceberDano(int valor, elementos tipo);
    }

    public enum elementos
    {
        FOGO,
        GRAMA,
        AGUA
    }
}
