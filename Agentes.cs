using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agentes : MonoBehaviour
{

    /*
     Protected solo lo puede modificar por el creador y por sus hijos
     Abstracto, compartir los datos, no hay start y update, solo lo ejecuta los ajentes
    
         */
         [SerializeField] //permite que el cod se pueda mod desde el inspector, forma de proteccion
    protected float velocidad;
    [SerializeField]
    protected Transform destino;
    [SerializeField]
    protected float freno;
    [SerializeField]
    protected float distanciaMeta;
    [SerializeField]
    protected Transform objetivo;
    [SerializeField]
    protected float VelocidadAgente;

    protected void ConfigurarDestino (Transform d)
        //deifiniar el espacio en donde se puede mover el personaje
    {
        
   
        //aislar los elementos
        Vector3 destinoFinal = new Vector3(d.position.x, this.transform.position.y, d.position.z);

        ConfiguracionFreno(destinoFinal, freno);

        transform.LookAt(destinoFinal);
       
            transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
        
    
    }
    //En vez de utilizar void,se utilizan variables (bool,int,float,double), regresar datos
    protected bool ConfiguracionFreno (Vector3 d, float f)
    {
        float valocidadLocal = 1;
        //ayuda a depurar los cambios
       float distancia = Vector3.Distance(transform.position, d);
      

        if (distancia < f)
        {
            velocidad = 0;
            return (true);
        }
        else
        {
            velocidad = valocidadLocal;
            return (false);
        }
 
    }
       protected float MedirDistanciaFloat()
    {
        Vector3 metaPos = new Vector3(objetivo.position.x, this.transform.position.y, objetivo.position.z);
        float distancia = Vector3.Distance(transform.position, metaPos);
        Debug.Log(distancia);
        return distancia;

    }

    protected bool MedirDistanciaBool()
    {
        Vector3 metaPos = new Vector3(objetivo.position.x, this.transform.position.y, objetivo.position.z);
        float distancia = Vector3.Distance(transform.position, metaPos);

        if (distancia < distanciaMeta)
            return true;
        else
            return false;
    }
}
