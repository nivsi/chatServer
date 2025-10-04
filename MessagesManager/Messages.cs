using System.ComponentModel.DataAnnotations;
namespace chatServer.MessagesManager;

public class Messages 
{
    [Key]
    public string Id { get; set; }
    
    public string ConversationId { get; set; }
    public string SenderMassage { get; set; }
    public string Content { get; set; }
    public DateTime Timestamp { get; set; }

    public Messages(string id, string conversationId ,string senderMassage, string content, DateTime timestamp)
    {
        Id = id;
        ConversationId = conversationId;
        SenderMassage = senderMassage;
        Content = content;
        Timestamp = timestamp;
        
    }
    
}