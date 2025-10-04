namespace chatServer.MessagesManager;

public class Participant
{
    string Id { get; set; }
    public int ConversationId { get; set; }
    public string UserEmail { get; set; }

    public Participant(string id, int conversationId, string userEmail)
    {
        Id = id;
        ConversationId = conversationId;
        UserEmail = userEmail;
    }
   

}