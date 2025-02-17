using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{

    //Zona variables globales
    [Header("Movement")]
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _turnSpeed;

    private float _horizontal,
                  _vertical;

    private Rigidbody _rb;


    private void Awake()
    {

        _rb = GetComponent<Rigidbody>();

    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void FixedUpdate()
    {
        Move();
    }


    // Update is called once per frame
    void Update()
    {

        InputsPlayer();

    }

    private void InputsPlayer()
    {

        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

    }


    private void Move()
    {
       
        Vector3 direction = transform.forward * _vertical * _speed * Time.deltaTime;
        _rb.MovePosition(transform.position + direction);

    }

}
