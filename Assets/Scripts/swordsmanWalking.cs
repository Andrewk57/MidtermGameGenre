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

    public static TextMeshProUGUI healthValue;
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
    public static float speed = 6f;
    //The minimum distance the unit must be from nextNode to move to the next one
    public float minDistance;
    public GameObject attackPoint;
    public float horseHP = 8f;
    public float swordHP = 4f;

    #endregion

    void Start()
    {
        controller = GetComponent<CharacterController>();
        healthValue = GameObject.Find("livesAmount").GetComponent<TextMeshProUGUI>();
        nextNode = GameObject.Find("A").GetComponent<nodeScript>();
        horseHP = 8f;
        swordHP = 4f;
        Debug.Log(horseHP);
        Debug.Log(swordHP);
        
    }

    void Update()
    {
        if (horseHP<=0f)
        {
            placementScript.money += 50;
            placementScript.coins.text = placementScript.money.ToString();
            Destroy(this.gameObject);
        }
        if (swordHP<=0f)
        {
            placementScript.money += 25;
            placementScript.coins.text = placementScript.money.ToString();
            Destroy(this.gameObject);
        }
        healthValue.text = hp.ToString();
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                if (gameObject.transform.CompareTag("Horse"))
                {
                    horseHP -= placementScript.clickPower;
                }
                else if (gameObject.transform.CompareTag("Swordsman"))
                {
                    swordHP -= placementScript.clickPower;
                }
                Debug.Log("Clicked on " + this.gameObject.name);
            }
        }
        if (hp<=0f)
        {
            Debug.Log("GameOver");
        }

        if (nextNode == null)
        {
            
        }
        else
        {
            Vector3 movement =
                (nextNode.transform.position - transform.position).normalized
                * speed
                * Time.deltaTime;

            controller.Move(movement);

            if (Vector3.Distance(nextNode.transform.position, transform.position) <= minDistance)
            {
                nextNode = nextNode.GetNext();
            }
        }
       

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Finish"))
        {
            hp--;
            
            healthValue.text = hp.ToString();
            Debug.Log("Reached end" + hp);
            
          
            Destroy(this.gameObject);
        }
        


    }

}



