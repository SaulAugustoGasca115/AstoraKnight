using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Camera Follow")]
    public float followHeight = 8.0f;
    public float followDistance = 6.0f;
    public Transform player;
    public float targetHeight;
    public float currentHeight;
    public float currentRotation;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    // Update is called once per frame
    void Update()
    {
        targetHeight = player.position.y + followHeight;

        currentRotation = transform.eulerAngles.y;

        currentHeight = Mathf.Lerp(transform.position.y,targetHeight, 0.9f * Time.deltaTime);

        Quaternion euler = Quaternion.Euler(0.0f,currentRotation,0.0f);

        Vector3 targetPosition = player.position - (euler * Vector3.forward) * followDistance;

        targetPosition.y = currentHeight;

        transform.position = targetPosition;

        transform.LookAt(player);
    }

    
}
