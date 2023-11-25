using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeEscena : MonoBehaviour
{
    public string irNuevaEscena;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L)) { SceneManager.LoadScene(irNuevaEscena); }
    }
}
