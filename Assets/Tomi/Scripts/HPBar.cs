
using UnityEngine;

public class HPBar : MonoBehaviour
{
    public RectTransform lifeimage;

    float _maxLifeWidth;
    float _maxLife;
    float _currentLife;

    private void Awake()
    {
        lifeimage = GetComponent<RectTransform>();
        _maxLifeWidth = lifeimage.rect.width;
        _maxLife = 3;    
    }

    private void Start()
    {   
        Manager.Instance.player.actualizarVida += UpdateLifeBar;
    }

    public void UpdateLifeBar()
    {
        _currentLife = Manager.Instance.player.CurrentHP;
        if (_currentLife <= 0 || _currentLife >_maxLife) return;
        float width = lifeimage.rect.width;
        width = RemapValues.Remap(_currentLife, 0, _maxLife, 0, _maxLifeWidth);
        lifeimage.sizeDelta = new Vector2 (width,lifeimage.rect.height);
    }
}