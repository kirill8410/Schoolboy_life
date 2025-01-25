using DialogueEditor;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class Mother : MonoBehaviour
{
    NPCConversation _NC;
    QuestManager _QM;
    NearFarInteractor[] _NF;

    private void Start()
    {
        _NC = GetComponentInChildren<NPCConversation>();
        _QM = FindFirstObjectByType<QuestManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<XROrigin>() != null)
        {
            if (Resources.Load<Quest>("SO/Quest1").isComplite)
            {
                _NF = GameObject.FindObjectsByType<NearFarInteractor>(FindObjectsSortMode.None);
                foreach (NearFarInteractor N in _NF)
                {
                    N.enableFarCasting = true;
                }
                ConversationManager.Instance.StartConversation(_NC);
            }
        }
    }

    public void AddQuest()
    {
        _QM.AddQuest(Resources.Load<Quest>("SO/Quest2"));
        _QM.AddQuest(Resources.Load<Quest>("SO/Quest3"));
        foreach (NearFarInteractor N in _NF)
        {
            N.enableFarCasting = false;
        }
    }
}
