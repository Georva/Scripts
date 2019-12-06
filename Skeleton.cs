using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
  Balbuena Nogues Gerorva Ivette
  Programacion  orienta a objetos
  Prof: JOSUE ISRAEL RIVAS DIAZ  
  Grupo: DAA07A
     */

public class Skeleton : Agentes
{
    public string Id;
    public string nombre;
    public int vida;
    public int magia;
    public float _velocidadAgente;
    Animator anim;

    /* lugar de donde se van a sacar los datos*/
    EnemigoB enemigoB;
    // Start is called before the first frame update
    void Start()
    {
        VelocidadAgente = velocidad;
        enemigoB = FindObjectOfType<EnemigoB>();
        BusquedaEnemigo(Id);

        this.anim = GetComponent<Animator>();
        destino = GameObject.Find("destino").GetComponent<Transform>();
        objetivo = GameObject.Find("destino").GetComponent<Transform>();
    }

    private void BusquedaEnemigo(string id)
    {
        /*Identificar BusquedaEnemigo que no existia antes */
        for (int i = 0; i < enemigoB.enemigo.Count; i++)
        {/*si el id que esta dentro del parametro, busca el dato y que haga una igualdad
dentro del nombre, se regresan datos especificos*/
            if (id == enemigoB.enemigo[i].nombre)
            {
                /* algoritmo de busqueda dentro de i*/
                nombre = enemigoB.enemigo[i].nombre;
                vida = enemigoB.enemigo[i].vida;
                magia = enemigoB.enemigo[i].magia;
            }
        }
    }

    void Update()
    {
        if (MedirDistanciaBool()) 
        {
            ConfigurarDestino(destino);

            if (MedirDistanciaFloat() <= freno)
            {
                Debug.Log("Tomaaaa");
                anim.SetBool("Ataque", true);
            }

            else
            {
                anim.SetBool("Atque", false);
            }

        }

        //El signo "!" es igual a false if (Medir if (!MedirDistanciaBool()==false)
        else if (!MedirDistanciaBool())
        {
            VelocidadAgente = 0;
        }

        if (anim != null)
        {
            anim.SetFloat("velocidad", VelocidadAgente);
        }
      
    }


}
