using SampleApp.FreshMVVM.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleApp.FreshMVVM.Interfaces
{
    public interface IMultiMediaPickerService
    {
        event EventHandler<MediaFile> OnMediaPicked;
        event EventHandler<IList<MediaFile>> OnMediaPickedCompleted;
        Task<IList<MediaFile>> PickPhotosAsync();
        Task<IList<MediaFile>> PickVideosAsync();
        void Clean();
    }
}
