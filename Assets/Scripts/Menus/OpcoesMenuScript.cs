﻿using UnityEngine;
using System.Collections;

public class OpcoesMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Cursor.visible = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		
		if (Input.anyKey) {
			Application.LoadLevel(0);
		}
	}
}
