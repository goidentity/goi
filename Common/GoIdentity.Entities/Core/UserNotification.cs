using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoIdentity.Entities.Core
{
    [Table(name: "trUserNotification", Schema = "Core")]
    public class UserNotification : Entity
    {
        [Key]
        public int UserNotificationId { get; set; }
        public int UserId { get; set; }
        public DateTime NotificationDate { get; set; }
        public string MessageHeader { get; set; }
        public string MessageContent { get; set; }
        public byte MessageStatus { get; set; }
    }
}
