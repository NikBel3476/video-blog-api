# video_blog

### To clone the repository
`git clone --recurse-submodules https://github.com/NikBel3476/video-blog-api.git`

### Prerequisites
1. .NET 7.x.x or above
2. Node.js 18.x.x or above

### Generate ssl certificate for development
1. `cd path/to/video_blog_api/project`
2. windows => `dotnet dev-certs https -ep %APPDATA%\ASP.NET\https\video_blog.pem --format Pem --no-password`  
   linux => `dotnet dev-certs https -ep $HOME/.aspnet/https/video_blog.pem --format Pem --no-password`
3. `dotnet dev-certs https --trust`

### API documentation
open `https://localhost:7240/swagger` in browser after running the project