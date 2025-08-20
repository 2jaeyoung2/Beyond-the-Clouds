using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsRemoval : MonoBehaviour
{
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
