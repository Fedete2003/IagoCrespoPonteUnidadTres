using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    //Zona variables globales
    public Transform Target;

    [Header("Vectores")]
    //Velocidad seguimiento cámara
    [SerializeField]
    private float _smoothing;
    //Distancia inicial entre cámara y John Lemon
    [SerializeField]
    private Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {
        _offset = transform.position - Target.position;
    }

    
    void Update()
    {
        
    }

    private void LateUpdate()
    {

        //Posicion a la que movemos la cámara
        Vector3 desiredPosition = Target.position + _offset;
        //Movimiento cámara
        transform.position = Vector3.Lerp(transform.position, desiredPosition, 
                                            _smoothing * Time.deltaTime);

    }
}
