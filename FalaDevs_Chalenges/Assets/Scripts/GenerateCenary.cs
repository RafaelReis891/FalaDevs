using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCenary : MonoBehaviour
{

	public List<GameObject> prefabs;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 1000; i++)
		{
			GameObject newPre = Instantiate(prefabs[Random.Range(0, prefabs.Count)], new Vector3(0, 0, i * 3), Quaternion.identity, transform.GetChild(0));
		}
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetChild(0).Translate(0,0, - 10 * Time.deltaTime);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Platform"))
        {
            Destroy(other.gameObject);
        }
    }
}
