using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
	public Help_Friend help_Friend;
	private void OnCollisionEnter(Collision collision)
	{
		if(collision.transform.CompareTag("Player"))
		{
			transform.tag = "Untagged";
			help_Friend.Create_LocalPlayer(collision.transform.position);
			Destroy(collision.gameObject);
			Destroy(this.gameObject);
		}
	}

}
