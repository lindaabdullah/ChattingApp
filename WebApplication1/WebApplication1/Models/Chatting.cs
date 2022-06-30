namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Chatting")]
    public partial class Chatting
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string SenderUsername { get; set; }

        [Required]
        [StringLength(100)]
        public string RecieverUsername { get; set; }

        [Required]
        [StringLength(100)]
        public string DateSent { get; set; }

        [Required]
        [StringLength(100)]
        public string Message { get; set; }

        [Required]
        [StringLength(100)]
        public string ChattingType { get; set; }

        [Required]
        [StringLength(10)]
        public string Encrypted { get; set; }
    }
}
