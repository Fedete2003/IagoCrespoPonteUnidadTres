using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    //Zona variables globales
    public Transform Target;

    [Header("Vectores")]
    //Velocidad seguimiento c�mara
    [SerializeField]
    private float _smoothing;
    //Distancia inicial entre c�mara y John Lemon
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

        //Posicion a la que movemos la c�mara
        Vector3 desiredPosition = Target.position + _offset;
        //Movimiento c�mara
        transform.position = Vector3.Lerp(transform.position, desiredPosition, 
                                            _smoothing * Time.deltaTime);

    }
}
