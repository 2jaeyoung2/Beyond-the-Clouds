using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsRemoval : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer.enabled = false;
    }

    private IEnumerator Start()
    {
        yield return new WaitForFixedUpdate();

        meshRenderer.enabled = true;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
