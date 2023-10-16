using AutoMapper;
using task_manager.api.Requests.Category;
using task_manager.api.Requests.Step;
using task_manager.api.Responses.Category;
using task_manager.api.Responses.Step;
using task_manager.data.Models;

namespace task_manager.api.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CategoryMapping();
            StepMapping();
        }


        public void CategoryMapping()
        {
            CreateMap<Category, CategoryResponse>();
            CreateMap<CreateCategoryRequest, Category>();
        }

        public void StepMapping()
        {
            CreateMap<Step, StepResponse>();
            CreateMap<CreateStepRequest, Step>();
            CreateMap<UpdateStepRequest, Step>();
        }

    }
}
