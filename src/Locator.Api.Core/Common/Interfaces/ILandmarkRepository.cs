using Locator.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locator.Api.Core.Common.Interfaces
{
    public interface ILandmarkRepository
    {
        IEnumerable<Landmark> GetAllLandMarksAsync();

        IEnumerable<Landmark> GetAdjecentLandMarksAsync(Landmark landmark);

        Landmark GetLandMarkByCodeAsync(string code);
    }
}
