public class TrainerResponse
{
    public ResponseMessageType ResponseType { get; private set; }

    public string Content { get; private set; } = string.Empty;

    public TrainerResponse(ResponseMessageType responseType, string content)
    {
        ResponseType = responseType;
        Content = content ?? throw new ArgumentNullException(nameof(content));
    }
}

public enum ResponseMessageType
{
    Error, Correct
}
