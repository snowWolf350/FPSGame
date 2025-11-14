using UnityEditor;

[CustomEditor(typeof(Interactable),true)]
public class InteractableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Interactable Interactable = (Interactable)target;
        if (target.GetType() == typeof(EventOnlyInteractable))
        {
            Interactable.promptMessage = EditorGUILayout.TextField("Prompt Message", Interactable.promptMessage);
            EditorGUILayout.HelpBox("using only unity events", MessageType.Info);
            if (Interactable.GetComponent<InteractionEvent>() == null)
            {
                Interactable.useEvents = true;
                Interactable.gameObject.AddComponent<InteractionEvent>();   
            }
        }else
        {
            base.OnInspectorGUI();
            if (Interactable.useEvents)
            {
                if (Interactable.GetComponent<InteractionEvent>() == null)
                    Interactable.gameObject.AddComponent<InteractionEvent>();
            }
            else
            {
                if (Interactable.GetComponent<InteractionEvent>() != null)
                {
                    DestroyImmediate(Interactable.gameObject.GetComponent<InteractionEvent>());
                }
            }
        }
    }
}
