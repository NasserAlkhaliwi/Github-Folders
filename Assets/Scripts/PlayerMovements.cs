using System;
using System.Threading;
using System.Collections.Specialized;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    GameManager gameManager;
    Rigidbody rb;

    public int CollectedCoins;
    public float moveSpeed = 5.0f;
    public float jumpForce = 5.0f;
    public int MaxHealth = 10;
    public float damageForce = 3.0f;
    int CurrentHealth ;



    private Camera mainCamera;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
        CurrentHealth = MaxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();


}
public void Movement(){

float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

         Vector3 cameraForward = mainCamera.transform.forward;
         Vector3 cameraRight = mainCamera.transform.right;

        cameraForward.y = 0;
        cameraRight.y = 0;

        Vector3 moveDirection = cameraForward.normalized * verticalInput + cameraRight.normalized * horizontalInput;

        if(moveDirection != Vector3.zero)
        {
            transform.forward = moveDirection;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }

}
public void Jump(){


if(Input.GetButtonDown("Jump")){

    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);


}



}



void OnCollisionEnter(Collision other)
{
        if(other.gameObject.CompareTag("Damage"))
    {
        Vector3 damageDirection = other.transform.position - transform.position;
            
            damageDirection.Normalize();

    rb.AddForce(- damageDirection * damageForce, ForceMode.Impulse);
        
        gameManager.Restart();

       CurrentHealth -= 1 ; 

      if(CurrentHealth <= 0)
      {
        gameManager.Restart();
      }
    
    } 
}
void OnTriggerEnter(Collider other)
{
    if(other.gameObject.CompareTag("Coin"))
{
    CollectedCoins += 1;
    gameManager.UpdateCoinText(CollectedCoins);
    Destroy(other.gameObject);

} 
}

    
}
