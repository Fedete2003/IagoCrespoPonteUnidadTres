using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnLemonMovement : MonoBehaviour
{
    //Zona variables globales
    [Header("Movement")]
    [SerializeField]
    private float _speed,
                  _turnSpeed;

    //Guardamos la dirección del movimiento
    [SerializeField]
    private Vector3 _direction;

    private Rigidbody _rb;
    private Animator _anim;
    private float _horizontal,
                  _vertical;
    

    private void Awake()
    {

        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();

    }


    private void OnAnimatorMove()
    {


        _rb.MovePosition(transform.position +
                        (_direction * _anim.deltaPosition.magnitude));


    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputPlayer();
        IsAnimate();
    }


    private void InputPlayer()
    {
        //Obtener valores de las teclas A, D, y flechas horizontales
        _horizontal = Input.GetAxis("Horizontal");
        //Obtener valores de las teclas W, S, y flechas verticales
        _vertical = Input.GetAxis("Vertical");

        //Utilizar un Vector vacío en el que almacenamos los "inputs" del jugador
        _direction = new Vector3 (_horizontal, 0.0f, _vertical);
        _direction.Normalize();
    }

    private void IsAnimate()
    {

        if (_horizontal != 0.0f || _vertical != 0.0f)
        {

            _anim.SetBool("IsWalking", true);

        }
        else
        {
            _anim.SetBool("IsWalking", false);
        }

    }
}
