using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField]
    GameObject position = null;
    [SerializeField]
    TMPro.TextMeshProUGUI posVal = null;
    [SerializeField]
    GameObject tutorial = null; 
    [SerializeField]
    GameObject player = null;

    void Start()
    {
        tutorial.SetActive(true);
        position.SetActive(false);
    }

    private void Update()
    {
        posVal.SetText("Current Position: " + player.transform.position);
    }

    public void DismissTutorial()
    {

        tutorial.SetActive(false);
        position.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;

    }
}
