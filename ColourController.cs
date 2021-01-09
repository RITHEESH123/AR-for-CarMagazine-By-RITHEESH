using System.Collections;
using System.Collections.Generic;
using Wikitude;
using UnityEngine;

public class ColourController : MonoBehaviour
{
    public void OnImageRecognized(ImageTarget target)
    {
        Color paintColor = Color.white;
        if (target.Name == "red")
        {
            paintColor = Color.red;
        }
        else if (target.Name == "blue")
        {
            paintColor = Color.blue;
        }

        GameObject[] cars = GameObject.FindGameObjectsWithTag("car");
        Debug.Log("Car Count " + cars.Length);
        foreach(GameObject c in cars)
        {
            MeshRenderer mr = c.GetComponentInChildren<MeshRenderer>();
            Material[] mats = mr.sharedMaterials;
            foreach(Material m in mats)
            {
                m.color = paintColor;
            }
        }

    }

    public void OnImageLost(ImageTarget target)
    {
        GameObject[] cars = GameObject.FindGameObjectsWithTag("car");
        Debug.Log("Car Count " + cars.Length);
        foreach(GameObject c in cars)
        {
            MeshRenderer mr = c.GetComponentInChildren<MeshRenderer>();
            Material[] mats = mr.sharedMaterials;
            foreach(Material m in mats)
            {
                m.color = Color.white;
            }
        }
    }
}
