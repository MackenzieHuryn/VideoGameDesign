using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O2BarRig : MonoBehaviour
{
    public GameObject player;
    public GameManager gameManager;
    public float xRig = 0.45f;
    public float yRig = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
            transform.position = player.transform.position + new Vector3(xRig, yRig, 0);

    }
}
