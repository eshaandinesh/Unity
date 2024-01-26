using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;
    private const string cherriesKey = "CherriesCount";
    private bool gameStarted = false;


    [SerializeField] private Text cherriesText;
    [SerializeField] private AudioSource collectionSoundEffect;

    private void Start()
    {
        if (!gameStarted)
        {
            LoadCherries(); // Load cherries count only if the game hasn't started yet
            gameStarted = true;
        }
    }

    private void LoadCherries()
    {
        if (PlayerPrefs.HasKey(cherriesKey))
        {
            cherries = PlayerPrefs.GetInt(cherriesKey);
            UpdateCherriesText();
        }
    }

    // Method to be called when the level finishes
    public void LevelFinished()
    {
        PlayerPrefs.SetInt(cherriesKey, cherries);
        PlayerPrefs.Save();
    }

    // Method to reset cherries count when the game starts again
    public void ResetCherries()
    {
        cherries = 0;
        PlayerPrefs.DeleteKey(cherriesKey);
        PlayerPrefs.Save();
        UpdateCherriesText();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            cherries++;
            UpdateCherriesText();
            
        }
    }

    private void UpdateCherriesText()
    {
        cherriesText.text = "Score: " + cherries;
    }
}
