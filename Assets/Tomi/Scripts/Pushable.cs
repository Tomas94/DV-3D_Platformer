using UnityEngine;

public class Pushable : MonoBehaviour
{
    Rigidbody _rb;
    public bool _picked;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Picked(Transform picker)
    {
        transform.SetParent(picker);
        _rb.isKinematic = false;
        _picked = true;
        picker.GetComponent<Interact>().DropObject += Dropped;
    }

    public void Dropped()
    {
        _picked = false;
        transform.SetParent(null);
        _rb.isKinematic = true;

    }

    private void OnTriggerEnter(Collider other)
    {
        Interact _player;
        if (other.TryGetComponent(out _player)) _player.PickObject += Picked;
    }

    private void OnTriggerExit(Collider other)
    {
        Interact _player;
        if (other.TryGetComponent(out _player)) _player.PickObject -= Picked;

    }
}
/*public float pushForce = 10f;
public float pullForce = 5f;
public float maxDistance = 10f;
public LayerMask boxLayer;

private void Update()
{
    if (Input.GetKeyDown(KeyCode.E))
    {
        InteractWithBox();
    }
}

private void InteractWithBox()
{
    RaycastHit hit;

    // Lanzar un rayo hacia adelante desde la posición del jugador
    if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, boxLayer))
    {
        // Obtener el objeto golpeado
        GameObject hitObject = hit.collider.gameObject;

        // Verificar si el objeto golpeado tiene un Rigidbody (es una caja)
        Rigidbody boxRigidbody = hitObject.GetComponent<Rigidbody>();

        if (boxRigidbody != null)
        {
            boxRigidbody.isKinematic = false;

            // Calcular la dirección relativa entre el jugador y la caja
            Vector3 directionToBox = hitObject.transform.position - transform.position;
            directionToBox.y = 0; // Ignorar la componente y

            // Normalizar la dirección
            directionToBox.Normalize();

            // Aplicar fuerza al Rigidbody de la caja para empujarla o tirar de ella
            if (Vector3.Dot(directionToBox, transform.forward) > 0)
            {
                // Empujar hacia adelante
                boxRigidbody.AddForce(transform.forward * pushForce, ForceMode.Impulse);
            }
            else
            {
                // Tirar hacia atrás
                boxRigidbody.AddForce(-transform.forward * pullForce, ForceMode.Impulse);
            }
        }
    }
}*/
