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

        _timer += Time.deltaTime;

        if(_timer >= _timeBetweenAttack)
        {

            _timer = 0.0f;
            _isAttacking = true;

        }

    }

    private void Launch()
    {

        Rigidbody clonShellPrefab = Instantiate(_shellEnemyPrefab, 
                                                _posRot.position, _posRot.rotation);

        clonShellPrefab.velocity = _posRot.forward * _launchForce;

    }
}
