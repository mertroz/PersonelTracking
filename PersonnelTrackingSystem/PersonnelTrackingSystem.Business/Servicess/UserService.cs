using PersonnelTrackingSystem.DataAccess;
using PersonnelTrackingSystem.Domain;
using PersonnelTrackingSystem.Users;
using System.Diagnostics;

namespace PersonnelTrackingSystem.Business.Servicess
{
    public class UserService
    {
        private PersonnelTrackingSystemContext _context = new PersonnelTrackingSystemContext();

        public IEnumerable<UserDto> GetAll()
        {
            try
            {
                return _context.Users.Select(MapToDto).ToList();
            }
            catch (Exception ex)
            {
                return new List<UserDto>();
            }
        }
        public UserDto GetById(int id)
        {
            try
            {
                var entity = _context.Users.Find(id);
                if (entity != null)
                {
                    var dto = MapToDto(entity);
                    return dto;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return null;
            }
        }
        public CommandResult Create(UserDto userDto)
        {
            if (userDto == null)
                throw new ArgumentNullException(nameof(userDto));
            try
            {
                var entity = MapToEntity(userDto);

                _context.Users.Add(entity);
                _context.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error(ex);
            }
        }
        public CommandResult Update(UserDto userDto)
        {
            try
            {
                var entity = MapToEntity(userDto);

                _context.Users.Update(entity);
                _context.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());

                return CommandResult.Error(ex);
            }
        }

        public CommandResult Delete(UserDto userDto)
        {
            var entity = MapToEntity(userDto);
            try
            {
                _context.Users.Remove(entity);
                _context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Error(ex);
            }
        }
        public CommandResult Delete(int id)
        {
            return Delete(new UserDto() { Id = id });
        }

        internal static UserDto? MapToDto(User? user)
        {
            UserDto dto = null;

            if (user != null)
            {
                return new UserDto()
                {
                    Id = user.Id,
                    EmployeeId = user.EmployeeId,
                    Password= user.Password,
                    RoleId= user.RoleId,    
                    UserName = user.UserName

                };
            }
            return dto;
        }
        internal static User MapToEntity(UserDto userDto)
        {
            User dto = null;

            if (userDto != null)
            {
                return new User()
                {
                    Id = userDto.Id,
                    EmployeeId = userDto.EmployeeId,
                    Password= userDto.Password,
                    RoleId= userDto.RoleId,
                    UserName= userDto.UserName
                };
            }
            return dto;
        }

        public UserDto Login(string username, string password)
        {
            try
            {
                var entity = _context.Users.FirstOrDefault(x=>x.UserName==username && x.Password==password);

                if (entity != null)
                {
                    var dto = MapToDto(entity);
                    return dto;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return null;
            }
        }
    }
}
