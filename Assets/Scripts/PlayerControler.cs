using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    Animator anim;
    bool isJumping;

    public static GameObject player;
    public static GameObject currentPlatform;
    [SerializeField] GameOverManager gameOverManager;
    Rigidbody rb;
    Vector3 startPos;
    int track;
    int takedRun;
    bool canTurn;
    public static bool isPlayerDead;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obsticle")
        {
            anim.SetBool("IsDead", true);
            isPlayerDead= true;
            gameOverManager.SetGameOver();

        }
        currentPlatform = collision.gameObject;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other is BoxCollider && PlatformSpawner.lastPlatform.tag != "PlatformT")
        {
            PlatformSpawner.RunDummy();
        }
        if(other is SphereCollider)
        {
            canTurn= true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other is SphereCollider)
        {
            canTurn = false;
        }
    }
    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        track = 2;
        takedRun = 1;
        rb = this.GetComponent<Rigidbody>();   
        anim = this.GetComponent<Animator>();
        isJumping = true;
        player = this.gameObject;
        startPos = player.transform.position;
        PlatformSpawner.RunDummy();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        GameOverCheck();
    }
    
    void CheckInput()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isJumping)
        {
            isJumping= false;
            anim.SetBool("IsJumping", true);
            rb.AddForce(Vector3.up * 200); 
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) )
        {
            if (canTurn)
            {
                this.transform.Rotate(Vector3.up * 90);
                PlatformSpawner.dummyPlayer.transform.forward = -this.transform.forward;
                PlatformSpawner.RunDummy();
                canTurn = false;
                if (takedRun > 0)
                {
                    takedRun = 0;
                    transform.position = new Vector3(startPos.x, transform.position.y, PlatformSpawner.lastPlatform.transform.position.z);
                }
                else
                {
                    takedRun = 1;
                    transform.position = new Vector3(PlatformSpawner.lastPlatform.transform.position.x, transform.position.y, transform.position.z);
                }
            }
            else
            {
                if (track < 3)
                {
                    track++;
                    transform.Translate(1.66f, 0, 0);
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (canTurn)
            {
                this.transform.Rotate(Vector3.up * -90);
                PlatformSpawner.dummyPlayer.transform.forward = -this.transform.forward;
                PlatformSpawner.RunDummy();
                canTurn = false;
                if (takedRun > 0)
                {
                    takedRun = 0;
                    transform.position = new Vector3(startPos.x, transform.position.y, PlatformSpawner.lastPlatform.transform.position.z);
                }
                else
                {
                    takedRun = 1;
                    transform.position = new Vector3(PlatformSpawner.lastPlatform.transform.position.x, transform.position.y, transform.position.z);
                }
            }
            else
            {
                if (track > 1)
                {
                    track--;
                    transform.Translate(-1.66f, 0, 0);
                }

            }

        }
    }
    void GameOverCheck()
    {
       if(player.transform.position.y < 0)
        {
            anim.SetBool("IsDead", true);
            gameOverManager.SetGameOver();
        }
    }

    private void StopJump()
    {
        isJumping = true;
        anim.SetBool("IsJumping", false);
    }
}
