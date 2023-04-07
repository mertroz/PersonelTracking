using PersonnelTrackingSystem.DataAccess;
using PersonnelTrackingSystem.Domain;
using PersonnelTrackingSystem.Employees;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Principal;
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
        public CommandResult Update(EmployeeDto employeeDto)
        {
            try
            {
                var entity = MapToEntity(employeeDto);

                _context.Employees.Update(entity);
                _context.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());

                return CommandResult.Error(ex);
            }
        }
        public CommandResult Delete(EmployeeDto employeeDto)
        {
            var entity = MapToEntity(employeeDto);
            try
            {
                _context.Employees.Remove(entity);
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
            return Delete(new EmployeeDto() { Id = id });
        }
        internal static EmployeeDto? MapToDto(Employee? employee)
        {
                EmployeeDto dto = null;

                if (employee != null)
                {
                    return new EmployeeDto()
                    {
                        Id = employee.Id,
                        Address = employee.Address,
                        Department = employee.Department,
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        Identity = employee.Identity,
                        RegistrationNumber = employee.RegistrationNumber,
                        HiringDate = employee.HiringDate,
                        HomePhone = employee.HomePhone,
                        MobilePhone = employee.MobilePhone,
                        Gender = employee.Gender
                    };
                }
                return dto;
        }
        internal static Employee MapToEntity(EmployeeDto employeeDto)
        {
            Employee dto = null;

            if (employeeDto != null)
            {
                return new Employee()
                {
                    Id = employeeDto.Id,
                    Address = employeeDto.Address,
                    Department = employeeDto.Department,
                    FirstName = employeeDto.FirstName,
                    LastName = employeeDto.LastName,
                    Identity = employeeDto.Identity,
                    RegistrationNumber = employeeDto.RegistrationNumber,
                    HiringDate = employeeDto.HiringDate,
                    HomePhone = employeeDto.HomePhone,
                    MobilePhone = employeeDto.MobilePhone,
                    Gender = employeeDto.Gender
                    
                };
            }
            return dto;
        }


    }
}


