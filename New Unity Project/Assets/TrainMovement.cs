using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMovement : MonoBehaviour
{
    public bool triggerHit;
    public GameObject myPrefab;
    private Rigidbody rb;

    private int turnIndex;

    private bool isTurning;

    public static bool leftTurnStarted;

    public Transform pivotPlaceHolder;
    public Transform pivot;

    public static Transform[] positions;


    // Start is called before the first frame update
    void Start()
    {
        triggerHit = false;
        rb = GetComponent<Rigidbody>();
        isTurning = false;
        leftTurnStarted = false;
        turnIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        /*if(triggerHit)
        {
            Instantiate(myPrefab, GetComponentInChildren);
            triggerHit = false;
        }*/
        if(leftTurnStarted)
        {
            isTurning = true;
            leftTurnStarted = false;
            turnIndex = 0;
        }

        if(isTurning)
        {
            Vector3 newPos = new Vector3(positions[turnIndex].position.x, rb.position.y, positions[turnIndex].position.z);
            rb.MovePosition(newPos);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, Quaternion.LookRotation(-(newPos - rb.position), Vector3.up), 0.1f));
            turnIndex++;
            if (turnIndex == 17)
                isTurning = false;
        }
        else
        {
            Vector3 newPos = rb.position + new Vector3(0, 0, -1);
            rb.MovePosition(newPos);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, Quaternion.LookRotation(-(newPos - rb.position), Vector3.up), 0.1f));
        }
        //rb.MovePosition(rb.position + new Vector3(0, 0, -1));

        //pivot.position = pivotPlaceHolder.position;
    }
}
