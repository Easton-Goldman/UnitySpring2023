using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour
{

    Vector2 moveDir;
    Rigidbody rb;
    float h, v;
    Vector3 inputVector;
    [Header("Movement Input")]
    [Tooltip("Speed adjusts the speed of the player")]
    public float speed = 10;
    [Tooltip("Jump height adjusts the force of the player jump")]
    [Range(0,20)]
    public float jumpHeight = 10;
    public LayerMask groundLayer;
    public Animator anim;
    public bool gameover = false;
    public GameObject playerModel;
    public GameObject playerRagdoll;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameover)
        {
            h = DampenValue(h, moveDir.x);
            v = DampenValue(v, moveDir.y);

            inputVector = new Vector3(h * speed, rb.velocity.y, v * speed);
            //Time.timeScale = Mathf.Clamp(inputVector.magnitude, 0, 1);
            transform.LookAt(transform.position + new Vector3(inputVector.x, 0, inputVector.z));
            rb.velocity = inputVector;
            anim.SetFloat("Moving", moveDir.magnitude);
            Debug.DrawRay(transform.position, transform.forward * 7, Color.green);
        }

        
    }

    public void MovePlayer(InputAction.CallbackContext ctx)
    {
        Debug.Log(ctx.ReadValue<Vector2>());
        moveDir = ctx.ReadValue<Vector2>();
    }

    public void jump()
    {
        if(GroundCheck())
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            anim.SetTrigger("Jump");
        }
        
    }

    float DampenValue(float readValue, float moveDir)
    {
        readValue = Mathf.MoveTowards(readValue, moveDir, Time.deltaTime * 2);
        return readValue = Mathf.Clamp(readValue, -1, 1);
    }

    bool GroundCheck()
    {
        float dist = GetComponent<Collider>().bounds.extents.y + 0.1f;
        Ray ray = new Ray(transform.position, Vector3.down);
        return Physics.Raycast(ray, dist, groundLayer);
    }

    private void OnDrawGizmos()
    {
        float dist = GetComponent<Collider>().bounds.extents.y + 0.1f;
        Debug.DrawRay(transform.position, Vector3.down * dist, Color.green);
    }

    public void PlayerDead()
    {
        gameObject.GetComponent<Collider>().enabled = false;
        rb.useGravity = false;
        playerModel.SetActive(false);
        playerRagdoll.SetActive(true);
    }
}
