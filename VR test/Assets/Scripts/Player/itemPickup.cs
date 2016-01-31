using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class itemPickup : MonoBehaviour
{

	public float collectDist;
	public float holdDist;

    private RaycastHit raycastHit;

    private Rigidbody rbItem;

    private GameObject ground;

    private bool hasItem;
    private bool itemSelected = false;

	public GameObject[] objects;

	GameObject _temp;
    // Use this for initialization
    void Start()
    {
		
        ground = GameObject.Find("Ground");
		objects = GameObject.FindGameObjectsWithTag("Item");
		foreach (GameObject obj in objects) {
		}
    }

    // Update is called once per frame
    void Update()
    {
		if (hasItem)
		{

			Vector3 newPos;
			newPos = (GameObject.Find("Eyes").GetComponent<Camera>().transform.forward.normalized * holdDist) + transform.position;
			newPos.y = Mathf.Max(newPos.y, ground.transform.position.y + 11);
			rbItem.position = newPos;
		}
        Vector3 fwd = GameObject.Find("Eyes").transform.forward;

        if (Input.GetAxis("Fire1") < 0)
        {
            rbItem = null;
            hasItem = false;
        }
		Debug.DrawRay (transform.position, fwd * 300);

        /*Als de rechter trigger ingedrukt en item is minder dat collectDist ver dan wordt hij opgepakt*/
		if (Physics.Raycast (transform.position, fwd, out raycastHit, collectDist)) {
			
			//print (raycastHit.collider.gameObject.tag );
			foreach (GameObject obj in objects) {

				if (raycastHit.collider.gameObject.tag == obj.tag) {
					obj.GetComponent<ParticleSystem> ().enableEmission = true;
					print ("I got into the true loop and the object is" + obj.name + " and the tag is " + obj.tag);

					if (Input.GetAxis ("Fire1") > 0) {
						pickupItem (obj);
					}
				}
				if (raycastHit.collider.gameObject.tag != obj.tag) {
					obj.GetComponent<ParticleSystem> ().enableEmission = false;
						print ("I got into the false loop and the object is" + obj.name + " and the tag is " + obj.tag);
				} 
			
		}
	}
	}
	void pickupItem(GameObject obj){
		rbItem = obj.GetComponent<Rigidbody>();
		hasItem = true;
	}
}