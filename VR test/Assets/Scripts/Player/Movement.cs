using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
	public float speed;

	public void Start(){

	}
	public void FixedUpdate(){
           
        if (Input.GetAxis("Vertical") < 0)
        {
		    transform.position += GameObject.Find ("Eyes").GetComponent<Camera> ().transform.forward * speed * Time.deltaTime;
		}

        if (Input.GetAxis("Vertical") > 0)
        {
            transform.position += GameObject.Find("Eyes").GetComponent<Camera>().transform.forward * speed * Time.deltaTime * -1;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.position += GameObject.Find("Eyes").GetComponent<Camera>().transform.right * speed * Time.deltaTime;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.position += GameObject.Find("Eyes").GetComponent<Camera>().transform.right * speed * Time.deltaTime * -1;
        }

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Dome"))
        {
            Debug.Log("collide");
            relocate(transform.position);
        }
    }

    void relocate(Vector3 position)
    {
        Debug.Log("relocate");
        position.x *= -0.5f;
        position.z *= -1;
        transform.position = position;
    }
}