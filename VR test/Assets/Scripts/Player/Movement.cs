using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
	public float speed;
    Quaternion rotationPlayer;
	public void Start(){

	}
	public void FixedUpdate(){
        rotationPlayer = transform.rotation;
        Debug.Log(rotationPlayer);
           
        print(Input.GetAxis("Vertical"));
        if (Input.GetAxis("Vertical") < 0){

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
}