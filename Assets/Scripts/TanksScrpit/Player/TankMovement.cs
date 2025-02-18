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

    [Header("Sound")]
    [SerializeField]
    private AudioClip _idleClip;
    [SerializeField]
    private AudioClip _driveClip;

    private AudioSource _audioSource;


    private void Awake()
    {

        _rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
        Cursor.lockState = CursorLockMode.Locked;

    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void FixedUpdate()
    {
        Move();
        Turn();
    }


    // Update is called once per frame
    void Update()
    {

        InputsPlayer();
        AudioPlayer();

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

    private void Turn()
    {

        float turn = _horizontal * _turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0.0f, _horizontal, 0.0f);
        _rb.MoveRotation(transform.rotation * turnRotation);

    }

    private void AudioPlayer()
    {
        
        //El tanque se mueve o rota
        if(_vertical != 0.0f || _horizontal != 0.0f)
        {
            if(_audioSource.clip != _driveClip)
            {
                _audioSource.clip = _driveClip;
                _audioSource.Play();
            }
        }else //El tanque esta parado
        {

            if(_audioSource.clip != _idleClip)
            {
                _audioSource.clip = _idleClip;
                _audioSource.Play();
            }

        }
    }

}
