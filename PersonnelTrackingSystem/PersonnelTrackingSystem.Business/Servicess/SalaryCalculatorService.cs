using PersonnelTrackingSystem.DataAccess;
using PersonnelTrackingSystem.Domain;
using PersonnelTrackingSystem.Employees;
using PersonnelTrackingSystem.SalaryCalculators;
using PersonnelTrackingSystem.Shifts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelTrackingSystem.Business.Servicess
{
    public class SalaryCalculatorService
    {
        private PersonnelTrackingSystemContext _context = new PersonnelTrackingSystemContext();

        public IEnumerable<SalaryCalculatorDto> GetAll()
        {
            try
            {
                return _context.SalaryCalculators.Select(MapToDto).ToList();
            }
            catch (Exception ex)
            {
                return new List<SalaryCalculatorDto>();
            }
        }
        public SalaryCalculatorDto GetById(int id)
        {
            try
            {
                var entity = _context.SalaryCalculators.Find(id);
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
        public CommandResult Create(SalaryCalculatorDto salaryCalculatorDto)
        {
            if (salaryCalculatorDto == null)
                throw new ArgumentNullException(nameof(salaryCalculatorDto));
            try
            {
                var entity = MapToEntity(salaryCalculatorDto);

                _context.SalaryCalculators.Add(entity);
                _context.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error(ex);
            }
        }
        public CommandResult Update(SalaryCalculatorDto salaryCalculatorDto)
        {
            try
            {
                var entity = MapToEntity(salaryCalculatorDto);

                _context.SalaryCalculators.Update(entity);
                _context.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());

                return CommandResult.Error(ex);
            }
        }
        public CommandResult Delete(SalaryCalculatorDto salaryCalculatorDto)
        {
            var entity = MapToEntity(salaryCalculatorDto);
            try
            {
                _context.SalaryCalculators.Remove(entity);
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
            return Delete(new SalaryCalculatorDto() { Id = id });
        }
        internal static SalaryCalculatorDto? MapToDto(SalaryCalculator? salaryCalculator)
        {
            SalaryCalculatorDto dto = null;

            if (salaryCalculator != null)
            {
                return new SalaryCalculatorDto()
                {
                   Id = salaryCalculator.Id,
                   EmployeeId = salaryCalculator.EmployeeId,
                   Bonus = salaryCalculator.Bonus,
                   MealAllowance = salaryCalculator.MealAllowance,
                   Salary = salaryCalculator.Salary,
                   TransportationAllowance = salaryCalculator.TransportationAllowance

                };
            }
            return dto;
        }
        internal static SalaryCalculator MapToEntity(SalaryCalculatorDto salaryCalculatorDto)
        {
            SalaryCalculator dto = null;

            if (salaryCalculatorDto != null)
            {
                return new SalaryCalculator()
                {
                   Id = salaryCalculatorDto.Id,
                   EmployeeId = salaryCalculatorDto.EmployeeId,
                   Bonus = salaryCalculatorDto.Bonus,
                   Salary = salaryCalculatorDto.Salary,
                   MealAllowance = salaryCalculatorDto.MealAllowance,
                   TransportationAllowance = salaryCalculatorDto.TransportationAllowance
                };
            }
            return dto;
        }
    }
}
