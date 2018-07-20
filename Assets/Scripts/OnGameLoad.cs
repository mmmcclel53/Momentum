using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class OnGameLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
		string path = "Assets/Resources/beginner.txt";

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        Debug.Log(reader.ReadToEnd());
        reader.Close();
	}
}
