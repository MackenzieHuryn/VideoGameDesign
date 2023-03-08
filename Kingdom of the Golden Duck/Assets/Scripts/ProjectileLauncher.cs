using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public GameObject projectilePrefab;
    // Start is called before the first frame updat e
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Project projectile when W pressed
        if (Input.GetKeyDown(KeyCode.W)) {
            Vector2 playerPosition = transform.position;
            Instantiate(projectilePrefab, playerPosition, projectilePrefab.transform.rotation);

            //Play Audio
            //playerAudio.PlayOneShot(projectileSound, 0.5f);
        }
    }
}
