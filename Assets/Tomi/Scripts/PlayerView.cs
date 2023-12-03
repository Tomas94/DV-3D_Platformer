using UnityEngine;

public class PlayerView : MonoBehaviour
{
    Animator _anim;

    void Start()
    {
        _anim = GetComponentInChildren<Animator>();       
    }

    public void MovementState(bool isMoving)
    {
        if(isMoving)  _anim.SetBool("Moving", true);
        else _anim.SetBool("Moving", false);
    }
}
