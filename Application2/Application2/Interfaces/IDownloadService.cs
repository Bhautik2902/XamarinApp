using System;
using System.Collections.Generic;
using System.Text;

namespace Application2.Interfaces
{
    public interface IDownloadService
    {
        string Downloadfile(byte[] filedata);
    }
}
