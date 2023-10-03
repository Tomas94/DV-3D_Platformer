using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] Transform[] _waypoints;
    [SerializeField] float speed;
    [SerializeField] Transform target;
    [SerializeField] int index;
    [SerializeField] float waitingTime;
    [SerializeField] bool waiting;

    void Start()
    {
        waiting = false;
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        target = _waypoints[index];
        if(!waiting) Patrol();
    }

    void Patrol()
    {
        if (Vector3.Distance(transform.position, target.position) > 1)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                return;
            }
        else { waiting = true; }

        StartCoroutine("ChangeWayPoint");
    }

    IEnumerator ChangeWayPoint()
    {

        yield return new WaitForSeconds(waitingTime);

        if (index < _waypoints.Length -1)
        {
            index++;
        }
        else
        {
            index = 0;
        }

        waiting = !waiting;
    }



}
