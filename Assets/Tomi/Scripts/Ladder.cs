using System.Collections;
using System.Collections.Generic;
using UnityEditor.Sprites;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField] Transform _bottom;
    [SerializeField] Transform _top;
    [SerializeField] Transform player;
    public float _climbSpeed;
    // public bool enrango;

    bool _climbing;

    private void Awake()
    {
        _bottom = transform.GetChild(1);
        _top = transform.GetChild(2);
    }


    void ClimbLadder(Transform pos)
    {
        //if (!enrango) return;
        if (Vector3.SqrMagnitude(_bottom.position - pos.position) < Vector3.SqrMagnitude(_top.position - pos.position))
        {
            Debug.Log("Abajo");
            StartCoroutine(LadderMov(_bottom.position, _top.position, true));
        }
        else
        {
            Debug.Log("Arriba");
            StartCoroutine(LadderMov(_top.position, _bottom.position, false));
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Interact _player;
        _player = other.GetComponent<Interact>();
        if (_player != null) _player.StartInteraction += ClimbLadder;
        //{
        //    _player.StartInteraction += ClimbLadder;
        //    enrango = true;
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        Interact _player;
        _player = other.GetComponent<Interact>();
        if (_player != null) _player.StartInteraction -= ClimbLadder;
        //if (_player != null)
        //{
        //    enrango = false;
        //}
    }

    IEnumerator LadderMov(Vector3 origin, Vector3 destiny, bool goingUp)
    {
        player.GetComponent<PMovement>().enabled = false;


        float impulse = 2f;
        float tiempoInicio = Time.time;
        float distanciaAB = Vector3.Distance(origin, destiny);
        
        if(!goingUp) {
            impulse *= -1;
            player.transform.forward *= -1;
        }

        while (Time.time - tiempoInicio < distanciaAB / _climbSpeed)
        {
            float tiempoPasado = Time.time - tiempoInicio;
            float fraccionViaje = tiempoPasado * _climbSpeed / distanciaAB;

            player.position = Vector3.Lerp(origin, destiny, fraccionViaje);

            yield return null;
        }

        if (!goingUp)player.transform.forward *= -1;
        
        player.position = destiny + (player.forward * impulse);


        player.GetComponent<PMovement>().enabled = true;
    }
}
