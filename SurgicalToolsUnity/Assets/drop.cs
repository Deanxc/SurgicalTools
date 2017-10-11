using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class drop : MonoBehaviour {

    // Use this for initialization
    private void Start()
    {
        if (this.GetComponent<Dropdown>() != null)
        {
            this.GetComponent<Dropdown>().captionText.text = "Surgical Tools";
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DropdownHandler(int input) {
        Debug.Log("Option selected: " + input);

        if(input.Equals(0))
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Instantiate(cube);

        }
        else if(input.Equals(1))
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            Instantiate(sphere);
        }
        else if(input.Equals(2))
        {
            GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
            Instantiate(plane);
        }

    }
}
