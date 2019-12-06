using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
  Balbuena Nogues Gerorva Ivette
  Programacion  orienta a objetos
  Prof: JOSUE ISRAEL RIVAS DIAZ  
  Grupo: DAA07A
     */

public class Daño : MonoBehaviour
{    crear_enem dañoEnemigo;
    public string eti;

    // Start is called before the first frame update
    void Start()
    {
        dañoEnemigo = GetComponentInParent<crear_enem>();
        Debug.Log(dañoEnemigo.name);
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.Space))
        {
            dañoEnemigo.vida -= 10;
        }*/
    }

    private void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.tag == eti)
            
        {
            dañoEnemigo.vida -= 10;
        }
    }


}
