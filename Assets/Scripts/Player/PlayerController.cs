﻿using UnityEngine;
using System.Collections;
using Prime31;

public class PlayerController : MonoBehaviour {


	public enum shiftState{HUMAN,WOLF};
	public shiftState currState = shiftState.HUMAN;
	public Sprite hForm;
	public Sprite wForm;
	private SpriteRenderer sr;
	private BoxCollider2D col;
	private CharacterController2D cc;
	private PlatformingController pCtrl;
	private Animator anim;

	[Header("Human specific variables")]

	public float h_formSpeed = 25.0f;



	[Header("Wolf specific variables")]

	public float w_formSpeed = 35.0f;


	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		col = GetComponent<BoxCollider2D> ();
		cc = GetComponent<CharacterController2D> ();
		anim = GetComponent<Animator> ();
		pCtrl = GetComponent<PlatformingController> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (currState == shiftState.WOLF) {
			if (!Physics2D.Raycast (transform.position, Vector2.up, 1.25f, cc.platformMask)) {
				if (Input.GetKeyDown (KeyCode.C)) {
					ChangeState ();
				}
			}
		} else if (currState == shiftState.HUMAN) {
			if (Input.GetKeyDown (KeyCode.C)) {
				ChangeState ();
			}
		}





		if (currState == shiftState.HUMAN) {
			HumanControls ();
		} else {
		
			WolfControls ();
		}


	}



	void HumanControls(){


	}

	void WolfControls(){
		
	}





	void ChangeState(){
		if (currState == shiftState.HUMAN) {
			pCtrl.ShapeShift ();
			transform.position = new Vector2 (transform.position.x, transform.position.y - 0.25f);
			col.size = new Vector2 (1f, 1f);
			cc.recalculateDistanceBetweenRays ();
			currState = shiftState.WOLF;
		} else {
			pCtrl.ShapeShift ();
			transform.position = new Vector2 (transform.position.x, transform.position.y + 0.5f);
			col.size = new Vector2 (1f, 1.5f);
			cc.recalculateDistanceBetweenRays ();
			currState = shiftState.HUMAN;
		}
	}

}
