﻿using UnityEngine;
using System.Collections;

public class OpcoesScript : MonoBehaviour {
	
	public static int score = 0;
	//public static int vida = 3;
	public Texture2D[] vidaAtual;
	private int vidas;
	private int contador;




	// Use this for initialization
	void Start () {

		GetComponent<GUITexture> ().texture =  vidaAtual [0];
		vidas = vidaAtual.Length;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUI.Label (new Rect(10.0f,10.0f,105,20), "Pontuaçao: "+ score.ToString());
		//GUI.Label (new Rect (10.0f, 30.0f, 70, 20), "Vidas: " + vida.ToString ());
	}



	public bool ExcluirVida(){
		if (vidas < 0) {
			return false;
		}
		if (contador < (vidas - 1)) {
			contador += 1;
			Debug.Log(contador);
			GetComponent<GUITexture> ().texture = vidaAtual [contador];
			return true;
		} else {
			return false;
		}
		return true;
	}

}