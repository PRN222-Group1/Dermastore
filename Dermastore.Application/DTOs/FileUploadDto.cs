using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.DTOs
{
    public class FileUploadDto
    {
        public string fileName { get; set; }
        public Stream fileStream { get; set; }
        public bool isImageUpload { get; set; }
    }
}
