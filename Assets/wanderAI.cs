using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wanderAI : MonoBehaviour


{

    public float moveSpeed = 3f;
    public float rotateSpeed = 100f;
    private bool isWandering;
    private bool isRotatingLeft;
    private bool isRotatingRight;
    private bool isWalking;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isWandering == false)
        {
            StartCoroutine(Wander());
        }
        if (isRotatingRight == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotateSpeed); 
        }
        if (isRotatingLeft == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * -rotateSpeed);
        }
        if (isWalking == true)
        {
            transform.position += transform.forward * moveSpeed;
        }
    }
    IEnumerator Wander()
    {
        int rotationTime = Random.Range(1, 3); //time of rotation
        int rotationWait = Random.Range(1, 5); //time in between rotation
        int rotateLeftorRight = Random.Range(1, 2); //direction of movement
        int walkWait = Random.Range(1, 4);
        int walkTime = Random.Range(1, 5);

        isWandering = true;

        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        yield return new WaitForSeconds(rotationWait);
        if (rotateLeftorRight == 1)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingRight = false;
        }
        if (rotateLeftorRight == 2)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingLeft = false;
        }
        isWandering = false;


    }
}
