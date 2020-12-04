using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeReset : MonoBehaviour
{
    Vector3 startPos;
    Vector3 startScale;
    public bool Drop = false;

    PickUp drop;

    void Start()
    {
        drop = GameObject.Find("Player").GetComponent<PickUp>();
        startPos = transform.position;
        startScale = transform.localScale;
    }

    void Update()
    {
        Drop = false;
    }

    public void Reset()
    {
        transform.position = startPos;
        transform.localScale = startScale;
        transform.rotation = Quaternion.identity;
        Drop = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ResetZone"))
        {
            transform.position = startPos;
            transform.localScale = startScale;
            transform.rotation = Quaternion.identity;
            Drop = true;
            drop.dropObject();
        }
    }
}
