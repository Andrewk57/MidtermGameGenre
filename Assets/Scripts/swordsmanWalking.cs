using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class swordsmanWalking : MonoBehaviour
{
    #region Variables
    public GameObject player;
    public Animator animator;
    public bool isAttacking = false;
    public float timeBetweenAttack;
    private float timeSinceLastAttack = 0f;
    private TextMeshProUGUI healthValue;
    //public Sprite healthImage;
    public static float hp= 5f;
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
        healthValue = GameObject.Find("livesAmount").GetComponent<TextMeshProUGUI>();

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
            hp--;
            
            Debug.Log(hp);
            healthValue.text = hp.ToString();
            timeSinceLastAttack = 0f;
            
            if(hp <= 0f)
            {
                Debug.Log("Deadscreen");
            }
        }

        Debug.Log("Attacking");
    }
}
