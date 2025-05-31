using Domain.entities;
using Domain;
using Domain.valueObjects;
using Domain.valueObjects.careTaskDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Adapters.resources;

namespace Adapters.mapper
{
    public static class CareTaskMapper
    {
        public static CareTaskResource ToResource(CareTask task)
        {
            var dto = new CareTaskResource
            {
                Id = task.Id,
                Type = task.Type
            };

            switch (task.Details)
            {
                case WateringDetails w:
                    dto.WateringDetails = new WateringDetailsResource
                    {
                        AmountInMl = w.AmountInMl
                    };
                    break;

                case FertilizingDetails f:
                    dto.FertilizingDetails = new FertilizingDetailsResource
                    {
                        FertilizerName = f.FertilizerName,
                        Dosage = f.Dosage
                    };
                    break;
            }

            if (task is RecurringCareTask r)
            {
                dto.IntervalDays = (int)r.Interval.TotalDays;
                dto.LastPerformed = r.LastPerformed;
            }
            else if (task is ScheduledCareTask s)
            {
                dto.ScheduledDate = s.ScheduledDate;
                dto.IsCompleted = s.IsCompleted;
            }

            return dto;
        }

        public static CareTask FromResource(CareTaskResource dto)
        {
            ICareTaskDetails details = dto.Type switch
            {
                Watering => new WateringDetails(dto.WateringDetails?.AmountInMl ?? throw new ArgumentNullException()),

                Fertilizing => new FertilizingDetails
                (
                    dto.FertilizingDetails?.FertilizerName ?? throw new ArgumentNullException(),
                    dto.FertilizingDetails.Dosage
                ),

                _ => throw new InvalidOperationException("Unsupported CareType")
            };

            if (dto.IntervalDays != null)
            {
                return new RecurringCareTask(dto.Type, details, TimeSpan.FromDays(dto.IntervalDays.Value), dto.LastPerformed ?? DateTime.Today);
            }
            else if (dto.ScheduledDate != null)
            {
                return new ScheduledCareTask(dto.Type, details, dto.ScheduledDate.Value, dto.IsCompleted ?? false);
            }
            throw new InvalidOperationException("DTO is missing required scheduling info");
        }
    }
}