using System.Collections;
using UnityEngine;

public class wanderAI : MonoBehaviour
{
    public float moveSpeed = 3f;//the speed at which the gosling moves
    public float rotateSpeed = 100f;//rotation speed
    private bool isWandering; //checks if the gosling is currently moving
    private bool isRotatingLeft;//checks if gosling is rotating left
    private bool isRotatingRight;//checks if gosling is rotating right
    private bool isWalking;//checks if gosling is currently walking
   // all these variables are used to create random movement for the gosling.
    void Update()
    {
        if ((subMenu.isPaused == false))
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
    }
    IEnumerator Wander() //this ienumerator is called every time the gosling wanders, it changes the boolean values so it is always called. 
    {
        int rotationTime = Random.Range(1, 3); //time of rotation
        int rotationWait = Random.Range(1, 5); //time in between rotation
        int rotateLeftorRight = Random.Range(1, 2); //direction of movement
        int walkWait = Random.Range(1, 4); //time to wait before next movement
        int walkTime = Random.Range(1, 5); //how long it takes to wait after movement

        isWandering = true;

        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        yield return new WaitForSeconds(rotationWait);
        if (rotateLeftorRight == 1) //rotates gosling right
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingRight = false;
        }
        if (rotateLeftorRight == 2) //rotates the gosling left
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingLeft = false;
        }
        isWandering = false;


    }
}
