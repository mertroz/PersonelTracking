using Microsoft.EntityFrameworkCore;
using PersonnelTrackingSystem.DataAccess;
using PersonnelTrackingSystem.Domain;
using PersonnelTrackingSystem.Employees;
using PersonnelTrackingSystem.Materials;
using PersonnelTrackingSystem.Shifts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelTrackingSystem.Business.Servicess
{
    public class MaterialService
    {
        private PersonnelTrackingSystemContext _context = new PersonnelTrackingSystemContext();

        public IEnumerable<MaterialDto> GetAll()
        {
            try
            {
                return _context.Materials.Select(MapToDto).ToList();
            }
            catch (Exception ex)
            {
                return new List<MaterialDto>();
            }
        }
        public MaterialDto GetById(int id)
        {
            try
            {
                var entity = _context.Materials.Find(id);
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
        public CommandResult Create(MaterialDto materialDto)
        {
            if (materialDto == null)
                throw new ArgumentNullException(nameof(materialDto));
            try
            {
                var entity = MapToEntity(materialDto);

                _context.Materials.Add(entity);
                _context.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error(ex);
            }
        }
        public CommandResult Update(MaterialDto materialDto)
        {
            try
            {
                var entity = MapToEntity(materialDto);

                _context.Materials.Update(entity);
                _context.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());

                return CommandResult.Error(ex);
            }
        }
        public CommandResult Delete(MaterialDto materialDto)
        {
            var entity = MapToEntity(materialDto);
            try
            {
                _context.Materials.Remove(entity);
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
            return Delete(new MaterialDto() { Id = id });
        }
        internal static MaterialDto? MapToDto(Material? material)
        {
            MaterialDto dto = null;

            if (material != null)
            {
                return new MaterialDto()
                {
                    Id = material.Id,
                    EmployeeId = material.EmployeeId,
                    Request = material.Request,
                };
            }
            return dto;
        }
        internal static Material MapToEntity(MaterialDto materialDto)
        {
            Material dto = null;

            if (materialDto != null)
            {
                return new Material()
                {
                    Id = materialDto.Id,
                    EmployeeId = materialDto.EmployeeId,
                    Request = materialDto.Request,
                    
                };
            }
            return dto;
        }
    }
    
}
