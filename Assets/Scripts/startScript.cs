//https://stackoverflow.com/questions/61253836/a-simple-start-button-in-unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class GameManager: MonoBehaviour
{
   public Button startButton;

   private void Awake()
   {
       Time.timeScale = 0f;
   }

   private void OnEnable()
   {
      startButton.onClick.AddListener(StartGame);
   }

   private void OnDisable()
   {
      startButton.onClick.RemoveListener(StartGame);
   }

   private void StartGame()
   {
      Time.timeScale = 1f;

      // Hides the button
      startButton.gameObject.SetActive(false);
   }
}