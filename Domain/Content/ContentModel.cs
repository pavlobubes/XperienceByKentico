using Domain.Image;

namespace Domain.Content;

public record ContentModel(string Title, string Description, IEnumerable<ImageModel> ImageThumbnail, string Link);