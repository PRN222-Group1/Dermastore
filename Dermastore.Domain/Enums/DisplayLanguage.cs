using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Domain.Enums
{
    public enum DisplayLanguage
    {
        /// <summary>
        /// Giao diện hiển thị bằng Tiếng Việt.  
        /// </summary>
        [Description("vn")]
        Vietnamese,

        /// <summary>
        /// Giao diện hiển thị bằng Tiếng Anh.  
        /// </summary>
        [Description("en")]
        English
    }
}
