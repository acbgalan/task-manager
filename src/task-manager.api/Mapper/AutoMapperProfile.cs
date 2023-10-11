using AutoMapper;
using task_manager.api.Responses.Category;
using task_manager.data.Models;

namespace task_manager.api.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CategoryMapping();
        }


        public void CategoryMapping()
        {
            CreateMap<Category, CategoryResponse>();
        }

    }
}
