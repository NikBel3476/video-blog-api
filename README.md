# video_blog

### Generate ssl certificate for development

#### For windows
1. `cd path/to/video_blog_api/project`
2. windows => `dotnet dev-certs https -ep %APPDATA%\ASP.NET\https\video_blog.pem --format Pem --no-password`  
   linux => `dotnet dev-certs https -ep $HOME/.aspnet/https/video_blog.pem --format Pem --no-password`
3. `dotnet dev-certs https --trust`