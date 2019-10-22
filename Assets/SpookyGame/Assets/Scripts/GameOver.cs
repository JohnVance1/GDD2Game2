using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    [SerializeField]
    private bool on;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Skeleton Center") && on)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
