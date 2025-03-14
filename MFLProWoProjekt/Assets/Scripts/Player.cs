using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 moveVector;
    private Vector3 gravityMovement;
    private Vector3 jumpVector;
    private float currentGravity = 1f;
    private float lastposition;
    
    // Start is called before the first frame update
    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
        lastposition = gameObject.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        
        // Move forward
        moveVector = Vector3.right * GameManager.instance.speed;

        //Apply Gravity if not jumping
        if (GameManager.instance.jumping)
        {
            currentGravity = 0f;
            gravityMovement = Vector3.zero;
        }
        else
        {
            gravityMovement = new Vector3(0, -currentGravity, 0);
            currentGravity += GameManager.instance.gravity * Time.deltaTime;

            // Dont apply Gravity while grounded
            if (characterController.isGrounded && currentGravity > 1)
            {
                currentGravity = 1;
            }
        }

        //Jump Start
        if (Input.GetButtonDown("Jump") && characterController.isGrounded)
        {
            GameManager.instance.jumping = true;
            GameManager.instance.jumpposition = gameObject.transform.position;
            jumpVector = new Vector3(0, 4 * GameManager.instance.speed, 0);
        }

        //Jumping stop
        if (GameManager.instance.jumping && gameObject.transform.position.y >= GameManager.instance.jumpposition.y + 35)
        {
            GameManager.instance.jumping = false;
            jumpVector = Vector3.zero;
        }

        // Ducken
        if (Input.GetButtonDown("Ducken") && (GameManager.instance.ducked == false) && characterController.isGrounded)
        {
            //Scale
            gameObject.transform.localScale = new Vector3(5, 6, 1);
            //Duckposition, ducked
            GameManager.instance.duckposition = gameObject.transform.position;
            GameManager.instance.ducked = true;
            //Bewegen
            gravityMovement.y -= 6 / Time.deltaTime;
        }
        
        //Aufstehen Vorbereiten
        if ((gameObject.transform.position.x >= GameManager.instance.duckposition.x + 35) && (GameManager.instance.ducked == true))
        {
            //ducked, ducking
            GameManager.instance.ducked = false;
            GameManager.instance.ducking = true;

            //Bewegen
            gravityMovement.y += 6 / Time.deltaTime;
        }
        
        //finalMovement
        Vector3 finalMovement = moveVector + gravityMovement + jumpVector;

        //Move
        if (!GameManager.instance.theend)
        {
            characterController.Move(finalMovement * Time.deltaTime);
        }
        else
        {
            GameManager.instance.jumping = false;
            characterController.Move(gravityMovement * Time.deltaTime);
        }


        //Aufstehen
        if (GameManager.instance.ducking)
        {
            gameObject.transform.localScale = new Vector3(5, 12, 1);
            GameManager.instance.ducking = false;

        }

        // End Jumping
        if (GameManager.instance.jumping && characterController.isGrounded)
        {
            GameManager.instance.jumping = false;
            currentGravity = 1;
        }

        if(lastposition >= gameObject.transform.position.x)
        {
            GameManager.instance.theend = true;
        }
        else
        {
            lastposition = gameObject.transform.position.x;
        }

        // Runterfallen
        if (transform.position.y <= -40)
        {
            Destroy(gameObject);
        }
       
    }

   
    // GameOver
    private void OnDestroy()
    {
        GameManager.instance.gameOver = true;
    }










}
