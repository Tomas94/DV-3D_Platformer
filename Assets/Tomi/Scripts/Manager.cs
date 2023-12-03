using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    public static Manager Instance;

    public int stampsCollected;
    public TextMeshProUGUI stampsAmountText;
    public PlayerStats player;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else Destroy(gameObject);
    }

    private void Start()
    {
        
    }

    void Update()
    {
        stampsAmountText.text = stampsCollected.ToString();
    }


}
