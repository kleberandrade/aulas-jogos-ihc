using System;
using UnityEngine;

public class Item : MonoBehaviour, ISavable
{
    public bool m_Collected;

    private void OnEnable()
    {
        Load();
    }

    private void OnDisable()
    {
        Save();
    }

    public void Load()
    {
        var data = SaveHelper.Load<ItemData>("item.sav");
        data.ToData(this);
        if (m_Collected) Destroy(gameObject);
    }

    public void Save()
    {
        var data = new ItemData(this);
        SaveHelper.Save(data, "item.sav");
    }

    [Serializable]
    class ItemData : IDataSavable
    {
        public bool collected;

        public ItemData(Item item)
        {
            collected = item.m_Collected;
        }

        public void ToData<T>(T data)
        {
            var item = data as Item;
            item.m_Collected = collected;
        }
    }
}
