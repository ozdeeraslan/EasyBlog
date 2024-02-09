using EasyBlog.Attributes;
using System.ComponentModel.DataAnnotations;

namespace EasyBlog.Areas.Admin.Models
{
    public class CreatePostViewModel
    {
        [Display(Name = "Title")]
        [Required(ErrorMessage = "{0} is required.")]
        public string Title { get; set; } = null!;

        [Display(Name = "Category")]
        [Required(ErrorMessage = "{0} is required.")]
        public int? CategoryId { get; set; }

        [Display(Name = "Content")]
        [Required(ErrorMessage = "{0} is required.")]
        public string Content { get; set; } = null!;

        [Display(Name = "Description")]
        [Required(ErrorMessage = "{0} is required.")]
        public string Description { get; set; } = null!;

        [Display(Name = "Image")]
        [ValidImage]
        public IFormFile? Image { get; set; }

    }
}
