using UnityEngine;
using System.Collections;

public class ItemParticleControl : MonoBehaviour {
	public ParticleSystem particleEmit;
	// Use this for initialization
	void Start () {
		particleEmit.GetComponent<ParticleSystem>().enableEmission = false;
	}
	
	// Update is called once per frame
	void Update () {
		}
	}