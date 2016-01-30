using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class itemPickup : MonoBehaviour {

    public float collectDist = 30;
    public float holdDist = 30;
    private RaycastHit raycastHit;
    private Rigidbody rbItem;
    private Rigidbody rbPlayer;
   // private Rigidbody rb;
    private GameObject ground;
    private GameObject selItem;
    private bool hasItem;

    public Canvas canvas;
    public ParticleSystem particle;

	// Use this for initialization
	void Start ()
    {
        //  rb = GetComponent<Rigidbody>();
        rbPlayer = GameObject.Find("Player").GetComponent<Rigidbody>();
        ground = GameObject.Find("Ground");
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Vector3 fwd = GameObject.Find("Eyes").transform.forward;
        float dist = Vector3.Distance(transform.position, rbPlayer.position);

        if (Input.GetAxis("Fire1") == 0)
        {
            rbItem = null;
            hasItem = false;
        }

        /*Als de rechter trigger ingedrukt en item is minder dat collectDist ver dan wordt hij opgepakt*/
        if (Physics.Raycast(transform.position, fwd, out raycastHit, collectDist))
        {
            if (raycastHit.collider.CompareTag("Item"))
            {
                selItem = raycastHit.collider.gameObject;
                selItem.GetComponent<ParticleSystem>().Play();
                Debug.Log("hit");
                    if (Input.GetAxis("Fire1") > 0)
                    {
                        Debug.Log("hit");
                        rbItem = raycastHit.rigidbody;
                        hasItem = true;
                    }
                
            }
            else
            {
                selItem.GetComponent<ParticleSystem>().Stop();
                selItem = null;
            }
        }
        else
        {
            selItem.GetComponent<ParticleSystem>().Stop();
            selItem = null;
        }

        if (hasItem)
        {
            Vector3 newPos;
            newPos = (GameObject.Find("Eyes").GetComponent<Camera>().transform.forward.normalized * holdDist) + transform.position;
            newPos.y = Mathf.Max(newPos.y, ground.transform.position.y + 11);
            rbItem.position = newPos;
        }
	}
}
