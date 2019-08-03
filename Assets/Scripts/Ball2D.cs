using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2D : MonoBehaviour
{
    [SerializeField]
    private Transform blockParent;

    private Rigidbody2D myRigitBody;

    private void Start()
    {
        myRigitBody = GetComponent<Rigidbody2D>();
        myRigitBody.velocity = new Vector2(-1.0f, 1.0f).normalized;
    }

    private void Update()
    {
        foreach(Transform child in blockParent)
        {
            float myMagnitude = myRigitBody.velocity.magnitude * Time.deltaTime;
            float distance = (child.transform.position - transform.position).magnitude;

            float x1_x0 = myRigitBody.velocity.x * Time.deltaTime;
            float y1_y0 = myRigitBody.velocity.x * Time.deltaTime;
            float x0 = transform.position.x;
            float y0 = transform.position.y;
            float x2 = child.position.x;
            float y2 = child.position.y;
            if ((x1_x0 * (x2 - x0) + y1_y0 * (y2 - y0)) - myMagnitude * distance <= 0.01f && myMagnitude >= distance)
            {
                transform.position = child.position;
                if (child.rotation.eulerAngles.z % 180 == 0)
                {
                    myRigitBody.velocity = new Vector2(myRigitBody.velocity.x, -myRigitBody.velocity.y);
                }
                if ((child.rotation.eulerAngles.z - 90) % 180 == 0)
                {
                    myRigitBody.velocity = new Vector2(-myRigitBody.velocity.x, myRigitBody.velocity.y);
                }
            }
        }
    }
}
