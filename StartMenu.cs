using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{

    private ItemCollector itemCollector; // Reference to the ItemCollector class

    private void Start()
    {
        itemCollector = FindObjectOfType<ItemCollector>(); // Find ItemCollector in the scene
        itemCollector.ResetCherries();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if (itemCollector != null)
        {
            itemCollector.ResetCherries(); // Call ResetCherries() from ItemCollector
        }
        else
        {
            Debug.LogWarning("ItemCollector not found in the scene.");
        }
    }

    
}