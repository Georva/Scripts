using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
  Balbuena Nogues Gerorva Ivette
  Programacion  orienta a objetos
  Prof: JOSUE ISRAEL RIVAS DIAZ  
  Grupo: DAA07A
     */


public class Barras : MonoBehaviour
{
    public Slider[] barras;
    public int vida;

    //se ancla al constructor de los enemigos en donde esta la vida
    crear_enem vidaEnemigo;

    // Start is called before the first frame update
    void Start()
    {
        //se ancla con el constructor de la creacion de enemigos (el cod largo)
        vidaEnemigo = GetComponentInParent<crear_enem>();
        StartCoroutine("asignarBarra");
    }

    // Update is called once per frame
    void Update()
    {
        barras[0].value = vidaEnemigo.vida;
        if (vidaEnemigo.vida == 0)
        {
            transform.parent.gameObject.SetActive(false);
        }
    }

    IEnumerator asignarvida()
    {
        yield return new WaitForSeconds(1);
        //en ese segundo le va a dejar pensar antes de asigar valores
        if (vidaEnemigo !=null)
        {
          vida = vidaEnemigo.vida;
            barras[0].maxValue = vida;
            barras[0].value = barras[0].maxValue;
        }
    }

    IEnumerator asignarBarra()
    {
        yield return new WaitForSeconds(1);
        barras = new Slider[2];
        barras = GetComponentsInChildren<Slider>();
        vida = vidaEnemigo.vida;
        for (int i = 0; i < barras.Length; i++)
        {
            barras[i] = barras[i];
            if (i == 0)
            {
                barras[i].maxValue = vida;
                barras[i].value = barras[i].maxValue;
            }
        }
    }
}
