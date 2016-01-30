using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class itemPickup : MonoBehaviour
{

    public float collectDist = 30;
    public float holdDist = 30;

    private RaycastHit raycastHit;

    private Rigidbody rbItem;

    private GameObject ground;
    private GameObject selItem;

    private bool hasItem;
    private bool itemSelected = false;

    // Use this for initialization
    void Start()
    {
        ground = GameObject.Find("Ground");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 fwd = GameObject.Find("Eyes").transform.forward;

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
                selectItem(raycastHit);
                if (Input.GetAxis("Fire1") > 0)
                {
                    rbItem = raycastHit.rigidbody;
                    hasItem = true;
                }
            }
            else
            {
                unSelectItem();
            }
        }
        else
        {
            unSelectItem();
        }

        if (hasItem)
        {
            Vector3 newPos;
            newPos = (GameObject.Find("Eyes").GetComponent<Camera>().transform.forward.normalized * holdDist) + transform.position;
            newPos.y = Mathf.Max(newPos.y, ground.transform.position.y + 11);
            rbItem.position = newPos;
        }
    }

    void unSelectItem()
    {
        if (selItem != null)
        {
            if (selItem.GetComponent<ParticleSystem>().isPlaying)
            {
                selItem.GetComponent<ParticleSystem>().Stop();
                selItem = null;
                itemSelected = false;
            }
        }

    }

    void selectItem(RaycastHit raycastHit)
    {
        if (raycastHit.collider.gameObject.GetComponent<ParticleSystem>().isStopped)
        {
            itemSelected = true;
            selItem = raycastHit.collider.gameObject;
            selItem.GetComponent<ParticleSystem>().Play();
        }
    }
}

