using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DistributedTaskSolving.Application.Generics.GridServices;
using DistributedTaskSolving.Application.Shared.Business.ProgrammingLanguages;
using DistributedTaskSolving.Business.BusinessEntities.ProgrammingLanguages;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using GridShared;

namespace DistributedTaskSolving.Application.Business.ProgrammingLanguages.QueryGridServices
{
    public class ProgrammingLanguageQueryGridService : QueryGridService<ProgrammingLanguage, int, ProgrammingLanguageDto>
    {
        public ProgrammingLanguageQueryGridService(IRepository<ProgrammingLanguage, int> repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public override IEnumerable<SelectItem> GetAllSelectItemList()
        {
            return _repository.GetAll()
                .Select(x => new SelectItem(x.Id.ToString(), x.Name))
                .ToList();
        }
    }
}