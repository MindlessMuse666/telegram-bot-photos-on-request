using FlickrNet;

namespace telegram_bot_photos_on_request.Scripts;

public static class FlickrAPI
{
    private static readonly Flickr _flickr = new(APIManager.FLICKR_API);
    private static readonly Random _random = new();


    public static async Task<string> GetPhotoUrlAsync(string request)
    {
        var photoSearchOptions = new PhotoSearchOptions
        {
            Text = request,
            SortOrder = PhotoSearchSortOrder.Relevance
        };

        PhotoCollection photos = await _flickr.PhotosSearchAsync(photoSearchOptions);
        var listPhotos = photos.ToList();

        if (listPhotos.Count == 0)
        {
            return null;
        }

        var randomPhotos = _random.Next(0, listPhotos.Count);
        return listPhotos[randomPhotos].LargeUrl;
    }
}