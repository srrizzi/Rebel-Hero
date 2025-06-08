using UnityEngine;

public class DialogueNPC : MonoBehaviour
{
  //public Sprite profileSprite;
  public string[] speechText;
  public string actorName;

  public LayerMask playerLayerMask;
  public float radius;

  private DialogueManager dialogueManager;
  bool onRadious;

  private bool dialogueStarted = false;

  AudioManager audioManager;

  private void Awake()
  {
    audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
  }

  private void Start()
  {
    dialogueManager = FindObjectOfType<DialogueManager>();
    if (dialogueManager == null)
    {
      Debug.LogError("DialogueManager not found in the scene.");
    }
  }

  private void FixedUpdate()
  {
    Interact();
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.E) && onRadious && !dialogueStarted)
    {
      dialogueManager.Speech(/*profileSprite,*/ speechText, actorName);
      dialogueStarted = true;
      audioManager.PlaySFX(audioManager.npcTalk);
    }

    // Stop dialogue if player leaves the radius and reset dialogue state
    if (!onRadious && dialogueManager.dialogueObj.activeSelf)
    {
      dialogueManager.dialogueObj.SetActive(false);
      // Reset dialogue state to avoid text duplication
      dialogueStarted = false;
      // Reset index and sentences in DialogueManager
      var type = dialogueManager.GetType();
      var indexField = type.GetField("index", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
      var sentencesField = type.GetField("sentences", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
      if (indexField != null) indexField.SetValue(dialogueManager, 0);
      if (sentencesField != null) sentencesField.SetValue(dialogueManager, null);
      if (dialogueManager.speechText != null) dialogueManager.speechText.text = "";
      if (dialogueManager.actorNameText != null) dialogueManager.actorNameText.text = "";
    }
  }

  public void Interact()
  {
    Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, playerLayerMask);

    if (hit != null)
    {
      onRadious = true;      
    }
    else
    {
      onRadious = false;
    }
  }

  private void OnDrawGizmosSelected()
  {
    Gizmos.color = Color.yellow;
    Gizmos.DrawWireSphere(transform.position, radius);
  }
}
