using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ScrenLoader : MonoBehaviour
{
 public void StartGame(int index)
    {
        SceneManager.LoadScene(index);
    }

}
