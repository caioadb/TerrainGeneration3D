using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainChecker : MonoBehaviour
{
    float distance = 1000f;
    Vector3 point;
    GameObject sphere;

    private void Start()
    {
        GameObject Localsphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere = Localsphere;
        sphere.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit, distance))
            {
                if (!sphere)
                { // create a sphere if no object assigned yet
                    sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                }
                sphere.SetActive(true);
                // change sphere color to yellow
                Renderer sphereRenderer = sphere.GetComponent<Renderer>();
                sphereRenderer.material.color = Color.yellow;

                // save terrain coordenates of mouse click
                Debug.Log(hit.point);
                point = hit.point;
                sphere.transform.position = hit.point;
            }
        }

    }

}
