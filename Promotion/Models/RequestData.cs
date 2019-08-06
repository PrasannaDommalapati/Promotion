using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Promotion.Models
{
    public class RequestData
    {
        [MaxLength(50)]
        [Required]
        public string RequesterId { get; set; }

        /// <summary>
        /// Base64 encoded template data.
        /// </summary>
        [Required]
        public string Data { get; set; }

        [MaxLength(50)]
        public string BusinessApplication { get; set; }

        [MaxLength(50)]
        public string BusinessUnit { get; set; }

        public Dictionary<string, string> Metadata { get; set; }

        public string[] Templates { get; set; }
    }
}
