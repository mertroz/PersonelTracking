using PersonnelTrackingSystem.Costs;
using PersonnelTrackingSystem.DataAccess;
using PersonnelTrackingSystem.Domain;
using PersonnelTrackingSystem.Permissions;
using PersonnelTrackingSystem.Shifts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelTrackingSystem.Business.Servicess
{
    public class PermissionService
    {
        private PersonnelTrackingSystemContext _context = new PersonnelTrackingSystemContext();

        public IEnumerable<PermissionDto> GetAll()
        {
            try
            {
                return _context.Permissions.Select(MapToDto).ToList();
            }
            catch (Exception ex)
            {
                return new List<PermissionDto>();
            }
        }

        public IEnumerable<PermissionDto> GetAllByUser(ClaimsPrincipal user)
        {
            try
            {
                int employeeId = Convert.ToInt32(user.Claims.FirstOrDefault(w => w.Type == ClaimTypes.NameIdentifier).Value);
                if (user.IsInRole("Admin"))
                {
                    return _context.Permissions.Select(MapToDto).ToList();
                }
                else
                {
                    return _context.Permissions.Where(x => x.EmployeeId == employeeId).Select(MapToDto);
                }
            }
            catch (Exception ex)
            {
                return new List<PermissionDto>();
            }
        }

        public PermissionDto? GetById(int id)
        {
            try
            {
                var entity = _context.Permissions.Find(id);
                if (entity != null)
                {
                    var dto = MapToDto(entity);
                    return dto;
                }
                   
                return null;
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return null;
            }
        }
        public CommandResult Create(PermissionDto permissionDto)
        {
            if (permissionDto == null)
                throw new ArgumentNullException(nameof(permissionDto));
            try
            {
                var entity = MapToEntity(permissionDto);

                _context.Permissions.Add(entity);
                _context.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error(ex);
            }
        }
        public CommandResult Update(PermissionDto permissionDto)
        {
            try
            {
                var entity = MapToEntity(permissionDto);

                _context.Permissions.Update(entity);
                _context.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());

                return CommandResult.Error(ex);
            }
        }
        public CommandResult Delete(PermissionDto permissionDto)
        {
            var entity = MapToEntity(permissionDto);
            try
            {
                _context.Permissions.Remove(entity);
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
            return Delete(new PermissionDto() { Id = id });
        }
        internal static PermissionDto? MapToDto(Permission? permission)
        {
            if (permission != null)
            {
                return new PermissionDto()
                {
                  Id = permission.Id,
                  EmployeeId = permission.EmployeeId,
                  PermitEndDate= permission.PermitEndDate,
                  PermitStartDate = permission.PermitStartDate
                };
            }
            return null;
        }
        internal static Permission? MapToEntity(PermissionDto permissionDto)
        {
            if (permissionDto != null)
            {
                return new Permission()
                {
                    Id = permissionDto.Id,
                    EmployeeId = permissionDto.EmployeeId,
                    PermitEndDate= permissionDto.PermitEndDate,
                    PermitStartDate= permissionDto.PermitStartDate
                };
            }
            return null;
        }
    }
}
