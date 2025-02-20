using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankAttack : MonoBehaviour
{


    //Zona variables globales
    [Header("Time")]
    [SerializeField]
    private float _timer;
    [SerializeField]
    private float _timeBetweenAttack;
    private bool _isAttacking;

    [Header("Prefab")]
    [SerializeField]
    private Rigidbody _shellEnemyPrefab;
    [SerializeField]
    private Transform _posRot;
    [SerializeField]
    private float _launchForce;
    [SerializeField]
    private float _factorLaunchForce;


    //[Header("Raycast")]
    private Ray _ray;
    private RaycastHit _hit;
    private float _distance;
    






    private void Awake()
    {
        _isAttacking = false;
    }


    private void FixedUpdate() 
    {

        if (_isAttacking)
        {

            Launch();
            _isAttacking = false;

        }
    
    }

    // Update is called once per frame
    void Update()
    {
        CountTimer();
    }

    private void CountTimer()
    {

        _ray.origin = transform.position;
        _ray.direction = transform.forward;

        _timer += Time.deltaTime;

        if(Physics.Raycast(_ray, out _hit))
        {
            if (_hit.collider.CompareTag("PlayerTank") && _timer >= _timeBetweenAttack)
            {

                _timer = 0.0f;
                _isAttacking = true;
                //Se saca la distancia entre el "Tanque Jugador" y el "Tanque Enemigo"
                _distance = _hit.distance;

            }
        }


    }

    private void Launch()
    {

        float launchForceFinal = _launchForce * _distance * _factorLaunchForce;

        Rigidbody clonShellPrefab = Instantiate(_shellEnemyPrefab, 
                                                _posRot.position, _posRot.rotation);

        clonShellPrefab.velocity = _posRot.forward * launchForceFinal;

    }
}
