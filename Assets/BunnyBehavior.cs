using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyBehavior : MonoBehaviour {
    const string scaleMatrixID = "scaleMatrix";

	// Use this for initialization
	void Start () {
        var rend = GetComponent<Renderer>();
        rend.material.SetMatrix(scaleMatrixID, Matrix4x4.Scale(new Vector3(2, 2, 2)));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
