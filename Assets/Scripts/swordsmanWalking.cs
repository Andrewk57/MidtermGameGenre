using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class swordsmanWalking : MonoBehaviour
{
    #region Variables
    public GameObject player;
    public Animator animator;
    public bool isAttacking = false;
    public float timeBetweenAttack;
    private float timeSinceLastAttack = 0f;
    public Image health;
    //public float startingHealthFill = .5f;
    [Header("Walk")]
    public float walkingSpeed;
    [Header("Idle")]
    CharacterController characterController;
    #endregion
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        timeSinceLastAttack = timeSinceLastAttack += Time.deltaTime;
        health.fillAmount = .5f;
    }

    // Update is called once per frame
    void Update()
    {
        walking();
        
        if (isAttacking == true)
        {
            attacking();
        }

    }
   
    void walking()
    {
        animator.SetInteger("State", 1);
        //characterController.Move(Vector3.right * walkingSpeed * Time.deltaTime);
        if (player.transform.position.x <= -8)
        {
            Debug.Log("Reached destination");
            animator.SetInteger("State", 0);
            isAttacking = true;
            return;
        }
        else
        {
            characterController.Move(Vector3.left * walkingSpeed * Time.deltaTime);
            Debug.Log("Moved");
        }
        
        
    }
    void attacking()
    {
        animator.SetInteger("State", 0);
        //if (timeSinceLastAttack >= timeBetweenAttack)
        //{
        //    health.fillAmount = health.fillAmount - .1f;
         //   timeSinceLastAttack = 0f;
       // }
            //animator.SetInteger("State", 2);
            Debug.Log("Attacking");
        
    }
    
}
