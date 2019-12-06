using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
  Balbuena Nogues Gerorva Ivette
  Programacion  orienta a objetos
  Prof: JOSUE ISRAEL RIVAS DIAZ  
  Grupo: DAA07A
     */

public class Mov : MonoBehaviour
{
    //va a considerar los modelos que estna dentro del escenario
    //este sirve en verdad sirve para . . . clasificar, encabezado de la variable en publico
    [Header("Visual")]
    //se adjunta al modelado
    /* 
     se declara esta variable ya que al nivel de animacion y keyframes ya tiene el giro definido
     por la propia secuencia
     como se requiere que el pivote lleve el peso se asigna un obj vacio 
         */
      //también se puede llamar TransformModel
    public GameObject model;
    public string[] tipoataque;
    public bool MovAtaq; 
    
    public int contador = 0;
    Animator anime;
    float velocidad;
    float velocidadlateral;
    //va a servir para poder hacer la rotacion dentro de la animacion
    float rotationSpeed = 2f;
    /*
     Quaternion = almacena el ángulo inicial del objeto para regresar y 
     para que no se quede a lo idiota
         */
    Quaternion targetModelRotation;

    //quaternion hace una lectura de fondo x,y,z,w en donde w es 0 o 1
    /* y define el peso dentro del pivote, se hace una interpolacion para hacer el cambio*/

    // Start is called before the first frame update
    void Start()
    {
        MovAtaq = false;
        contador = 0;
        anime = GetComponent<Animator>();
        velocidad = 6;
        velocidadlateral = 6;

        targetModelRotation = Quaternion.Euler(0, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
      //manda a llamar el codigo dentro del void. (muy complejo)
        ControlMovimiento();
        //CambioAtaque();
        Ataque(contador, "contador");
     

        //ctrlmov ataque

        if (Input.GetMouseButtonDown(0))
        {
            contador++;
            if (contador >= 4)
            {
                contador = 0;
            }
        }

    }//fin de update

    //manera de compartir codigos
    void ControlMovimiento()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        //no necesariamente se necesita declarar 2 veces translate

        Vector3 direccion = new Vector3(horizontal * velocidad * Time.deltaTime, 0, vertical * velocidad * Time.deltaTime);
        //aqui se pueden declarar los tres tipos de ejes dentro de un ambiente 3D

        //Transformar el movimiento del personaje para girar dentro de las 3 dimensiones
        /*
         Quaternion.Lerp = interpolacion o union, toma la última lectura de giro que tiene el 
         objeto que se especifica antes, el siguiente dato es hacia donde se quiere llegar
         pero con un estilo de suavizado en el mov, lo último se ref a la vel para trasladarse
         de la ultima lectura hasta donde va a llegar (time.deltatime estabiliza los cuadros a un sist
         de tiempo) si se pone primero es = la ultima lectura de cuadro se va a refresacar con la velocidad

         */
        model.transform.rotation = Quaternion.Lerp(model.transform.rotation, targetModelRotation, Time.deltaTime * rotationSpeed);

        transform.Translate(direccion);
        anime.SetFloat("Velocidad", vertical * velocidad);
        anime.SetFloat("Blend", horizontal * velocidadlateral);
     
        /*
         direccion.Normalize(); va a buscar la direccion entre 0 y 1, va a estabilizar la lectura
         */
        direccion.Normalize();

        /*
         de la variable direccion solo va a leer una coordenada en especifico
         se siguen las manecillas del reloj
         no se pueden leer angulos en negativo ya que afecta al pivote y lo mueve

         */
        if (direccion.z > 0)
        {
            targetModelRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direccion.z < 0)
        {
            targetModelRotation = Quaternion.Euler(0, 100, 0);
        }

        if (direccion.x > 0)
        {
            targetModelRotation = Quaternion.Euler(0, 90, 0);
        }
        else if (direccion.x < 0)
        {
            targetModelRotation = Quaternion.Euler(0, 270, 0);
        }

    }

    void ControlMovimientoAtaque()
    {
         ControlMovimientoAtaque();

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
       

        Vector3 direccion = new Vector3(horizontal * velocidad * Time.deltaTime, 0, vertical * velocidad * Time.deltaTime);
       

        transform.Translate(direccion);
        anime.SetFloat("velocidadAtFron", vertical * velocidad);
        anime.SetFloat("velocidadAtLat", horizontal * velocidadlateral);

       
        direccion.Normalize();


        
        if (direccion.z > 0)
        {
            targetModelRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direccion.z < 0)
        {
            targetModelRotation = Quaternion.Euler(0, 100, 0);
        }

        if (direccion.x > 0)
        {
            targetModelRotation = Quaternion.Euler(0, 90, 0);
        }
        else if (direccion.x < 0)
        {
            targetModelRotation = Quaternion.Euler(0, 270, 0);
        }

    }

    void ControlGeneralMovimiento()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            MovAtaq = true;
        }
        else
        {
            MovAtaq = false;
        }

        if (MovAtaq == false)
        {
            anime.SetLayerWeight(0, 1);
            anime.SetLayerWeight(1, 0);
            anime.SetLayerWeight(2, 0);
            ControlMovimiento();
        }
        if (MovAtaq == true)
        {
            anime.SetLayerWeight(0, 0);
            anime.SetLayerWeight(1, 0);
            anime.SetLayerWeight(2, 1);
            ControlMovimientoAtaque();
        }
    }


    //Metodo sobrecargado: Se llaman igual, pero realizan diferentes funciones (pide parametros o no ).
    /*
     El método parametrado no necesariamnente necesita parámetros dentro de los ()    
    */
    void Ataque (string tipoataque)
    {
                if (Input.GetMouseButtonDown(0))
                {
                    comAtaque();
                    anime.SetBool(tipoataque, true);
                 
                }
                else
                {
                    anime.SetBool(tipoataque, false);
          
                }

              
    }
    //Esto es un Metodo Sobrecargado 
    void Ataque(int contador, string contadorText) //combo
    {
           anime.SetInteger(contadorText, contador);
          
          
    }
           
    void CambioAtaque()
    {
          if (Input.GetKeyDown(KeyCode.Alpha1))
          {
                 contador++;
                 if (contador > tipoataque.Length -1)
                 {
                    contador = 0;
                 }

          }
        
    }
    void comAtaque()
    {
        contador++;
        if (contador > tipoataque.Length - 1)
        {
            contador = 0;
        }

    }
    /*
     METODS SOBRECARGADOS

     void Ataque() 
      void Ataque(string tipoAtaque) = conocido con bool
       void Ataque(int contador, string contadorText) = combo de juego 
     */


}
