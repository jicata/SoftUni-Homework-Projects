namespace BasicHttpServer.Resources
{
    public static class MimeMapper
    {
        public static string MapMimeToType(string type)
        {
            string contentType = "Content-Type: ";
            if (type == "jpeg" || type == "png" || type == "jpg")
            {
                return contentType + "image/"+ type;
            }
            else
            {
                return contentType + "text/html";
            }
        }
    }
}
