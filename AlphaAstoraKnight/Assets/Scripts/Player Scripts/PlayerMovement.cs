using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Attributes")]
    private Animator animator;
    private CharacterController characterController;
    private CollisionFlags collisionFlags = CollisionFlags.None;
    private bool canMove;
    private bool finished_Movement = true;
    private float playerToPointDistance;
    private Vector3 targetPosition = Vector3.zero;
    private Vector3 playerMove = Vector3.zero;
    private float gravity = 9.8f;
    private float height;
    
    [Header("OwnMovement")]
    public GameObject sphere;
    Vector3 direction;
    public float moveSpeed = 5.0f;

    // Start is called before the first frame update
    void Awake()
    {

        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();

        direction = sphere.transform.position - this.transform.position;

        MathematicMovement();

        

    }

    // Update is called once per frame
    void Update()
    {
        //OwnMoveThePlayer();
        //MoveThePlayer();
        //this.transform.position += playerMove;
        //IsGrounded();
        CalculateHeight();
        CheckIfFinishedMovement();

    }

    bool IsGrounded()
    {
        return collisionFlags == CollisionFlags.CollidedBelow ? true : false;
    }

    void CalculateHeight()
    {
        if(IsGrounded())
        {
            height = 0.0f;
        }
        else
        {
            height -= gravity * Time.deltaTime;
        }
    }

    void CheckIfFinishedMovement()
    {
        if(!finished_Movement)
        {
            if(!animator.IsInTransition(0) && !animator.GetCurrentAnimatorStateInfo(0).IsName("Stand")
                && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f)
            {
                finished_Movement = true;
            }
        }
        else
        {
            MoveThePlayer();
            //playerMove.y = height * Time.deltaTime;
            //collisionFlags =  characterController.Move(playerMove);
            this.transform.position += playerMove;
        }
    }

    void MoveThePlayer()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider is TerrainCollider)
                {
                    //playerToPointDistance = Vector3.Distance(this.transform.position,hit.point);

                    playerToPointDistance = OwnMathematics.Distance(new Coordinates(hit.point),new Coordinates(this.transform.position));

                    if(playerToPointDistance >= 1.0f)
                    {
                        canMove = true;
                        //targetPosition = sphere.transform.position;
                        targetPosition = hit.point;

                        
                    }
                }
            }


        }



        if (canMove)
        {
            animator.SetFloat("Walk", 1.0f);

            Vector3 targetTemporal = new Vector3(targetPosition.x - transform.position.x, targetPosition.y - transform.position.y, targetPosition.z - transform.position.z);

            Quaternion playerRotation = Quaternion.LookRotation(targetTemporal);

            transform.rotation = Quaternion.Slerp(transform.rotation, playerRotation, 15.0f * Time.deltaTime);

            playerMove = transform.forward * moveSpeed * Time.deltaTime;

            if (OwnMathematics.Distance(new Coordinates(targetPosition), new Coordinates(transform.position)) <= 0.5f)
            {
                canMove = false;
            }

        }
        else
        {
            playerMove.Set(0.0f, 0.0f, 0.0f);
            animator.SetFloat("Walk", 0.0f);
        }
    }

    void OwnMoveThePlayer()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(sphere.transform.position);
            RaycastHit hit;

            if(Physics.Raycast(ray,out hit))
            {
                if(hit.collider is TerrainCollider)
                {
                    if (OwnMathematics.Distance(new Coordinates(sphere.transform.position), new Coordinates(this.transform.position)) > 0.3f)
                    {
                        this.transform.position += direction * moveSpeed * Time.deltaTime;
                    }
                }
            }

           
        }
        
        
    }

    void MathematicMovement()
    {
        Coordinates normal = OwnMathematics.Normal(new Coordinates(direction));
        direction = normal.ConvertToVector();

    }

}
