using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    //Zona variables globales
    [Header("Vida")]
    [SerializeField]
    private float _maxHealth;
    [SerializeField]
    private float _currentHealth;
    [SerializeField]
    private float _damagePlayer;

    [Header("Barra de vida")]
    [SerializeField]
    private Image _lifeBarEnemy;


    private void Awake()
    {

        _currentHealth = _maxHealth;
        _lifeBarEnemy.fillAmount = 1.0f;


    }

    private void OnCollisionEnter(Collision infoCollision)
    {
        if (infoCollision.collider.CompareTag("PlayerBullet"))
        {
            //Restamos el daño de la bala del jugador al enemigo
            _currentHealth -= _damagePlayer;
            _lifeBarEnemy.fillAmount = _currentHealth / _maxHealth;

            Destroy(infoCollision.gameObject);

            if (_currentHealth <= 0.0f)
            {

                Death();

            }
        }

    }
   

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Death()
    {

        Destroy(gameObject);

    }
}
