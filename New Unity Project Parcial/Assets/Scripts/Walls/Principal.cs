using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Principal : MonoBehaviour
{
    string path;
    public Texture image;
    public void OpenExplorer()
    {
        path = EditorUtility.OpenFilePanel("Elige tu obra: ", "", "png");
        GetImage();
    }
    void GetImage()
    {
        if (path != null)
        {
            UpdateImage();
        }
    }
    void UpdateImage()
    {
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
        WWW www = new WWW("file:///" + path);
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
        image = www.texture;
    }
}
