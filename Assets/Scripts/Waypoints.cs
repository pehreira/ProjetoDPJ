using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] points; //static para que não seja necessário referenciar este script, mas para que possa ser acedido a partir de qualquer sitio

    // Start is called before the first frame update
    void Awake()
    {
        points = new Transform[transform.childCount]; //criamos um array com 13 espaços (13 espaços porque existem no total 13 filhos), ou seja, ele conta a quantidade de filhos do objeto atual, e cria uma string com espaço igual ao numero total de filhos
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i); //definimos que cada espaço do array guarda um filho, ou seja, o espaço zero guarda o filho 0, o espaço 1 o filho 1 etc...
        }
    }

}
