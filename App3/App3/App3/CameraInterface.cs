using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App3
{
    public interface IPhotoPickerService
    {
        Task<Stream> GetImageStreamAsync();
    }
    
}
