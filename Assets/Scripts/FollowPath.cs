using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowPath : MonoBehaviour
{
    //tutorial followed from https://www.youtube.com/watch?v=11ofnLOE8pw

    [SerializeField] private Transform[] routes;
    [SerializeField] private Transform follow;

    private int routeToGo;

    private float tParam;

    private Vector3 objectPosition;

    private float speedModifier;

    private bool coroutineAllowed;

    public float rotationSpeed;

    

    // Start is called before the first frame update
    void Start()
    {
        routeToGo = 0;
        tParam = 0f;
        speedModifier = 0.1f;
        coroutineAllowed = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (coroutineAllowed)
        {
            StartCoroutine(GoByTheRoute(routeToGo));
        }
    }

    private IEnumerator GoByTheRoute(int routeNum)
    {
        coroutineAllowed = false;

        Vector3 p0 = routes[routeNum].GetChild(0).position;
        Vector3 p1 = routes[routeNum].GetChild(1).position;
        Vector3 p2 = routes[routeNum].GetChild(2).position;
        Vector3 p3 = routes[routeNum].GetChild(3).position;

        while (tParam < 1)
        {
            tParam += Time.deltaTime * speedModifier;

            objectPosition = Mathf.Pow(1 - tParam, 3) * p0 + 3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 + 3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 + Mathf.Pow(tParam, 3) * p3;

            //transform.LookAt(transform.position*2);

            //transform.forward = objectPosition;

            Vector3 movementDirection = objectPosition - transform.position;

            //-------------------------------------------------------------------//
            //Considered alternative for rotation//

            /*if (movementDirection != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            } */

            //-------------------------------------------------------------------//

            transform.position = objectPosition;
            /*follow.position = objectPosition * 2;
            Vector3 followPosition = new Vector3(follow.position.x, 0f, follow.position.z);
            transform.LookAt(followPosition);*/

            yield return new WaitForEndOfFrame(); 
        } 

        tParam = 0;
        speedModifier = speedModifier * 0.90f;
        routeToGo += 1;

        if (routeToGo > routes.Length - 1)
        {
            routeToGo = 0;
        }

        coroutineAllowed = true;

    }
}
