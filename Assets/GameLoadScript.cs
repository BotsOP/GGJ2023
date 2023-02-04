using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoadScript : MonoBehaviour
{
    [SerializeField] private int[] SceneIndexes;
    void Start()
    {
        if (SceneIndexes.Length > 0)
        {
            for (int i = 0; i < SceneIndexes.Length; i++)
            {
                SceneManager.LoadScene(SceneIndexes[i], LoadSceneMode.Additive);
            }
        }
        else
        {
            Debug.LogWarning("No Scenes found in the root controler");
        }
    }
}
