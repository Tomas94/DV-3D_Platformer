using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamp : MonoBehaviour
{
    private void Awake()
    {
        GameManager.totalStamps++;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.currentStamps++;
            Destroy(gameObject);
        }
    }
}
