using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using vefast_src.DTO.Attribute_value;

namespace vefast_src.Domain.Services.Attribute_value
{
    public interface IAttribute_valueService
    {
        IEnumerable<Attribute_valueResponse> GetAllAttribute_value();
        Task<Attribute_valueResponse> CreateAttribute_valueAsync(Attribute_valueRequest objRequest);
        Task<Attribute_valueResponse> GetAttribute_valueByIdAsync(Guid id);
        Task DeleteAttribute_valueById(Guid id);
        Task<Attribute_valueResponse> EditAttribute_valueByIdAsync(Guid id, Attribute_valueRequest objRequest);
    }
}
