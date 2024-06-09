using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class ForgeInteract : MonoBehaviour
{
    public GameObject completeUI;
    public float interactionDistance = 5.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsPlayerCloseToForge())
        {
            completeUI.SetActive(!completeUI.activeSelf);
        }
        else if (!IsPlayerCloseToForge())
        {
            completeUI.SetActive(false);
        }
    }

    bool IsPlayerCloseToForge()
    {
        GameObject[] forges = GameObject.FindGameObjectsWithTag("Forge");
        foreach (GameObject forge in forges)
        {
            if (Vector3.Distance(transform.position, forge.transform.position) <= interactionDistance)
            {
                return true;
            }
        }
        return false;
    }
}
