using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private LayerMask groundLayers;

    private bool isGrounded;
    private Vector3 _moveDir;
     
    private Rigidbody rb;
    private float depth;
    private int score;
   

    // Start is called before the first frame update
    void Start()
    {
        InputManager.Init(this);
        InputManager.GameMode();
        rb = GetComponent<Rigidbody>();
        depth = GetComponent<Collider>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime * _moveDir; 
        CheckGround();
    }

    public void playerJump()
    {
        // if player is on the ground do this
        if (isGrounded)
        {
          //send object up based on variable jump speed
          rb.AddForce(Vector2.up * jumpSpeed, ForceMode.Impulse);
        }
    }


    private void CheckGround()
    {
        //check if player is on the ground
        isGrounded = Physics.Raycast(transform.position, Vector3.down, depth, groundLayers);
        Debug.DrawRay(transform.position, Vector3.down * depth, Color.blue, 0, false);
    }

    public void SetMovementDirection(Vector3 newDirection)
    {
        //set movement direction of player
        _moveDir = newDirection;
    }

    public void coinCounter()
    {
        int newScore = score + 1;
        
        if (newScore > score)
        {
        Debug.Log("coin collected. Coins:"+score); 
        }
    }
}
