using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPoint : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(FinalPointPlace());
    }

    IEnumerator FinalPointPlace()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
