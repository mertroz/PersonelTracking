using PersonnelTrackingSystem.Costs;
using PersonnelTrackingSystem.DataAccess;
using PersonnelTrackingSystem.Domain;
using PersonnelTrackingSystem.Permissions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelTrackingSystem.Business.Servicess
{
    public class CostService
    {
        private PersonnelTrackingSystemContext _context = new PersonnelTrackingSystemContext();

        public IEnumerable<CostDto> GetAll()
        {
            try
            {
                return _context.Costs.Select(MapToDto).ToList();
            }
            catch (Exception ex)
            {
                return new List<CostDto>();
            }
        }
        public CostDto GetById(int id)
        {
            try
            {
                var entity = _context.Costs.Find(id);
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
        public CommandResult Create(CostDto costDto)
        {
            if (costDto == null)
                throw new ArgumentNullException(nameof(costDto));
            try
            {
                var entity = MapToEntity(costDto);

                _context.Costs.Add(entity);
                _context.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error(ex);
            }
        }
        public CommandResult Update(CostDto costDto)
        {
            try
            {
                var entity = MapToEntity(costDto);

                _context.Costs.Update(entity);
                _context.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());

                return CommandResult.Error(ex);
            }
        }
        public CommandResult Delete(CostDto costDto)
        {
            var entity = MapToEntity(costDto);
            try
            {
                _context.Costs.Remove(entity);
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
            return Delete(new CostDto() { Id = id });
        }
        internal static CostDto? MapToDto(Cost? cost)
        {
            CostDto dto = null;

            if (cost != null)
            {
                return new CostDto()
                {
                 Id = cost.Id,
                 CostAmount = cost.CostAmount,
                 CostType = cost.CostType,
                 EmployeeId = cost.EmployeeId

                };
            }
            return dto;
        }
        internal static Cost MapToEntity(CostDto costDto)
        {
            Cost dto = null;

            if (costDto != null)
            {
                return new Cost()
                {
                   Id = costDto.Id,
                   CostAmount = costDto.CostAmount,
                   CostType = costDto.CostType,
                   EmployeeId = costDto.EmployeeId
                };
            }
            return dto;
        }
    }
}
