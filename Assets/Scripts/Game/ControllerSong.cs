using UnityEngine;
using UnityEngine.UI;

public class ControllerSong : MonoBehaviour
{
  private bool statusSong = true;
  [SerializeField] private AudioSource backgroundSong;

  [SerializeField] private Sprite onSongSprite;
  [SerializeField] private Sprite offSongSprite;

  [SerializeField] private Image muteImage;

  public void OnOffSong()
  {
    statusSong = !statusSong;
    backgroundSong.enabled = statusSong;

    if(statusSong)
    {
      muteImage.sprite = onSongSprite;
    }
    else
    {
      muteImage.sprite = offSongSprite;
    }
  }

  public void VolumeSong(float volumeSong)
  {
    backgroundSong.volume = volumeSong;
  }
}
