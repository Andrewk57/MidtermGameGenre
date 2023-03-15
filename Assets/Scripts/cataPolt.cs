using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cataPolt : MonoBehaviour
{
    public CharacterController characterController;
    public GameObject player;
    public Animator animator;
    public bool isAttacking = false;
    public float timeBetweenAttack;
    //private float timeSinceLastAttack = 0f;
    public bool isDamaging = false;
    public GameObject swordPrefab;
    public GameObject cataBallPrefab;
    public GameObject bulletSpawnPoint;
    public float bspeed = 5f;
    public GameObject bulletTarget;
    void Start()
    {
        characterController = GetComponent<CharacterController>();  
        animator = GetComponent<Animator>();
        animator.SetInteger("State", 0);
    }

    // Update is called once per frame
    void Update()
    {
        InRange();
    }
    void InRange()
    {
        if (swordPrefab.transform.position.x >=7 && swordPrefab.CompareTag("Enemy"))
        {
            isAttacking=true;
            Attacking();
            Debug.Log("Ememy in attacking range");
        }
        //do same thing for horseman
    }
    void Attacking()
    {
        animator.SetInteger("State", 1);
        Debug.Log("Played animation for cata");

        Vector3 direction = (bulletTarget.transform.position - bulletSpawnPoint.transform.position).normalized;
        var bullet = Instantiate(cataBallPrefab, bulletSpawnPoint.transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = direction * bspeed;
    }
}
