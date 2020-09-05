using UnityEngine;
using UnityEngine.UI;

public class CreditsManager : MonoBehaviour {
    public float m_ScrollSpeed = 20.0f;
    public Text m_TextUI;

    public bool m_CapitalizeTitle;

    private void Start(){
        var json = Resources.Load<TextAsset>("credits");
        var credit = JsonUtility.FromJson<Credit>(json.text);
        var builder = new System.Text.StringBuilder();
        foreach (var team in credit.teams){
            builder.AppendFormat("<b><size={0}>{1}</size></b>", credit.titleSize, m_CapitalizeTitle ? team.title.ToUpper() : team.title);
            builder.AppendFormat("<size={0}>\n</size>", credit.titleSize);

            foreach (var name in team.names){
                builder.AppendFormat("<size={0}>{1}</size>", credit.nameSize, name);
                builder.AppendFormat("<size={0}>\n</size>", credit.nameSize);
            }

            builder.AppendFormat("<size={0}>\n</size>", credit.titleSize);
        }

        m_TextUI.text = builder.ToString();
        Canvas.ForceUpdateCanvases();
    }

    private void Update() {
        m_TextUI.transform.Translate(Vector3.up * m_ScrollSpeed * Time.deltaTime);
    }
}

[System.Serializable]
public class Credit {
    public int titleSize;
    public int nameSize;
    public Team[] teams;
}

[System.Serializable]
public class Team  {
    public string title;
    public string[] names;
}