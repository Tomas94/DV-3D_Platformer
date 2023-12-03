using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GroundTrap : MonoBehaviour
{
    public Transform spikes;
    public Vector3 _activePos;
    public Vector3 _hidePos;
    public float cooldown;
    public float impulseForce;
    
    void Start()
    {
        StartCoroutine(SpikesSystem());
    }

    public void Activate()
    {
        spikes.localPosition = _activePos;
    }

    public void Deactivate()
    {
        spikes.localPosition = _hidePos;
    }


    public IEnumerator SpikesSystem()
    {
        while (true)
        {
            yield return new WaitForSeconds(cooldown);
            Deactivate();
            yield return new WaitForSeconds(cooldown);
            Activate();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Manager.Instance.player._playerDash._isDashing) return;
            Rigidbody player = other.GetComponentInParent<Rigidbody>();
            var impulseDir = other.gameObject.transform.position - transform.position;
            impulseDir.y = 0;
            player.AddForce(impulseDir.normalized*impulseForce, ForceMode.Impulse);
            Manager.Instance.player.TakeDamage(1);
            Debug.Log("tocado");
        }
    }

}
