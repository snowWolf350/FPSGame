using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    Camera Camera;
    float distance = 3f;
    [SerializeField] private LayerMask Layermask;
    PlayerUI PlayerUI;
    GameInput GameInput;

    private void Start()
    {
        Camera = GetComponent<PlayerLook>().Camera;
        PlayerUI = GetComponent<PlayerUI>();
        GameInput = GetComponent<GameInput>();
    }

    private void Update()
    {
        Ray ray = new Ray(Camera.transform.position,Camera.transform.forward);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, distance, Layermask))
        {
            if (hitInfo.transform.TryGetComponent(out Interactable Interactable))
            {
                PlayerUI.UpdateText(Interactable.promptMessage);
                if (GameInput.PlayerInput.Player.Interact.triggered)
                {
                    Interactable.BaseInteract();
                }
            }
        }
        else
            PlayerUI.UpdateText(string.Empty);
    }
}
