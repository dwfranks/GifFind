using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GifFind.API.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
    }
}
