using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
  [Header("Components")]
  public GameObject dialogueObj;
  //public Image profile;
  public TextMeshProUGUI speechText;
  public TextMeshProUGUI actorNameText;

  [Header("Settings")]
  public float typingSpeed;
  private string[] sentences;
  private int index = 0;

  AudioManager audioManager;

  private void Awake()
  {
    audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
  }

  public void Speech(/*Sprite sprite*/ string[] txt, string actorName)
  {
    dialogueObj.SetActive(true);
    //profile.sprite = sprite;
    sentences = txt;
    actorNameText.text = actorName;
    StartCoroutine(TypeSentence());
  }

  IEnumerator TypeSentence()
  {
    foreach(char letter in sentences[index].ToCharArray())
    {
      speechText.text += letter;
      yield return new WaitForSeconds(typingSpeed);
    }
  }

  public void NextSentece()
  {
    if (sentences == null || sentences.Length == 0 || index >= sentences.Length)
    {
      // Defensive: nothing to show or index out of bounds
      speechText.text = string.Empty;
      index = 0;
      dialogueObj.SetActive(false);
      return;
    }

    if (speechText.text == sentences[index])
    {
      if (index < sentences.Length - 1)
      {
        index++;
        speechText.text = string.Empty;
        StartCoroutine(TypeSentence());
      }
      else
      {
        speechText.text = string.Empty;
        index = 0;
        dialogueObj.SetActive(false);
      }
    }
  }
  void Update()
  {
    if (dialogueObj.activeSelf && Input.GetKeyDown(KeyCode.Return))
    {
      NextSentece();
      audioManager.PlaySFX(audioManager.npcSkipTalk);
    }
  }
}
