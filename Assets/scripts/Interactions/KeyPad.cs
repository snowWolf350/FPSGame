using UnityEngine;

public class KeyPad : Interactable
{
    [SerializeField] GameObject doors;
    Animator doorAnimator;
    bool doorOpen;

    const string ISOPEN = "isOpen";

    private void Start()
    {
        doorAnimator = doors.GetComponent<Animator>();
    }

    protected override void Interact()
    {
        doorOpen = !doorOpen;
        doorAnimator.SetBool(ISOPEN, doorOpen);
    }
}
