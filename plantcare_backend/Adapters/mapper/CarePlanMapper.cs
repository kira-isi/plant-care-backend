using Adapters.resources;
using Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapters.mapper
{
    public static class CarePlanMapper
    {
        public static CarePlanResource ToResource(CarePlan plan) => new()
        {
            Id = plan.Id,
            Name = plan.Name,
            TaskList = plan.TaskList.Select(CareTaskMapper.ToResource).ToList(),
            Plants = plan.Plants
        };

        public static CarePlan FromResource(CarePlanResource dto, List<CareTask> tasks) =>
            new(dto.Id, dto.Name, tasks, dto.Plants);
    }
}