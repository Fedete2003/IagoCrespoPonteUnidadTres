using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{


    //Zona Variables globales
    [Header("Health")]
    //Salud máxima del tanque
    [SerializeField]
    private float _maxHealth;
    //Salud actual
    [SerializeField]
    private float _currentHealth;
    //Daño balas enemigas
    [SerializeField]
    private float _damageEnemy;

    [Header("Lifebar")]
    //Referencia a la imagen de la barra de salud
    [SerializeField]
    private Image _lifeBar;

    [Header("Game Over")]
    [SerializeField]
    private GameManagerTanks _gameManager;

    private void Awake()
    {

        
        _currentHealth = _maxHealth;
        _lifeBar.fillAmount = 1;

    }

    private void OnCollisionEnter(Collision infoCollider)
    {

        if(infoCollider.collider.CompareTag("EnemyBullet"))
        {

            _currentHealth -= _damageEnemy;

            _lifeBar.fillAmount = _currentHealth / _maxHealth;
            Destroy(infoCollider.gameObject);

            if(_currentHealth <= 0)
            {
                Death();
            }

        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Death()
    {
        
        _gameManager.GameOver();


        Camera.main.transform.SetParent(null);

        Destroy(gameObject, 0.5f);


    }
}
