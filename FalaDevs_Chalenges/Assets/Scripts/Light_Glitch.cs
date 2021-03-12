/*

 Bem vindo ao FalaDevs!

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Glitch : MonoBehaviour
{
	public float glitchTime = 0.1f;
	
    // Start is called before the first frame update
    void Start()
    {        
		InvokeRepeating("RandonLightTime", 0, 0.15f);
	}
	
	void ChangeLightState()
	{
		GetComponent<Light>().enabled = !GetComponent<Light>().enabled;		
	}

	void RandonLightTime()
	{
		glitchTime = Random.Range(1.0f, 10.0f) / 10.0f;
		InvokeRepeating("ChangeLightState", 1, glitchTime);
		GetComponent<Light>().color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255),255);
	}
}
