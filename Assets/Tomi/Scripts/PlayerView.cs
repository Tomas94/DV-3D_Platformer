using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    Animator _anim;

    void Start()
    {
        _anim = GetComponentInChildren<Animator>();       
    }

    void Update()
    {

    }

    public void MovementState(bool isMoving)
    {
        if(isMoving)  _anim.SetBool("Moving", true);
        else _anim.SetBool("Moving", false);
    }


}
