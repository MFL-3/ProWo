using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player3d : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 moveVector;
    private Vector3 gravityMovement;
    private Vector3 jumpVector;
    private Vector3 spurwechsel;
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
        moveVector = Vector3.forward * GameManager3d.instance.speed;

        //Apply Gravity if not jumping
        if (GameManager3d.instance.jumping)
        {
            currentGravity = 0f;
            gravityMovement = Vector3.zero;
        }
        else
        {
            gravityMovement = new Vector3(0, -currentGravity, 0);
            currentGravity += GameManager3d.instance.gravity * Time.deltaTime;

            // Dont apply Gravity while grounded
            if (characterController.isGrounded && currentGravity > 1)
            {
                currentGravity = 1;
            }
        }

        //Spuren wechseln
        spurwechsel = Vector3.right * GameManager3d.instance.speed * Input.GetAxis("Horizontal") * 3f;

        //Jump Start
        if (Input.GetButtonDown("Jump") && characterController.isGrounded)
        {
            GameManager3d.instance.jumping = true;
            GameManager3d.instance.jumpposition = gameObject.transform.position;
            jumpVector = new Vector3(0, 4 * GameManager3d.instance.speed, 0);
        }

        //Jumping stop
        if (GameManager3d.instance.jumping && gameObject.transform.position.y >= GameManager3d.instance.jumpposition.y + 35)
        {
            GameManager3d.instance.jumping = false;
            jumpVector = Vector3.zero;
        }

        // Ducken
        if (Input.GetButtonDown("Ducken") && (GameManager3d.instance.ducked == false) && characterController.isGrounded)
        {
            //Scale
            gameObject.transform.localScale = new Vector3(5, 6, 1);
            //Duckposition, ducked
            GameManager3d.instance.duckposition = gameObject.transform.position;
            GameManager3d.instance.ducked = true;
            //Bewegen
            gravityMovement.y -= 6 / Time.deltaTime;
        }

        //Aufstehen Vorbereiten
        if ((gameObject.transform.position.z >= GameManager3d.instance.duckposition.z + 35) && (GameManager3d.instance.ducked == true))
        {
            //ducked, ducking
            GameManager3d.instance.ducked = false;
            GameManager3d.instance.ducking = true;

            //Bewegen
            gravityMovement.y += 6 / Time.deltaTime;
        }

        //finalMovement
        Vector3 finalMovement = moveVector + gravityMovement + jumpVector + spurwechsel;

        //Move
        characterController.Move(finalMovement * Time.deltaTime);

        //Aufstehen
        if (GameManager3d.instance.ducking)
        {
            gameObject.transform.localScale = new Vector3(5, 12, 1);
            GameManager3d.instance.ducking = false;

        }

        // End Jumping
        if (GameManager3d.instance.jumping && characterController.isGrounded)
        {
            GameManager3d.instance.jumping = false;
            currentGravity = 1;
        }

        // Tile2 Collision
        if (lastposition == gameObject.transform.position.z)
        {
            Destroy(gameObject);
        }
        else
        {
            lastposition = gameObject.transform.position.z;
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
        GameManager3d.instance.gameOver = true;
    }
}
