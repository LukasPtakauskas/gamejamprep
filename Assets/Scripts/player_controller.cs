using UnityEngine;

public class player_controller : MonoBehaviour
{
    public float movementVelocity = 3f;
    public float depthVelocityModifier = 0.66f;
    public float jumpVelocity = 200f;
    private Transform myTransform;
    bool up = false;
    public BoxCollider myCollide;

    private float inputV, inputH, jump = 0;// we get this from input


    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();
        myCollide = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        checkInput();
        doMove();
    }

    void OnCollisionEnter(Collision col)
    {
        
    }

    private void doMove()
    {
        float x = myTransform.position.x;
        float z = myTransform.position.z;
        if (inputV != 0)
        {
            var move = inputV * movementVelocity * Time.deltaTime * depthVelocityModifier;
            x -= move;
            z -= move;
        }
        if (inputH != 0)
        {
            var move = inputH * movementVelocity * Time.deltaTime;
            x -= move;
            z += move;
        }

        myTransform.position = new Vector3
        (
            x,
            myTransform.position.y,
            z
        );

        if (up)
        {
            if (GetComponent<Rigidbody>().velocity.y <= 0 && GetComponent<Rigidbody>().velocity.y > -0.01)
            {
                GetComponent<Rigidbody>().AddForce(0, jumpVelocity, 0);
            }
            up = false;
        }
    }
    
    private void checkInput()
    {
        inputV = Input.GetAxis("Vertical");
        inputH = Input.GetAxis("Horizontal");

        jump = Input.GetAxis("Jump");
        if (jump != 0)
        {
            up = true;
        }
    }
}