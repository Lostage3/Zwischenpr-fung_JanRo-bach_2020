using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] float range = 100f;
    public float minScale = 1f;
    [SerializeField] float middleScale = 2f;
    [SerializeField] float maxScale = 3f;

    [SerializeField] Camera fpsCamera = null;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shrink();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1)) 
        {
            Enlarge();
        }
    }

    void Shrink()
    {
        RaycastHit hit;
        if(Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            if (hit.transform.CompareTag("GunTarget"))
            {
                if (hit.transform.localScale == new Vector3(middleScale, middleScale, middleScale))
                {
                    hit.transform.localScale = new Vector3(minScale, minScale, minScale);
                }

                if (hit.transform.localScale == new Vector3(maxScale, maxScale, maxScale))
                {
                    hit.transform.localScale = new Vector3(middleScale, middleScale, middleScale);
                }
            }
        }
    }

    void Enlarge()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            if (hit.transform.CompareTag("GunTarget"))
            {
                if (hit.transform.localScale == new Vector3(middleScale, middleScale, middleScale))
                {
                    hit.transform.localScale = new Vector3(maxScale, maxScale, maxScale);
                }

                if (hit.transform.localScale == new Vector3(minScale, minScale, minScale))
                {
                    hit.transform.localScale = new Vector3(middleScale, middleScale, middleScale);
                }
            }
        }
    }
}
