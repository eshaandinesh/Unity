using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;

    private bool levelCompleted = false;

    private ItemCollector itemCollector; // Reference to the ItemCollector class

    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
        itemCollector = FindObjectOfType<ItemCollector>(); // Find ItemCollector in the scene
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            finishSound.Play();
            levelCompleted = true;
            Invoke("CompleteLevel", 2f);
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if (itemCollector != null)
        {
            itemCollector.LevelFinished(); // Call LevelFinished() from ItemCollector
        }
        else
        {
            Debug.LogWarning("ItemCollector not found in the scene.");
        }
    }
}