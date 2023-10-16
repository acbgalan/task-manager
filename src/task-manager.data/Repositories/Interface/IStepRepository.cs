using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task_manager.data.Models;

namespace task_manager.data.Repositories.Interface
{
    public interface IStepRepository : IRepositoryAsync<Step>
    {
        Task<List<Step>> GetAllSteps(string taskId);
        
    }
}
