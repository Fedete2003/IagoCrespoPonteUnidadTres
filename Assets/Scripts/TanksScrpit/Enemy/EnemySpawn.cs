using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    
    //Zona variables globales
    [Header("Instantiation")]
    [SerializeField]
    private GameObject _prefabEnemy;
    [SerializeField]
    private Transform[] _posRotEnemy;
    [SerializeField]
    private float _timeBetweenEnemies;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0.5f, _timeBetweenEnemies);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnEnemy()
    {
        int n = Random.Range(0, _posRotEnemy.Length);

        Instantiate(_prefabEnemy, _posRotEnemy[n].position,
                        _posRotEnemy[n].rotation);

    }

}
