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
    //public Sprite healthImage;
    //private float hp = 5f;
    public bool isDamaging = false;
    //public float startingHealthFill = .5f;
    [Header("Walk")]
    public float walkingSpeed;
    [Header("Idle")]
    CharacterController characterController;
    #endregion

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        health.fillAmount = .5f;
    }

    void Update()
    {
        walking();
    }

    void walking()
    {
        animator.SetInteger("State", 1);

        if (player.transform.position.x <= -8)
        {
            Debug.Log("Reached destination");
            animator.SetInteger("State", 0);
            isAttacking = true;
            if (isAttacking == true)
            {
                attacking();
            }
            return;
        }
        else
        {
            characterController.Move(Vector3.left * walkingSpeed * Time.deltaTime);
            isAttacking = false;
            Debug.Log("Moved");
        }
    }

    void attacking()
    {
        animator.SetInteger("State", 0);

        timeSinceLastAttack += Time.deltaTime;
        if (timeSinceLastAttack >= timeBetweenAttack)
        {
            //hp--;
            //Debug.Log(hp);
            timeSinceLastAttack = 0f;
            health.fillAmount -= 0.1f;
            if(health.fillAmount <= 0f)
            {
                Debug.Log("Deadscreen");
            }
        }

        Debug.Log("Attacking");
    }
}
