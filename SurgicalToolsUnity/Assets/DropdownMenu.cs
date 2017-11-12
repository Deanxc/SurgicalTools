using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownMenu : MonoBehaviour {

    public GameObject human;
    public GameObject forceps;
    public GameObject graspingForceps;
    public GameObject lancet;
    public GameObject scissors;
    public GameObject surgicalMirror;
    public GameObject surgicalSaw;
    public GameObject syringe;

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

        if (input.Equals(0))
        {
            Instantiate(human);
        }
        else if (input.Equals(1))
        {
            Instantiate(forceps);
        }
        else if (input.Equals(2))
        {
            Instantiate(graspingForceps);
        }
        else if (input.Equals(3))
        {
            Instantiate(lancet);
        }
        else if (input.Equals(4))
        {
            Instantiate(scissors);
        }
        else if (input.Equals(5))
        {
            Instantiate(surgicalMirror);
        }
        else if (input.Equals(6))
        {
            Instantiate(surgicalSaw);
        }
        else if (input.Equals(7))
        {
            Instantiate(syringe);
        }

    }
}








