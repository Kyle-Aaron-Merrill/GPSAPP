using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.PrivacySettings
{
    internal class PrivacySettingsModel : IPrivacySettingsModel
    {
        public int PrivacySettingsID { get; set; }

        // User-related settings
        [Required(ErrorMessage = "UserID is required.")]
        public int UserID { get; set; }

        // Activity-related settings
        public bool ShowActivityMap { get; set; }
        public bool ShowActivityStats { get; set; }
        public bool AllowComments { get; set; }
        public bool AllowLikes { get; set; }

        // Privacy settings
        [Required(ErrorMessage = "IsPublic is required.")]
        public bool IsPublic { get; set; }

        [StringLength(255, ErrorMessage = "VisibleToFollowers must be at most 255 characters.")]
        public string VisibleToFollowers { get; set; }

        // Date when the privacy settings were last updated
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime LastUpdated { get; set; }
    }
}
