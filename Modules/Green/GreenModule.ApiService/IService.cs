namespace GreenModule.ApiService;

[ServiceContract]
public interface IService
{
    [OperationContract]
    string GetData(int value);

    [OperationContract]
    CompositeType GetDataUsingDataContract(CompositeType composite);
}

public class Service : IService
{
    public string GetData(int value)
    {
        return $"You entered: {value}";
    }

    public CompositeType GetDataUsingDataContract(CompositeType composite)
    {
        if (composite == null)
        {
            throw new ArgumentNullException(nameof(composite));
        }

        if (composite.BoolValue)
        {
            composite.StringValue += "Suffix";
        }

        return composite;
    }
}

// Use a data contract as illustrated in the sample below to add composite types to service operations.
[DataContract]
public class CompositeType
{
    private bool _boolValue = true;
    private string _stringValue = "Hello ";

    [DataMember]
    public bool BoolValue
    {
        get { return _boolValue; }
        set { _boolValue = value; }
    }

    [DataMember]
    public string StringValue
    {
        get { return _stringValue; }
        set { _stringValue = value; }
    }
}