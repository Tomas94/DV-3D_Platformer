using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoLuz : MonoBehaviour
{
    //Sistema de movimiento de la cookie de la directional light
    //El sistema usa una curva de animacion y mueve la luz y por tanto la cookie de la light por esa curva tomando valores de 
    //Magnitud, time, offset, etc

    [SerializeField] Vector2 duracionCicloXZ = new Vector2(100f, 100f);
    [SerializeField] AnimationCurve movimientoX;
    [SerializeField] AnimationCurve movimientoZ;
    [SerializeField] Vector2 magnitudMovXZ = new Vector2(1, 1);
    [SerializeField] Vector2 timeOffsetMovXZ = new Vector2();

    //Te odio serialized field

    private Vector3 m_initialPosition;

    private void Awake()
    {
        m_initialPosition = transform.position;
    }

    void Update()
    {
        UpdateMotion();   
    }

    private void UpdateMotion () 
    {

        float timeX = Time.time % duracionCicloXZ.x;
        timeX /= duracionCicloXZ.x;

        float timeZ = Time.time % duracionCicloXZ.y;
        timeZ /= duracionCicloXZ.y;

        float newX = movimientoX.Evaluate(timeX + timeOffsetMovXZ.x) * magnitudMovXZ.x;
        float newZ = movimientoX.Evaluate(timeZ + timeOffsetMovXZ.y) * magnitudMovXZ.y;

        transform.position = m_initialPosition + new Vector3(newX, 0, newZ);
    }
}
