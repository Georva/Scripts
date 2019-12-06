using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
  Balbuena Nogues Gerorva Ivette
  Programacion  orienta a objetos
  Prof: JOSUE ISRAEL RIVAS DIAZ  
  Grupo: DAA07A
     */

/* sirve para hacer invocaciones, metodo constructor (Bob)*/
[System.Serializable]
    public class Enemigo
    {
        public string nombre;
        public int vida;
        public int magia;
        public Enemigo(int v, int m, string n)
        {
            /*llave de acceso de datos almacenados en enemigos*/
            this.nombre = n;
            this.vida = v;
            this.magia = m;
        }
    }


