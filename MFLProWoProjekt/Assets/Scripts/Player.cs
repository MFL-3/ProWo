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
    [SerializeField] GameObject welle;

    private Animator ani;
    private CapsuleCollider coli;

    // Start is called before the first frame update
    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
        lastposition = gameObject.transform.position.x;
        ani = gameObject.GetComponent<Animator>();
        coli = gameObject.GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new(gameObject.transform.position.x, gameObject.transform.position.y, 0);
        ani.SetBool("trstart", GameManager.instance.start);
        ani.SetBool("trjumping", GameManager.instance.jumping);
        ani.SetBool("trduckedrun", GameManager.instance.ducked);
        ani.SetBool("end", GameManager.instance.theend);

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
        if (Input.GetButtonDown("Jump") && characterController.isGrounded && (!GameManager.instance.start))
        {
            coli.center = new(0, 0.9f, 0);
            coli.height = 1.8f;
            characterController.center = new(0, 0.9f, 0);
            characterController.height = 1.8f;
            GameManager.instance.jumping = true;
            if(GameManager.instance.ducked)
            {
                GameManager.instance.ducked = false;
            }
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
        if (Input.GetButtonDown("Ducken") && (GameManager.instance.ducked == false) && characterController.isGrounded && (!GameManager.instance.start))
        {
            //Scale
            coli.height = 1.1f;
            coli.center = new(0, 0.55f, 0);
            characterController.height = 1.1f;
            characterController.center = new(0, 0.55f, 0);

            //Duckposition, ducked
            GameManager.instance.duckposition = gameObject.transform.position;
            GameManager.instance.ducked = true;

        }
        
        //Aufstehen
        if ((!GameManager.instance.ducked && GameManager.instance.jumping ) || (gameObject.transform.position.x >= GameManager.instance.duckposition.x + 33) && (GameManager.instance.ducked == true))
        {
            GameManager.instance.ducked = false;
            coli.center = new(0, 0.9f, 0);
            coli.height = 1.8f;
            characterController.center = new(0, 0.9f, 0);
            characterController.height = 1.8f;
        }
        
        //finalMovement
        Vector3 finalMovement = moveVector + gravityMovement + jumpVector;

        //Move
        if ((!GameManager.instance.theend) && (!GameManager.instance.start))
        {
            characterController.Move(finalMovement * Time.deltaTime);
        }
        else
        {
            GameManager.instance.jumping = false;
            characterController.Move(gravityMovement * Time.deltaTime);
        }

        // End Jumping
        if (GameManager.instance.jumping && characterController.isGrounded)
        {
            GameManager.instance.jumping = false;
            currentGravity = 1;
        }

        //Tile2 Colission
        if(lastposition >= gameObject.transform.position.x && (!GameManager.instance.start))
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
            GameManager.instance.theend = true;
        }

        //Sterben
        if (gameObject.transform.position.x <= welle.transform.position.x + 10)
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
