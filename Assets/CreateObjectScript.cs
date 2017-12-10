using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using LocalJoost.HoloToolkitExtensions;

public class CreateObjectScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var cap = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        cap.AddComponent<BoxCollider>();
        cap.AddComponent<MeshRenderer>();
        cap.AddComponent<MeshFilter>();
        cap.AddComponent<HandDraggable>();
        cap.AddComponent<GazeManager>();
        cap.AddComponent<TapToSelect>();
        cap.AddComponent<SpatialManipulator>();
        cap.AddComponent<SpatialMappingCollisionDetector>();
        cap.transform.position = new Vector3(2, 0, 2);
        cap.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        cap.transform.parent = GameObject.Find("HologramCollection").transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
