namespace Domain.Image;

public record ImageModel(string Title, string? Description, string Url, IEnumerable<ImageVariantModel> Variants);

public record ImageVariantModel(string Name, string Url);