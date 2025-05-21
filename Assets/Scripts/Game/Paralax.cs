using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
  [SerializeField]
  private Transform cameraTransform;

  [SerializeField]
  private Vector2 parallaxEffectMultiplier;

  private Vector3 lastCameraPosition;

  void Start()
  {
    lastCameraPosition = cameraTransform.position;
  }

  void LateUpdate()
  {
    Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;

    transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y, 0);

    lastCameraPosition = cameraTransform.position;
  }
}

