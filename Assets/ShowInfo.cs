using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInfo : MonoBehaviour
{

    [SerializeField] private GameObject canvas = null;
    [SerializeField] private Camera camera = null;
    [SerializeField] private GameObject[] objects = null;

    public void OnMouseDown()
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(false);
        }
        canvas.SetActive(true);
        camera.transform.position = new Vector3(2.7f, 6.1f, -385f);
        camera.transform.rotation = Quaternion.identity;
    }

}
