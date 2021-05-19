using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attack Attributes")]
    public List<Image> fillWaitImage;
    public int[] fadeImages = new int[] { 0, 0, 0, 0, 0, 0 };
    private Animator animator;
    private bool canAttack = true;
    private PlayerMovement playerMovement;


    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!animator.IsInTransition(0) && animator.GetCurrentAnimatorStateInfo(0).IsName("Stand"))
        {
            canAttack = true;
        }
        else
        {
            canAttack = false;
        }

        
        CheckInput();
        CheckToFade();
    }


    void CheckInput()
    {
        if(animator.GetInteger("Atk") == 0)
        {
            playerMovement.FinishedMovement = false;

            if(!animator.IsInTransition(0) && animator.GetCurrentAnimatorStateInfo(0).IsName("Stand"))
            {
                playerMovement.FinishedMovement = true;
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerMovement.TargetPosition = transform.position;

            if(playerMovement.FinishedMovement && fadeImages[0] != 1 && canAttack)
            {
                fadeImages[0] = 1;
                animator.SetInteger("Atk", 1);
            }
        }else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            playerMovement.TargetPosition = transform.position;

            if (playerMovement.FinishedMovement && fadeImages[1] != 1 && canAttack)
            {
                fadeImages[1] = 1;
                animator.SetInteger("Atk", 2);
            }
        }else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            playerMovement.TargetPosition = transform.position;
            
            if(playerMovement.FinishedMovement && fadeImages[2] != 1 && canAttack)
            {
                fadeImages[2] = 1;

                animator.SetInteger("Atk", 3);
            }
        }else if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            playerMovement.TargetPosition = transform.position;

            if(playerMovement.FinishedMovement && fadeImages[3] != 1 && canAttack)
            {
                fadeImages[3] = 1;
                animator.SetInteger("Atk", 4);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            playerMovement.TargetPosition = transform.position;

            if (playerMovement.FinishedMovement && fadeImages[4] != 1 && canAttack)
            {
                fadeImages[4] = 1;
                animator.SetInteger("Atk", 5);
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            playerMovement.TargetPosition = transform.position;

            if (playerMovement.FinishedMovement && fadeImages[5] != 1 && canAttack)
            {
                fadeImages[5] = 1;
                animator.SetInteger("Atk", 6);
            }
        }
        else
        {
            animator.SetInteger("Atk", 0);
        }

        if(Input.GetKey(KeyCode.Space))
        {
            Vector3 targetPosition = Vector3.zero;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                targetPosition = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            }

            transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(targetPosition -transform.position),15.0f * Time.deltaTime);

        }

    }

    void CheckToFade()
    {
        if(fadeImages[0] == 1)
        {
            if(FadeAndWait(fillWaitImage[0],1.0f))
            {
                fadeImages[0] = 0;
            }
        }

        if (fadeImages[1] == 1)
        {
            if (FadeAndWait(fillWaitImage[1], 0.7f))
            {
                fadeImages[1] = 0;
            }
        }

        if (fadeImages[2] == 1)
        {
            if (FadeAndWait(fillWaitImage[2], 0.1f))
            {
                fadeImages[2] = 0;
            }
        }

        if (fadeImages[3] == 1)
        {
            if (FadeAndWait(fillWaitImage[3], 0.1f))
            {
                fadeImages[3] = 0;
            }
        }

        if (fadeImages[4] == 1)
        {
            if (FadeAndWait(fillWaitImage[4], 0.2f))
            {
                fadeImages[4] = 0;
            }
        }

        if (fadeImages[5] == 1)
        {
            if (FadeAndWait(fillWaitImage[5], 0.08f))
            {
                fadeImages[5] = 0;
            }
        }
    }

    bool FadeAndWait(Image fadeImg,float fadeTime)
    {
        bool faded = false;

        if(fadeImg == null)
        {
            return faded;
        }

        if(!fadeImg.gameObject.activeInHierarchy)
        {
            fadeImg.gameObject.SetActive(true);
            fadeImg.fillAmount = 1;
        }

        fadeImg.fillAmount -= fadeTime * Time.deltaTime;

        if(fadeImg.fillAmount <= 0.0f)
        {
            fadeImg.gameObject.SetActive(false);
            faded = true;
        }

        return faded;
    }

}
