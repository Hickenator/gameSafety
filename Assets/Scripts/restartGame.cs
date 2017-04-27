using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartGame : MonoBehaviour {
	
    void Init()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
