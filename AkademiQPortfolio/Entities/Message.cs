using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AkademiQPortfolio.Entities;

public partial class Message
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    public int MessageId { get; set; }

    public string? SenderName { get; set; }
    public string? SenderEmail { get; set; }
    public string? MessageText { get; set; }
    public string MessageSubject { get; set; }
    public DateTime? SendDate { get; set; }
    public bool? IsRead { get; set; }
}
