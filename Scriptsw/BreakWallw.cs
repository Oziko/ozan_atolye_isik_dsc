using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakWallw : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Duvara carpti.");
            BreakTheWall();
        }
    }

    void BreakTheWall()
    {
        transform.GetComponent<BoxCollider>().enabled = false;

        foreach (Transform child in transform)
        {
            child.GetComponent<Rigidbody>().isKinematic = false;
            child.GetComponent<Rigidbody>().AddForce(Vector3.forward, ForceMode.Impulse);
        }
    }
}
