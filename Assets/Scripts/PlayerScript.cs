﻿using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float playerSpeed;
	public Transform player;
	private Animator animator;
	public GameObject ExplosionPrefab;
	Renderer rend;

	private OpcoesScript vida;


	void Awaje(){
		transform.tag = "Player";
	}
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		rend = GetComponent<Renderer> ();
	
	}

	// Update is called once per frame
	void Update () {
		Movimentar ();
	}

	void Movimentar(){
		animator.SetFloat ("run", Mathf.Abs(Input.GetAxis("Horizontal")));
		animator.SetFloat ("runVerticalCima",Input.GetAxis("Vertical"));
		animator.SetFloat ("runVerticalBaixo", Mathf.Abs(Input.GetAxis("Vertical")));

		if (Input.GetAxisRaw ("Horizontal") > 0) {
			transform.Translate ( Vector3.right * playerSpeed * Time.deltaTime);
			transform.eulerAngles = new Vector3 (0,0,0);
		}

		if (Input.GetAxisRaw ("Horizontal") < 0) {
			transform.Translate ( Vector3.right * playerSpeed * Time.deltaTime);
			transform.eulerAngles = new Vector3 (0,180,0);
		}
		if (Input.GetAxisRaw ("Vertical") > 0) {
			transform.Translate (Vector3.up * playerSpeed * Time.deltaTime);

		} else if (Input.GetAxisRaw ("Vertical") < 0) {
			transform.Translate (Vector3.down * playerSpeed * Time.deltaTime);
		}
	}

	void OnCollisionEnter2D(Collision2D colisor){
		if (colisor.gameObject.tag == "Enemy") {
			vida = GameObject.FindGameObjectWithTag("Vidas").GetComponent<OpcoesScript>() as OpcoesScript;

			if(vida.ExcluirVida()){
				StartCoroutine(DestroyShip());
			}else{
				//Application.LoadLevel(2);
			}

			/*if(OpcoesScript.vida != 0 ){
				OpcoesScript.vida--;
			}else{
				Application.LoadLevel(2);
			}
			StartCoroutine(DestroyShip());*/
		}
	}

	IEnumerator DestroyShip(){
		Instantiate(ExplosionPrefab,transform.position,transform.rotation);
		rend.enabled = false;
		transform.position = new Vector3 (-19.68f,-13.03f,0);
		yield return new WaitForSeconds (1.5f);
		rend.enabled = true;

	}










	/*void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("Collision: " + other.name);

	}*/

}
