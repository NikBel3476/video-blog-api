using AutoMapper;
using video_blog_api.Data.Models;
using video_blog_api.Domain.Models;

namespace video_blog_api.Utils
{
	public class CustomUserMap
	{
		public static List<UserDTO> MapToDTO(List<User> users)
		{
			var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
			return mapper.Map<IEnumerable<User>, List<UserDTO>>(users);
		}

		public static UserDTO MapToDTO(User user)
		{
			var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
			return mapper.Map<User, UserDTO>(user);
		}

		public static List<User> MapToData(List<UserDTO> usersDTO)
		{
			var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, User>()).CreateMapper();
			return mapper.Map<IEnumerable<UserDTO>, List<User>>(usersDTO);
		}

		public static User MapToData(UserDTO userDTO)
		{
			var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, User>()).CreateMapper();
			return mapper.Map<UserDTO, User>(userDTO);
		}
	}
}
