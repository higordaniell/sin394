﻿using UnityEngine;
using System.Collections;

public class LixoScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D colisor){
		if (colisor.gameObject.tag == "Player") {
			Destroy(gameObject);
			OpcoesScript.score = OpcoesScript.score+10;
		}
	}
}
