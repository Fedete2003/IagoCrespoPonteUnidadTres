using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ghost : MonoBehaviour
{

    //Zona variables globales
    [Header("Waypoints")]
    [SerializeField]
    //Posiciones de los waypoints
    private Transform[] _positionsArray;
    [SerializeField]
    private float _speed;
    //Direccion del fantasma
    private Vector3 _posToGo;
    //Indice para controlar que posición del "array" estoy
    private int _i;

    //Raycast
    private Ray _ray;
    private RaycastHit _hit;

    public GameManager GameManagerScript;
    

    // Start is called before the first frame update
    void Start()
    {

        _i = 0;
        _posToGo = _positionsArray[_i].position;
        
    }

    private void FixedUpdate()
    {

        DetectionJohnLemon();

    }

    // Update is called once per frame
    void Update()
    {

        Move();
        ChangePosition();
        Rotate();

    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _posToGo,
                                            _speed * Time.deltaTime);


    }

    private void ChangePosition()
    {

        //Si el fantasma llega a la posición
        if(Vector3.Distance(transform.position, _posToGo) <= Mathf.Epsilon)
        {
            //Comprobar posicion en el "array"
            if(_i == _positionsArray.Length - 1)
            {
                //Volver a la casilla inicial
                _i = 0;
            }
            else
            { 
                //Sumar uno al índice
                _i++;
            
            }
            //Ir a la posición selecionada
            _posToGo = _positionsArray[_i].position;


        }
    }

    private void Rotate()
    {
        transform.LookAt(_posToGo);
    }

    private void DetectionJohnLemon()
    {
        //Subir el origen del rayo 1 metro en el eje Y con respecto al pivote
        _ray.origin = new Vector3(transform.position.x,
                                transform.position.y + 1.0f, transform.position.z);
        _ray.direction = transform.forward;

        if(Physics.Raycast(_ray, out _hit))
        {
            if(_hit.collider.CompareTag("JohnLemon"))
            {
                Debug.Log("Booooo, te agarre.");
                GameManagerScript.IsPlayerCaught = true;
            }
        }
    }
}
