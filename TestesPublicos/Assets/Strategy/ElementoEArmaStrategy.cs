using interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementoEArmaStrategy : MonoBehaviour
{
    [SerializeField] ArmaBaseStrategy armaArmazenada;
    [SerializeField] elementos elementoArmazenado;

    public ArmaBaseStrategy ArmaArmazenada { get { return armaArmazenada; } set { armaArmazenada = value; } }
    public elementos Elementos { get { return elementoArmazenado; } set { elementoArmazenado = value; } }

}
