namespace Jeeves.Domain
{
    using System.ComponentModel.DataAnnotations;

    public enum MediaResourceType
    {
        [Display(Name = "Audio")]
        Audio,

        [Display(Name = "Image")]
        Image
    }
}
