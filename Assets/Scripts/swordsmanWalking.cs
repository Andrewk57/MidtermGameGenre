using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordsmanWalking : MonoBehaviour
{
    #region Variables
    public enum swordsmanStates { idle = 0, walking = 1, attacking = 2 }
    [Header ("States")]
    public swordsmanStates state;
    [Header("Animations")]
    public Animator animator;
    public string stateParameterName = "State";
    [Header("Walk")]
    private float walkingSpeed;
    [Header("Idle")]
    CharacterController characterController;
    #endregion
    void Start()
    {
        characterController = GetComponent<CharacterController>();  
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case swordsmanStates.idle:
                idle();
            break;
            case swordsmanStates.walking:
                walking();
            break;
            case swordsmanStates.attacking:
                attacking();
            break;
        }
        updateAnimation();
    }
    void idle()
    {
        state = swordsmanStates.idle;
    }
    void walking()
    {
        state = swordsmanStates.walking;
        // add if collides with tower, change the state to attacking
    }
    void attacking()
    {
        state = swordsmanStates.attacking;
    }
    void updateAnimation()
    {
        animator.SetInteger(stateParameterName, (int)state);
    }
}
