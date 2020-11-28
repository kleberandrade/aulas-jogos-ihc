using System;
using UnityEngine;

public class Player : MonoBehaviour, ISavable
{
    public float m_Speed = 5.0f;
    public float m_Life = 100.0f;

    private void OnEnable()
    {
        Load();
    }

    private void OnDisable()
    {
        Save();
    }


    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontal, vertical, 0) * m_Speed * Time.deltaTime);
    }

    public void Load()
    {
        var data = SaveHelper.Load<PlayerData>("player.sav");
        data.ToData(this);
    }

    public void Save()
    {
        var data = new PlayerData(this);
        SaveHelper.Save(data, "player.sav");
    }


    [Serializable]
    class PlayerData : IDataSavable
    {
        public float life;
        public float positionX;
        public float positionY;

        public PlayerData(Player player)
        {
            life = player.m_Life;
            positionX = player.transform.position.x;
            positionY = player.transform.position.y;
        }

        public void ToData<T>(T data)
        {
            var player = data as Player;
            player.m_Life = life;
            player.gameObject.transform.position = new Vector3(positionX, positionY, 0);
        }
    }
}
