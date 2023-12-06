using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models.PrivacySettings
{
    public class PrivacySettingsModel : IPrivacySettingsModel
    {
        public int PrivacySettingsID { get; set; }

        // User-related settings
        [Required(ErrorMessage = "UserID is required.")]
        public int? UserID { get; set; }

        // Activity-related settings
        [Display(Name = "Show Activity Map")]
        public bool ShowActivityMap { get; set; }

        [Display(Name = "Show Activity Statistics")]
        public bool ShowActivityStats { get; set; }

        [Display(Name = "Allow Comments")]
        public bool AllowComments { get; set; }

        [Display(Name = "Allow Likes")]
        public bool AllowLikes { get; set; }

        // Privacy settings
        [Required(ErrorMessage = "IsPublic is required.")]
        [Display(Name = "Is Public")]
        public bool? IsPublic { get; set; }

        [StringLength(255, ErrorMessage = "VisibleToFollowers must be at most 255 characters.")]
        [Display(Name = "Visible to Followers")]
        public string VisibleToFollowers { get; set; }

        // Date when the privacy settings were last updated
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "Last Updated")]
        public DateTime LastUpdated { get; set; }
    }
}
