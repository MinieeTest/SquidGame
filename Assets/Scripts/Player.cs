using Unity.Cinemachine;
using UnityEngine;

public class Player : MonoBehaviour
{
    //private GameManager gameManager;
    private CinemachineInputAxisController inputAxisController;
    private PlayerMovement playerMovement;
    public bool HasReachedFinish { get; set; }

    private void OnEnable()
    {
        GameManager.OnGameStateChanged += HandleGameStateChanged;
    }

    private void OnDisable()
    {
        GameManager.OnGameStateChanged -= HandleGameStateChanged;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FinishLine")) HasReachedFinish = true;
    }


    private void HandleGameStateChanged(LightState state)
    {
        if (state is LightState.GameOver or LightState.Won)
        {
            inputAxisController = GetComponentInChildren<CinemachineInputAxisController>();
            playerMovement = GetComponent<PlayerMovement>();
            inputAxisController.enabled = false;
            playerMovement.enabled = false;
        }
    }
}