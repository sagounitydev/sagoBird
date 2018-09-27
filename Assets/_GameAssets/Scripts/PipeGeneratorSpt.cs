using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGeneratorSpt : MonoBehaviour {

    [SerializeField] Transform prefabTuberia;

    // Use this for initialization
	void Start () {

        InvokeRepeating("GeneratePipe", 0, 1);
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void GeneratePipe () {
        //Generador de tuberias
        if (GameConfig.IsPlaying())
        {
            Instantiate(prefabTuberia, transform.position, Quaternion.identity);
        }
        
    }
}
