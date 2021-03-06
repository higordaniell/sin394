﻿using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float playerSpeed;
	public Transform player;
	private Animator animator;
	public GameObject ExplosionPrefab;
	Renderer rend;

	private OpcoesScript temperatura;


	void Awaje(){
		transform.tag = "Player";
	}
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		rend = GetComponent<Renderer> ();
	
		if (MapaJogoScript.level == 2) {
			transform.position = new Vector3(-16.0f, 4.0f, transform.position.z);
		}
        if (MapaJogoScript.level == 3)
        {
            transform.position = new Vector3(-2.7f, 4.0f, transform.position.z);
        }
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
			
			OpcoesScript.temperatura++;
			StartCoroutine(DestroyShip());
		}
		
		//Gambiarra! Arrumar
		if (colisor.gameObject.tag == "startFase1Tag") {
			Application.LoadLevel (8);
		}
        else if (colisor.gameObject.tag == "startFase2Tag") {
			Application.LoadLevel (14);
		}
        else if (colisor.gameObject.tag == "startFase3Tag")
        {
            Application.LoadLevel(14);
            //Application.LoadLevel(15);
        }

    }

	IEnumerator DestroyShip(){
		Instantiate(ExplosionPrefab,transform.position,transform.rotation);
		rend.enabled = false;
		transform.position = new Vector3 (-19.68f,-13.03f,0);
		yield return new WaitForSeconds (1.5f);
		rend.enabled = true;
	}
}
