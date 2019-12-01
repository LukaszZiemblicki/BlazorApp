using System.Collections.Generic;
using System.Linq;
using BlazorApp.Interface.Web.Models;
using BlazorApp.Shared.Common.DTOs;

namespace BlazorApp.Interface.Web.Mappers
{
    public static class ExchangeRateAlertMapper
    {
        public static ExchangeRateAlertModel ToModel(this ExchangeRateAlertDTO dto)
        {
            return new ExchangeRateAlertModel
            {
                Value = dto.Value,
                ID = dto.ID,
                Currency = dto.Currency,
                Comment = dto.Comment
            };
        }

        public static IEnumerable<ExchangeRateAlertModel> ToModelList(this IEnumerable<ExchangeRateAlertDTO> dtoList)
        {
            return dtoList.Select(q => q.ToModel());
        }

        public static ExchangeRateAlertDTO ToDTO(this ExchangeRateAlertModel model)
        {
            return new ExchangeRateAlertDTO
            {
                Value = model.Value ?? 0,
                ID = model.ID,
                Currency = model.Currency,
                Comment = model.Comment
            };
        }

        public static IEnumerable<ExchangeRateAlertDTO> ToDTOList(this IEnumerable<ExchangeRateAlertModel> modelList)
        {
            return modelList.Select(q => q.ToDTO());
        }
    }
}
