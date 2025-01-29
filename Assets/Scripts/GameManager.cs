using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    //Zona de variables globales
    [Header("Imágenes")]
    [SerializeField]
    private Image _caughtImage;
    [SerializeField]
    private Image _wonImage;
    [Header("Desvanecimiento")]
    //Duración del desvanecimiento de las imagenes
    [SerializeField]
    private float _fadeDuration;
    [SerializeField]
    private float _displayImage;
    //Contador de tiempo
    private float _timer;

    //"Booleanos" para mostrar las imágenes 
    public bool IsPlayerAtExit,
                IsPlayerCaught;

    //Reseteo de nivel
    private bool _isRestart;

    [Header("Audio")]
    [SerializeField]
    private AudioClip _caughtClip;
    [SerializeField]
    private AudioClip _wonClip;

    private AudioSource _audioSource;




    private void Awake()
    {

        _audioSource = GetComponent<AudioSource>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPlayerAtExit)
        {
            Win();
        }
        else if (IsPlayerCaught)
        {
            Caught();
        }
    }

    private void Win()
    {
        _audioSource.clip = _wonClip;
        if(_audioSource.isPlaying == false)
        {
            _audioSource.Play();
        }

        _timer += Time.deltaTime;
        //Aumentar transparecia de la imagen poco a poco
        _wonImage.color = new Color(_wonImage.color.r, _wonImage.color.g,
                                    _wonImage.color.b, _timer/_fadeDuration);
        //Mantener imagen en pantalla

        if(_timer > _fadeDuration + _displayImage)
        {

            Debug.Log("HE GANADO");

        }
    }

    private void Caught()
    {
        _audioSource.clip = _caughtClip;
        if (_audioSource.isPlaying == false)
        {
            _audioSource.Play();
        }

        _timer += Time.deltaTime;
        //Aumentar transparecia de la imagen poco a poco
        _caughtImage.color = new Color(_caughtImage.color.r, _caughtImage.color.g,
                                    _caughtImage.color.b, _timer / _fadeDuration);
        //Mantener imagen en pantalla

        if (_timer > _fadeDuration + _displayImage)
        {

            Debug.Log("ME PILLARON");
            SceneManager.LoadScene(0);

        }
    }

}
