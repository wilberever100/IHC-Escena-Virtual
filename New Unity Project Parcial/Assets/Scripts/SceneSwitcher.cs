using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
    public void principalMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void designEscenary()
    {
        SceneManager.LoadScene(1);
    }
    public void helpScene()
    {
        SceneManager.LoadScene(2);
    }
    public void templatesMenu()
    {
        SceneManager.LoadScene(3);
    }
}
