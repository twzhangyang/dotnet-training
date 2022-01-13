namespace WebApi.Infrastructure
{
    public static class FileUploader
    {
        public static Task<string> UploadImage(IFormFile file)
        {
            return Task.FromResult(file.Name);

        }

        public static Task<string> UploadFile(IFormFile file)
        {
            return Task.FromResult(file.Name);
        }
    }
}
