public interface ISavable
{
    void Save();
    void Load();
}

public interface IDataSavable
{
    void ToData<T>(T data);
}

