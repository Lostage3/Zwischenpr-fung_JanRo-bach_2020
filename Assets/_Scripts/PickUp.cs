using UnityEngine;

public class PickUp : MonoBehaviour
{
	[SerializeField] GameObject fpsCamera = null;
	bool carrying;
	GameObject carriedObject;
	[SerializeField] float nearDistance = 1f;
	[SerializeField] float normalDistance = 3f;
	[SerializeField] float farDistance = 6f;
	[SerializeField] float smooth = 4f;
	[SerializeField] float range = 5f;
	
	void Update()
	{
		if (carrying)
		{
			Carry(carriedObject);
			CheckDrop();
		}
		else
		{
			pickup();
		}
	}

	void Carry(GameObject o)
	{

		if (Input.GetKey(KeyCode.Alpha1))
		{
			o.transform.position = Vector3.Lerp(o.transform.position, fpsCamera.transform.position + fpsCamera.transform.forward * nearDistance, Time.fixedDeltaTime * smooth);
		}
		if (Input.GetKey(KeyCode.Alpha2))
		{ 
			o.transform.position = Vector3.Lerp(o.transform.position, fpsCamera.transform.position + fpsCamera.transform.forward * farDistance, Time.fixedDeltaTime * smooth);
		}

		o.transform.position = Vector3.Lerp(o.transform.position, fpsCamera.transform.position + fpsCamera.transform.forward * normalDistance, Time.fixedDeltaTime * smooth);
		o.transform.rotation = Quaternion.identity;

		if (carriedObject.gameObject.GetComponent<CubeReset>().Drop)
		{
			dropObject();
			
		}

	}

	void pickup()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			RaycastHit hit;
			if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
			{
				PickUpEnable pickUpEnable = hit.collider.GetComponent<PickUpEnable>();
				if (pickUpEnable != null)
				{
					carrying = true;
					carriedObject = pickUpEnable.gameObject;
					pickUpEnable.gameObject.GetComponent<Rigidbody>().isKinematic = true;
					pickUpEnable.gameObject.GetComponent<MeshCollider>().isTrigger = true;
				}
			}
		}
	}

	void CheckDrop()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			dropObject();
		}
	}

	public void dropObject()
	{
		carrying = false;
		carriedObject.gameObject.GetComponent<Rigidbody>().isKinematic = false;
		carriedObject.gameObject.GetComponent<MeshCollider>().isTrigger = false;

		carriedObject = null;
	}
}
