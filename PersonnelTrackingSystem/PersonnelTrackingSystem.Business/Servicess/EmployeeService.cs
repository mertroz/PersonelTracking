using PersonnelTrackingSystem.DataAccess;
using PersonnelTrackingSystem.Employees;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelTrackingSystem.Business.Servicess
{
    public class EmployeeService
    {
        private PersonnelTrackingSystemContext _context = new PersonnelTrackingSystemContext();



        public IEnumerable<EmployeeDto> GetAll()
        {
            try
            {
                return _context.Employees.Select(MapToDto).ToList();
            }
            catch (Exception ex)
            {
                return new List<EmployeeDto>();
            }
        }

        public EmployeeDto GetById(int id)
        {
            try
            {
                var entity = _context.Employees.Find(id);
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

        public CommandResult Create(EmployeeDto employeeDto)
        {
            if (employeeDto == null)
                throw new ArgumentNullException(nameof(employeeDto));
            try
            {
                var entity = MapToEntity(employeeDto);

                var validationResult = _validator.Validate(entity);
                if (validationResult.HasErrors)
                {
                    return CommandResult.Failure(validationResult.ErrorString);
                }
                _context.Employees.Add(entity);
                _context.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error(ex);
            }
        }

    }
}
