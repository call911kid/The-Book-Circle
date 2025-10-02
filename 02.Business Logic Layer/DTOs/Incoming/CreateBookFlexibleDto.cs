using System.ComponentModel.DataAnnotations;

namespace The_Book_Circle._02.Business_Logic_Layer.DTOs.Incoming
{
    public class CreateBookFlexibleDto
    {
        [StringLength(13, MinimumLength = 13, ErrorMessage = "ISBN must be exactly 13 characters long.")]
        [RegularExpression(@"^\d{13}$", ErrorMessage = "ISBN must be exactly 13 digits.")]
        public string? ISBN { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        [StringLength(200)]
        public string? Subtitle { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(1, 10000)]
        public int Pages { get; set; }

        [Required]
        [StringLength(50)]
        public string Language { get; set; }


        [Display(Name = "Cover Image URL")]
        public string CoverImageUrl { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; }

        public int? AuthorID { get; set; }
        public CreateAuthorDto? NewAuthor { get; set; }

        public int? PublisherID { get; set; }
        public CreatePublisherDto? NewPublisher { get; set; }

        public ICollection<int> GenresIDs { get; set; } = new List<int>();
        public ICollection<CreateGenreDto> NewGenres { get; set; } = new List<CreateGenreDto>();

    }
}
