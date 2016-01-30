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
<<<<<<< HEAD
     

        
=======
           
        print(Input.GetAxis("Vertical"));
>>>>>>> d1849cfb98e7c9a0df3ab2d9b17d21dc9c9fdded
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