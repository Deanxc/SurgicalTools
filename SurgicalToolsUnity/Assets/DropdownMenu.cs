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
            this.GetComponent<Dropdown>().itemText.fontSize = 8;
        }   
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DropdownHandler(int input) {
        Debug.Log("Option selected: " + input);

        if (input.Equals(1))
        {
            human.transform.position = new Vector3(5, -2, 0);
            human.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            Instantiate(human);
        }
        else if (input.Equals(2))
        {
            forceps.transform.position = new Vector3(5, 0, 0);
            forceps.transform.localScale = new Vector3(10, 10, 10);
            Instantiate(forceps);
        }
        else if (input.Equals(3))
        {
            graspingForceps.transform.position = new Vector3(5, 0, 0);
            graspingForceps.transform.localScale = new Vector3(10, 10, 10);
            Instantiate(graspingForceps);
        }
        else if (input.Equals(4))
        {
            lancet.transform.position = new Vector3(3, 0, 0);
            lancet.transform.localScale = new Vector3(10, 10, 10);
            Instantiate(lancet);
        }
        else if (input.Equals(5))
        {
            scissors.transform.position = new Vector3(-5, 0, 0);
            scissors.transform.localScale = new Vector3(10, 10, 10);
            Instantiate(scissors);
        }
        else if (input.Equals(6))
        {
            surgicalMirror.transform.position = new Vector3(-3, 0, 0);
            surgicalMirror.transform.localScale = new Vector3(10, 10, 10);
            Instantiate(surgicalMirror);
        }
        else if (input.Equals(7))
        {
            surgicalSaw.transform.position = new Vector3(0, 5, 0);
            surgicalSaw.transform.localScale = new Vector3(10, 10, 10);
            Instantiate(surgicalSaw);
        }
        else if (input.Equals(8))
        {
            syringe.transform.position = new Vector3(0, 7, 0);
            syringe.transform.localScale = new Vector3(10, 10, 10);
            Instantiate(syringe);
        }

    }
}








