using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneSwapper : MonoBehaviour
{
    [SerializeField] private string sceneName = "MapName";
    public void OnButtonPressed()
    {
        SceneSwapper.LoadScene(sceneName);
    }

}
