using PersonnelTrackingSystem.DataAccess;
using PersonnelTrackingSystem.Domain;
using PersonnelTrackingSystem.Roles;
using System.Data;
using System.Diagnostics;

namespace PersonnelTrackingSystem.Business.Servicess
{
    public class RoleService
    {
        private PersonnelTrackingSystemContext _context = new PersonnelTrackingSystemContext();

        public IEnumerable<RoleDto> GetAll()
        {
            try
            {
                return _context.Roles.Select(MapToDto).ToList();
            }
            catch (Exception ex)
            {
                return new List<RoleDto>();
            }
        }
        public RoleDto GetById(int id)
        {
            try
            {
                var entity = _context.Roles.Find(id);
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
        public CommandResult Create(RoleDto roleDto)
        {
            if (roleDto == null)
                throw new ArgumentNullException(nameof(roleDto));
            try
            {
                var entity = MapToEntity(roleDto);

                _context.Roles.Add(entity);
                _context.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error(ex);
            }
        }
        public CommandResult Update(RoleDto roleDto)
        {
            try
            {
                var entity = MapToEntity(roleDto);

                _context.Roles.Update(entity);
                _context.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());

                return CommandResult.Error(ex);
            }
        }

        public CommandResult Delete(RoleDto roleDto)
        {
            var entity = MapToEntity(roleDto);
            try
            {
                _context.Roles.Remove(entity);
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
            return Delete(new RoleDto() { Id = id });
        }

        internal static RoleDto? MapToDto(Role? role)
        {
            RoleDto dto = null;

            if (role != null)
            {
                return new RoleDto()
                {
                    Id = role.Id,
                    Name = role.Name,

                };
            }
            return dto;
        }
        internal static Role MapToEntity(RoleDto roleDto)
        {
            Role dto = null;

            if (roleDto != null)
            {
                return new Role()
                {
                    Id = roleDto.Id,
                    Name = roleDto.Name,
                };
            }
            return dto;
        }

    }
}
