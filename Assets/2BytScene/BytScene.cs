using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BytScene : MonoBehaviour
{
    private void OnMouseDown()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        print(sceneIndex);

        if(sceneIndex==0)
            SceneManager.LoadScene(1);
        else
            SceneManager.LoadScene(0);

    }


}
