using PersonnelTrackingSystem.DataAccess;
using PersonnelTrackingSystem.Domain;
using PersonnelTrackingSystem.SalaryPayments;
using PersonnelTrackingSystem.Shifts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelTrackingSystem.Business.Servicess
{
    public class SalaryPaymentService
    {
        private PersonnelTrackingSystemContext _context = new PersonnelTrackingSystemContext();

        public IEnumerable<SalaryPaymentDto> GetAll()
        {
            try
            {
                return _context.SalaryPayments.Select(MapToDto).ToList();
            }
            catch (Exception ex)
            {
                return new List<SalaryPaymentDto>();
            }
        }
        public SalaryPaymentDto GetById(int id)
        {
            try
            {
                var entity = _context.SalaryPayments.Find(id);
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
        public CommandResult Create(SalaryPaymentDto salaryPaymentDto)
        {
            if (salaryPaymentDto == null)
                throw new ArgumentNullException(nameof(salaryPaymentDto));
            try
            {
                var entity = MapToEntity(salaryPaymentDto);

                _context.SalaryPayments.Add(entity);
                _context.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error(ex);
            }
        }
        public CommandResult Update(SalaryPaymentDto salaryPaymentDto)
        {
            try
            {
                var entity = MapToEntity(salaryPaymentDto);

                _context.SalaryPayments.Update(entity);
                _context.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());

                return CommandResult.Error(ex);
            }
        }
        public CommandResult Delete(SalaryPaymentDto salaryPaymentDto)
        {
            var entity = MapToEntity(salaryPaymentDto);
            try
            {
                _context.SalaryPayments.Remove(entity);
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
            return Delete(new SalaryPaymentDto() { Id = id });
        }
        internal static SalaryPaymentDto? MapToDto(SalaryPayment? salaryPayment)
        {
            SalaryPaymentDto dto = null;

            if (salaryPayment != null)
            {
                return new SalaryPaymentDto()
                {
                    Id = salaryPayment.Id,
                    EmployeeId = salaryPayment.EmployeeId,

                };
            }
            return dto;
        }
        internal static SalaryPayment MapToEntity(SalaryPaymentDto salaryPaymentDto)
        {
            SalaryPayment dto = null;

            if (salaryPaymentDto != null)
            {
                return new SalaryPayment()
                {
                    Id = salaryPaymentDto.Id,
                    EmployeeId = salaryPaymentDto.EmployeeId
                };
            }
            return dto;
        }
    }
}
