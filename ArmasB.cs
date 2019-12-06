using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
  Balbuena Nogues Gerorva Ivette
  Programacion  orienta a objetos
  Prof: JOSUE ISRAEL RIVAS DIAZ  
  Grupo: DAA07A
     */

[System.Serializable]

public class ArmasB : MonoBehaviour
{
    public List<Armas> armasPC;
    public List<Armas> armasfire;

    // Start is called before the first frame update
    void Awake()
    {
        armasPC.Add(new Armas("Suibian", 10));
        armasfire.Add(new Armas("Jackal", 50, 6));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
