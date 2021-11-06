using interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace outrosStrategy
{
    [System.Serializable]
    public class Cores
    {
        public Color corAgua, corGrama, CorFogo;
        public Color coresElementos(elementos elemento)
        {
            if(elemento == elementos.FOGO)
            {
                return CorFogo;
            }
            else if (elemento == elementos.GRAMA)
            {
                return corGrama;
            }
            else
            {
                return corAgua;
            }
            
        }
    }

    public enum Turnos
    {
        Player,
        Inimigo,
        Vitoria,
        Derrota
    }
}