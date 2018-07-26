using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour {

    // Use this for initialization
    public string levelName;
	void Start () {
        StartCoroutine("Wait");


    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        Application.LoadLevel(levelName);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
