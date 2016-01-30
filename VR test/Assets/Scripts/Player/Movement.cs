using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
	public float speed;

	public void Start(){

	}
	public void FixedUpdate(){
		if(Input.GetAxis("Horizontal") < 0){
		transform.position += GameObject.Find ("Eyes").GetComponent<Camera> ().transform.forward * speed * Time.deltaTime;
		}
	}
}