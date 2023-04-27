using PersonnelTrackingSystem.DataAccess;
using PersonnelTrackingSystem.Domain;
using PersonnelTrackingSystem.Employees;
using PersonnelTrackingSystem.Shifts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelTrackingSystem.Business.Servicess
{
    public class ShiftService
    {
        private PersonnelTrackingSystemContext _context = new PersonnelTrackingSystemContext();

        public IEnumerable<ShiftDto> GetAll()
        {
            try
            {
                return _context.Shifts.Select(MapToDto).ToList();
            }
            catch (Exception ex)
            {
                return new List<ShiftDto>();
            }
        }
        public ShiftDto GetById(int id)
        {
            try
            {
                var entity = _context.Shifts.Find(id);
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
        public CommandResult Create(ShiftDto shiftDto)
        {
            if (shiftDto == null)
                throw new ArgumentNullException(nameof(shiftDto));
            try
            {
                var entity = MapToEntity(shiftDto);

                _context.Shifts.Add(entity);
                _context.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error(ex);
            }
        }
        public CommandResult Update(ShiftDto shiftDto)
        {
            try
            {
                var entity = MapToEntity(shiftDto);

                _context.Shifts.Update(entity);
                _context.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());

                return CommandResult.Error(ex);
            }
        }

        public CommandResult Delete(ShiftDto shiftDto)
        {
            var entity = MapToEntity(shiftDto);
            try
            {
                _context.Shifts.Remove(entity);
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
            return Delete(new ShiftDto() { Id = id });
        }

        internal static ShiftDto? MapToDto(Shift? shift)
        {
            ShiftDto dto = null;

            if (shift != null)
            {
                return new ShiftDto()
                {
                    Id = shift.Id,
                    EmployeeId = shift.EmployeeId,
                   WorkingDate = shift.WorkingDate,
                   WorkingTime = shift.WorkingTime
                   
                  
                };
            }
            return dto;
        }
        internal static Shift MapToEntity(ShiftDto shiftDto)
        {
            Shift dto = null;

            if (shiftDto != null)
            {
                return new Shift()
                {
                   Id = shiftDto.Id,
                   EmployeeId = shiftDto.EmployeeId,
                   WorkingDate = shiftDto.WorkingDate,
                   WorkingTime = shiftDto.WorkingTime
                };
            }
            return dto;
        }
        
    }
}
