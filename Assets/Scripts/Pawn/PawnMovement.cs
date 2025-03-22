using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnMovement : MonoBehaviour
{
    Pawn pawnReference;


    // Start is called before the first frame update
    void Start()
    {
        pawnReference = GetComponent<Pawn>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pawnReference == null)
            return;

        Vector3 newPos = gameObject.transform.position;

        if (pawnReference.target == null)
        {
            newPos += gameObject.transform.right * pawnReference.moveSpeed * Time.deltaTime * 0.5f;
        }
        else
        {
            newPos += (pawnReference.target.transform.position -  gameObject.transform.position).normalized * pawnReference.moveSpeed * Time.deltaTime;
        }

        gameObject.transform.position = newPos;
    }
}
