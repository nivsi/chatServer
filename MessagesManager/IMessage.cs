namespace chatServer.MessagesManager;

public interface IMessage
{
    public string Id {get;set;} 
    public string Sender {get;set;}
    public string Receiver {get;set;}
    public string Content {get;set;}
    public DateTime Timestamp {get;set;}
}