using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager Instance;
    public static Vector3 lastCheckpoint;
    public static int totalStamps;
    public static int currentStamps;
    [SerializeField] TextMeshProUGUI _stampsText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        _stampsText.text = currentStamps + "/" + totalStamps;
    }
}
