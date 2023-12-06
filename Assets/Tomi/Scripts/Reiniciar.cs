using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reiniciar : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)) { SceneManager.LoadScene(0); }
        
    }
}
