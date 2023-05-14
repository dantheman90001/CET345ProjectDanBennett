using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoingToWinScreen : MonoBehaviour
{


    private void OnTriggerEnter(Collider collideObject)
    {
        if (collideObject.gameObject.name == "Player")
        {
            SceneManager.LoadScene("WinScreen");
        }
    }
}
