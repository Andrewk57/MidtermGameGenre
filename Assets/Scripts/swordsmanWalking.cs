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

    private TextMeshProUGUI healthValue;
    public GameObject cataPrefab;
    //public Sprite healthImage;
    public static float hp = 5f;
    public bool isDamaging = false;
    //public float startingHealthFill = .5f;
    [Header("Walk")]
    public float walkingSpeed;
    [Header("Idle")]

    //The node that we are currently following. Set it at edit time to determine the first node.
    public nodeScript nextNode;
    //A reference to the controller so we can call the "move" function
    public CharacterController controller;
    //The speed at which this unit will move towards nextNode
    public float speed;
    //The minimum distance the unit must be from nextNode to move to the next one
    public float minDistance;
    #endregion

    void Start()
    {

        controller = GetComponent<CharacterController>();
        healthValue = GameObject.Find("livesAmount").GetComponent<TextMeshProUGUI>();


    }

    void Update()
    {
        healthValue.text = hp.ToString();

        //If there's no next node, this unit will not move
        if (nextNode == null)


            return;

        Vector3 movement =
            (nextNode.transform.position - transform.position).normalized
            * speed
            * Time.deltaTime;

        //Otherwise, the unit will move in the direction towards its nextNode reference
        controller.Move(movement);

        //If the distance between this unit and nextNode is less than the minimum distance,
        //we get a new nextNode from the current one, by "asking" it what its own "next node" is.
        if (Vector3.Distance(nextNode.transform.position, transform.position) <= minDistance)
        {
            nextNode = nextNode.GetNext();
        }

    }



}



