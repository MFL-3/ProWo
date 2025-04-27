using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Net.Cache;

public class Player3d : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 moveVector;
    private Vector3 gravityMovement;
    private Vector3 jumpVector;
    private Vector3 spurwechsel;
    private float currentGravity = 1f;
    private float lastposition;
    private float wechselposition;
    private float x;
    private Animator ani;

    [SerializeField] GameObject welle;


    // Start is called before the first frame update
    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
        lastposition = gameObject.transform.position.x;
        ani = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager3d.instance.paused)
        {
            ani.SetBool("trstart", GameManager3d.instance.start);
            ani.SetBool("trjumping", GameManager3d.instance.jumping);
            ani.SetBool("trduckedrun", GameManager3d.instance.ducked);
            ani.SetBool("end", GameManager3d.instance.theend);
            ani.SetBool("trfall", GameManager3d.instance.falling);
            ani.speed = 1;
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
                gravityMovement = new(0, -currentGravity, 0);
                currentGravity += GameManager3d.instance.gravity * Time.deltaTime;

                // Dont apply Gravity while grounded
                if (characterController.isGrounded && currentGravity > 1)
                {
                    currentGravity = 1;
                }
            }

            //Spuren wechseln
            if (!GameManager3d.instance.strangewechsel)
            {
                x = Input.GetAxis("Horizontal");
                spurwechsel = 3f * GameManager3d.instance.speed * x * Vector3.right;
                GameManager3d.instance.wechselt = Input.GetAxis("Horizontal") != 0;
            }
            else
            {
                //Input
                if ((Input.GetAxis("Horizontal") < 0) && !GameManager3d.instance.wechselt && gameObject.transform.position.x > -10)
                {
                    x = -1;
                    GameManager3d.instance.wechselt = true;
                    wechselposition = gameObject.transform.position.x;
                }
                else if ((Input.GetAxis("Horizontal") > 0) && !GameManager3d.instance.wechselt && gameObject.transform.position.x < 10)
                {
                    x = 1;
                    GameManager3d.instance.wechselt = true;
                    wechselposition = gameObject.transform.position.x;
                }

                if (wechselposition >= 10)
                {
                    wechselposition = 20;
                }
                else if (wechselposition <= -10)
                {
                    wechselposition = -20;
                }
                else
                {
                    wechselposition = 0;
                }


                //Vector
                if (GameManager3d.instance.wechselt)
                {
                    spurwechsel = 3f * GameManager3d.instance.speed * x * Vector3.right;
                }

                //Stopwechsel
                if (GameManager3d.instance.backwechsel && x < 0 && gameObject.transform.position.x <= wechselposition)
                {
                    x = 0;
                    GameManager3d.instance.wechselt = false;
                    GameManager3d.instance.backwechsel = false;
                    spurwechsel = Vector3.zero;
                }
                else if (GameManager3d.instance.backwechsel && x > 0 && gameObject.transform.position.x >= wechselposition)
                {
                    x = 0;
                    GameManager3d.instance.wechselt = false;
                    GameManager3d.instance.backwechsel = false;
                    spurwechsel = Vector3.zero;
                }
                else if (!GameManager3d.instance.backwechsel && x > 0 && GameManager3d.instance.wechselt && gameObject.transform.position.x >= wechselposition + 20)
                {
                    x = 0;
                    GameManager3d.instance.wechselt = false;
                    spurwechsel = Vector3.zero;
                }
                else if (!GameManager3d.instance.backwechsel && x < 0 && GameManager3d.instance.wechselt && gameObject.transform.position.x <= wechselposition - 20)
                {
                    x = 0;
                    GameManager3d.instance.wechselt = false;
                    spurwechsel = Vector3.zero;
                }
            }
            //Jump Start
            if (Input.GetButtonDown("Jump") && characterController.isGrounded && (!GameManager3d.instance.start))
            {
                GameManager3d.instance.jumping = true;
                if (GameManager3d.instance.ducked)
                {
                    GameManager3d.instance.ducked = false;
                    characterController.center = new(0, 0.9f, 0);
                    characterController.height = 1.8f;
                }
                GameManager3d.instance.jumpposition = gameObject.transform.position;
                jumpVector = new(0, 4 * GameManager3d.instance.speed, 0);
            }

            //Jumping stop
            if (GameManager3d.instance.jumping && (gameObject.transform.position.y >= GameManager3d.instance.jumpposition.y + 35))
            {
                GameManager3d.instance.jumping = false;
                jumpVector = Vector3.zero;
            }

            // Ducken
            if (GameManager3d.instance.strangeVersion)
            {
                if (Input.GetButton("Ducken") && (!GameManager3d.instance.ducked) && characterController.isGrounded && (!GameManager3d.instance.start))
                {
                    //Scale
                    characterController.height = 1.1f;
                    characterController.center = new(0, 0.55f, 0);

                    //Duckposition, ducked
                    GameManager3d.instance.duckposition = gameObject.transform.position;
                    GameManager3d.instance.ducked = true;
                }

                //Aufstehen
                if (!Input.GetButton("Ducken") && GameManager3d.instance.ducked)
                {
                    GameManager3d.instance.ducked = false;
                    characterController.center = new(0, 0.9f, 0);
                    characterController.height = 1.8f;
                }
            }
            else
            {
                if (Input.GetButtonDown("Ducken") && (!GameManager3d.instance.ducked) && characterController.isGrounded && (!GameManager3d.instance.start))
                {
                    //Scale
                    characterController.height = 1.1f;
                    characterController.center = new(0, 0.55f, 0);

                    //Duckposition, ducked
                    GameManager3d.instance.duckposition = gameObject.transform.position;
                    GameManager3d.instance.ducked = true;
                }

                //Aufstehen
                if ((gameObject.transform.position.z >= GameManager3d.instance.duckposition.z + 35) && (GameManager3d.instance.ducked))
                {
                    GameManager3d.instance.ducked = false;
                    characterController.center = new(0, 0.9f, 0);
                    characterController.height = 1.8f;
                }
            }
            //finalMovement
            Vector3 finalMovement = moveVector + gravityMovement + jumpVector + spurwechsel;

            //Move
            if ((!GameManager3d.instance.start) && (!GameManager3d.instance.theend))
            {
                characterController.Move(finalMovement * Time.deltaTime);
            }
            else
            {
                GameManager3d.instance.jumping = false;
                characterController.Move(2 * Time.deltaTime * gravityMovement);
            }

            //Sides Collision
            if (GameManager3d.instance.jumping && (characterController.collisionFlags & CollisionFlags.Sides) != 0 && GameManager3d.instance.wechselt)
            {
                characterController.stepOffset = 1;
            }
            else
            {
                characterController.stepOffset = characterController.height;
            }

            //Sides Collision komischeversion
            if ((characterController.collisionFlags & CollisionFlags.Sides) != 0 && GameManager3d.instance.wechselt && GameManager3d.instance.strangewechsel && !GameManager3d.instance.backwechsel)
            {
                GameManager3d.instance.backwechsel = true;
                x = -x;
            }

            // End Jumping
            if (GameManager3d.instance.jumping && characterController.isGrounded)
            {
                GameManager3d.instance.jumping = false;
                currentGravity = 1;
            }

            if (!characterController.isGrounded && !GameManager3d.instance.jumping)
            {
                GameManager3d.instance.falling = true;
            }
            else
            {
                GameManager3d.instance.falling = false;
            }

            // Tile2 Collision
            if (lastposition == gameObject.transform.position.z && (!GameManager3d.instance.start))
            {
                GameManager3d.instance.theend = true;
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

            //Sterben
            if (gameObject.transform.position.z + 20 <= welle.transform.position.z && GameManager3d.instance.theend)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            ani.speed = 0;
        }
    }


    // GameOver
    private void OnDestroy()
    {
        GameManager3d.instance.gameOver = true;
    }
}
