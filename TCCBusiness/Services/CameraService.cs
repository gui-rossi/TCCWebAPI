using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCBusiness.Interfaces;
using TCCDomain.Entities;
using TCCDomain.ViewModels;
using TCCRepositories.Interfaces;

namespace TCCBusiness.Services
{
    //internal class CameraService : ICameraService
    //{
    //    private readonly IGenericRepository<CameraEntity> _repository;

    //    public CameraService(IGenericRepository<CameraEntity> repository)
    //    {
    //        _repository = repository;
    //    }

    //    public Task AddStatusAsync(CameraVM camera)
    //    {
    //        CameraEntity entity = new()
    //        {
    //            Id = camera.Id,
    //            Action = camera.Action,
    //            Date = camera.Date,
    //            IsViewed = camera.IsViewed
    //        };

    //        _repository.Insert(entity);

    //        return Task.CompletedTask;
    //    }

    //    public async Task<IEnumerable<CameraVM>> FetchStatusAsync()
    //    {
    //        var entities = await _repository.SelectAllAsync(q => q.Where(cam => cam.IsViewed != false));

    //        List<CameraVM> camerasVM = new(); 

    //        foreach (var entity in entities)
    //        {
    //            camerasVM.Add(new CameraVM()
    //            {
    //                Id = entity.Id,
    //                Action = entity.Action,
    //                Date = entity.Date,
    //                IsViewed = entity.IsViewed
    //            });
    //        }

    //        return camerasVM;
    //    }
    //}
}
