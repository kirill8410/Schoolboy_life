using DialogueEditor;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class Mother : MonoBehaviour
{
    [SerializeField] NPCConversation[] _NCs = new NPCConversation[2];
    NPCConversation _NC;
    QuestManager _QM;
    NearFarInteractor[] _NF;
    [SerializeField] bool[] _isDialogues = new bool[2] {false, false};
    [SerializeField] Transform teleport;
    XROrigin player;

    private void Start()
    {
        _NC = _NCs[0];
        _QM = FindFirstObjectByType<QuestManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<XROrigin>() != null)
        {
            player = other.GetComponent<XROrigin>();

            if (Resources.Load<Quest>("SO/Quest2").isComplite && Resources.Load<Quest>("SO/Quest3").isComplite && !_isDialogues[1])
            {
                _NF = GameObject.FindObjectsByType<NearFarInteractor>(FindObjectsSortMode.None);
                foreach (NearFarInteractor N in _NF)
                {
                    N.enableFarCasting = true;
                }
                ConversationManager.Instance.StartConversation(_NC);
                _isDialogues[1] = true;
            }
            else if (Resources.Load<Quest>("SO/Quest1").isComplite && !_isDialogues[0])
            {
                _NF = GameObject.FindObjectsByType<NearFarInteractor>(FindObjectsSortMode.None);
                foreach (NearFarInteractor N in _NF)
                {
                    N.enableFarCasting = true;
                }
                ConversationManager.Instance.StartConversation(_NC);
                _isDialogues[0] = true;
                _NC = _NCs[1];
            }
            
        }
    }

    public void AddQuestOne()
    {
        _QM.AddQuest(Resources.Load<Quest>("SO/Quest2"));
        _QM.AddQuest(Resources.Load<Quest>("SO/Quest3"));
        foreach (NearFarInteractor N in _NF)
        {
            N.enableFarCasting = false;
        }
    }
    
    public void AddQuestTwo()
    {
        _QM.AddQuest(Resources.Load<Quest>("SO/Quest4"));
        foreach (NearFarInteractor N in _NF)
        {
            N.enableFarCasting = false;
        }
        player.transform.position = teleport.position;
    }
}
