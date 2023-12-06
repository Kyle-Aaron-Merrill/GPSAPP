using System;

namespace DomainLayer.Models.PrivacySettings
{
    public interface IPrivacySettingsModel
    {
        bool AllowComments { get; set; }
        bool AllowLikes { get; set; }
        bool? IsPublic { get; set; }
        DateTime LastUpdated { get; set; }
        int PrivacySettingsID { get; set; }
        bool ShowActivityMap { get; set; }
        bool ShowActivityStats { get; set; }
        int? UserID { get; set; }
        string VisibleToFollowers { get; set; }
    }
}