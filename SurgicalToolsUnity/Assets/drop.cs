using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class drop : MonoBehaviour {

	// Use this for initialization
	private void Start () {
        this.GetComponent<Dropdown>().captionText.text = "Surgical Tools";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
