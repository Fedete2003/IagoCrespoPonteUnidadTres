using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManagerTanks : MonoBehaviour
{

    //Zona variables globales
    [Header("Game Over")]
    [SerializeField]
    private GameObject _panelGameOver;
    [SerializeField]
    private EnemySpawn _managerEnemies;


    public void GameOver()
    {
        //Activamos el panel de Game Over
        _panelGameOver.SetActive(true);
        //Desactivamos el script de aparición de enemigos
        _managerEnemies.enabled = false;
        //Reactivar el cursor
        Cursor.lockState = CursorLockMode.Confined;

    }

    public void LoadScene()
    {

        SceneManager.LoadScene(0);

    }



}
