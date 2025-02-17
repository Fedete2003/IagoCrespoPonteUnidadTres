using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAttack : MonoBehaviour
{
    //Zona de variables globales
    //Referencia al prefab
    [SerializeField]
    private Rigidbody _shellPrefab;
    //Referencia al "gameObject" vacio que instacia las balas
    [SerializeField]
    private Transform _posRot;
    //Fuerza salida balas
    [SerializeField]
    private float _launchForce;
    //AudioSource que lleva el objecto "_posRot"
    [SerializeField]
    private AudioSource _audioSource;


    // Update is called once per frame
    void Update()
    {
        InputPlayer();
    }

    private void InputPlayer()
    {

        if (Input.GetMouseButtonDown(0)) 
        {
            Launch();
        }


    }
    private void Launch()
    {

        Rigidbody clonShellPrefab = Instantiate(_shellPrefab, 
                                                _posRot.position, _posRot.rotation);
        _audioSource.Play();
        clonShellPrefab.velocity = _posRot.forward * _launchForce;
    }
}
