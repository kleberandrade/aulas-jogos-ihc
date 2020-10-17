using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(MoveUI))]
public class DialogManager : MonoBehaviour
{
    #region [ Singleton ]
    public static DialogManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    #endregion

    [Header("HUD")]
    public Image m_AvatarUI;
    public Text m_NameUI;
    public Text m_MessageUI;

    private MoveUI m_Animator;
    private AudioSource m_Audio;
    private bool m_IsOpen;
    private Queue<DialogSentence> m_Sentences = new Queue<DialogSentence>();

    private void Start()
    {
        m_Audio = GetComponent<AudioSource>();
        m_Animator = GetComponent<MoveUI>();
    }

    [ContextMenu("Show dialog")]
    public void Show()
    {
        Open(true);
    }

    [ContextMenu("Hide dialog")]
    public void Hide()
    {
        Open(false);
    }

    public void Open(bool open)
    {
        m_IsOpen = open;
        if (m_Animator)
        {
            if (open)
                m_Animator.Enable();
            else
                m_Animator.Disable();
        }
    }

    public void BeginDialog(Dialog dialog)
    {
        if (m_IsOpen) return;

        Show();

        m_Sentences.Clear();

        if (m_NameUI) m_NameUI.text = dialog.m_Name;
        if (m_AvatarUI) m_AvatarUI.sprite = dialog.m_Avatar;

        foreach (var sentence in dialog.m_Sentences)
            m_Sentences.Enqueue(sentence);

        StartCoroutine(FirstSentence());
    }

    public IEnumerator FirstSentence()
    {
        m_MessageUI.text = string.Empty;
        yield return new WaitForSeconds(m_Animator.m_EnableTime + 0.5f);
        NextSentence();
    }

    public void NextSentence()
    {
        if (m_Audio) m_Audio.Stop();

        if (m_Sentences.Count == 0)
        {
            Hide();
            return;
        }

        var sentence = m_Sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(WriteSentence(sentence));
    }

    private IEnumerator WriteSentence(DialogSentence sentence)
    {
        if (m_Audio)
        {
            m_Audio.clip = sentence.m_Voice;
            m_Audio.Play();
        }

        m_MessageUI.text = string.Empty;
        foreach (char letter in sentence.m_Text.ToCharArray())
        {
            while (Time.timeScale == 0) yield return null;
            m_MessageUI.text += letter;
            yield return null;
        }
    }
}

[System.Serializable]
public class Dialog
{
    public string m_Name;
    public Sprite m_Avatar;
    public List<DialogSentence> m_Sentences;
}

[System.Serializable]
public class DialogSentence
{
    [TextArea(1, 10)]
    public string m_Text;
    public AudioClip m_Voice;
}