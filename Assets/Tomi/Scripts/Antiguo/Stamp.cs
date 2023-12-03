using System.Collections;
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
            //GameManager.currentStamps++;
            Manager.Instance.stampsCollected++;
            Destroy(gameObject);
        }
    }
}
