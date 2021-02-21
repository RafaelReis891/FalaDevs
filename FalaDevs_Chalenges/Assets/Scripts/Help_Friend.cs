using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help_Friend : MonoBehaviour
{
    public GameObject Player;
    public Transform _currentPlayer;

    public float force = 50f;
    public float SpeedMove = 10F;
    public float moveX;
    private void Start()
    {
        Create_Player();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _currentPlayer.GetComponent<Rigidbody>().AddForceAtPosition(transform.forward * force, transform.position, ForceMode.Impulse);
            _currentPlayer = null;
            Invoke("Create_Player", 0.2f);
        }

        if (Input.GetMouseButton(0))
        {
            moveX = Input.GetAxis("Mouse X") * SpeedMove * Time.deltaTime;
            _currentPlayer.transform.Translate(transform.right * moveX);
        }
    }

    public void Create_Player()
    {
        GameObject player = Instantiate(Player, transform.position, Quaternion.identity);
        player.tag = "Player";
        player.AddComponent<Destroy>();
        player.GetComponent<Destroy>().help_Friend = GetComponent<Help_Friend>();
        _currentPlayer = player.transform;
    }

    public void Create_LocalPlayer(Vector3 position)
    {
        GameObject player = Instantiate(Player, position, Quaternion.identity);
        player.tag = "Player";
        player.AddComponent<Destroy>();
        player.GetComponent<Destroy>().help_Friend = GetComponent<Help_Friend>();
    }
}
