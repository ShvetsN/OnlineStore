using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Interfaces;
using UnitOfWork.Extensions;

namespace BusinessLogicLayer.Services
{
    public class CRUDService<UnitEntity, EntityBLL> :BaseService
        where UnitEntity : UnitOfWork.Models.UnitEntity
    {
        public CRUDService(IUnitOfWork uof, IMapper mapper) : base(uof, mapper) { }

        public async Task<bool> Create(EntityBLL value)
        {
            //try
            //{
                var item = _mapper.Map<UnitEntity>(value);
                _unitOfWork.Entry<UnitEntity>().CreateAsync(item);
                _unitOfWork.SaveAsync();
                return true;
            //}
            //catch (Exception)
            //{
            //    return false;
            //}
        }
    }
}
